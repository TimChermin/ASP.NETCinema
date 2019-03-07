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
                return RedirectToAction("ListHalls");
                //return RedirectToAction("ListMovies", "Movie");
            }
            return View();
        }
        
        [Authorize(Roles = "Administrator")]
        public ActionResult ListHalls()
        {
            return View(hallLogic.GetHalls());
        }
        
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteHall(int? id)
        {
            return View(hallLogic.GetHall(id));
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteMovie(int id)
        {
            hallLogic.DeleteHall(id);
            return RedirectToAction("ListMovies");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult EditHall(int? id)
        {
            return View(hallLogic.GetHall(id));
        }
    }
}