using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using DAL;
using DAL.Repository;
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Logic
{
    public class TaskLogic : ITaskLogic
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

        public TaskModel GetTaskById(int id)
        {
            return Repository.GetTaskById(id);
        }

        public List<TaskModel> GetTasks()
        {
            var tasks = new List<TaskModel>();
            foreach (var task in Repository.GetTasks())
            {
                if (task.EmployeeName == "")
                {
                    task.EmployeeName = "Unassigned";
                }
                if (task.TaskType == "")
                {
                    task.TaskType = "No TaskType Assigned";
                }
                tasks.Add(task);
            }
            return tasks;
        }

        public void AddTask(int id, int idScreening, string taskType, TimeSpan taskLenght, IScreening screening, List<IEmployee> employees)
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

        public void EditTask(int id, int idScreening, string taskType, TimeSpan taskLenght, IScreening screening, List<IEmployee> employees)
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
