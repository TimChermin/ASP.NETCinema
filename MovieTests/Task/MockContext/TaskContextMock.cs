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

        }

        public void DeleteTask(int id)
        {

        }

        public void EditTask(ITask task)
        {

        }

        public ITask GetTaskById(int id)
        {
            return null;
        }

        public IEnumerable<ITask> GetTasks()
        {
            return null;
        }

        public IEnumerable<ITask> GetTasksAssigned()
        {
            return null;
        }

        public IEnumerable<ITask> GetTasksNotAssigned()
        {
            return null;
        }
    }
}
