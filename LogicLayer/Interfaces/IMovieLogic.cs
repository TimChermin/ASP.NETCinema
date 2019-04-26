using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IMovieLogic
    {
        IEnumerable<IMovie> GetMovies(string orderBy);
        void AddMovie(IMovie movie);
        IMovie GetMovieById(int id);
        void EditMovie(IMovie movie);
        void DeleteMovie(int id);

        IEnumerable<IScreening> GetScreeningsForMovie(int idMovie);
    }
}
