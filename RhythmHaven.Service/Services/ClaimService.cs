using Microsoft.AspNetCore.Http;
using RhythmHaven.Service.Services.Interfaces;
using RhythmHaven.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services
{
    public class ClaimService : IClaimService
    {
        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            // todo implementation to get the current userId
            var identity = httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            var extractedId = ClaimUtils.GetCurrentUsername(identity);
            GetCurrentUserName = extractedId;
        }

        public string GetCurrentUserName { get; }
    }
}
