using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class MovieController : Controller
    {
        //GET
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ListMovies()
        {
            //using ASPNETCinema.Models; added
            List<MovieModel> movies = new List<MovieModel>();
            
            movies.Add(new MovieModel(1, "300", "Fightingstuff and thangs", "3D"));
            movies.Add(new MovieModel(2, "400", "Fightingstuff and thangs", "3D IMAX"));
            movies.Add(new MovieModel(3, "500", "Fightingstuff and thangs", "IMAX"));
            return View(movies);
        }
    }
}