using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Settings
{
    public class VnPaySetting
    {
        public required string TmnCode { get; set; }
        public required string HashSecret { get; set; }
        public required string BaseUrl { get; set; }
        public required string ReturnUrl { get; set; }
        public required string Command { get; set; }
        public required string CurrCode { get; set; }
        public required string Version { get; set; }
        public required string Locale { get; set; }
    }
}
