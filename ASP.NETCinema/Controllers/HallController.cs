using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using DAL;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class HallController : Controller
    {
        private readonly IHallContext _hall;

        //added scoped stuff in startup 
        public HallController(IHallContext hall)
        {
            _hall = hall;
        }
        //other things
        //List
        //Add
        //details
        //Edit
        //Delete


        [Authorize(Roles = "Administrator")]
        public ActionResult ListHalls()
        {
            var hallLogic = new HallLogic(_hall);
            List<HallViewModel> halls = new List<HallViewModel>();
            foreach (var hall in hallLogic.GetHalls())
            {
                halls.Add(new HallViewModel
                {
                    Id = hall.Id,
                    Price = hall.Price,
                    ScreenType = hall.ScreenType,
                    Seats = hall.Seats,
                    SeatsTaken = hall.SeatsTaken
                });
            }
            return View(halls);
        }

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
            var hallLogic = new HallLogic(_hall);
            if (ModelState.IsValid)
            {
                hallLogic.AddHall(hall.Id, hall.Price, hall.ScreenType, hall.Seats, hall.SeatsTaken);
                return RedirectToAction("ListHalls");
            }
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult EditHall(int id)
        {
            var hallLogic = new HallLogic(_hall);
            if (ModelState.IsValid)
            {
                IHall hall = hallLogic.GetHallById(id);
                HallViewModel viewHall = new HallViewModel
                {
                    Id = hall.Id,
                    Price = hall.Price,
                    ScreenType = hall.ScreenType,
                    Seats = hall.Seats,
                    SeatsTaken = hall.SeatsTaken
                };
                return View(viewHall);
            }
            return RedirectToAction("ListMovies");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditHall(HallModel hall)
        {
            var hallLogic = new HallLogic(_hall);
            hallLogic.EditHall(hall.Id, hall.Price, hall.ScreenType, hall.Seats, hall.SeatsTaken);
            return RedirectToAction("ListHalls");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteHall(int id)
        {
            var hallLogic = new HallLogic(_hall);
            return View(hallLogic.GetHallById(id));
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteHall(HallModel hall)
        {
            var hallLogic = new HallLogic(_hall);
            hallLogic.DeleteHall(hall.Id);
            return RedirectToAction("ListHalls");
        }

        
    }
}