using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CryptProject.Models.ModelForm
{
    public class LoginForm
    {
        [Required]
        [Display(Name ="Nickname or Email")]
        public string name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string password { get; set; }

    }
}