using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhythmHaven.Service.BusinessModels.CartModels;
using RhythmHaven.Service.Services.Interfaces;

namespace RhythmHaven.API.Controllers
{
    [Route("carts")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService _cartService;
        private IClaimService _claimService;

        public CartController(ICartService cartService, IClaimService claimService)
        {
            _cartService = cartService;
            _claimService = claimService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var username = _claimService.GetCurrentUserName;
                var result = await _cartService.GetCartByUser(username);
                return Ok(result);
            } catch { throw; }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(CartProcessModel cartProcessModel)
        {
            try
            {
                var username = _claimService.GetCurrentUserName;
                var result = await _cartService.AddCart(username, cartProcessModel);
                return Ok(result);
            } catch { throw; }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, CartProcessModel cartProcessModel)
        {
            try
            {
                var result = await _cartService.UpdateCart(id, cartProcessModel);
                return Ok(result);
            } catch { throw; }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _cartService.DeleteCart(id);
                return Ok(result);
            } catch { throw; }
        }
    }
}
