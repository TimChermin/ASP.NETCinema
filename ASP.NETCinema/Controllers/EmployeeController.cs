using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ASPNETCinema.DAL;
using Interfaces;

namespace ASPNETCinema.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeContext _employee;

        //added scoped stuff in startup 
        public EmployeeController(IEmployeeContext employee)
        {
            _employee = employee;
        }
        

        public ActionResult ListEmployees()
        {
            var employeeLogic = new EmployeeLogic(_employee);
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            foreach (var emp in employeeLogic.GetEmployees())
            {
                employees.Add(new EmployeeViewModel
                {
                    Id = emp.Id,
                    Name = emp.Name
                });
            }
            //List<EmployeeModel> employees = employee.GetEmployees();
            return View(employees);
            //test


            //return View(employeeLogic.GetEmployees());
        }

        public ActionResult DetailsEmployee()
        {
            ViewBag.employeeName = _employee.GetName(1);
            return View();
        }

    }
}