using System;
using System.Collections.Generic;
using System.Text;
using ASPNETCinema.Models;
using DAL.Dtos;

namespace ASPNETCinema.DAL
{
    public interface IHallContext
    {
        List<HallDto> GetHalls();
        void AddHall(HallModel hall);
        HallDto GetHallById(int id);
        void EditHall(HallModel hall);
        void DeleteHall(int id);


    }
}
