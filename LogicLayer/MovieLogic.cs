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
        DatabaseMovie database = new DatabaseMovie();

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

        public IMovie GetById(int id)
        {
            return Repository.GetById(id);
        }

        public IEnumerable<IMovie> GetMovies(string orderBy)
        {
            return Repository.GetMovies(orderBy);
        }

        public void AddMovie(MovieModel movie)
        {
            Repository.Add(movie);
        }

        

        public void EditMovie(MovieModel movie)
        {
            database.EditMovie(movie);
        }
        

        public void DeleteMovie(MovieModel movie)
        {
            Repository.Delete(movie);
        }


    }
}
