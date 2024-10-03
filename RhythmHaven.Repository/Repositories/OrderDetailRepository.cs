using Microsoft.EntityFrameworkCore;
using RhythmHaven.Repository.Entities;
using RhythmHaven.Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Repository.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        private RhythmHavenContext _context;
        public OrderDetailRepository(RhythmHavenContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<OrderDetail>> GetAllByOrderId(Guid orderId)
        {
            return await _context.OrderDetails.Where(x => x.OrderId.Equals(orderId)).ToListAsync();
        }
    }
}
