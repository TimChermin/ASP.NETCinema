using ASPNETCinema.DAL;
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
