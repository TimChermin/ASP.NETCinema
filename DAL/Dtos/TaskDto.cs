using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public int IdScreening { get; set; }
        public string TaskType { get; set; }
        public TimeSpan TaskLenght { get; set; }
        public ScreeningDto Screening { get; set; }
        public List<EmployeeDto> Employees { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateOfScreening { get; set; }
        public TimeSpan TimeOfScreening { get; set; }
        public int HallId { get; set; }
    }
}
