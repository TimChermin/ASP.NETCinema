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
    public class HallController : Controller
    {
        HallLogic hallLogic = new HallLogic();
        [Authorize(Roles = "Administrator")]
        public ActionResult AddHall()
        {
            return View();
        }


        // POST: Hall/AddHall
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddHall(HallModel hall)
        {
            if (ModelState.IsValid)
            {
                hallLogic.AddHall(hall);
                return RedirectToAction("ListMovies", "Movie");
            }
            return View();
        }


        public ActionResult ListHalls()
        {
            return View(hallLogic.GetHalls());
        }
    }
}