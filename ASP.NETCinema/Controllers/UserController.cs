using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using ASPNETCinema.Logic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using DAL;
using ASPNETCinema.ViewModels;

namespace ASPNETCinema.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserContext _user;
        
        public UserController(IUserContext user)
        {
            _user = user;
        }

        [HttpGet]
        public IActionResult LoginUser()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("ListMovies", "Movie");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginUser(UserViewModel user)
        {
            var userLogic = new UserLogic(_user);
            if (userLogic.CheckIfThisLoginIsCorrect(user.Name, user.Password))
            {
                int userId = userLogic.GetUser(user.Name, user.Password).Id;
                string userRole = userLogic.GetRoleUser(userId);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, userRole)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                //Just redirect to our index after logging in. 
                return RedirectToAction("ListMovies", "Movie");
            }

            return View();
        }

        public ActionResult AddUser()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("ListMovies", "Movie");
            }
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(UserViewModel user)
        {
            var userLogic = new UserLogic(_user);
            if (ModelState.IsValid)
            {
                userLogic.AddUser(user.Id, user.Name, user.Password, user.ConfirmPassword, user.Administrator);
                
                await LoginUser(user);
                return RedirectToAction("ListMovies", "Movie");
            }
            return View();
        }

        public async Task<IActionResult> LogoutUser()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction("ListMovies", "Movie");
            }
            return RedirectToAction("ListMovies", "Movie");
        }
    }
}