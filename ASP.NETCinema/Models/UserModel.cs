﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class UserModel
    {
        public UserModel()
        {
        }



        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Administrator { get; set; }
        public List<ScreeningModel> Tickets { get; set; }




    }
}
