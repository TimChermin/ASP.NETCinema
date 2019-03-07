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
        DatabaseHall database = new DatabaseHall();

        public HallLogic()
        {


        }


        public void AddHall(HallModel hall)
        {
            database.AddHall(hall);
        }

        public List<HallModel> GetHalls()
        {
            return database.GetHalls();
        }

        public HallModel GetHall(int? id)
        {
            foreach (HallModel hall in database.GetHalls())
            {
                if (id == hall.Id && id != null)
                {
                    return hall;
                }
            }
            return null;
        }

        public void DeleteHall(int id)
        {
            foreach (HallModel hall in database.GetHalls())
            {
                if (id == hall.Id)
                {
                    database.DeleteHall(id);
                }
            }
        }
    }
}
