using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class ScreeningModel
    {
        public ScreeningModel()
        {
        }


        public int Id { get; set; }
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public DateTime DateOfScreening { get; set; }
        public TimeSpan TimeOfScreening { get; set; }
        public MovieModel Movie { get; set; }
        public HallModel Hall { get; set; }
        public TaskModel Task { get; set; }

        public List<MovieModel> Movies { get; set; }
        public List<HallModel> Halls { get; set; }
    }
}
