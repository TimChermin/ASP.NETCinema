using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Interfaces
{
    public interface ITaskLogic
    {
        IEnumerable<ITask> GetTasks();
        void AddTask(int id, int idScreening, string taskType, TimeSpan taskLenght, IScreening screening, List<IEmployee> employees);
        ITask GetTaskById(int id);
        void EditTask(int id, int idScreening, string taskType, TimeSpan taskLenght, IScreening screening, List<IEmployee> employees);
        void DeleteTask(int id);
    }
}
