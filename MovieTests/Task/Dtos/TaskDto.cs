using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Task.Dtos
{
    class TaskDto : ITask
    {
        public int Id { get; set; }
        public int IdScreening { get; set; }
        public int TaskType { get; set; }
        public TimeSpan TaskLenght { get; set; }
        public IScreening Screening { get; set; }
        public List<IEmployee> Employees { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfScreening { get; set; }
        public TimeSpan TimeOfScreening { get; set; }
        public int HallId { get; set; }
        string ITask.TaskType { get; set; }
    }
}
