using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using Interfaces;
using Interfaces.Outside_interfaces;
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

        public ActionResult DetailsEmployee()
        {
            IEmployee employee = new Employee();
            ViewBag.employeeName = employee.GetName(1);
            return View();
        }

    }
}