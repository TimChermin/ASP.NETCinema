using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class MovieModel
    {
        public MovieModel(int iD, string name, string description, string movieType)
        {
            ID = iD;
            Name = name;
            Description = description;
            MovieType = movieType;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime LastScreeningDate { get; set; }
        public string MovieType { get; set; }



    }
}
