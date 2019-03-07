using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class ScreeningController : Controller
    {
        ScreeningLogic screeningLogic = new ScreeningLogic();

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public ActionResult ListScreenings()
        {
            return View(screeningLogic.GetScreenings());
        }

        public ActionResult AddScreening()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddScreening(ScreeningModel screening)
        {
            if (ModelState.IsValid && screeningLogic.IsThisDateAndTimeAvailable(screening))
            {
                screeningLogic.AddScreening(screening);
                return RedirectToAction("ListScreenings");
            }
            return View();
        }


    }
}