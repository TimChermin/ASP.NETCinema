using System;
using System.Collections.Generic;
using System.Text;
using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using DAL.Dtos;

namespace DAL.Repository
{
    public class EmployeeRepository : IEmployeeContext
    {
        private readonly IEmployeeContext _context;

        public EmployeeRepository(IEmployeeContext context)
        {
            _context = context;
        }

        public List<EmployeeDto> GetEmployees()
        {
            return _context.GetEmployees();
        }

        public void AddEmployee(EmployeeModel employee)
        {
            _context.AddEmployee(employee);
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            return _context.GetEmployeeById(id);
        }

        public void EditEmployee(EmployeeModel employee)
        {
            _context.EditEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            _context.DeleteEmployee(id);
        }

    }
}
