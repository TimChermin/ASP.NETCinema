using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IMovieContext
    {
        string GetName(int id);
        IEnumerable<IMovie> GetMovies();
    }
}
