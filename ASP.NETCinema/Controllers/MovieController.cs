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
using Models.Interfaces;

namespace ASPNETCinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieLogic _movieLogic;
        private readonly IMapper _mapper;

        //added scoped stuff in startup 
        public MovieController(IMovieLogic movieLogic, IMapper mapper)
        {
            _movieLogic = movieLogic;
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
            List<MovieViewModel> movies = new List<MovieViewModel>();
            if (screeningFilter == null)
            {
                _movieLogic.ScreeningFilter = DateTime.Today.ToShortDateString();
            }
            else
            {
                _movieLogic.ScreeningFilter = screeningFilter;
            }

            foreach (var movie in _movieLogic.GetMovies(orderBy))
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
            if (_movieLogic.DoesThisMovieExist(movie.Name) == false && movie.ReleaseDate <= movie.LastScreeningDate)
            {
                _movieLogic.AddMovie(movie.Id, movie.Name, movie.Description, movie.ReleaseDate, movie.LastScreeningDate,
                movie.MovieType, movie.MovieLenght, movie.ImageString, movie.BannerImageString);
                return RedirectToAction("ListMovies");
            }
            else if (_movieLogic.DoesThisMovieExist(movie.Name) == true)
            {
                ModelState.AddModelError("Name", movie.Name + " already exists");
            }
            return View();
        }


        public ActionResult DetailsMovie(int id)
        {
            if (_movieLogic.GetMovieById(id) != null)
            {
                var movie = _movieLogic.GetMovieById(id);
                var viewMovie = _mapper.Map<MovieViewModel>(movie);
                return View(viewMovie);
            }
            return RedirectToAction("Error", "Home");
        }

        
       

        [Authorize(Roles = "Administrator")]
        public ActionResult EditMovie(int id)
        {
            
            if (_movieLogic.GetMovieById(id) != null)
            {
                var movie = _movieLogic.GetMovieById(id);
                var viewMovie = _mapper.Map<MovieViewModel>(movie);
                return View(viewMovie);
            }
            return RedirectToAction("Error", "Home");
        }
        

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditMovie(MovieViewModel movie)
        {
            
            _movieLogic.EditMovie(movie.Id, movie.Name, movie.Description, movie.ReleaseDate, movie.LastScreeningDate,
                movie.MovieType, movie.MovieLenght, movie.ImageString, movie.BannerImageString);
            return RedirectToAction("DetailsMovie", new { id = movie.Id });
        }

        
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteMovie(int id)
        {
            
            if (_movieLogic.GetMovieById(id) != null)
            {
                var movie = _movieLogic.GetMovieById(id);
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
            
            _movieLogic.DeleteMovie(movie.Id);
            return RedirectToAction("ListMovies");
        }
    }
}