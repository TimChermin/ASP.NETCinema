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

        //List
        //Add
        //details
        //Edit
        //Delete


        public List<MovieModel> GetMoviesAndOrderBy(string orderBy)
        {
            List<MovieModel> movies = null;
            if (orderBy != "MoviesToday")
            {
                //orderBy = orderBy.Replace(" ", "");
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

        public MovieModel GetMovie(int? id)
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

        public void EditMovie(MovieModel movie)
        {
            database.EditMovie(movie);
        }
        

        public void DeleteMovie(MovieModel movie)
        {
            database.DeleteMovie(movie.ID);
            /*foreach (MovieModel movie in database.GetMovies())
            {
                if (id == movie.ID)
                {
                    database.DeleteMovie(id);
                }
            }
            */
        }


    }
}
