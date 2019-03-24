using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class TaskRepository
    {
        private readonly ITaskContext _context;

        public TaskRepository(ITaskContext context)
        {
            _context = context;
        }

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        public IEnumerable<ITask> GetTasks()
        {
            return _context.GetTasks();
        }

        public void AddTask(ITask task)
        {
            _context.AddTask(task);
        }

        public ITask GetTaskById(int id)
        {
            return _context.GetTaskById(id);
        }

        public void EditTask(ITask task)
        {
            _context.EditTask(task);
        }

        public void DeleteTask(int id)
        {
            _context.DeleteTask(id);
        }
    }
}
