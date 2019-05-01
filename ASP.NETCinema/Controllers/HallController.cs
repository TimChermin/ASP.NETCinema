using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using AutoMapper;
using DAL;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class HallController : Controller
    {
        private readonly IHallContext _hall;
        private readonly IMapper _mapper;

        //added scoped stuff in startup 
        public HallController(IHallContext hall, IMapper mapper)
        {
            _hall = hall;
            _mapper = mapper;
        }
        //other things
        //List
        //Add
        //details
        //Edit
        //Delete


        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult ListHalls()
        {
            var hallLogic = new HallLogic(_hall);
            List<HallViewModel> halls = new List<HallViewModel>();
            foreach (var hall in hallLogic.GetHalls())
            {
                halls.Add(_mapper.Map<HallViewModel>(hall));
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
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult EditHall(int id)
        {
            var hallLogic = new HallLogic(_hall);
            if (hallLogic.GetHallById(id) != null)
            {
                var hall = hallLogic.GetHallById(id);
                var viewHall = _mapper.Map<HallViewModel>(hall);
                return View(viewHall);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditHall(HallModel hall)
        {
            var hallLogic = new HallLogic(_hall);
            if (ModelState.IsValid)
            {
                hallLogic.EditHall(hall.Id, hall.Price, hall.ScreenType, hall.Seats, hall.SeatsTaken);
                return RedirectToAction("ListHalls");
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteHall(int id)
        {
            var hallLogic = new HallLogic(_hall);
            if (hallLogic.GetHallById(id) != null)
            {
                var hall = hallLogic.GetHallById(id);
                var viewHall = _mapper.Map<HallViewModel>(hall);
                return View(viewHall);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteHall(HallViewModel hall)
        {
            var hallLogic = new HallLogic(_hall);
            hallLogic.DeleteHall(hall.Id);
            return RedirectToAction("ListHalls");
        }

        
    }
}