using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IEmployee
    {
        string GetName(int id);
        List<EmployeeModel> GetEmployees();
    }
}
