using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using AutoMapper;
using DAL;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskLogic _taskLogic;
        private readonly IMapper _mapper;

        public TaskController(ITaskLogic taskLogic, IMapper mapper)
        {
            _mapper = mapper;
            _taskLogic = taskLogic;
        }

        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult ListTasks()
        {
            
            List<TaskViewModel> tasks = new List<TaskViewModel>();
            foreach (var task in _taskLogic.GetTasks())
            {
                tasks.Add(_mapper.Map<TaskViewModel>(task));
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
            
            if (ModelState.IsValid)
            {
                _taskLogic.AddTask(_mapper.Map<TaskModel>(task));
                return RedirectToAction("ListTasks");
            }
            return View();
        }

        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult DetailsTask(int id)
        {
            
            if (_taskLogic.GetTaskById(id) != null)
            {
                var task = _taskLogic.GetTaskById(id);
                var viewTask = _mapper.Map<TaskViewModel>(task);
                return View(viewTask);
            }
            return RedirectToAction("Error", "Home");
        }


        [Authorize(Roles = "Administrator")]
        public ActionResult EditTask(int id)
        {
            
            if (_taskLogic.GetTaskById(id) != null)
            {
                var task = _taskLogic.GetTaskById(id);
                var viewTask = _mapper.Map<TaskViewModel>(task);
                return View(viewTask);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditTask(TaskViewModel task)
        {
            
            if (ModelState.IsValid)
            {
                _taskLogic.EditTask(_mapper.Map<TaskModel>(task));
                return RedirectToAction("ListTasks");
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteTask(int id)
        {
            
            if (_taskLogic.GetTaskById(id) != null)
            {
                var task = _taskLogic.GetTaskById(id);
                var viewTask = _mapper.Map<TaskViewModel>(task);
                return View(viewTask);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteTask(TaskViewModel task)
        {
            
            if (ModelState.IsValid)
            {
                _taskLogic.DeleteTask(task.Id);
                return RedirectToAction("ListTasks");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}