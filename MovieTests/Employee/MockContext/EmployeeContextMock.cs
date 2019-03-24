using ASPNETCinema.DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Employee.MockContext
{
    class EmployeeContextMock : IEmployeeContext
    {
        public void AddEmployee(IEmployee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public void EditEmployee(IEmployee employee)
        {
            throw new NotImplementedException();
        }

        public IEmployee GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IEmployee> GetEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
