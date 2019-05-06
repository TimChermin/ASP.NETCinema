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
using static aMVCLayer.Enums.MovieType;
using AutoMapper;

namespace ASPNETCinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieContext _movie;
        private readonly IMapper _mapper;

        //added scoped stuff in startup 
        public MovieController(IMovieContext movie, IMapper mapper)
        {
            _movie = movie;
            _mapper = mapper;
        }
        //other things
        //List
        //Add
        //details
        //Edit
        //Delete


        public ActionResult ListMovies(string orderBy, string screeningFilter)
        {
            var movieLogic = new MovieLogic(_movie);
            List<MovieViewModel> movies = new List<MovieViewModel>();
            if (screeningFilter == null)
            {
                movieLogic.ScreeningFilter = DateTime.Today.ToShortDateString();
            }
            else
            {
                movieLogic.ScreeningFilter = screeningFilter;
            }

            foreach (var movie in movieLogic.GetMovies(orderBy))
            {
                movies.Add(_mapper.Map<MovieViewModel>(movie));
            }
            return View(movies);
        }


        [Authorize(Roles = "Administrator")]
        public ActionResult AddMovie()
        {
            var viewMovie = new MovieViewModel
            {
                MovieTypes = Enum.GetValues(typeof(MovieTypes)).Cast<MovieTypes>().ToList(),
            };
            return View(viewMovie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddMovie(MovieViewModel movie)
        {
            var movieLogic = new MovieLogic(_movie);
            if (movieLogic.DoesThisMovieExist(movie.Name) == false && movie.ReleaseDate <= movie.LastScreeningDate)
            {
                movieLogic.AddMovie(movie.Id, movie.Name, movie.Description, movie.ReleaseDate, movie.LastScreeningDate,
                movie.MovieType, movie.MovieLenght, movie.ImageString, movie.BannerImageString);
                return RedirectToAction("ListMovies");
            }
            else if (movie.ReleaseDate >= movie.LastScreeningDate && movieLogic.DoesThisMovieExist(movie.Name) == true)
            {
                ModelState.AddModelError("ReleaseDate", movie.ReleaseDate.ToShortDateString() + " Is after the Last Screening Date");
                ModelState.AddModelError("Name", movie.Name + " already exists");
            }
            else if (movieLogic.DoesThisMovieExist(movie.Name) == true)
            {
                ModelState.AddModelError("Name", movie.Name + " already exists");
            }
            else
            {
                ModelState.AddModelError("ReleaseDate", movie.ReleaseDate.ToShortDateString() + " Is after the LastScreeningDate");
            }
            return View();
        }


        public ActionResult DetailsMovie(int id)
        {
            var movieLogic = new MovieLogic(_movie);
            if (movieLogic.GetMovieById(id) != null)
            {
                var movie = movieLogic.GetMovieById(id);
                var viewMovie = _mapper.Map<MovieViewModel>(movie);
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
                var viewMovie = _mapper.Map<MovieViewModel>(movie);
                return View(viewMovie);
            }
            return RedirectToAction("Error", "Home");
        }
        

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditMovie(MovieViewModel movie)
        {
            var movieLogic = new MovieLogic(_movie);
            movieLogic.EditMovie(movie.Id, movie.Name, movie.Description, movie.ReleaseDate, movie.LastScreeningDate,
                movie.MovieType, movie.MovieLenght, movie.ImageString, movie.BannerImageString);
            return RedirectToAction("DetailsMovie", new { id = movie.Id });
        }

        
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteMovie(int id)
        {
            var movieLogic = new MovieLogic(_movie);
            if (movieLogic.GetMovieById(id) != null)
            {
                var movie = movieLogic.GetMovieById(id);
                var viewMovie = _mapper.Map<MovieViewModel>(movie);
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
            movieLogic.DeleteMovie(movie.Id);
            return RedirectToAction("ListMovies");
        }
    }
}