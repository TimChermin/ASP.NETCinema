using Interfaces;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPNETCinema.DAL
{
    public interface IEmployeeContext
    {
        IEmployee GetEmployeeById(int id);
        IEnumerable<IEmployee> GetEmployees();
        void AddEmployee(IEmployee employee);
        void EditEmployee(IEmployee employee);
        void DeleteEmployee(int id);

    }
}
