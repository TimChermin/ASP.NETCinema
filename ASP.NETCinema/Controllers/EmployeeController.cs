using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCinema.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeLogic employeeLogic = new EmployeeLogic();

        public ActionResult ListEmployees()
        {
            return View(employeeLogic.GetEmployees());
        }
    }
}