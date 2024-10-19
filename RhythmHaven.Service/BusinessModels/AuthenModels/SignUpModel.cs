using RhythmHaven.Repository.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.BusinessModels.AuthenModels
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Vui lòng nhập username.")]
        [Display(Name = "User name")]
        public string UserName { get; set; } = "";

        //[Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        //[Display(Name = "Full name")]
        //public string Name { get; set; } = "";


        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Mật khẩu phải có từ 4 đến 20 kí tự.")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mậu khẩu nhập không trùng khớp")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Mật khẩu phải có từ 4 đến 20 kí tự.")]
        [PasswordPropertyText]
        public string ConfirmPassword { get; set; } = ""; //Confirm Password


        //[Display(Name = "Phone Number")]
        //[DataType(DataType.PhoneNumber, ErrorMessage = "Số điện thoại không hợp lệ.")]
        //[RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Số điện thoại phải có 10 số.")]
        //public string PhoneNum { get; set; } = "";

        //[DataType(DataType.EmailAddress,
        //          ErrorMessage = "Email không hợp lệ")]
        //[EmailAddress(ErrorMessage = "Email không hợp lệ")]
        //[RegularExpression(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$",
        //          ErrorMessage = "Email không hợp lệ")]
        //[Required(AllowEmptyStrings = false,
        //          ErrorMessage = "Vui lòng nhập email")]
        //[Display(Name = "Email Address")]
        //public string Email { get; set; } = ""; //Email Address
    }
}
