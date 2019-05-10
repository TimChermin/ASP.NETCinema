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
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class HallController : Controller
    {
        private readonly IHallLogic _hallLogic;
        private readonly IMapper _mapper;

        //added scoped stuff in startup 
        public HallController(IHallLogic hallLogic, IMapper mapper)
        {
            _hallLogic = hallLogic;
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
            
            List<HallViewModel> halls = new List<HallViewModel>();
            foreach (var hall in _hallLogic.GetHalls())
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
            
            if (ModelState.IsValid)
            {
                _hallLogic.AddHall(hall.Id, hall.Price, hall.ScreenType, hall.Seats, hall.SeatsTaken);
                return RedirectToAction("ListHalls");
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult EditHall(int id)
        {
            
            if (_hallLogic.GetHallById(id) != null)
            {
                var hall = _hallLogic.GetHallById(id);
                var viewHall = _mapper.Map<HallViewModel>(hall);
                return View(viewHall);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditHall(HallModel hall)
        {
            
            if (ModelState.IsValid)
            {
                _hallLogic.EditHall(hall.Id, hall.Price, hall.ScreenType, hall.Seats, hall.SeatsTaken);
                return RedirectToAction("ListHalls");
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteHall(int id)
        {
            
            if (_hallLogic.GetHallById(id) != null)
            {
                var hall = _hallLogic.GetHallById(id);
                var viewHall = _mapper.Map<HallViewModel>(hall);
                return View(viewHall);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteHall(HallViewModel hall)
        {
            
            _hallLogic.DeleteHall(hall.Id);
            return RedirectToAction("ListHalls");
        }

        
    }
}