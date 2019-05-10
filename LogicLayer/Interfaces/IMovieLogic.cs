using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IMovieLogic
    {
        string ScreeningFilter { get; set; }

        bool DoesThisMovieExist(string name);
        List<MovieModel> GetMovies(string orderBy);
        void AddMovie(MovieModel movie);
        MovieModel GetMovieById(int id);
        void EditMovie(MovieModel movie);
        void DeleteMovie(int id);
        
    }
}
