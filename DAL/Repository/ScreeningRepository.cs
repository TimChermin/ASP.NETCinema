using Interfaces;
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

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public IEnumerable<IScreening> GetScreenings()
        {
            return _context.GetScreenings();
        }

        public void AddScreening(IScreening screening)
        {
            _context.AddScreening(screening);
        }

        public IScreening GetScreeningById(int id)
        {
            return _context.GetScreeningById(id);
        }

        public void EditScreening(IScreening screening)
        {
            _context.EditScreening(screening);
        }

        public void DeleteScreening(int id)
        {
            _context.DeleteScreening(id);
        }

        public IMovie GetMovie(int idMovie)
        {
            return _context.GetMovie(idMovie);
        }

        public IHall GetHall(int idHall)
        {
            return _context.GetHall(idHall);
        }
    }
}
