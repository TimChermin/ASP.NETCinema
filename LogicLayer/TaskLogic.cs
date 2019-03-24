using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using DAL;
using DAL.Repository;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Logic
{
    public class TaskLogic
    {
        private TaskRepository Repository { get; }

        public TaskLogic(ITaskContext context)
        {
            Repository = new TaskRepository(context);
        }
        //other things
        //Listt
        //Add
        //details
        //Edit
        //Delete

        public ITask GetTaskById(int id)
        {
            return Repository.GetTaskById(id);
        }

        public IEnumerable<ITask> GetTasks()
        {
            return Repository.GetTasks();
        }

        public void AddTask(int id, int idScreening, int taskType, TimeSpan taskLenght, IScreening screening, List<IEmployee> employees)
        {
            var task = new TaskModel
            {
                Id = id,
                IdScreening = idScreening,
                TaskType = taskType,
                TaskLenght = taskLenght,
                Screening = screening,
                Employees = employees
            };
            Repository.AddTask(task);
        }

        public void EditTask(int id, int idScreening, int taskType, TimeSpan taskLenght, IScreening screening, List<IEmployee> employees)
        {
            var task = new TaskModel
            {
                Id = id,
                IdScreening = idScreening,
                TaskType = taskType,
                TaskLenght = taskLenght,
                Screening = screening,
                Employees = employees
            };
            Repository.EditTask(task);
        }

        public void DeleteTask(int id)
        {
            Repository.DeleteTask(id);
        }
    }
}
