using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.BusinessModels.UserModels
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNum { get; set; } = null!;
        public double Credit { get; set; }
        public string UserName { get; set; } = null!;
        public string? Avatar { get; set; }
        public string? UnsignName { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }
    }
}
