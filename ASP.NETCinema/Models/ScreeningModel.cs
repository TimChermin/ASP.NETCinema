using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class ScreeningModel
    {
        public ScreeningModel(int id, int movieId, int hallId, DateTime timeAndDayOfScreening)
        {
            Id = id;
            MovieId = movieId;
            HallId = hallId;
            TimeAndDayOfScreening = timeAndDayOfScreening;
        }

        public ScreeningModel()
        {
        }


        public int Id { get; set; }


        public int MovieId { get; set; }
        public MovieModel Movie{ get; set; }
        public int HallId { get; set; }
        public HallModel Hall { get; set; }
        

        [Display(Name = "Screening date and Time")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyy HH:mm}")]
        [Required(ErrorMessage = "The Date field is required.")]
        [DataType(DataType.DateTime)]
        public DateTime TimeAndDayOfScreening { get; set; }

        public TaskModel Task { get; set; }



    }
}
