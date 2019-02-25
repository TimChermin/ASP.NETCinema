using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ASPNETCinema.Logic
{
    public class MovieLogic
    {
        DatabaseMovie database = new DatabaseMovie();

        public List<MovieModel> GetMovies()
        {
            List<MovieModel> movies = database.GetMovies();
            return movies;
        }

        public void AddMovie(string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght)
        {
            database.AddMovie(name, description, releaseDate, lastScreeningDate, movieType, movieLenght);
        }

        public MovieModel EditMovie(int? id)
        {
            foreach (MovieModel movie in database.GetMovies())
            {
                if (id == movie.ID && id != null)
                {
                    return movie;
                }
            }
            return null;
        }

        public void EditMovie(int id, string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght)
        {
            database.EditMovie(id, name, description, releaseDate, lastScreeningDate, movieType, movieLenght);
        }


        public ActionResult DeleteMovie(int? id)
        {
            foreach (MovieModel movie in database.GetMovies())
            {
                if (id == movie.ID && id != null)
                {
                    return View(movie);
                }
            }
            return NotFound();
        }


    }
}
