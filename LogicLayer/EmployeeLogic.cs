using ASPNETCinema.DataLayer;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Logic
{
    public class EmployeeLogic
    {
        DatabaseEmployee database = new DatabaseEmployee();
        DatabaseMovie databaseMovie = new DatabaseMovie();
        List<EmployeeModel> EmployeeWithMovies;

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete


        public List<EmployeeModel> GetEmployees()
        {
            return database.GetEmployees();
        }

    }
}
