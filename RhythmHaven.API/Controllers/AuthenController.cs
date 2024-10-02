using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhythmHaven.Service.BusinessModels.AuthenModels;
using RhythmHaven.Service.Services.Interfaces;

namespace RhythmHaven.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private IAuthenService _authenService;
        private IClaimService _claimService;
        public AuthenController(IAuthenService authenService, IClaimService claimService)
        {
            _authenService = authenService;
            _claimService = claimService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(SignInModel model)
        {
            try
            {
                var result = await _authenService.LoginWithUsernamePassword(model.Username, model.Password);
                return Ok(result);
            } catch { throw; }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(SignUpModel model)
        {
            try
            {
                var result = await _authenService.RegisterAsync(model);
                return Ok(result);
            } catch { throw; }
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            try
            {
                var username = _claimService.GetCurrentUserName;
                var result = await _authenService.ChangePasswordAsync(username, model);
                return Ok(result);
            } catch { throw; }
        }

        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                var username = _claimService.GetCurrentUserName;
                var result = await _authenService.GetLoginUserInformationAsync(username);
                return Ok(result);
            } catch { throw; }
        }
    }
}
