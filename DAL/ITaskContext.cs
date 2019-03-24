using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ITaskContext
    {
        IEnumerable<ITask> GetTasks();
        void AddTask(ITask task);
        ITask GetTaskById(int id);
        void EditTask(ITask task);
        void DeleteTask(int id);

    }
}
