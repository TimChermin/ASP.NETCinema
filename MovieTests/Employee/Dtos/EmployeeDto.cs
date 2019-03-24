using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Employee.Dtos
{
    class EmployeeDto : IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
