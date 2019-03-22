using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Dtos
{
    class EmployeeDto : IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
