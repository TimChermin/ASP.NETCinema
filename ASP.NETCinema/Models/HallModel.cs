using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class HallModel
    {
        public HallModel()
        {



        }


        public int Id { get; set; }
        public int Seats { get; set; }
        public int ScreenType { get; set; }
        public Decimal Price { get; set; }
        public List<ScreeningModel> Screenings { get; set; }




        
    }
}
