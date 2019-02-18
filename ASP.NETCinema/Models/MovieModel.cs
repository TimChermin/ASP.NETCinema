using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCinema.Models
{
    public class MovieModel
    {
        public MovieModel(int iD, string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght)
        {
            ID = iD;
            Name = name;
            Description = description;
            ReleaseDate = releaseDate;
            LastScreeningDate = lastScreeningDate;
            MovieType = movieType;
            MovieLenght = movieLenght;
        }

        public MovieModel()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime LastScreeningDate { get; set; }
        public string MovieType { get; set; }
        public string MovieLenght { get; set; }
        


    }
}
