using System.Collections.Generic;
using ASPNETCinema.Logic;
using ASPNETCinema.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ASPNETCinema.DAL;
using AutoMapper;
using ASPNETCinema.Models;
using LogicLayer.Interfaces;

namespace ASPNETCinema.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeLogic _employeeLogic;
        private readonly IMapper _mapper;
        
        public EmployeeController(IEmployeeLogic employeeLogic, IMapper mapper)
        {
            _employeeLogic = employeeLogic;
            _mapper = mapper;
        }

        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult ListEmployees()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
            foreach (var employee in _employeeLogic.GetEmployees())
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
            if (ModelState.IsValid)
            {
                _employeeLogic.AddEmployee(_mapper.Map<EmployeeModel>(employee));
                return RedirectToAction("ListMovies");
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Administrator, Employee")]
        public ActionResult DetailsEmployee(int id)
        {
            if (_employeeLogic.GetEmployeeById(id) != null)
            {
                var employee = _employeeLogic.GetEmployeeById(id);
                var viewEmployee = _mapper.Map<EmployeeViewModel>(employee);
                return View(viewEmployee);
            }
            return RedirectToAction("Error", "Home");
        }


        [Authorize(Roles = "Administrator")]
        public ActionResult EditEmployee(int id)
        {
            if (_employeeLogic.GetEmployeeById(id) != null)
            {
                var employee = _employeeLogic.GetEmployeeById(id);
                var viewEmployee = _mapper.Map<EmployeeViewModel>(employee);
                return View(viewEmployee);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditEmployee(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                _employeeLogic.AddEmployee(_mapper.Map<EmployeeModel>(employee));
                return RedirectToAction("ListEmployees");
            }
            return RedirectToAction("Error", "Home");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteEmployee(int id)
        {
            if (_employeeLogic.GetEmployeeById(id) != null)
            {
                var employee = _employeeLogic.GetEmployeeById(id);
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
            _employeeLogic.DeleteEmployee(employee.Id);
            return RedirectToAction("ListEmployees");
        }

    }
}