using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Models;
using System.Data.SqlClient;
using ASPNETCinema.DAL;
using DAL.Repository;
using DAL;
using Models.Interfaces;
using AutoMapper;

namespace ASPNETCinema.Logic
{
    public class MovieLogic : IMovieLogic
    {
        private MovieRepository Repository { get; }
        public DateTime ScreeningDate { get; set; }
        public string ScreeningFilter { get; set; }
        private IMapper _mapper;

        public MovieLogic(IMovieContext context, IMapper mapper)
        {
            Repository = new MovieRepository(context);
            _mapper = mapper;
        }
        
        //List
        //Add
        //details
        //Edit
        //Delete
        //other things

        public List<MovieModel> GetAndAddScreeningsToMovie(List<MovieModel> movies)
        {
            var moviesWithScreenings = new List<MovieModel>();
            foreach (var movie in movies)
            {
                movie.Screenings = _mapper.Map<List<ScreeningModel>>(Repository.GetScreeningsForMovie(movie.Id));
                moviesWithScreenings.Add(movie);
            }
            return moviesWithScreenings;
        }


        public MovieModel GetMovieById(int id)
        {
            var movies = new List<MovieModel>();
            if (Repository.GetMovieById(id) == null)
            {
                return null;
            }
            movies.Add(_mapper.Map<MovieModel>(Repository.GetMovieById(id)));
            ScreeningDate = new DateTime(1800, 2, 3);
            movies = GetAndAddScreeningsToMovie(movies);
            return movies[0];
        }

        public List<MovieModel> GetMovies(string orderBy)
        {
            var movies = new List<MovieModel>();
            movies = _mapper.Map<List<MovieModel>>(Repository.GetMovies(orderBy));
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

        public void AddMovie(MovieModel movie)
        {
            Repository.AddMovie(movie);
        }

        public void EditMovie(MovieModel movie)
        {
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
