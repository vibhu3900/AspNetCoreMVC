using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore.Models.SignInModel
{
    public class SignInModel
    {
        [Key]
        public int id { get; set; }
        [Required, EmailAddress(ErrorMessage = "Enter correct email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter correct password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
    }
}
