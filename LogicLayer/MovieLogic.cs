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

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public IMovie GetMovieById(int id)
        {
            return Repository.GetMovieById(id);
        }

        public IEnumerable<IMovie> GetMovies(string orderBy)
        {
            return Repository.GetMovies(orderBy);
        }

        public void AddMovie(int id, string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght, string imageString)
        {
            var movie = new MovieModel
            { Id = id,Name = name,Description = description,ReleaseDate = releaseDate,
              LastScreeningDate = lastScreeningDate,MovieType = movieType,
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
