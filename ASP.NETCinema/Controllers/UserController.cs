using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCinema.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using ASPNETCinema.Data;

namespace ASPNETCinema.Controllers
{
    public class UserController : Controller
    {
        DatabaseUser database = new DatabaseUser();
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                database.AddUser(user);
                return RedirectToAction("ListMovies");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            if (LoginUser(userModel.Name, userModel.Password))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userModel.Name)
            };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return Redirect("/");
            }
            return View();
        }

        private bool LoginUser(string name, string password)
        {
            //As an example. This method would go to our data store and validate that the combination is correct. 
            //For now just return true. 
            return true;
        }
    }
}