using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IScreening
    {
        int Id { get; set; }
        int MovieId { get; set; }
        IMovie Movie { get; set; }
        int HallId { get; set; }
        IHall Hall { get; set; }
        DateTime DateOfScreening { get; set; }
        TimeSpan TimeOfScreening { get; set; }
        ITask Task { get; set; }
        IEnumerable<IMovie> Movies { get; set; }
        IEnumerable<IHall> Halls { get; set; }
    }
}
