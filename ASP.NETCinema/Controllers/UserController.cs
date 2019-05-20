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
using AutoMapper;
using LogicLayer.Interfaces;
using ASPNETCinema.Models;

namespace ASPNETCinema.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserLogic _userLogic;
        private readonly IMapper _mapper;

        public UserController(IUserLogic userLogic, IMapper mapper)
        {
            _mapper = mapper;
            _userLogic = userLogic;
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
            
            if (_userLogic.CheckIfThisLoginIsCorrect(user.Name, user.Password))
            {
                int userId = _userLogic.GetUser(user.Name, user.Password).Id;
                string userRole = _userLogic.GetRoleUser(userId);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, userRole)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                
                return RedirectToAction("ListMovies", "Movie");
            }
            ViewBag.Test = "The Username or Password is incorrect.";
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
            if (ModelState.IsValid)
            {
                _userLogic.AddUser(_mapper.Map<UserModel>(user));
                
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