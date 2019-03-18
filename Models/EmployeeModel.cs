using ASPNETCinema.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class EmployeeModel : IEmployee
    {
        public EmployeeModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public EmployeeModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }



    }
}
