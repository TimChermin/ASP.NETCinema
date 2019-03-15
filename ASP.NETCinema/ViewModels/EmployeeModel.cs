using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public EmployeeViewModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }



    }
}
