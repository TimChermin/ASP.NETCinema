using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Interfaces
{
    public interface IEmployeeLogic
    {
        List<EmployeeModel> GetEmployees();
        void AddEmployee(int id, string name);
        EmployeeModel GetEmployeeById(int id);
        void EditEmployee(int id, string name);
        void DeleteEmployee(int id);
    }
}
