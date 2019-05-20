using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using AutoMapper;
using DAL;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class HallController : Controller
    {
        private readonly IHallLogic _hallLogic;
        private readonly IMapper _mapper;
        
        public HallController(IHallLogic hallLogic, IMapper mapper)
        {
            _hallLogic = hallLogic;
            _mapper = mapper;
        }


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
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddHall(HallModel hall)
        {
            
            if (ModelState.IsValid)
            {
                _hallLogic.AddHall(_mapper.Map<HallModel>(hall));
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
                _hallLogic.EditHall(_mapper.Map<HallModel>(hall));
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