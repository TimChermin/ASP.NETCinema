using System;
using System.Collections.Generic;
using System.Text;
using ASPNETCinema.DAL;
using Interfaces;

namespace DAL.Repository
{
    public class EmployeeRepository
    {
        private readonly IEmployeeContext _context;

        public EmployeeRepository(IEmployeeContext context)
        {
            _context = context;
        }
        
        //List
        //Add
        //details
        //Edit
        //Delete
        //other things

        public IEnumerable<IEmployee> GetEmployees()
        {
            return _context.GetEmployees();
        }

        public void AddEmployee(IEmployee employee)
        {
            _context.AddEmployee(employee);
        }

        public IEmployee GetEmployeeById(int id)
        {
            return _context.GetEmployeeById(id);
        }

        public void EditEmployee(IEmployee employee)
        {
            _context.EditEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            _context.DeleteEmployee(id);
        }

    }
}
