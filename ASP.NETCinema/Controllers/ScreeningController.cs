using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using ASPNETCinema.ViewModels;
using AutoMapper;
using DAL;
using Interfaces;
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

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete
        

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
            foreach (var screening in _screeningLogic.GetScreenings())
            {
                screenings.Add(new ScreeningViewModel
                {
                    Id = screening.Id,
                    Movie = screening.Movie,
                    Hall = screening.Hall,
                    DateOfScreening = screening.DateOfScreening,
                    TimeOfScreening = screening.TimeOfScreening,
                    Movies = screening.Movies,
                    Halls = screening.Halls
                });
            }
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
                    _screeningLogic.AddScreening(screening.Id, screening.MovieId, screening.HallId, screening.DateOfScreening, screening.TimeOfScreening);
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
                _screeningLogic.EditScreening(screening.Id, screening.MovieId, screening.HallId, screening.DateOfScreening, screening.TimeOfScreening);
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

        public ActionResult TicketConfirm(string[] methodParam)
        {
            return View();
        }
    }
}