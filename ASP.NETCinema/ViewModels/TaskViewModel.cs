﻿using ASPNETCinema.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.ViewModels
{
    public class TaskViewModel
    {
        public TaskViewModel()
        {
        }


        public int Id { get; set; }
        public int IdScreening { get; set; }
        public int TaskType { get; set; }
        public TimeSpan TaskLenght { get; set; }
        public IScreening Screening { get; set; }
        public List<IEmployee> Employees { get; set; }



    }
}
