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

namespace ASPNETCinema.Controllers
{
    public class UserController : Controller
    {
        DatabaseUser database = new DatabaseUser();
        UserLogic userLogic = new UserLogic();

        [HttpGet]
        public IActionResult LoginUser()
        {
            if (User.IsInRole("True") || User.IsInRole("1"))
            {

            }

            if (User.Identity.IsAuthenticated == true)
            {
                return Redirect("/");
            }
            
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(UserModel user)
        {
            if (ModelState.IsValid)
            {
                database.AddUser(user);
                await LoginUser(user);
            }
            return Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(UserModel userModel)
        {
            string userRole = userLogic.IsThisUserAnAdmin(userModel);
            if (userLogic.CheckIfThisLoginIsCorrect(userModel.Name, userModel.Password))
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userModel.Name),
                new Claim(ClaimTypes.Role, userLogic.IsThisUserAnAdmin(userModel).ToString())
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