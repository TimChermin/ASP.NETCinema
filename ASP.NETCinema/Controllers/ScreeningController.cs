using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using ASPNETCinema.ViewModels;
using DAL;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class ScreeningController : Controller
    {
        private readonly IScreeningContext _screening;
        
        public ScreeningController(IScreeningContext screening)
        {
            _screening = screening;
        }

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete
        

        public ActionResult ListScreenings()
        {
            var screeningLogic = new ScreeningLogic(_screening);
            List<ScreeningViewModel> screenings = new List<ScreeningViewModel>();
            foreach (var screening in screeningLogic.GetScreenings())
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
            return View(screenings);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AddScreening()
        {
            var screeningLogic = new ScreeningLogic(_screening);
            List<ScreeningViewModel> screenings = new List<ScreeningViewModel>();
            foreach (var screening in screeningLogic.GetScreenings())
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
            var screeningLogic = new ScreeningLogic(_screening);
            if (ModelState.IsValid)
            {
                if (screeningLogic.IsThisDateAndTimeAvailable(screening.HallId, screening.DateOfScreening, screening.TimeOfScreening, screening.MovieId, screening.Id))
                {
                    screeningLogic.AddScreening(screening.Id, screening.MovieId, screening.HallId, screening.DateOfScreening, screening.TimeOfScreening);
                    return RedirectToAction("ListScreenings");
                }
                ModelState.AddModelError("TimeOfScreening", "Another movie is already showing in this hall at this time");
                return View();
            }
            return RedirectToAction("Error", "Home");
        }
        
        public ActionResult DetailsScreening(int id)
        {
            var screeningLogic = new ScreeningLogic(_screening);
            if (screeningLogic.GetScreeningById(id) != null)
            {
                var screening = screeningLogic.GetScreeningById(id);
                ScreeningViewModel viewScreening = new ScreeningViewModel
                {
                    Id = screening.Id,
                    MovieId = screening.MovieId,
                    HallId = screening.HallId,
                    DateOfScreening = screening.DateOfScreening,
                    TimeOfScreening = screening.TimeOfScreening,
                    Movies = screening.Movies,
                    Halls = screening.Halls
                };
                return View(viewScreening);
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult EditScreening(int id)
        {
            var screeningLogic = new ScreeningLogic(_screening);
            if (screeningLogic.GetScreeningById(id) != null)
            {
                var screening = screeningLogic.GetScreeningById(id);
                ScreeningViewModel viewScreening = new ScreeningViewModel
                {
                    Id = screening.Id,
                    MovieId = screening.MovieId,
                    HallId = screening.HallId,
                    DateOfScreening = screening.DateOfScreening,
                    TimeOfScreening = screening.TimeOfScreening,
                    Movies = screening.Movies,
                    Halls = screening.Halls
                };
                return View(viewScreening);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditScreening(ScreeningViewModel screening)
        {
            var screeningLogic = new ScreeningLogic(_screening);
            if (ModelState.IsValid && screeningLogic.IsThisDateAndTimeAvailable(screening.HallId, screening.DateOfScreening, screening.TimeOfScreening, screening.MovieId, screening.Id))
            {
                screeningLogic.EditScreening(screening.Id, screening.MovieId, screening.HallId, screening.DateOfScreening, screening.TimeOfScreening);
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
            var screeningLogic = new ScreeningLogic(_screening);
            if (screeningLogic.GetScreeningById(id) != null)
            {
                var screening = screeningLogic.GetScreeningById(id);
                ScreeningViewModel viewScreening = new ScreeningViewModel
                {
                    Id = screening.Id,
                    MovieId = screening.MovieId,
                    HallId = screening.HallId,
                    DateOfScreening = screening.DateOfScreening,
                    TimeOfScreening = screening.TimeOfScreening,
                    Movies = screening.Movies,
                    Halls = screening.Halls
                };
                return View(viewScreening);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteScreening(ScreeningViewModel screening)
        {
            var screeningLogic = new ScreeningLogic(_screening);
            screeningLogic.DeleteScreening(screening.Id);
            return RedirectToAction("ListScreenings");
        }

        public ActionResult SeatSelector(ScreeningViewModel screening)
        {
            var screeningLogic = new ScreeningLogic(_screening);
            ScreeningViewModel viewScreening = new ScreeningViewModel
            {
                Id = screening.Id,
                MovieId = screening.MovieId,
                HallId = screening.HallId,
                Hall = screening.Hall,
                DateOfScreening = screening.DateOfScreening,
                TimeOfScreening = screening.TimeOfScreening,
            };
            return View(viewScreening);
        }

        public ActionResult TicketConfirm(string[] methodParam)
        {
            return View();
        }
    }
}