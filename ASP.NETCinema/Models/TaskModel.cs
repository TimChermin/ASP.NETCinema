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
        public int ScreeningId { get; set; }
        public int TaskType { get; set; }
        public ScreeningModel Screening { get; set; }
        public List<EmployeeModel> Employees { get; set; }



    }
}
