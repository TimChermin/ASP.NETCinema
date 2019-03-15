using ASPNETCinema.DataLayer;
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

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete


        public HallLogic()
        {
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

        public List<HallModel> GetHalls()
        {
            return database.GetHalls();
        }
        
        public void AddHall(HallModel hall)
        {
            database.AddHall(hall);
        }

        //details

        public void EditHall(HallModel hall)
        {
            database.EditHall(hall);
        }

        public void DeleteHall(HallModel hall)
        {
            database.DeleteHall(hall.Id);
        }

        
    }
}
