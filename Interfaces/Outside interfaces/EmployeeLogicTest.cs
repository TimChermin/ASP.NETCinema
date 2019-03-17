using System;
using System.Collections.Generic;
using System.Text;
using ASPNETCinema.DataLayer;
using ASPNETCinema.Models;

namespace Interfaces.Outside_interfaces
{
    public class Employee : IEmployee
    {

        DatabaseEmployee database = new DatabaseEmployee();
        public string GetName(int id)
        {
            return "test " + id;
        }
        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            foreach (var employee in database.GetEmployees())
            {
                employees.Add(new EmployeeModel { Name = employee.Name, Id = employee.Id });
            }
            
            return employees;
        }
    }
}
