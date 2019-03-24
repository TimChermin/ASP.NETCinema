using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class TaskModel : ITask
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
        public TimeSpan TaskLenght { get; set; }
        public IScreening Screening { get; set; }
        public List<IEmployee> Employees { get; set; }



    }
}
