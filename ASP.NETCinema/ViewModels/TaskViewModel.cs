using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.ViewModels
{
    public class TaskViewModel
    {
        public TaskViewModel(int id, int idScreening, int taskType)
        {
            Id = id;
            IdScreening = idScreening;
            TaskType = taskType;
        }


        public TaskViewModel()
        {
        }


        public int Id { get; set; }
        public int IdScreening { get; set; }
        public int TaskType { get; set; }
        public ScreeningModel Screening { get; set; }
        public List<EmployeeModel> Employees { get; set; }



    }
}
