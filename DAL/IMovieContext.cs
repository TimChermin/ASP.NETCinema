using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IMovieContext
    {
        IEnumerable<IMovie> GetMovies(string orderBy);
        void AddMovie(IMovie movie);
        void DeleteMovie(IMovie movie);
        IMovie GetMovieById(int id);
    }
}
