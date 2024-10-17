using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RhythmHaven.Service.BusinessModels.OrderModels;
using RhythmHaven.Service.BusinessModels.TransactionModels;
using RhythmHaven.Service.Settings;
using RhythmHaven.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services.Interfaces
{
    public interface IPaymentService
    {
        string CreatePaymentUrl(TransactionModel model, HttpContext context);
    }
}
