using ASPNETCinema.Models;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class ScreeningRepository
    {
        private readonly IScreeningContext _context;

        public ScreeningRepository(IScreeningContext context)
        {
            _context = context;
        }

        public List<ScreeningDto> GetScreenings()
        {
            return _context.GetScreenings();
        }

        public void AddScreening(ScreeningModel screening)
        {
            _context.AddScreening(screening);
        }

        public ScreeningDto GetScreeningById(int id)
        {
            return _context.GetScreeningById(id);
        }

        public void EditScreening(ScreeningModel screening)
        {
            _context.EditScreening(screening);
        }

        public void DeleteScreening(int id)
        {
            _context.DeleteScreening(id);
        }

        public MovieDto GetMovie(int idMovie)
        {
            return _context.GetMovie(idMovie);
        }

        public HallDto GetHall(int idHall)
        {
            return _context.GetHall(idHall);
        }

        public List<MovieDto> GetMovies()
        {
            return _context.GetMovies();
        }
        public List<HallDto> GetHalls()
        {
            return _context.GetHalls();
        }
    }
}
