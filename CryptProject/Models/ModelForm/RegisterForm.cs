using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CryptProject.Models.ModelForm
{
    public class RegisterForm
    {
        [Required]
        [Display(Name = "Nickname")]
        public string name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [Display(Name ="Confirm Password")]
        public string confirmPassword { get; set; }

    }
}