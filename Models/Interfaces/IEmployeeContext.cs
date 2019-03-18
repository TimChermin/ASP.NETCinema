using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IEmployeeContext
    {
        string GetName(int id);
        IEnumerable<IEmployee> GetEmployees();
    }
}
