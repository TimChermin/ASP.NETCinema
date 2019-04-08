using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using ASPNETCinema.ViewModels;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskContext _task;
        
        public TaskController(ITaskContext task)
        {
            _task = task;
        }

        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult ListTasks()
        {
            var taskLogic = new TaskLogic(_task);
            List<TaskViewModel> tasks = new List<TaskViewModel>();
            foreach (var task in taskLogic.GetTasks())
            {
                tasks.Add(new TaskViewModel
                {
                    Id = task.Id,
                    EmployeeId = task.EmployeeId,
                    EmployeeName = task.EmployeeName,
                    DateOfScreening = task.DateOfScreening,
                    TimeOfScreening = task.TimeOfScreening,
                    TaskType = task.TaskType,
                    TaskLenght = task.TaskLenght,
                    Screening = task.Screening,
                    Employees = task.Employees
                });
            }
            return View(tasks);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddTask(TaskViewModel task)
        {
            var taskLogic = new TaskLogic(_task);
            if (ModelState.IsValid)
            {
                taskLogic.AddTask(task.Id, task.IdScreening, task.TaskType, task.TaskLenght, task.Screening, task.Employees);
                return RedirectToAction("ListTasks");
            }
            return View();
        }

        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult DetailsTask(int id)
        {
            var taskLogic = new TaskLogic(_task);
            if (taskLogic.GetTaskById(id) != null)
            {
                var task = taskLogic.GetTaskById(id);
                var viewTask = new TaskViewModel
                {
                    Id = task.Id,
                    IdScreening = task.IdScreening,
                    TaskType = task.TaskType,
                    TaskLenght = task.TaskLenght,
                    Screening = task.Screening,
                    Employees = task.Employees
                };
                return View(viewTask);
            }
            return RedirectToAction("Error", "Home");
        }


        [Authorize(Roles = "Administrator")]
        public ActionResult EditTask(int id)
        {
            var taskLogic = new TaskLogic(_task);
            if (taskLogic.GetTaskById(id) != null)
            {
                var task = taskLogic.GetTaskById(id);
                var viewTask = new TaskViewModel
                {
                    Id = task.Id,
                    IdScreening = task.IdScreening,
                    TaskType = task.TaskType,
                    TaskLenght = task.TaskLenght,
                    Screening = task.Screening,
                    Employees = task.Employees
                };
                return View(viewTask);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditTask(TaskViewModel task)
        {
            var taskLogic = new TaskLogic(_task);
            if (ModelState.IsValid)
            {
                taskLogic.EditTask(task.Id, task.IdScreening, task.TaskType, task.TaskLenght, task.Screening, task.Employees);
                return RedirectToAction("ListTasks");
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteTask(int id)
        {
            var taskLogic = new TaskLogic(_task);
            if (taskLogic.GetTaskById(id) != null)
            {
                var task = taskLogic.GetTaskById(id);
                var viewTask = new TaskViewModel
                {
                    Id = task.Id,
                    IdScreening = task.IdScreening,
                    TaskType = task.TaskType,
                    TaskLenght = task.TaskLenght,
                    Screening = task.Screening,
                    Employees = task.Employees
                };
                return View(viewTask);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteTask(TaskViewModel task)
        {
            var taskLogic = new TaskLogic(_task);
            if (ModelState.IsValid)
            {
                taskLogic.DeleteTask(task.Id);
                return RedirectToAction("ListTasks");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}