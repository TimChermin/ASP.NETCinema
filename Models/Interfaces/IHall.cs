using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IHall
    {
        int Id { get; set; }
        int Seats { get; set; }
        int SeatsTaken { get; set; }
        string ScreenType { get; set; }
        decimal Price { get; set; }
        List<IScreening> Screenings { get; set; }
    }
}
