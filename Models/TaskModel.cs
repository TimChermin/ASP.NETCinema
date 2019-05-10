using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class TaskModel
    {
        public TaskModel()
        {
        }

        public int Id { get; set; }
        public int IdScreening { get; set; }
        public string TaskType { get; set; }
        public TimeSpan TaskLenght { get; set; }
        public ScreeningModel Screening { get; set; }
        public List<EmployeeModel> Employees { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfScreening { get; set; }
        public TimeSpan TimeOfScreening { get; set; }
        public int HallId { get; set; }
    }
}
