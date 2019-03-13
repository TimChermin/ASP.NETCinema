using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCinema.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using ASPNETCinema.Data;
using ASPNETCinema.Logic;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ASPNETCinema.Controllers
{
    public class UserController : Controller
    {
        DatabaseUser database = new DatabaseUser();
        UserLogic userLogic = new UserLogic();

        [HttpGet]
        public IActionResult LoginUser()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return Redirect("/");
            }
            
            return View();
        }

        public ActionResult AddUser()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return Redirect("/");
            }
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                database.AddUser(user);
                await LoginUser(user);
                return Redirect("/");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser(UserModel userModel)
        {
            
            if (userLogic.CheckIfThisLoginIsCorrect(userModel.Name, userModel.Password))
            {
                string userRole = userLogic.GetRoleUser(userModel);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userModel.Name),
                    new Claim(ClaimTypes.Role, userRole)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return Redirect("/");
            }
            
            return View();
        }

        public async Task<IActionResult> LogoutUser()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                await HttpContext.SignOutAsync();
                return Redirect("/");
            }
            return View("/");
        }
    }
}