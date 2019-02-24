using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ASPNETCinema.Controllers
{
    public class MovieController : Controller
    {
        Database database = new Database();
       


        //GET
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ListMovies()
        {
            List<MovieModel> movies = database.GetMovies();
            return View(movies);
        }

        public ActionResult AddMovie()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult AddMovie(string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght)
        {
            database.AddMovie(name, description, releaseDate, lastScreeningDate, movieType, movieLenght);
            return RedirectToAction("ListMovies");
        }

        public ActionResult EditMovie(int id)
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult EditMovie(string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght)
        {
           
            return View();
        }


            public ActionResult Home()
        {
            return View();
        }

    }
}