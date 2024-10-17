using AutoMapper;
using RhythmHaven.Repository;
using RhythmHaven.Repository.Entities;
using RhythmHaven.Service.BusinessModels.CartModels;
using RhythmHaven.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services
{
    public class CartService : ICartService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CartModel> AddCart(string username, CartProcessModel model)
        {
            var addCart = _mapper.Map<Cart>(model);
            var user = await _unitOfWork.AccountRepository.GetByUsernameAsync(username);
            addCart.AccountId = user.Id;
            var result = await _unitOfWork.CartRepository.AddAsync(addCart);
            return _mapper.Map<CartModel>(result);
        }

        public async Task<CartModel> DeleteCart(Guid id)
        {
            var cart = await _unitOfWork.CartRepository.GetByIdAsync(id);
            if (cart == null)
            {
                throw new Exception("Cart not found!");
            }
            _unitOfWork.CartRepository.PermanentDeletedAsync(cart);
            _unitOfWork.Save();
            return _mapper.Map<CartModel>(cart);
        }

        public async Task<List<CartModel>> GetCartByUser(string username)
        {
            var user = await _unitOfWork.AccountRepository.GetByUsernameAsync(username);
            var listCart = await _unitOfWork.CartRepository.GetAllByUserId(user.Id);
            return _mapper.Map<List<CartModel>>(listCart);
        }

        public async Task<CartModel> UpdateCart(Guid id, CartProcessModel process)
        {
            var cart = await _unitOfWork.CartRepository.GetByIdAsync(id);
            if (cart == null)
            {
                throw new Exception("Cart not found");
            }
            var updateCart = _mapper.Map(process, cart);
            _unitOfWork.CartRepository.UpdateAsync(updateCart);
            _unitOfWork.Save();
            return _mapper.Map<CartModel>(updateCart);
        }
    }
}
