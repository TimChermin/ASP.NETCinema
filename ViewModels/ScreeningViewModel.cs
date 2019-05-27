
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
           string todayString  = today.ToShortDateString();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "The Movie Id field is required.")]
        public int MovieId { get; set; }
        public MovieViewModel Movie { get; set; }


        [Required(ErrorMessage = "The Hall Id field is required.")]
        public int HallId { get; set; }
        public HallViewModel Hall { get; set; }
        

        [Display(Name = "Screening date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "The Date field is required.")]
        [DataType(DataType.Date)]
        [DateMustBeEqualOrGreaterThanCurrentDateValidation]
        public DateTime DateOfScreening { get; set; }


        [Display(Name = "Screening Time")]
        [Required(ErrorMessage = "The Time field is required.")]
        [DataType(DataType.Time)]
        public TimeSpan TimeOfScreening { get; set; }

        public List<MovieViewModel> Movies { get; set; }
        public List<HallViewModel> Halls { get; set; }

        public TaskViewModel Task { get; set; }



    }
    public sealed class DateMustBeEqualOrGreaterThanCurrentDateValidation : ValidationAttribute
    {

        private const string DefaultErrorMessage = "Date selected {0} must be on or after today";

        public DateMustBeEqualOrGreaterThanCurrentDateValidation()
            : base(DefaultErrorMessage)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(DefaultErrorMessage, name);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateEntered = (DateTime)value;
            if (dateEntered < DateTime.Today)
            {
                var message = FormatErrorMessage(dateEntered.ToShortDateString());
                return new ValidationResult(message);
            }
            return null;
        }
    }
}
