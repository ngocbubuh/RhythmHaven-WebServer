using RhythmHaven.Service.BusinessModels.AuthenModels;
using RhythmHaven.Service.BusinessModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services.Interfaces
{
    public interface IAuthenService
    {
        public Task<bool> RegisterAsync(SignUpModel model);

        public Task<AuthenModel> LoginWithUsernamePassword(string email, string password);

        public Task<bool> ChangePasswordAsync(string email, ChangePasswordModel changePasswordModel);

        public Task<UserModel> GetLoginUserInformationAsync(string email);
    }
}
