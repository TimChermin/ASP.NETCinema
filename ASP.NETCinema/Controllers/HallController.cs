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

        //Add
        //List
        //details
        //Edit
        //Delete


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

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteHall(HallModel hall)
        {
            hallLogic.DeleteHall(hall);
            return RedirectToAction("ListHalls");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult EditHall(int? id)
        {
            return View(hallLogic.GetHall(id));
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditHall(HallModel hall)
        {
            hallLogic.EditHall(hall);
            return RedirectToAction("ListHalls");
        }
    }
}