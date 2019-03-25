﻿using ASPNETCinema.DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTests.Employee.Dtos;

namespace UnitTests.Employee.MockContext
{
    class EmployeeContextMock : IEmployeeContext
    {
        List<IEmployee> employees = new List<IEmployee>();
        List<IEmployee> employeesTemp = new List<IEmployee>();
        List<IEmployee> employeesTempDeleted = new List<IEmployee>();
        int delete = 0;

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete
        public IEnumerable<IEmployee> GetEmployees()
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

        public void AddEmployee(IEmployee employee)
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

        public void EditEmployee(IEmployee employee)
        {
            throw new NotImplementedException();
        }

        public IEmployee GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
