using AutoMapper;
using Microsoft.Extensions.Configuration;
using RhythmHaven.Repository;
using RhythmHaven.Repository.Entities;
using RhythmHaven.Repository.Enums;
using RhythmHaven.Service.BusinessModels.AuthenModels;
using RhythmHaven.Service.BusinessModels.UserModels;
using RhythmHaven.Service.Services.Interfaces;
using RhythmHaven.Service.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services
{
    public class AuthenService : IAuthenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthenService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }   

        public async Task<bool> ChangePasswordAsync(string userName, ChangePasswordModel changePasswordModel)
        {
            var user = await _unitOfWork.AccountRepository.GetByUsernameAsync(userName);
            if (user != null)
            {
                bool checkPassword = PasswordUtils.VerifyPassword(changePasswordModel.OldPassword, user.PasswordHash);
                if (checkPassword)
                {
                    user.PasswordHash = PasswordUtils.HashPassword(changePasswordModel.NewPassword);
                    _unitOfWork.AccountRepository.UpdateAsync(user);
                    _unitOfWork.Save();
                    return true;
                }
                else
                {
                    throw new Exception("Mật khẩu cũ không đúng.");
                }
            }
            else
            {
                throw new Exception("Tài khoản không tồn tại.");
            }
        }

        public async Task<UserModel> GetLoginUserInformationAsync(string userName)
        {
            var user = await _unitOfWork.AccountRepository.GetByUsernameAsync(userName);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<AuthenModel> LoginWithUsernamePassword(string userName, string password)
        {
            var existUser = await _unitOfWork.AccountRepository.GetByUsernameAsync(userName);
            if (existUser == null)
            {
                throw new Exception("Tài khoản không tồn tại");
            }
            var verifyUser = PasswordUtils.VerifyPassword(password, existUser.PasswordHash);
            if (verifyUser)
            {
                // check status user
                if (existUser.Status == AccountStatus.INACTIVE.ToString() || existUser.IsDeleted == true)
                {
                    return new AuthenModel
                    {
                        HttpCode = 401,
                        Message = "Tài khoản đã bị cấm."
                    };
                }

                var accessToken = GenerateAccessToken(userName, existUser);

                _unitOfWork.Save();

                return new AuthenModel
                {
                    HttpCode = 200,
                    AccessToken = accessToken
                };
            }
            return new AuthenModel
            {
                HttpCode = 401,
                Message = "Sai mật khẩu."
            };
        }

        public async Task<bool> RegisterAsync(SignUpModel model)
        {
            try
            {
                var newUser = _mapper.Map<Account>(model);
                var existUser = await _unitOfWork.AccountRepository.GetByUsernameAsync(newUser.UserName);
                if (existUser != null)
                {
                    throw new Exception("Tài khoản đã tồn tại.");
                }
                // hash password
                newUser.PasswordHash = PasswordUtils.HashPassword(model.Password);
                await _unitOfWork.AccountRepository.AddAsync(newUser);
                _unitOfWork.Save();
                return true;
            }
            catch
            {
                throw;
            }
        }

        private string GenerateAccessToken(string userName, Account user)
        {
            var role = user.Role.ToUpper();

            var authClaims = new List<Claim>();

            if (role != null)
            {
                authClaims.Add(new Claim(ClaimTypes.Name, userName));
                authClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            var accessToken = GenerateJWT.CreateToken(authClaims, _configuration, DateTime.UtcNow);
            return new JwtSecurityTokenHandler().WriteToken(accessToken);
        }
    }
}
