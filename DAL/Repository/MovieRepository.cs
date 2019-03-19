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

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public void GetName(IMovieContext person)
        {
            //_context.GetName();
        }

        public IEnumerable<IMovie> GetMovies(string orderBy)
        {
            return _context.GetMovies(orderBy);
        }

        public void Add(IMovie movie)
        {
            _context.Add(movie);
        }

        public void Delete(IMovie movie)
        {
            _context.Add(movie);
        }

        public IMovie GetById(int id)
        {
            return _context.GetById(id);
        }


    }
}
