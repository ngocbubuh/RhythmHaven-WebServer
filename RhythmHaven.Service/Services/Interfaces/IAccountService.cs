using RhythmHaven.Repository.Common;
using RhythmHaven.Service.BusinessModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<UserModel> GetByIdAsync(Guid id);
        public Task<Pagination<UserModel>> GetAllAsync();
        public Task<UserModel> UpdateAsync(Guid id, UserProcessModel model);
    }
}
