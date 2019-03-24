using DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Task.MockContext
{
    class TaskContextMock : ITaskContext
    {
        public void AddTask(ITask task)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public void EditTask(ITask task)
        {
            throw new NotImplementedException();
        }

        public ITask GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITask> GetTasks()
        {
            throw new NotImplementedException();
        }
    }
}
