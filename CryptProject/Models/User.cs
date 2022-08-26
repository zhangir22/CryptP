using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptProject.Models
{
    public class User
    {
        public int id { get; set; }
        public string login {get;set;}
        public string email { get; set; }
        public string password { get; set; }
    }
}