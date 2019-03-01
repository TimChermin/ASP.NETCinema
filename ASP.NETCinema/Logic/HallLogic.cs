using ASPNETCinema.Data;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Logic
{
    public class HallLogic
    {
        DatabaseHall databaseHall = new DatabaseHall();
        public HallLogic()
        {


        }


        public void AddHall(HallModel hall)
        {
            databaseHall.AddHall(hall);
        }


    }
}
