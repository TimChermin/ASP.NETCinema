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
            movies = GetAndAddScreeningsToMovie(movies);
            return movies[0];
        }

        public IEnumerable<IMovie> GetMovies(string orderBy)
        {
            var movies = new List<IMovie>();
            movies = Repository.GetMovies(orderBy).ToList();
            movies = GetAndAddScreeningsToMovie(movies);
            movies = GetAndAddScreeningsToMovie(movies);
            return movies;
        }

        public void AddMovie(int id, string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght, string imageString)
        {
            var movie = new MovieModel
            { Id = id, Name = name, Description = description, ReleaseDate = releaseDate,
              LastScreeningDate = lastScreeningDate, MovieType = movieType,
              MovieLenght = movieLenght, ImageString = imageString
            };
            Repository.AddMovie(movie);
        }

        public void EditMovie(int id, string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght, string imageString)
        {
            var movie = new MovieModel
            { Id = id,Name = name,Description = description,ReleaseDate = releaseDate,
              LastScreeningDate = lastScreeningDate,MovieType = movieType,
              MovieLenght = movieLenght, ImageString = imageString
            };
            Repository.EditMovie(movie);
        }

        public void DeleteMovie(int id)
        {
            Repository.DeleteMovie(id);
        }


    }
}
