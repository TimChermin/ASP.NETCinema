using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Interfaces
{
    public interface IEmployeeLogic
    {
        List<EmployeeModel> GetEmployees();
        void AddEmployee(EmployeeModel employee);
        EmployeeModel GetEmployeeById(int id);
        void EditEmployee(EmployeeModel employee);
        void DeleteEmployee(int id);
    }
}
