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
        List<HallDto> hallsTempDeleted = new List<HallDto>();
        int delete = 0;
        int edit = 0;
        string editName = "";

        public List<HallDto> GetHalls()
        {
            halls.Clear();
            SetHalls();
            AddedHalls();
            return halls;
        }

        public void SetHalls()
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

            WasSomethingDeleted();
            WasSomethingEdited();
        }

        public void WasSomethingDeleted()
        {
            if (delete != 0)
            {
                foreach (var hall in halls)
                {
                    if (hall.Id == delete)
                    {
                        halls.Remove(hall);
                        break;
                    }
                }
            }
        }

        public void WasSomethingEdited()
        {
            if (edit != 0)
            {
                foreach (var hall in halls)
                {
                    if (hall.Id == edit && editName != "")
                    {
                        halls[0].ScreenType = editName;
                        break;
                    }
                }
            }
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

        private void AddedHalls()
        {
            foreach (var hall in hallsTemp)
            {
                halls.Add(hall);
            }
        }

        public void EditHall(HallModel hall)
        {
            edit = hall.Id;
            editName = hall.ScreenType;
        }

        public void DeleteHall(int id)
        {
            delete = id;
        }

        public HallDto GetHallById(int id)
        {
            foreach (var hall in halls)
            {
                if (hall.Id == id)
                {
                    return hall;
                }
            }
            foreach (var hall in hallsTemp)
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
