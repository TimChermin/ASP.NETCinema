
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.ViewModels
{
    public class TaskViewModel
    {
        public TaskViewModel()
        {
        }

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Screening Id")]
        [Range(1, Double.PositiveInfinity)]
        [Required(ErrorMessage = "The Id Screen field is required.")]
        public int IdScreening { get; set; }

        [Display(Name = "Task Type")]
        [Required(ErrorMessage = "The Task Type field is required.")]
        public string TaskType { get; set; }

        [Display(Name = "Task Lenght")]
        public TimeSpan TaskLenght { get; set; }
        public ScreeningViewModel Screening { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }

        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }

        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Screening date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "The Date field is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfScreening { get; set; }

        [Display(Name = "Screening Time")]
        [Required(ErrorMessage = "The Time field is required.")]
        [DataType(DataType.Time)]
        public TimeSpan TimeOfScreening { get; set; }

        [Display(Name = "Hall Id")]
        public int HallId { get; set; }

    }
}
