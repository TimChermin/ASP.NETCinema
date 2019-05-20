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
    public class ScreeningController : Controller
    {
        private readonly IScreeningLogic _screeningLogic;
        private readonly IMapper _mapper;
        
        public ScreeningController(IScreeningLogic screeningLogic, IMapper mapper)
        {
            _mapper = mapper;
            _screeningLogic = screeningLogic;
        }
       
        public ActionResult ListScreenings()
        {
            List<ScreeningViewModel> screenings = new List<ScreeningViewModel>();
            foreach (var screening in _screeningLogic.GetScreenings())
            {
                screenings.Add( _mapper.Map<ScreeningViewModel>(screening));
            }
            return View(screenings);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AddScreening()
        {
            
            List<ScreeningViewModel> screenings = new List<ScreeningViewModel>();

            screenings = _mapper.Map<List<ScreeningViewModel>>(_screeningLogic.GetScreenings());
            return View(screenings[0]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddScreening(ScreeningViewModel screening)
        {
            
            if (ModelState.IsValid)
            {
                if (_screeningLogic.IsThisDateAndTimeAvailable(screening.HallId, screening.DateOfScreening, screening.TimeOfScreening, screening.MovieId, screening.Id))
                {
                    _screeningLogic.AddScreening(_mapper.Map<ScreeningModel>(screening));
                    return RedirectToAction("ListScreenings");
                }
                ModelState.AddModelError("TimeOfScreening", "Another movie is already showing in this hall at this time");
                return View();
            }
            return RedirectToAction("Error", "Home");
        }
        
        public ActionResult DetailsScreening(int id)
        {
            
            if (_screeningLogic.GetScreeningById(id) != null)
            {
                var screening = _screeningLogic.GetScreeningById(id);
                var viewScreening = _mapper.Map<ScreeningViewModel>(screening);
                return View(viewScreening);
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult EditScreening(int id)
        {
            
            if (_screeningLogic.GetScreeningById(id) != null)
            {
                var screening = _screeningLogic.GetScreeningById(id);
                var viewScreening = _mapper.Map<ScreeningViewModel>(screening);
                return View(viewScreening);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditScreening(ScreeningViewModel screening)
        {
            
            if (ModelState.IsValid && _screeningLogic.IsThisDateAndTimeAvailable(screening.HallId, screening.DateOfScreening, screening.TimeOfScreening, screening.MovieId, screening.Id))
            {
                _screeningLogic.EditScreening(_mapper.Map<ScreeningModel>(screening));
                return RedirectToAction("ListScreenings");
            }
            else
            {
                ModelState.AddModelError("TimeOfScreening", "Another movie is already showing in this hall at this time");
            }

            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteScreening(int id)
        {
            
            if (_screeningLogic.GetScreeningById(id) != null)
            {
                var screening = _screeningLogic.GetScreeningById(id);
                var viewScreening = _mapper.Map<ScreeningViewModel>(screening);
                return View(viewScreening);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteScreening(ScreeningViewModel screening)
        {
            
            _screeningLogic.DeleteScreening(screening.Id);
            return RedirectToAction("ListScreenings");
        }

        public ActionResult SeatSelector(ScreeningViewModel screening)
        {
            
            var viewScreening = _mapper.Map<ScreeningViewModel>(screening);
            return View(viewScreening);
        }

        public ActionResult SeatConfirm(string jsonData)
        {
            return View();
        }

        public ActionResult SeatConfirm()
        {
            return View();
        }
    }
}