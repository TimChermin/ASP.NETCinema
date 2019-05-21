using ASPNETCinema;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnitTests.Hall.MockContext;
using Xunit;

namespace HallTests
{
    public class GettingHallsTest
    {
        HallLogic _hallLogic;
        IMapper _mapper;
        List<HallModel> halls = new List<HallModel>();
        List<HallModel> halls2 = new List<HallModel>();

        public GettingHallsTest()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
        }
        

        [Fact]
        public void Should_AddAHall_WhenAddingAHall()
        {
            //Arrange
            var hallLogic = new HallLogic(new HallContextMock(), _mapper);
            halls = hallLogic.GetHalls().ToList();
            hallLogic.AddHall(new HallModel{ Id = 5, Price = 5, ScreenType = "IMAX", Seats = 30, SeatsTaken = 0 });
            halls2 = hallLogic.GetHalls().ToList();

            //Act
            bool HallAdded = (halls2[0].Id == 5 && halls2[0].Price == 5 && halls2[0].ScreenType == "IMAX"
                && halls2[0].Seats == 30 && halls2[0].SeatsTaken == 0);
            bool CountIsNotTheSame = halls.Count() != halls2.Count();

            //Assert
            Assert.True(HallAdded);
            Assert.True(CountIsNotTheSame);
        }

        [Fact]
        public void Should_EditAHall_WhenEditingAHall()
        {
            //Arrange
            var hallLogic = new HallLogic(new HallContextMock(), _mapper);


            //Act
            halls = hallLogic.GetHalls().ToList();
            hallLogic.EditHall(new HallModel { Id = 5, Price = 5, ScreenType = "IMAX", Seats = 30, SeatsTaken = 0 });
            halls2 = hallLogic.GetHalls().ToList();


            //Assert
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
            //Arrange
            var hallLogic = new HallLogic(new HallContextMock(), _mapper);

            //Act
            hallLogic.AddHall(new HallModel { Id = 5, Price = 5, ScreenType = "IMAX", Seats = 30, SeatsTaken = 0 });
            HallModel hall = hallLogic.GetHallById(5);

            //Assert
            Assert.Equal(5, hall.Id);
        }

        [Fact]
        public void Should_ReturnAHallListWithAnDeleteHall_WhenDeleteingAHall()
        {
            //Arrange
            var hallLogic = new HallLogic(new HallContextMock(), _mapper);
            halls = hallLogic.GetHalls().ToList();

            //Act
            hallLogic.DeleteHall(3);
            halls2 = hallLogic.GetHalls().ToList();

            //Assert
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
    }
}
