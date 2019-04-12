using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IMovie
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        DateTime ReleaseDate { get; set; }
        DateTime LastScreeningDate { get; set; }
        string MovieType { get; set; }
        string MovieLenght { get; set; }
        string ImageString { get; set; }
        string BannerImageString { get; set; }
        IEnumerable<IScreening> Screenings { get; set; }

    }
}
