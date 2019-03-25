using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCinema.Logic;
using Microsoft.AspNetCore.Authorization;
using ASPNETCinema.ViewModels;
using DAL;
using Interfaces;

namespace ASPNETCinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieContext _movie;
        
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

        public ActionResult ListMovies(string orderBy)
        {
            var movieLogic = new MovieLogic(_movie);
            List<MovieViewModel> movies = new List<MovieViewModel>();
            foreach (var movie in movieLogic.GetMovies(orderBy))
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
                    ImageString = movie.ImageString,
                    Screenings = movie.Screenings

                });
            }
            return View(movies);
        }


        [Authorize(Roles = "Administrator")]
        public ActionResult AddMovie()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddMovie(MovieViewModel movie)
        {
            var movieLogic = new MovieLogic(_movie);
            if (ModelState.IsValid)
            {
                movieLogic.AddMovie(movie.Id, movie.Name, movie.Description, movie.ReleaseDate, movie.LastScreeningDate,
                    movie.MovieType, movie.MovieLenght, movie.ImageString);
                return RedirectToAction("ListMovies");
            }
            return RedirectToAction("Error", "Home");
        }


        public ActionResult DetailsMovie(int id)
        {
            var movieLogic = new MovieLogic(_movie);
            if (movieLogic.GetMovieById(id) != null)
            {
                var movie = movieLogic.GetMovieById(id);
                var viewMovie = new MovieViewModel
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Description = movie.Description,
                    ReleaseDate = movie.ReleaseDate,
                    LastScreeningDate = movie.LastScreeningDate,
                    MovieType = movie.MovieType,
                    MovieLenght = movie.MovieLenght,
                    ImageString = movie.ImageString
                };
                return View(viewMovie);
            }
            return RedirectToAction("Error", "Home");
        }

        
       

        [Authorize(Roles = "Administrator")]
        public ActionResult EditMovie(int id)
        {
            var movieLogic = new MovieLogic(_movie);
            if (movieLogic.GetMovieById(id) != null)
            {
                var movie = movieLogic.GetMovieById(id);
                var viewMovie = new MovieViewModel
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Description = movie.Description,
                    ReleaseDate = movie.ReleaseDate,
                    LastScreeningDate = movie.LastScreeningDate,
                    MovieType = movie.MovieType,
                    MovieLenght = movie.MovieLenght,
                    ImageString = movie.ImageString
                };
                return View(viewMovie);
            }
            return RedirectToAction("Error", "Home");
        }
        

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditMovie(MovieViewModel movie)
        {
            var movieLogic = new MovieLogic(_movie);
            if (ModelState.IsValid)
            {
                movieLogic.EditMovie(movie.Id, movie.Name, movie.Description, movie.ReleaseDate, movie.LastScreeningDate,
                    movie.MovieType, movie.MovieLenght, movie.ImageString);
                return RedirectToAction("ListMovies");
            }
            return RedirectToAction("Error", "Home");
        }

        
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteMovie(int id)
        {
            var movieLogic = new MovieLogic(_movie);
            if (movieLogic.GetMovieById(id) != null)
            {
                var movie = movieLogic.GetMovieById(id);
                var viewMovie = new MovieViewModel
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Description = movie.Description,
                    ReleaseDate = movie.ReleaseDate,
                    LastScreeningDate = movie.LastScreeningDate,
                    MovieType = movie.MovieType,
                    MovieLenght = movie.MovieLenght,
                    ImageString = movie.ImageString
                };
                return View(viewMovie);
            }
            return RedirectToAction("Error", "Home");
        }

        // POST: Movies/Delete/5
        //[HttpPost, ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteMovie(MovieViewModel movie)
        {
            var movieLogic = new MovieLogic(_movie);
            if (ModelState.IsValid)
            {
                movieLogic.DeleteMovie(movie.Id);
                return RedirectToAction("ListMovies");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}