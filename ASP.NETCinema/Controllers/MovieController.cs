using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using ASPNETCinema.Logic;

namespace ASPNETCinema.Controllers
{
    public class MovieController : Controller
    {
        DatabaseMovie database = new DatabaseMovie();
        MovieLogic movieLogic = new MovieLogic();
       


        //GET
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ListMovies()
        {
            return View(movieLogic.GetMovies());
        }

        public ActionResult AddMovie()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult AddMovie(string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght)
        {
            movieLogic.AddMovie(name, description, releaseDate, lastScreeningDate, movieType, movieLenght);
            return RedirectToAction("ListMovies");
        }

        public ActionResult EditMovie(int? id)
        {
            return View(movieLogic.EditMovie(id));
        }

        // GET: Movies/Edit/5
        [HttpPost]
        public ActionResult EditMovie(int id, string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght)
        {
            movieLogic.EditMovie(id, name, description, releaseDate, lastScreeningDate, movieType, movieLenght);
            return RedirectToAction("ListMovies");
        }


        // GET: Movies/Delete/5
        public ActionResult DeleteMovie(int? id)
        {
            foreach (MovieModel movie in database.GetMovies())
            {
                if (id == movie.ID && id != null)
                {
                    return View(movie);
                }
            }
            return NotFound();
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMovie(int id)
        {
            foreach (MovieModel movie in database.GetMovies())
            {
                if (id == movie.ID)
                {
                    database.DeleteMovie(id);
                }
            }
            return RedirectToAction("ListMovies");
        }
        


        public ActionResult Home()
        {
            return View();
        }

    }
}