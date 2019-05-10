using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Dtos;

namespace ASPNETCinema.DAL
{
    public interface IEmployeeContext
    {
        EmployeeDto GetEmployeeById(int id);
        List<EmployeeDto> GetEmployees();
        void AddEmployee(EmployeeModel employee);
        void EditEmployee(EmployeeModel employee);
        void DeleteEmployee(int id);

    }
}
