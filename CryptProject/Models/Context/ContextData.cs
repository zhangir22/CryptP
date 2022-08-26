using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CryptProject.Models.Context
{
    public class ContextData:DbContext
    {
        public ContextData():
            base("name=Context")
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<CryptValue> CryptValues { get; set; }

    }
}