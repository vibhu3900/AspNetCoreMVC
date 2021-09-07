using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore.Models.SignUpUserModel
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please Enter your first name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Key]
        [Required(ErrorMessage = "Please Enter your email")]
        [Display(Name ="Email Address")]
        [EmailAddress(ErrorMessage ="Please Enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a strong password")]
        [Compare("ConfirmPassword", ErrorMessage ="Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please confirm your password")]
        [Display(Name ="Confirm password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


    }
}
