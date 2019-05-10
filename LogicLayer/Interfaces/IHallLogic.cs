using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Interfaces
{
    public interface IHallLogic
    {
        IEnumerable<IHall> GetHalls();
        void AddHall(int id, decimal price, string screenType, int seats, int seatsTaken);
        IHall GetHallById(int id);
        void EditHall(int id, decimal price, string screenType, int seats, int seatsTaken);
        void DeleteHall(int id);
    }
}
