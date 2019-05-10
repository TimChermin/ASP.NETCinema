using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public TaskLogic(ITaskContext context, IMapper mapper)
        {
            Repository = new TaskRepository(context);
            _mapper = mapper;
        }
        //other things
        //Listt
        //Add
        //details
        //Edit
        //Delete

        public TaskModel GetTaskById(int id)
        {
            return _mapper.Map<TaskModel>(Repository.GetTaskById(id));
        }

        public List<TaskModel> GetTasks()
        {
            var tasks = new List<TaskModel>();
            foreach (var task in Repository.GetTasks())
            {
                var taskModel = _mapper.Map<TaskModel>(task);
                if (taskModel.EmployeeName == "")
                {
                    taskModel.EmployeeName = "Unassigned";
                }
                if (taskModel.TaskType == "")
                {
                    taskModel.TaskType = "No TaskType Assigned";
                }
                tasks.Add(taskModel);
            }
            return tasks;
        }

        public void AddTask(TaskModel task)
        {
            Repository.AddTask(task);
        }

        public void EditTask(TaskModel task)
        {
            Repository.EditTask(task);
        }

        public void DeleteTask(int id)
        {
            Repository.DeleteTask(id);
        }
    }
}
