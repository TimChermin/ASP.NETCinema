using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IMovieContext
    {
        IEnumerable<IMovie> GetMovies();
        void Add(IMovie movie);
        void Delete(IMovie movie);
        IMovie GetById(int id);
    }
}
