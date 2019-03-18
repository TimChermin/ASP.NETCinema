﻿using System;
using System.Collections.Generic;
using System.Text;
using ASPNETCinema.DAL;
using ASPNETCinema.Interfaces;

namespace Repository
{
    public class EmployeeRepository
    {
        private readonly IEmployeeContext _context;

        public EmployeeRepository(IEmployeeContext context)
        {
            _context = context;
        }

        public void GetName(IEmployeeContext person)
        {
            //_context.GetName();
        }

        public IEnumerable<IEmployee> GetEmployees()
        {
            return _context.GetEmployees();
        }

    }
}
