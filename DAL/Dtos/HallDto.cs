using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Dtos
{
    public class HallDto
    {
        public int Id { get ; set ; }
        public int Seats { get ; set ; }
        public int SeatsTaken { get ; set ; }
        public string ScreenType { get ; set ; }
        public decimal Price { get ; set ; }
        public List<ScreeningDto> Screenings { get; set; }
    }
}
