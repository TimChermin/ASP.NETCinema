using ASPNETCinema.Controllers;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ScreeningTests
{
    public class GettingScreeningsTest
    {
        [Fact]
        public void Test1()
        {

        }




        class ThingEqualityComparer : IEqualityComparer<MovieModel>
        {
            public bool Equals(MovieModel x, MovieModel y)
            {
                if (x == null || y == null)
                    return false;

                return (x.Id == y.Id && x.Name == y.Name && x.Description == y.Description && x.ReleaseDate == y.ReleaseDate
                    && x.LastScreeningDate == y.LastScreeningDate && x.MovieType == y.MovieType && x.MovieLenght == y.MovieLenght
                    && x.ImageString == y.ImageString);
            }

            public int GetHashCode(MovieModel obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
