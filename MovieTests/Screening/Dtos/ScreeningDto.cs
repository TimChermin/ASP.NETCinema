using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Screening.Dtos
{
    class ScreeningDto : IScreening
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public IMovie Movie { get; set; }
        public int HallId { get; set; }
        public IHall Hall { get; set; }
        public DateTime DateOfScreening { get; set; }
        public TimeSpan TimeOfScreening { get; set; }
        public ITask Task { get; set; }
    }
}
