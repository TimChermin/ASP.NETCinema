using ASPNETCinema.DAL;
using ASPNETCinema.Models;
using DAL;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Hall.MockContext
{
    class HallContextMock : IHallContext
    {
        List<HallDto> halls = new List<HallDto>();
        List<HallDto> hallsTemp = new List<HallDto>();
        
        public List<HallDto> GetHalls()
        {
            halls.Clear();
            foreach (var hall in hallsTemp)
            {
                halls.Add(hall);
            }
            halls = AddHallsInOrderBy(halls);
            return halls;
        }

        public List<HallDto> AddHallsInOrderBy(List<HallDto> halls)
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

        public void AddHall(HallModel hall)
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

        public void EditHall(HallModel hall)
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

        public HallDto GetHallById(int id)
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
