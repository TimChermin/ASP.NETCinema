using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ITask
    {
        int Id { get; set; }
        int IdScreening { get; set; }
        int TaskType { get; set; }
        TimeSpan TaskLenght { get; set; }
        IScreening Screening { get; set; }
        List<IEmployee> Employees { get; set; }
    }
}
