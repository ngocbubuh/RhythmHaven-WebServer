using RhythmHaven.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Repository.Repositories.Interfaces
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        public Task<List<Cart>> GetAllByUserId(Guid id);
    }
}
