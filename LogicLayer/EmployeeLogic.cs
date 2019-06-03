using System;
using System.Collections.Generic;
using System.Text;
using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using AutoMapper;
using DAL.Repository;
using LogicLayer.Interfaces;

namespace ASPNETCinema.Logic
{
    public class EmployeeLogic: IEmployeeLogic
    {
        private EmployeeRepository Repository { get; }
        private readonly IMapper _mapper;

        public EmployeeLogic(IEmployeeContext context, IMapper mapper)
        {
            Repository = new EmployeeRepository(context);
            _mapper = mapper;
        }
        
        public EmployeeModel GetEmployeeById(int id)
        {
            return _mapper.Map<EmployeeModel>(Repository.GetEmployeeById(id));
            
        }

        public List<EmployeeModel> GetEmployees()
        {
            return _mapper.Map<List<EmployeeModel>>(Repository.GetEmployees());
        }

        public void AddEmployee(EmployeeModel employee)
        {
            Repository.AddEmployee(employee);
        }

        public void EditEmployee(EmployeeModel employee)
        {
            Repository.EditEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            Repository.DeleteEmployee(id);
        }
    }
}
