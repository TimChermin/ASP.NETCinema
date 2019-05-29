using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeDto = DAL.Dtos.EmployeeDto;

namespace UnitTests.Employee.MockContext
{
    class EmployeeContextMock : IEmployeeContext
    {
        List<EmployeeDto> employees = new List<EmployeeDto>();
        List<EmployeeDto> employeesTemp = new List<EmployeeDto>();
        List<EmployeeDto> employeesTempDeleted = new List<EmployeeDto>();
        int delete = 0;
        int edit = 0;
        string editName = "";

        public List<EmployeeDto> GetEmployees()
        {
            employees.Clear();
            SetEmployees();
            AddedEmployees();
            return employees;
        }

        public void SetEmployees()
        {
            employees.Add(new EmployeeDto
            {
                Id = 1,
                Name = "AFilm"
            });

            employees.Add(new EmployeeDto
            {
                Id = 5,
                Name = "CFilms"
            });

            employees.Add(new EmployeeDto
            {
                Id = 2,
                Name = "BFilmpie"
            });

            employees.Add(new EmployeeDto
            {
                Id = 3,
                Name = "DFilm"
            });

            WasSomethingDeleted();
            WasSomethingEdited();
        }

        public void WasSomethingDeleted()
        {
            if (delete != 0)
            {
                foreach (var employee in employees)
                {
                    if (employee.Id == delete)
                    {
                        employees.Remove(employee);
                        break;
                    }
                }
            }
        }

        public void WasSomethingEdited()
        {
            if (edit != 0)
            {
                foreach (var employee in employees)
                {
                    if (employee.Id == edit && editName != "")
                    {
                        employees[0].Name = editName;
                        break;
                    }
                }
            }
        }

        public void AddEmployee(EmployeeModel employee)
        {
            employeesTemp.Add(new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
            });
        }

        private void AddedEmployees()
        {
            foreach (var employee in employeesTemp)
            {
                employees.Add(employee);
            }
        }

        public void DeleteEmployee(int id)
        {
            delete = id;
        }

        public void EditEmployee(EmployeeModel employee)
        {
            edit = employee.Id;
            editName = employee.Name;
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            foreach (var employee in employees)
            {
                if (employee.Id == id)
                {
                    return employee;
                }
            }
            foreach (var employee in employeesTemp)
            {
                if (employee.Id == id)
                {
                    return employee;
                }
            }
            return null;
        }
    }
}
