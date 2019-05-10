
using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Interfaces
{
    public interface ITaskLogic
    {
        List<TaskModel> GetTasks();
        void AddTask(TaskModel task);
        TaskModel GetTaskById(int id);
        void EditTask(TaskModel task);
        void DeleteTask(int id);
    }
}
