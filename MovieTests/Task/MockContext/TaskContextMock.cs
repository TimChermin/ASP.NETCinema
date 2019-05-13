using ASPNETCinema.Models;
using DAL;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Task.MockContext
{
    class TaskContextMock : ITaskContext
    {
        public void AddTask(TaskModel task)
        {

        }

        public void DeleteTask(int id)
        {

        }

        public void EditTask(TaskModel task)
        {

        }

        public TaskDto GetTaskById(int id)
        {
            return null;
        }

        public List<TaskDto> GetTasks()
        {
            return null;
        }

        public List<TaskDto> GetTasksAssigned()
        {
            return null;
        }

        public List<TaskDto> GetTasksNotAssigned()
        {
            return null;
        }
    }
}
