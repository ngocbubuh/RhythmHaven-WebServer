﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Services.Interfaces
{
    public interface IClaimService
    {
        public string GetCurrentUserName { get; }
    }
}