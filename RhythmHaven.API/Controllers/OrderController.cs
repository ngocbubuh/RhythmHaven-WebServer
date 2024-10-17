using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhythmHaven.Repository.Common;
using RhythmHaven.Service.BusinessModels.OrderModels;
using RhythmHaven.Service.Services.Interfaces;

namespace RhythmHaven.API.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private IClaimService _claimService;
        public OrderController(IOrderService orderService, IClaimService claimService)
        {
            _orderService = orderService;
            _claimService = claimService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] PaginationParameter paginationParameter)
        {
            try
            {
                var username = _claimService.GetCurrentUserName;
                var result = await _orderService.GetAllByUsername(username, paginationParameter);
                return Ok(result);
            } catch { throw; }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(OrderProcessModel model)
        {
            try
            {
                var username = _claimService.GetCurrentUserName;
                var result = await _orderService.AddOrder(username, model);
                return Ok(result);
            } catch { throw; }
        }
    }
}
