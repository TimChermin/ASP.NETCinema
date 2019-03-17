using System;
using System.Collections.Generic;
using System.Text;
using ASPNETCinema.Models;

namespace Interfaces.Outside_interfaces
{
    public class Employee : IEmployee
    {
        public string GetName(int id)
        {
            return "test " + id;
        }
        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            employees.Add(new EmployeeModel { Name = "Test", Id = 1 });
            return employees;
        }
    }
}
