using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Interfaces
{
    public interface IHallLogic
    {
        List<HallModel> GetHalls();
        void AddHall(HallModel hall);
        HallModel GetHallById(int id);
        void EditHall(HallModel hall);
        void DeleteHall(int id);
    }
}
