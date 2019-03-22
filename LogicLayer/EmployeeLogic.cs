using System;
using System.Collections.Generic;
using System.Text;
using ASPNETCinema.DAL;
using Interfaces;
using ASPNETCinema.Models;
using DAL.Repository;

namespace ASPNETCinema.Logic
{
    public class EmployeeLogic
    {
        private EmployeeRepository Repository { get; }

        public EmployeeLogic(IEmployeeContext context)
        {
            Repository = new EmployeeRepository(context);
        }

        //other things
        //details
        //List
        //Add
        //Edit
        //Delete

        public IEmployee GetEmployeeById(int id)
        {
            return Repository.GetEmployeeById(id);
        }

        public IEnumerable<IEmployee> GetEmployees()
        {
            return Repository.GetEmployees();
        }

        public void AddEmployee(string name)
        {
            var employee = new EmployeeModel
            {
                Name = name
            };
            Repository.AddEmployee(employee);
        }

        public void EditEmployee(int id, string name)
        {
            var employee = new EmployeeModel
            {
                Id = id,
                Name = name
            };
            Repository.EditEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            Repository.DeleteEmployee(id);
        }
    }
}
