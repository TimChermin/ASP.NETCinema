using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class HallRepository
    {
        private readonly IHallContext _context;

        public HallRepository(IHallContext context)
        {
            _context = context;
        }

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public IEnumerable<IHall> GetHalls()
        {
            return _context.GetHalls();
        }

        public void AddHall(IHall hall)
        {
            _context.AddHall(hall);
        }

        public IHall GetHallById(int id)
        {
            return _context.GetHallById(id);
        }

        public void EditHall(IHall hall)
        {
            _context.EditHall(hall);
        }

        public void DeleteHall(int id)
        {
            _context.DeleteHall(id);
        }
    }
}
