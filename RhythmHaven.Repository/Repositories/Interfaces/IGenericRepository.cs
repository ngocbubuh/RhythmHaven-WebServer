using RhythmHaven.Repository.Common;
using RhythmHaven.Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Repository.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity> AddAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void SoftDeleteAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        void SoftDeleteRangeAsync(List<TEntity> entities);
        void PermanentDeletedAsync(TEntity entity);
        void PermanentDeletedListAsync(List<TEntity> entities);
        Task<Pagination<TEntity>> ToPagination(PaginationParameter paginationParameter);
    }
}
