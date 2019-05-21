
using ASPNETCinema.Models;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IMovieContext
    {
        List<MovieDto> GetMovies(string orderBy);
        void AddMovie(MovieModel movie);
        MovieDto GetMovieById(int id);
        void EditMovie(MovieModel movie);
        void DeleteMovie(int id);
        MovieDto GetMovieByName(string name);

        List<ScreeningDto> GetScreeningsForMovie(int idMovie);

    }
}
