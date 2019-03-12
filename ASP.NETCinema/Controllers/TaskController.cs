using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class TaskController : Controller
    {
        TaskLogic taskLogic = new TaskLogic();

        public ActionResult ListTasks()
        {
            return View(taskLogic.GetTasks());
        }
    }
}