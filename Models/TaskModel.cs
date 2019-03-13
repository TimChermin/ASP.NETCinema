using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class TaskModel
    {
        public TaskModel(int id, int idScreening, int taskType)
        {
            Id = id;
            IdScreening = idScreening;
            TaskType = taskType;
        }


        public TaskModel()
        {
        }


        public int Id { get; set; }
        public int IdScreening { get; set; }
        public int TaskType { get; set; }
        public ScreeningModel Screening { get; set; }
        public List<EmployeeModel> Employees { get; set; }



    }
}
