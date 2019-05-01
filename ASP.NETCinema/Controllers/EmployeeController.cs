using System.Collections.Generic;
using ASPNETCinema.Logic;
using ASPNETCinema.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASPNETCinema.DAL;
using AutoMapper;
using ASPNETCinema.Models;

namespace ASPNETCinema.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeContext _employee;
        private readonly IMapper _mapper;

        //added scoped stuff in startup 
        public EmployeeController(IEmployeeContext employee, IMapper mapper)
        {
            _employee = employee;
            _mapper = mapper;
        }
        

        //List
        //Add
        //details
        //Edit
        //Delete

        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult ListEmployees()
        {
            var employeeLogic = new EmployeeLogic(_employee);
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            foreach (var employee in employeeLogic.GetEmployees())
            {
                employees.Add(_mapper.Map<EmployeeViewModel>(employee));
            }
            return View(employees);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddEmployee(EmployeeViewModel employee)
        {
            var employeeLogic = new EmployeeLogic(_employee);
            if (ModelState.IsValid)
            {
                employeeLogic.AddEmployee(employee.Id, employee.Name);
                return RedirectToAction("ListMovies");
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult DetailsEmployee(int id)
        {
            var employeeLogic = new EmployeeLogic(_employee);
            if (employeeLogic.GetEmployeeById(id) != null)
            {
                var employee = employeeLogic.GetEmployeeById(id);
                var viewEmployee = _mapper.Map<EmployeeViewModel>(employee);
                return View(viewEmployee);
            }
            return RedirectToAction("Error", "Home");
        }


        [Authorize(Roles = "Administrator")]
        public ActionResult EditEmployee(int id)
        {
            var employeeLogic = new EmployeeLogic(_employee);
            if (employeeLogic.GetEmployeeById(id) != null)
            {
                var employee = employeeLogic.GetEmployeeById(id);
                var viewEmployee = _mapper.Map<EmployeeViewModel>(employee);
                return View(viewEmployee);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditEmployee(EmployeeViewModel employee)
        {
            var employeeLogic = new EmployeeLogic(_employee);
            if (ModelState.IsValid)
            {
                employeeLogic.EditEmployee(employee.Id, employee.Name);
                return RedirectToAction("ListEmployees");
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteEmployee(int id)
        {
            var employeeLogic = new EmployeeLogic(_employee);
            if (employeeLogic.GetEmployeeById(id) != null)
            {
                var employee = employeeLogic.GetEmployeeById(id);
                var viewEmployee = _mapper.Map<EmployeeViewModel>(employee);
                return View(viewEmployee);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteEmployee(EmployeeViewModel employee)
        {
            var employeeLogic = new EmployeeLogic(_employee);
            employeeLogic.DeleteEmployee(employee.Id);
            return RedirectToAction("ListEmployees");
        }

    }
}