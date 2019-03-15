using ASPNETCinema.DataLayer;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Logic
{
    public class TaskLogic
    {
        DatabaseTask database = new DatabaseTask();
        DatabaseMovie databaseMovie = new DatabaseMovie();
        //List<TaskModel> TasksWithMovies;

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete


        public List<TaskModel> GetTasks()
        {
            return database.GetTasks();
        }
    }
}
