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
        

        public MovieModel GetDetailsMovie(int? id)
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



        public void AddMovie(string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght, string imageString)
        {
            database.AddMovie(name, description, releaseDate, lastScreeningDate, movieType, movieLenght, imageString);
        }

        public MovieModel GetToEditMovie(int? id)
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

        public void EditMovie(int id, string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght, string imageString)
        {
            database.EditMovie(id, name, description, releaseDate, lastScreeningDate, movieType, movieLenght, imageString);
        }


        public MovieModel GetToDeleteMovie(int? id)
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

        public void DeleteMovie(int id)
        {
            foreach (MovieModel movie in database.GetMovies())
            {
                if (id == movie.ID)
                {
                    database.DeleteMovie(id);
                }
            }
        }


    }
}
