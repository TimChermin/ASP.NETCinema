using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace DAL
{
    public interface IHallContext
    {
        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        IEnumerable<IHall> GetHalls();
        void AddHall(IHall hall);
        IHall GetHallById(int id);
        void EditHall(IHall hall);
        void DeleteHall(int id);


    }
}
