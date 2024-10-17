using RhythmHaven.Repository.Common;
using RhythmHaven.Service.BusinessModels.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderModel> AddOrder(string username, OrderProcessModel orderProcessModel);
        public Task<Pagination<OrderModel>> GetAllByUsername(string username, PaginationParameter paginationParameter);
    }
}
