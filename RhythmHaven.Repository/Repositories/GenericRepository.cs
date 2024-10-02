﻿using Microsoft.EntityFrameworkCore;
using RhythmHaven.Repository.Common;
using RhythmHaven.Repository.Entities;
using RhythmHaven.Repository.Entities.Base;
using RhythmHaven.Repository.Repositories.Interfaces;
using RhythmHaven.Repository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(RhythmHavenContext context)
        {
            _dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreateDate = CommonUtils.GetCurrentTime();
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreateDate = CommonUtils.GetCurrentTime();
            }
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            return result;
        }

        public void PermanentDeletedAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void PermanentDeletedListAsync(List<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void SoftDeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }

        public void SoftDeleteRangeAsync(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
            }
            _dbSet.UpdateRange(entities);
        }

        public async Task<Pagination<TEntity>> ToPagination(PaginationParameter paginationParameter)
        {
            var itemCount = await _dbSet.CountAsync();
            var items = await _dbSet.Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize)
                                    .Take(paginationParameter.PageSize)
                                    .AsNoTracking()
                                    .ToListAsync();
            var result = new Pagination<TEntity>(items, itemCount, paginationParameter.PageIndex, paginationParameter.PageSize);

            return result;
        }

        public void UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
