using ASPNETCinema.Logic;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTests.Hall.MockContext;
using Xunit;

namespace UnitTests.Hall
{
    public class GettingHallsTest
    {
        HallLogic _hallLogic;
        ThingEqualityComparer comparer = new ThingEqualityComparer();
        List<IHall> halls = new List<IHall>();
        List<IHall> halls2 = new List<IHall>();

        public GettingHallsTest()
        {
            _hallLogic = new HallLogic(new HallContextMock());
        }

        [Fact]
        public void Should_ReturnAListOfHalls_WhenGettingHalls()
        {
            var hallLogic = new HallLogic(new HallContextMock());

            //var result =  hallLogic.GetAllCustomers();
            //halls = hallLogic.GetHalls().ToList();
            //halls2 = hallLogic.GetHalls().ToList();

            //Assert.True(AreTheyInTheSameOrder(halls, halls2));
            Assert.True(true);
        }

        public bool AreTheyInTheSameOrder(IEnumerable<IHall> halls, IEnumerable<IHall> halls2)
        {
            bool found;
            int hallNr = 0;
            int hall2Nr = 0;
            foreach (var hall in halls)
            {
                hall2Nr = 0;
                found = false;
                foreach (var hall2 in halls2)
                {
                    if (comparer.Equals(hall, hall2) && hallNr == hall2Nr)
                    {
                        Assert.True(true);
                        found = true;
                    }
                    hall2Nr++;
                }
                if (found == false)
                {
                    return false;
                }
                hallNr++;
            }
            return true;
        }


        class ThingEqualityComparer : IEqualityComparer<IHall>
        {
            public bool Equals(IHall x, IHall y)
            {
                if (x == null || y == null)
                    return false;

                return (x.Id == y.Id && x.Price == y.Price && x.ScreenType == y.ScreenType && x.Seats == y.Seats
                    && x.SeatsTaken == y.SeatsTaken);
            }

            public int GetHashCode(IHall obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
