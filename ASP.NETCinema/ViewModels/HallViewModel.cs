using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.ViewModels
{
    public class HallViewModel
    {
        public HallViewModel(decimal price, string screenType, int seats, int seatsTaken)
        {
            Price = price;
            ScreenType = screenType;
            Seats = seats;
            SeatsTaken = seatsTaken;
        }

        public HallViewModel(int id, decimal price, string screenType, int seats, int seatsTaken)
        {
            Id = id;
            Price = price;
            ScreenType = screenType;
            Seats = seats;
            SeatsTaken = seatsTaken;
        }

        public HallViewModel()
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
