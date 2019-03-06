using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class ScreeningController : Controller
    {
        ScreeningLogic screeningLogic = new ScreeningLogic();
        HallModel hallModel = new HallModel();
        HallLogic hallLogic = new HallLogic();


        public ActionResult ListScreenings()
        {
            return View(screeningLogic.GetScreenings());
        }

        public ActionResult AddScreening()
        {
            return View();
        }

        public List<MovieModel> GetMovies()
        {
            List<MovieModel> movies = new List<MovieModel>();
            MovieModel movie = new MovieModel();
            movies.Add(movie);
            return movies;
        }






    }
}