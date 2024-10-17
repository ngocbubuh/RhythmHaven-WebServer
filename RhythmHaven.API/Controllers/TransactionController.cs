using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhythmHaven.Repository.Common;
using RhythmHaven.Service.BusinessModels;
using RhythmHaven.Service.Services;
using RhythmHaven.Service.Services.Interfaces;

namespace RhythmHaven.API.Controllers
{
    [Route("transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private ITransactionService _transactionService;
        private IPaymentService _paymentService;
        private IClaimService _claimService;
        public TransactionController(ITransactionService transactionService, IClaimService claimService, IPaymentService paymentService)
        {
            _transactionService = transactionService;
            _claimService = claimService;
            _paymentService = paymentService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] PaginationParameter paginationParameter)
        {
            try
            {
                var username = _claimService.GetCurrentUserName;
                var result = await _transactionService.GetAllByUsername(username, paginationParameter);
                return Ok(result);
            } catch { throw; }
        }

        [HttpPost("Recharge")]
        [Authorize]
        public async Task<IActionResult> Recharge(double amount)
        {
            try
            {
                if (!(amount >= 10000)) { throw new Exception("Recharge at least 10.000 VND"); }
                var username = _claimService.GetCurrentUserName;
                var transaction = await _transactionService.AddTransactionByVNPAYAsync(amount, username);
                var paymentURL = _paymentService.CreatePaymentUrl(transaction, HttpContext);
                return Ok(paymentURL);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("VNPayReturn")]
        public async Task<IActionResult> VnPayReturn([FromQuery] VnPayModel model)
        {
            try
            {
                var transaction = await _transactionService.UpdateTransactionByVNPAYStatusAsync(model);
                return Ok(transaction);
            }
            catch
            {
                throw;
            }
        }
    }
}
