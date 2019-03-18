using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class MovieRepository
    {
        private readonly IMovieContext _context;

        public MovieRepository(IMovieContext context)
        {
            _context = context;
        }

        public void GetName(IMovieContext person)
        {
            //_context.GetName();
        }

        public IEnumerable<IMovie> GetMovies()
        {
            return _context.GetMovies();
        }


    }
}
