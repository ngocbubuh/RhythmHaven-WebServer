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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private RhythmHavenContext _context;
        public OrderRepository(RhythmHavenContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Pagination<Order>> GetAllByUserId(Guid userId, PaginationParameter paginationParameter)
        {
            var itemCount = await _context.Orders.CountAsync();
            var items = await _context.Orders.Skip((paginationParameter.PageIndex - 1) * paginationParameter.PageSize)
                                    .Take(paginationParameter.PageSize)
                                    .AsNoTracking()
                                    .ToListAsync();
            var result = new Pagination<Order>(items, itemCount, paginationParameter.PageIndex, paginationParameter.PageSize);
            return result;
        }
    }
}
