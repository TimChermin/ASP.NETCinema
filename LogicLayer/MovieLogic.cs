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

        public MovieModel GetMovie(int? id)
        {
            /*foreach (MovieModel movie in database.GetMovies())
            {
                if (id == movie.Id && id != null)
                {
                    return movie;
                }
            }
            */
            return null;
        }

        public IEnumerable<IMovie> GetMovies(string orderBy)
        {
            if (orderBy != "MoviesToday")
            {
                database.OrderBy = orderBy;
            }
            else if (orderBy != null)
            {
                database.OrderBy = "MoviesToday";
            }
            return Repository.GetMovies();
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
