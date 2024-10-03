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
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private RhythmHavenContext _context;
        public CartRepository(RhythmHavenContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Cart>> GetAllByUserId(Guid id)
        {
            return await _context.Carts.Where(x => x.AccountId.Equals(id)).ToListAsync();
        }
    }
}
