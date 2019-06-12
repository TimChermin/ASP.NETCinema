using ASPNETCinema.Models;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ITaskContext
    {
        List<TaskDto> GetTasks();
        void AddTask(TaskModel task);
        TaskDto GetTaskById(int id);
        void EditTask(TaskModel task);
        void DeleteTask(int id);

    }
}
