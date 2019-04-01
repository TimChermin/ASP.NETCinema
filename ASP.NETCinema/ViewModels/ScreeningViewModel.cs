using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.ViewModels
{
    public class ScreeningViewModel
    {
        string todayString;
        public ScreeningViewModel()
        {
            DateTime today = new DateTime();
           todayString  = today.ToShortDateString();
        }
        public int Id { get; set; }


        [Required(ErrorMessage = "The Movie Id field is required.")]
        public int MovieId { get; set; }
        public IMovie Movie{ get; set; }


        [Required(ErrorMessage = "The Hall Id field is required.")]
        public int HallId { get; set; }
        public IHall Hall { get; set; }
        

        [Display(Name = "Screening date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "The Date field is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfScreening { get; set; }


        [Display(Name = "Screening Time")]
        [Required(ErrorMessage = "The Time field is required.")]
        [DataType(DataType.Time)]
        public TimeSpan TimeOfScreening { get; set; }

        public IEnumerable<IMovie> Movies { get; set; }

        public ITask Task { get; set; }



    }
}
