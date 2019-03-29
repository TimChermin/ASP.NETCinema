using DAL;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTests.Hall.Dtos;

namespace UnitTests.Hall.MockContext
{
    class HallContextMock : IHallContext
    {
        List<IHall> halls = new List<IHall>();
        List<IHall> hallsTemp = new List<IHall>();

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete
        public IEnumerable<IHall> GetHalls()
        {
            halls.Clear();
            foreach (var hall in hallsTemp)
            {
                halls.Add(hall);
            }
            halls = AddHallsInOrderBy(halls);
            return halls;
        }

        public List<IHall> AddHallsInOrderBy(List<IHall> halls)
        {
            halls.Add(new HallDto
            {
                Id = 1,
                Seats = 30,
                SeatsTaken = 25,
                ScreenType = "3D",
                Price = 5
            });

            halls.Add(new HallDto
            {
                Id = 2,
                Seats = 30,
                SeatsTaken = 25,
                ScreenType = "3D",
                Price = 5
            });

            halls.Add(new HallDto
            {
                Id = 3,
                Seats = 30,
                SeatsTaken = 25,
                ScreenType = "3D",
                Price = 5
            });

            halls.Add(new HallDto
            {
                Id = 4,
                Seats = 30,
                SeatsTaken = 25,
                ScreenType = "3D",
                Price = 5
            });
            return halls;
        }

        public void AddHall(IHall hall)
        {
            hallsTemp.Add(new HallDto
            {
                Id = hall.Id,
                Seats = hall.Seats,
                SeatsTaken = hall.SeatsTaken,
                ScreenType = hall.ScreenType,
                Price = hall.Price
            });
        }

        public void EditHall(IHall hall)
        {
            foreach (var hal in GetHalls())
            {
                if (hal.Id == hall.Id)
                {
                    hal.Id = hall.Id;
                    hal.Seats = hall.Seats;
                    hal.SeatsTaken = hall.SeatsTaken;
                    hal.ScreenType = hall.ScreenType;
                    hal.Price = hall.Price;
                }
            }
        }

        public void DeleteHall(int id)
        {
            foreach (var hall in GetHalls())
            {
                if (hall.Id == id)
                {
                    hall.ScreenType = "Deleted";
                    hallsTemp.Add(hall);
                }
            }
        }

        public IHall GetHallById(int id)
        {
            foreach (var hall in GetHalls())
            {
                if (hall.Id == id)
                {
                    return hall;
                }
            }
            return null;
        }
    }
}
