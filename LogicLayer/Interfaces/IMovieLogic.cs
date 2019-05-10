using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IMovieLogic
    {
        string ScreeningFilter { get; set; }

        bool DoesThisMovieExist(string name);
        IEnumerable<IMovie> GetMovies(string orderBy);
        void AddMovie(int id, string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght, string imageString, string bannerImageString);
        IMovie GetMovieById(int id);
        void EditMovie(int id, string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght, string imageString, string bannerImageString);
        void DeleteMovie(int id);
        
    }
}
