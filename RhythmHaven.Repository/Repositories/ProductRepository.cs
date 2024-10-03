using Microsoft.EntityFrameworkCore;
using RhythmHaven.Repository.Common;
using RhythmHaven.Repository.Entities;
using RhythmHaven.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private RhythmHavenContext _context;
        public ProductRepository(RhythmHavenContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Pagination<Product>> GetAllAsync(PaginationParameter paginationParameter)
        {
            var itemCount = await _context.Products.CountAsync();
            var items = await _context.Products.Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize)
                                    .Take(paginationParameter.PageSize)
                                    .AsNoTracking()
                                    .ToListAsync();
            var result = new Pagination<Product>(items, itemCount, paginationParameter.PageIndex, paginationParameter.PageSize);
            return result;
        }
    }
}
