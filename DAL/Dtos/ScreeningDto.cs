using Interfaces;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Dtos
{
    internal class ScreeningDto : IScreening
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
