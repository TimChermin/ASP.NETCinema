using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.ViewModels
{
    public class HallViewModel
    {
        public HallViewModel()
        {

        }


        public int Id { get; set; }

        [Display(Name = "Seats")]
        [Range(0, 200)]
        [Required(ErrorMessage = "The Seats field is required.")]
        public int Seats { get; set; }

        [Display(Name = "Seats Taken")]
        [Range(0, 200)]
        [Required(ErrorMessage = "The Seats Taken field is required.")]
        public int SeatsTaken { get; set; }

        [Display(Name = "Screen Type")]
        [Required(ErrorMessage = "The Screen Type field is required.")]
        public string ScreenType { get; set; }

        [Display(Name = "Price")]
        [Range(typeof(decimal), "0,00", "99,00")]
        [Required(ErrorMessage = "The Price field is required.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public List<ScreeningModel> Screenings { get; set; }




        
    }
}
