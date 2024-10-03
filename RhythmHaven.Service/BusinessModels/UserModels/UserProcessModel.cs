using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.BusinessModels.UserModels
{
    public class UserProcessModel
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNum { get; set; } = null!;
        public string? Avatar { get; set; }
    }
}
