using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<ScreeningDto> Tickets { get; set; }
        public int IdScreening { get; set; }
    }
}
