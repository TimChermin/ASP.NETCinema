using System;
using System.Collections.Generic;
using System.Text;
using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using DAL.Repository;
using LogicLayer.Interfaces;

namespace ASPNETCinema.Logic
{
    public class EmployeeLogic: IEmployeeLogic
    {
        private EmployeeRepository Repository { get; }

        public EmployeeLogic(IEmployeeContext context)
        {
            Repository = new EmployeeRepository(context);
        }
        
        public EmployeeModel GetEmployeeById(int id)
        {
            return Repository.GetEmployeeById(id);
        }

        public List<EmployeeModel> GetEmployees()
        {
            return Repository.GetEmployees();
        }

        public void AddEmployee(int id, string name)
        {
            var employee = new EmployeeModel
            {
                Id = id,
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
