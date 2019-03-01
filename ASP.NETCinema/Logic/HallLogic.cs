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

        public List<HallModel> GetHalls()
        {
            return databaseHall.GetHalls();
        }

        public HallModel GetHall(int? id)
        {
            foreach (HallModel hall in databaseHall.GetHalls())
            {
                if (id == hall.Id && id != null)
                {
                    return hall;
                }
            }
            return null;
        }
    }
}
