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
            else
            {
                ViewBag.HasError = true;
                ViewBag.ErrorMessage = "This Hall already has a screening on this day and time!";
            }
            
            return View();
        }

        public ActionResult DetailsScreening(int? id)
        {
            return View(screeningLogic.GetScreening(id));
        }

        public ActionResult EditScreening(int? id)
        {
            return View(screeningLogic.GetScreening(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditScreening(ScreeningModel screening)
        {
            if (ModelState.IsValid && screeningLogic.IsThisDateAndTimeAvailable(screening))
            {
                screeningLogic.EditScreening(screening);
                return RedirectToAction("ListScreenings");
            }
            else
            {
                ViewBag.HasError = true;
                ViewBag.ErrorMessage = "This Hall already has a screening on this day and time!";
            }

            return View();
        }


    }
}