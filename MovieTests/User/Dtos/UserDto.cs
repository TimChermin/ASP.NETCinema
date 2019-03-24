using ASPNETCinema.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.User.Dtos
{
    class UserDto : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Administrator { get; set; }
        public int IdScreening { get; set; }
        public List<ScreeningModel> Tickets { get; set; }
    }
}
