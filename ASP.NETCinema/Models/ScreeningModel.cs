using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class ScreeningModel
    {
        public ScreeningModel(int id, int movieId, int hallId, DateTime dateOfScreening, TimeSpan timeOfScreening)
        {
            Id = id;
            MovieId = movieId;
            HallId = hallId;
            DateOfScreening = dateOfScreening;
            TimeOfScreening = timeOfScreening;
        }

        public ScreeningModel()
        {
        }


        public int Id { get; set; }


        public int MovieId { get; set; }
        public MovieModel Movie{ get; set; }
        public int HallId { get; set; }
        public HallModel Hall { get; set; }
        

        [Display(Name = "Screening date and Time: dd/mm/yyyy")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "The Date field is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfScreening { get; set; }

        [Display(Name = "Screening Time")]
        [Required(ErrorMessage = "The Time field is required.")]
        [DataType(DataType.Time)]
        public TimeSpan TimeOfScreening { get; set; }

        public TaskModel Task { get; set; }



    }
}
