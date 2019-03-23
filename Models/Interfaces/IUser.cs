using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        int Administrator { get; set; }
        int IdScreening { get; set; }
        List<ScreeningModel> Tickets { get; set; }

    }
}
