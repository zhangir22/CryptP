using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CryptProject.Models.ModelForm;
using CryptProject.Models.Context;
using CryptProject.Models;
using System.Web.Security;

namespace CryptProject.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult AccountDetails()
        {
            User _user = null;
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    using(ContextData db =new ContextData())
                    {
                        _user = db.Users.FirstOrDefault(u => u.login == User.Identity.Name);
                        if(_user != null)
                        {
                            return View(_user);
                        }
                    }
                }
            }
            return HttpNotFound();
        }

        public ActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "name,email,password,confirmPassword")] RegisterForm model) 
        {
            
           
                User _user = null;
                using (ContextData db = new ContextData())
                {
                    _user = db.Users.FirstOrDefault(u => u.email == model.email && u.login == model.name);
                }
                if(_user == null)
                {   
                    User newUser = new User();
                    newUser.login = model.name;
                    newUser.password = model.password;
                    newUser.email = model.email;
                    using(ContextData db = new ContextData())
                    {
                        db.Users.Add(newUser);
                        db.SaveChanges();
                        newUser = db.Users.Where(u => u.login == model.name && u.email == model.email).FirstOrDefault();
                    }
                    if(newUser != null)
                    {
                        FormsAuthentication.RedirectFromLoginPage(newUser.login, true);
                        FormsAuthentication.SetAuthCookie(newUser.login, true);
                        return RedirectToAction("Index", "Crypt");
                    }
                }
                else
                {
                    ModelState.AddModelError("","ERROR TO REGISTER");
                }
        
            return View();
        }
        public ActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginForm model) 
        {
            User _user = null;
            if (ModelState.IsValid)
            {
                using(ContextData db = new ContextData()) 
                {
                    _user = db.Users.Where(
                    u => u.login == model.name ||
                    u.email == model.name &&
                    u.password == model.password
                    ).FirstOrDefault();
                }
                if(_user != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(_user.login, true);
                    FormsAuthentication.SetAuthCookie(_user.login, true);
                    return RedirectToAction("Index", "Crypt");
                }
                else
                {
                    return RedirectToAction("Register", "Account");
                }
                return View();
            }
            return View();
        }
        public ActionResult Logout(int id)
        {
            User user = null;
            using (ContextData db = new ContextData())
            {
                user = db.Users.Find(id);
            }
            if (user != null)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Account");
            }
            return null;
        }
    }
}
