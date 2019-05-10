using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.Interfaces
{
    public interface IEmployeeLogic
    {
        IEnumerable<IEmployee> GetEmployees();
        void AddEmployee(int id, string name);
        IEmployee GetEmployeeById(int id);
        void EditEmployee(int id, string name);
        void DeleteEmployee(int id);
    }
}
