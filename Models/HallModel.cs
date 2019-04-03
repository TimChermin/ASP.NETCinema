﻿using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class HallModel : IHall
    {
        public HallModel()
        {

        }


        public int Id { get; set; }
        public int Seats { get; set; }
        public int SeatsTaken { get; set; }
        public string ScreenType { get; set; }
        public decimal Price { get; set; }
        public List<IScreening> Screenings { get; set; }
    }
}
