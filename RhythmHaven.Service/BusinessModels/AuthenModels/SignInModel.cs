﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.BusinessModels.AuthenModels
{
    public class SignInModel
    {
        [Required(ErrorMessage = "User name is required!")]
        [Display(Name = "User name")]
        public string Username { get; set; } = "";

        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password")]
        public string Password { get; set; } = "";
    }
}
