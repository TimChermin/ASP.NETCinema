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
        ScreeningLogic screeningLogic = new ScreeningLogic();
        ScreeningController screeningController = new ScreeningController();
        List<ScreeningModel> screenings = new List<ScreeningModel>();
        List<ScreeningModel> screenings2 = new List<ScreeningModel>();
        ThingEqualityComparer comparer = new ThingEqualityComparer();

        [Fact]
        public void Should_ReturnAListOfScreenings_WhenLoadingScreenings()
        {
            //Arrange
            //try to add a test database later to put stuff in it first 

            //Act
            screenings = screeningLogic.GetScreenings();
            screenings2 = screeningLogic.GetScreenings();

            bool found = false;
            int screeningNr = 0;
            int screeningNr2 = 0;
            foreach (var screening in screenings)
            {
                screeningNr2 = 0;
                found = false;
                foreach (var screening2 in screenings2)
                {

                    if (comparer.Equals(screening, screening2) && screeningNr == screeningNr2)
                    {
                        Assert.True(true);
                        found = true;
                    }
                    screeningNr2++;
                }
                if (found == false)
                {
                    Assert.True(false);
                }
                screeningNr++;
            }
        }




        class ThingEqualityComparer : IEqualityComparer<ScreeningModel>
        {
            public bool Equals(ScreeningModel x, ScreeningModel y)
            {
                if (x == null || y == null)
                    return false;

                return (x.Id == y.Id && x.MovieId == y.MovieId && x.HallId == y.HallId && x.DateOfScreening == y.DateOfScreening
                    && x.TimeOfScreening == y.TimeOfScreening);
            }

            public int GetHashCode(ScreeningModel obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
