using RhythmHaven.Repository.Common;
using RhythmHaven.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Repository.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public Task<Pagination<Order>> GetAllByUserId(Guid userId, PaginationParameter paginationParameter);
    }
}
