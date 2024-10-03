using AutoMapper;
using RhythmHaven.Repository;
using RhythmHaven.Repository.Common;
using RhythmHaven.Repository.Entities;
using RhythmHaven.Repository.Repositories.Interfaces;
using RhythmHaven.Service.BusinessModels.UserModels;
using RhythmHaven.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Pagination<UserModel>> GetAllAsync()
        {
            var result = await _unitOfWork.AccountRepository.GetAllAsync();
            return _mapper.Map<Pagination<UserModel>>(result);
        }

        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            return _mapper.Map<UserModel>(result);
        }

        public async Task<UserModel> UpdateAsync(Guid id, UserProcessModel model)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            if (account == null)
            {
                throw new Exception("Account not found!");
            }
            var updateAccount = _mapper.Map(model, account);
            _unitOfWork.AccountRepository.UpdateAsync(updateAccount);
            _unitOfWork.Save();
            return _mapper.Map<UserModel>(updateAccount);
        }
    }
}
