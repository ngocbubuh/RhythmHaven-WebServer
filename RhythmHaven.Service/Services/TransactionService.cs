using AutoMapper;
using RhythmHaven.Repository;
using RhythmHaven.Repository.Common;
using RhythmHaven.Repository.Entities;
using RhythmHaven.Repository.Enums;
using RhythmHaven.Service.BusinessModels;
using RhythmHaven.Service.BusinessModels.TransactionModels;
using RhythmHaven.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TransactionModel> AddTransactionByVNPAYAsync(double amount, string username)
        {
            var user = await _unitOfWork.AccountRepository.GetByUsernameAsync(username);
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = user.Id,
                TransactionType = TransactionType.IN.ToString(),
                Amount = amount,
                TransactionDes = $"RhythmHaven {username.ToUpper()}: Recharge +{amount}.",
            };
            var result = await _unitOfWork.TransactionRepository.AddAsync(transaction);
            _unitOfWork.Save();
            return _mapper.Map<TransactionModel>(result);
        }

        public async Task<Pagination<TransactionModel>> GetAllByUsername(string username, PaginationParameter paginationParameter)
        {
            var user = await _unitOfWork.AccountRepository.GetByUsernameAsync(username);
            var listTransaction = await _unitOfWork.TransactionRepository.GetAllByUserId(user.Id, paginationParameter);
            return _mapper.Map<Pagination<TransactionModel>>(listTransaction);
        }

        public async Task<TransactionModel> UpdateTransactionByVNPAYStatusAsync(VnPayModel model)
        {
            if (model.vnp_ResponseCode == "00")
            {
                var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(model.vnp_TxnRef);
                transaction.TransactionStatus = true;
                _unitOfWork.TransactionRepository.UpdateAsync(transaction);

                //Update credit for user
                var user = await _unitOfWork.AccountRepository.GetByIdAsync(transaction.AccountId);
                user.Credit += double.Parse(model.vnp_Amount) / 100;
                _unitOfWork.AccountRepository.UpdateAsync(user);
                _unitOfWork.Save();
                return _mapper.Map<TransactionModel>(transaction);
            }
            else
            {
                var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(model.vnp_TxnRef);
                return _mapper.Map<TransactionModel>(transaction);
            }
        }
    }
}
