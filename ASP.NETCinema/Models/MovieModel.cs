using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCinema.Models
{
    public class MovieModel
    {
        public MovieModel(string name, string description, DateTime releaseDate, DateTime lastScreeningDate, string movieType, string movieLenght)
        {
            Name = name;
            Description = description;
            ReleaseDate = releaseDate;
            LastScreeningDate = lastScreeningDate;
            MovieType = movieType;
            MovieLenght = movieLenght;
        }

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

        
        //[Range(100000, 999999, ErrorMessage = "This ID isn't good")]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //[Range(DateTime.Today, DateTime.Today, ErrorMessage = "This ID isn't good")]
        public DateTime ReleaseDate { get; set; }
        public DateTime LastScreeningDate { get; set; }
        public string MovieType { get; set; }

        //[Display(Name = "Movie Lenght")]
        [Required(ErrorMessage = "You need to fill in the movie lenght")]
        public string MovieLenght { get; set; }
        


    }
}
