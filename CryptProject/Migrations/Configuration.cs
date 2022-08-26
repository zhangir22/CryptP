namespace CryptProject.Migrations
{
    using CryptProject.Models;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Net;

    internal sealed class Configuration : DbMigrationsConfiguration<CryptProject.Models.Context.ContextData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
      
        protected override void Seed(CryptProject.Models.Context.ContextData context)
        {
            var user = new List<User>
            {
                new User { login = "admin",
                    email = "admin123@mail.ru",password="admin123"},
                new User{ login = "subAdmin",
                    email = "sub@mail.ru", password = "123" },
             
            };
            user.ForEach(s => context.Users.AddOrUpdate(p => p.email, s));
            context.SaveChanges();

        }
    }
}
