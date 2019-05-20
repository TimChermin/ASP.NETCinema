
using ASPNETCinema.Models;
using DAL.Dtos;
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

        public List<ScreeningDto> GetScreeningsForMovie(int idMovie)
        {
            return _context.GetScreeningsForMovie(idMovie);
        }

        public List<MovieDto> GetMovies(string orderBy)
        {
            return _context.GetMovies(orderBy);
        }

        public void AddMovie(MovieModel movie)
        {
            _context.AddMovie(movie);
        }

        public MovieDto GetMovieById(int id)
        {
            return _context.GetMovieById(id);
        }

        public void EditMovie(MovieModel movie)
        {
            _context.EditMovie(movie);
        }

        public void DeleteMovie(int id)
        {
            _context.DeleteMovie(id);
        }
    }
}
