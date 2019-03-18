using Interfaces;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPNETCinema.DAL
{
    public interface IEmployeeContext
    {
        string GetName(int id);
        IEnumerable<IEmployee> GetEmployees();
    }
}
