using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class CinemaModel
    {
        public List<MovieModel> Movies { get; set; }
        public List<UserModel> Users { get; set; }
        public List<HallModel> Halls { get; set; }
        public List<ScreeningModel> Screenings { get; set; }
        public List<TaskModel> Tasks { get; set; }


        
        public CinemaModel()
        {
        }


    }
}
