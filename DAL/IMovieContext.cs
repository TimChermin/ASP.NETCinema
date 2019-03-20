using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IMovieContext
    {
        //other things
        //List
        //Add
        //details
        //Edit
        //Delete
        IEnumerable<IMovie> GetMovies(string orderBy);
        void AddMovie(IMovie movie);
        IMovie GetMovieById(int id);
        void EditMovie(IMovie movie);
        void DeleteMovie(int id);
        
    }
}
