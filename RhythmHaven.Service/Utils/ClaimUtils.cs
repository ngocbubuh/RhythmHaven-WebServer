using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Utils
{
    public class ClaimUtils
    {
        public static string GetCurrentUsername(ClaimsIdentity identity)
        {
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return userClaims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
            }
            return null;
        }
    }
}
