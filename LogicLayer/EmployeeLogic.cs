using System;
using System.Collections.Generic;
using System.Text;
using ASPNETCinema.DAL;
using ASPNETCinema.Interfaces;
using ASPNETCinema.Models;
using Repository;

namespace ASPNETCinema.Logic
{
    public class EmployeeLogic
    {
        private EmployeeRepository Repository { get; }

        public EmployeeLogic(IEmployeeContext context)
        {
            Repository = new EmployeeRepository(context);
        }

        public string GetName(int id)
        {
            return "test " + id;
        }

        public IEnumerable<IEmployee> GetEmployees()
        {
            return Repository.GetEmployees();
        }
    }
}
