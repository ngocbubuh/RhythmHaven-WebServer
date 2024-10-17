using RhythmHaven.Service.BusinessModels.CartModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services.Interfaces
{
    public interface ICartService
    {
        public Task<List<CartModel>> GetCartByUser(string username);
        public Task<CartModel> AddCart(string username, CartProcessModel model);
        public Task<CartModel> UpdateCart(Guid id, CartProcessModel process);
        public Task<CartModel> DeleteCart(Guid id);
    }
}
