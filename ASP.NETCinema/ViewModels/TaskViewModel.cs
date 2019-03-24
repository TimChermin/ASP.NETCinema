using ASPNETCinema.Models;
using Interfaces;
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


        public int Id { get; set; }

        [Range(1, Double.PositiveInfinity)]
        [Required(ErrorMessage = "The Id Screen field is required.")]
        public int IdScreening { get; set; }

        [Range(1, Double.PositiveInfinity)]
        [Required(ErrorMessage = "The Task Type field is required.")]
        public int TaskType { get; set; }
        
        public TimeSpan TaskLenght { get; set; }
        public IScreening Screening { get; set; }
        public List<IEmployee> Employees { get; set; }



    }
}
