using AutoMapper;
using RhythmHaven.Repository;
using RhythmHaven.Repository.Common;
using RhythmHaven.Repository.Entities;
using RhythmHaven.Repository.Enums;
using RhythmHaven.Service.BusinessModels.OrderModels;
using RhythmHaven.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Transaction = RhythmHaven.Repository.Entities.Transaction;

namespace RhythmHaven.Service.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderModel> AddOrder(string username, OrderProcessModel orderProcessModel)
        {
            var addOrder = _mapper.Map<Order>(orderProcessModel);
            var user = await _unitOfWork.AccountRepository.GetByUsernameAsync(username);
            
            if(orderProcessModel.OrderDetails == null)
            {
                throw new Exception("OrderDetail cannot empty!");
            }

            if(user.Credit < orderProcessModel.Total)
            {
                throw new Exception("Not enough Credit!");
            }
            
            //Decrease product quantity
            foreach (var item in orderProcessModel.OrderDetails) 
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                {
                    throw new Exception("Product not found!");
                }
                if (product.Quantity < item.Quantity)
                {
                    throw new Exception("Not enough product's quantity!");
                }
                product.Quantity -= item.Quantity;
                _unitOfWork.ProductRepository.UpdateAsync(product);
            }

            //Decrease Credit
            user.Credit -= orderProcessModel.Total;
            _unitOfWork.AccountRepository.UpdateAsync(user);

            //Tao order
            addOrder.AccountId = user.Id;
            var result = await _unitOfWork.OrderRepository.AddAsync(addOrder);

            //Tao orderDetail
            foreach (var item in addOrder.OrderDetails)
            {
                item.OrderId = result.Id;
            }
            await _unitOfWork.OrderDetailRepository.AddRangeAsync(addOrder.OrderDetails);

            //Add Transaction
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = user.Id,
                Amount = orderProcessModel.Total,
                TransactionDes = $"Payment for order {result.Id}",
                TransactionStatus = true,
                TransactionType = TransactionType.OUT.ToString()
            };

            await _unitOfWork.TransactionRepository.AddAsync(transaction);
            _unitOfWork.Save();
            return _mapper.Map<OrderModel>(result);
        }

        public async Task<Pagination<OrderModel>> GetAllByUsername(string username, PaginationParameter paginationParameter)
        {
            var user = await _unitOfWork.AccountRepository.GetByUsernameAsync(username);
            var result = await _unitOfWork.OrderRepository.GetAllByUserId(user.Id, paginationParameter);
            return _mapper.Map<Pagination<OrderModel>>(result);
        }
    }
}
