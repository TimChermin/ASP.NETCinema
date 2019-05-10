
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Dtos
{
    public class ScreeningDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public MovieDto Movie { get; set; }
        public int HallId { get; set; }
        public HallDto Hall { get; set; }
        public DateTime DateOfScreening { get; set; }
        public TimeSpan TimeOfScreening { get; set; }
        public TaskDto Task { get; set; }
        public List<MovieDto> Movies { get; set; }
        public List<HallDto> Halls { get; set; }
    }
}
