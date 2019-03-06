using ASPNETCinema.Data;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Logic
{
    public class ScreeningLogic
    {
        DatabaseScreening database = new DatabaseScreening();
        public List<ScreeningModel> GetScreenings()
        {
            List<ScreeningModel> screenings = null;
            screenings = database.GetScreenings();
            return screenings;

        }
        



    }
}
