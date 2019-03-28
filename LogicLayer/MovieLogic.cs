using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using System.Data.SqlClient;
using ASPNETCinema.DAL;
using DAL.Repository;
using DAL;
using Interfaces;

namespace ASPNETCinema.Logic
{
    public class MovieLogic
    {
        private MovieRepository Repository { get; }
        public DateTime ScreeningDate { get; set; }
        public string ScreeningFilter { get; set; }

        public MovieLogic(IMovieContext context)
        {
            Repository = new MovieRepository(context);
        }


        //List
        //Add
        //details
        //Edit
        //Delete
        //other things

        public List<IMovie> GetAndAddScreeningsToMovie(List<IMovie> movies)
        {
            var moviesWithScreenings = new List<IMovie>();
            foreach (var movie in movies)
            {
                movie.Screenings = Repository.GetScreeningsForMovie(movie.Id);
                moviesWithScreenings.Add(movie);
            }
            return moviesWithScreenings;
        }


        public IMovie GetMovieById(int id)
        {
            var movies = new List<IMovie>();
            if (Repository.GetMovieById(id) == null)
            {
                return null;
            }
            movies.Add(Repository.GetMovieById(id));
            ScreeningDate = new DateTime(1800, 2, 3);
            movies = GetAndAddScreeningsToMovie(movies);
            return movies[0];
        }

        public IEnumerable<IMovie> GetMovies(string orderBy)
        {
            var movies = new List<IMovie>();
            movies = Repository.GetMovies(orderBy).ToList();
            if (ScreeningFilter == "" || ScreeningFilter == null)
            {
                ScreeningDate = DateTime.Today;
            }
            else
            {
                try
                {
                    ScreeningDate = DateTime.Parse(ScreeningFilter);
                }
                catch
                {
                    ScreeningDate = DateTime.Today;
                }
            }
            

            if (ScreeningDate < DateTime.Today.AddYears(-100) || ScreeningDate == null || ScreeningDate >= DateTime.Today.AddYears(2000))
            {
                ScreeningDate = DateTime.Today;
            }
            movies = GetAndAddScreeningsToMovie(movies);
            return movies;
        }

        public void AddMovie(int id, string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght, string imageString, string bannerImageString)
        {
            var _movie = new MovieModel
            { Id = id, Name = name, Description = description, ReleaseDate = releaseDate,
              LastScreeningDate = lastScreeningDate, MovieType = movieType,
              MovieLenght = movieLenght, ImageString = imageString,
                BannerImageString = bannerImageString
            };
            Repository.AddMovie(_movie);
        }

        public void EditMovie(int id, string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght, string imageString, string bannerImageString)
        {
            var movie = new MovieModel
            { Id = id,Name = name,Description = description,ReleaseDate = releaseDate,
              LastScreeningDate = lastScreeningDate,MovieType = movieType,
              MovieLenght = movieLenght, ImageString = imageString, BannerImageString = bannerImageString
            };
            Repository.EditMovie(movie);
        }

        public void DeleteMovie(int id)
        {
            Repository.DeleteMovie(id);
        }

        public bool DoesThisMovieExist(string name)
        {
            foreach (var movie in GetMovies("Name"))
            {
                if (movie.Name == name)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
