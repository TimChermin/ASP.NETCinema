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

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public MovieModel GetMovie(int? id)
        {
            foreach (MovieModel movie in database.GetMovies())
            {
                if (id == movie.Id && id != null)
                {
                    return movie;
                }
            }
            return null;
        }

        public List<MovieModel> GetMoviesAndOrderBy(string orderBy)
        {
            List<MovieModel> movies = null;
            if (orderBy != "MoviesToday")
            {
                database.OrderBy = orderBy;
                movies = database.GetMovies();
            }
            else if (orderBy != null)
            {
                movies = database.GetMoviesToday();
            }
            
            return movies;
        }

        public void AddMovie(MovieModel movie)
        {
            database.AddMovie(movie);
        }

        

        public void EditMovie(MovieModel movie)
        {
            database.EditMovie(movie);
        }
        

        public void DeleteMovie(MovieModel movie)
        {
            database.DeleteMovie(movie.Id);
        }


    }
}
