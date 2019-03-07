using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using ASPNETCinema.Logic;
using Microsoft.AspNetCore.Authorization;

namespace ASPNETCinema.Controllers
{
    public class MovieController : Controller
    {
        DatabaseMovie database = new DatabaseMovie();
        MovieLogic movieLogic = new MovieLogic();


        [Authorize(Roles = "Administrator")]
        public ActionResult AddMovie()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddMovie(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                movieLogic.AddMovie(movie);
                return RedirectToAction("ListMovies");
            }
            return View();
        }


        public ActionResult ListMovies(string OrderBy)
        {
            return View(movieLogic.GetMoviesAndOrderBy(OrderBy));
        }


        public ActionResult DetailsMovie(int? id)
        {
            return View(movieLogic.GetMovie(id));
        }

        
       

        [Authorize(Roles = "Administrator")]
        public ActionResult EditMovie(int? id)
        {
            return View(movieLogic.GetMovie(id));
        }
        

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditMovie(MovieModel movie)
        {
            movieLogic.EditMovie(movie);
            return RedirectToAction("ListMovies");
        }

        
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteMovie(int? id)
        {
            if (User.IsInRole("Administrator"))
            {
                return View(movieLogic.GetMovie(id));
            }
            //Redirects to standard
            return Redirect("/");
        }

        // POST: Movies/Delete/5
        //[HttpPost, ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteMovie(MovieModel movie)
        {
            movieLogic.DeleteMovie(movie);
            return RedirectToAction("ListMovies");
        }
    }
}