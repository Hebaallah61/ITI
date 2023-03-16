using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using task1.Models;

namespace task1.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Client client)
        {
            //check if valid user (ModelState.IsValid)
            //Insert newUser into DB
            //Create User Identity for this user Using Claims (Name, Email, Password, Phone)
            //Owin Cookie middleware, user identity to create cookie for this user to authenticate him

            // Redirect to Home/Index


            if (ModelState.IsValid)
            {
                DBContext context = new DBContext();

                context.Clients.Add(client);
                context.SaveChanges();

                var userIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim("Name", client.Name),
                    new Claim(ClaimTypes.Email, client.Email),
                    new Claim("Password", client.Password)
                }, "AppCookie");

                //Owin Authentication manager
               Request.GetOwinContext().Authentication.SignIn(userIdentity);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Client client)
        {
            //get User from Db
            //check user is not null
            //if not null { OWIN }
            //else return view

            DBContext context = new DBContext();

            var loggedUser = context.Clients.FirstOrDefault(
                c => c.Email == client.Email && c.Password == client.Password);

            if (loggedUser != null)
            {
                var signInIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, client.Email),
                    new Claim("Password", client.Password)
                }, "AppCookie");

                //Owin Authentication manager
                Request.GetOwinContext().Authentication.SignIn(signInIdentity);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Name", "User is not Existed");

                return View();
            }
        }

        public ActionResult Logout()
        {
            //Destroy Cookie for this user

            Request.GetOwinContext().Authentication.SignOut("AppCookie");
            return RedirectToAction("Login");
        }

        //GET: Account
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}