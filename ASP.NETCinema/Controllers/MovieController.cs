using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using ASPNETCinema.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using ASPNETCinema.ViewModels;
using DAL;

namespace ASPNETCinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieContext _movie;

        //added scoped stuff in startup 
        public MovieController(IMovieContext movie)
        {
            _movie = movie;
        }
        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public ActionResult ListMovies(string OrderBy)
        {
            var movieLogic = new MovieLogic(_movie);
            List<MovieViewModel> movies = new List<MovieViewModel>();
            foreach (var movie in movieLogic.GetMovies(OrderBy))
            {
                movies.Add(new MovieViewModel
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Description = movie.Description,
                    ReleaseDate = movie.ReleaseDate,
                    LastScreeningDate = movie.LastScreeningDate,
                    MovieType = movie.MovieType,
                    MovieLenght = movie.MovieLenght,
                    ImageString = movie.ImageString
                });
            }
            return View(movies);
            //return View(movieLogic.GetMoviesAndOrderBy(OrderBy));
        }


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
            var movieLogic = new MovieLogic(_movie);
            if (ModelState.IsValid)
            {
                movieLogic.AddMovie(movie);
                return RedirectToAction("ListMovies");
            }
            return View();
        }


        public ActionResult DetailsMovie(int? id)
        {
            var movieLogic = new MovieLogic(_movie);
            return View(movieLogic.GetMovie(id));
        }

        
       

        [Authorize(Roles = "Administrator")]
        public ActionResult EditMovie(int? id)
        {
            var movieLogic = new MovieLogic(_movie);
            return View(movieLogic.GetMovie(id));
        }
        

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditMovie(MovieModel movie)
        {
            var movieLogic = new MovieLogic(_movie);
            movieLogic.EditMovie(movie);
            return RedirectToAction("ListMovies");
        }

        
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteMovie(int? id)
        {
            var movieLogic = new MovieLogic(_movie);
            return View(movieLogic.GetMovie(id));
        }

        // POST: Movies/Delete/5
        //[HttpPost, ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteMovie(MovieModel movie)
        {
            var movieLogic = new MovieLogic(_movie);
            movieLogic.DeleteMovie(movie);
            return RedirectToAction("ListMovies");
        }
    }
}