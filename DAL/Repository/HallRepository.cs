
using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class HallRepository : IHallContext
    {
        private readonly IHallContext _context;

        public HallRepository(IHallContext context)
        {
            _context = context;
        }

        public List<HallDto> GetHalls()
        {
            return _context.GetHalls();
        }

        public void AddHall(HallModel hall)
        {
            _context.AddHall(hall);
        }

        public HallDto GetHallById(int id)
        {
            return _context.GetHallById(id);
        }

        public void EditHall(HallModel hall)
        {
            _context.EditHall(hall);
        }

        public void DeleteHall(int id)
        {
            _context.DeleteHall(id);
        }
    }
}
