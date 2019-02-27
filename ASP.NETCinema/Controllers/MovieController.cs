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

        public ActionResult ListMovies(string OrderBy)
        {
            return View(movieLogic.GetMoviesAndOrderBy(OrderBy));
        }


        public ActionResult DetailsMovie(int? id)
        {
            return View(movieLogic.GetDetailsMovie(id));
        }

        public ActionResult AddMovie()
        {
            return View();
        }

        public ActionResult OrderByName()
        {

            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMovie(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                movieLogic.AddMovie(movie);
                return RedirectToAction("ListMovies");
            }
            return View();
        }

        public ActionResult EditMovie(int? id)
        {
            return View(movieLogic.GetToEditMovie(id));
        }

        // GET: Movies/Edit/5
        [HttpPost]
        public ActionResult EditMovie(MovieModel movie)
        {
            movieLogic.EditMovie(movie);
            return RedirectToAction("ListMovies");
        }


        // GET: Movies/Delete/5
        public ActionResult DeleteMovie(int? id)
        {
            return View(movieLogic.GetToDeleteMovie(id));
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMovie(int id)
        {
            movieLogic.DeleteMovie(id);
            return RedirectToAction("ListMovies");
        }
        


        public ActionResult Home()
        {
            return View();
        }

    }
}