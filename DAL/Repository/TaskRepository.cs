using ASPNETCinema.Models;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class TaskRepository : ITaskContext
    {
        private readonly ITaskContext _context;

        public TaskRepository(ITaskContext context)
        {
            _context = context;
        }
        public List<TaskDto> GetTasks()
        {
            return _context.GetTasks();
        }

        public void AddTask(TaskModel task)
        {
            _context.AddTask(task);
        }

        public TaskDto GetTaskById(int id)
        {
            return _context.GetTaskById(id);
        }

        public void EditTask(TaskModel task)
        {
            _context.EditTask(task);
        }

        public void DeleteTask(int id)
        {
            _context.DeleteTask(id);
        }
    }
}
