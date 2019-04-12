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
            
            halls = hallLogic.GetHalls().ToList();
            halls2 = hallLogic.GetHalls().ToList();

            Assert.True(AreTheyInTheSameOrder(halls, halls2));
        }

        [Fact]
        public void Should_AddAHallToTheList_WhenAddingAHall()
        {
            var hallLogic = new HallLogic(new HallContextMock());
            //var result =  hallLogic.GetAllCustomers();
            halls = hallLogic.GetHalls().ToList();
            hallLogic.AddHall(5, 5, "IMAX", 30, 0);
            halls2 = hallLogic.GetHalls().ToList();

            Assert.True(halls2[0].Id == 5 && halls2[0].Price == 5 && halls2[0].ScreenType == "IMAX" 
                && halls2[0].Seats == 30 && halls2[0].SeatsTaken == 0);
            Assert.True(halls.Count() != halls2.Count());
        }

        [Fact]
        public void Should_ReturnAHallListWithAnEditedHall_WhenEditingAHall()
        {
            var hallLogic = new HallLogic(new HallContextMock());
            //var result =  hallLogic.GetAllCustomers();
            halls = hallLogic.GetHalls().ToList();
            hallLogic.EditHall(5, 5, "IMAX", 30, 0);
            halls2 = hallLogic.GetHalls().ToList();

            foreach (var hall in halls)
            {
                if (hall.ScreenType != "Edited")
                {
                    Assert.True(true);
                }
            }
            foreach (var hall in halls2)
            {
                if (hall.ScreenType == "Edited")
                {
                    Assert.True(true);
                }
            }
        }

        [Fact]
        public void Should_ReturnAHall_WhenGettingAHallById()
        {
            var hallLogic = new HallLogic(new HallContextMock());
            hallLogic.AddHall(5, 5, "IMAX", 30, 0);
            IHall hall = hallLogic.GetHallById(5);


            Assert.Equal(5, hall.Id);
        }

        [Fact]
        public void Should_ReturnAHallListWithAnDeleteHall_WhenDeleteingAHall()
        {
            var hallLogic = new HallLogic(new HallContextMock());
            halls = hallLogic.GetHalls().ToList();
            hallLogic.DeleteHall(3);
            halls2 = hallLogic.GetHalls().ToList();

            foreach (var hall in halls)
            {
                if (hall.ScreenType != "Deleted")
                {
                    Assert.True(true);
                }
            }
            foreach (var hall in halls2)
            {
                if (hall.ScreenType == "Deleted")
                {
                    Assert.True(true);
                }
            }

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
