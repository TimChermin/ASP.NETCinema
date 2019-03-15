using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class HallModel
    {
        public HallModel(decimal price, string screenType, int seats, int seatsTaken)
        {
            Price = price;
            ScreenType = screenType;
            Seats = seats;
            SeatsTaken = seatsTaken;
        }

        public HallModel(int id, decimal price, string screenType, int seats, int seatsTaken)
        {
            Id = id;
            Price = price;
            ScreenType = screenType;
            Seats = seats;
            SeatsTaken = seatsTaken;
        }

        public HallModel()
        {

        }


        public int Id { get; set; }
        public int Seats { get; set; }
        public int SeatsTaken { get; set; }
        public string ScreenType { get; set; }
        public decimal Price { get; set; }
        public List<ScreeningModel> Screenings { get; set; }




        
    }
}
