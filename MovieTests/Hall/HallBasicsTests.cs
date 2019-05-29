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
    public class HallBasicsTests
    {
        HallLogic hallLogic;
        IMapper _mapper;

        public HallBasicsTests()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            hallLogic = new HallLogic(new HallContextMock(), _mapper);
        }

        [Fact]
        public void Should_AddAHall_WhenAddingAHall()
        {
            //Arrange
            
            //Act
            hallLogic.AddHall(new HallModel { Id = 5, Price = 5, ScreenType = "AddTest", Seats = 30, SeatsTaken = 0 });

            //Assert
            Assert.True(hallLogic.GetHallById(5).ScreenType == "AddTest");
        }

        [Fact]
        public void Should_EditAHall_WhenEditingAnHall()
        {
            //Arrange
            HallModel hall = new HallModel { Id = 1, Price = 5, ScreenType = "EditTest", Seats = 30, SeatsTaken = 0 };

            //Act
            hallLogic.EditHall(hall);

            //Assert
            Assert.True(hallLogic.GetHalls()[0].ScreenType == "EditTest");
        }
        

        [Fact]
        public void Should_ReturnAHall_WhenGettingAHallById()
        {
            //Arrange
            hallLogic.AddHall(new HallModel { Id = 5, Price = 5, ScreenType = "GetByIdTest", Seats = 30, SeatsTaken = 0 });
            
            //Act
            HallModel hall = hallLogic.GetHallById(5);

            //Assert
            Assert.True(hall.Id == 5 && hall.ScreenType == "GetByIdTest");
        }

        [Fact]
        public void Should_DeleteAnHall_WhenDeleteingAnHall()
        {
            //Arrange
            List<HallModel> halls = new List<HallModel>();
            halls = hallLogic.GetHalls();
            string screenType = halls[0].ScreenType;

            //Act
            hallLogic.DeleteHall(halls[0].Id);

            //Assert
            Assert.False(halls[0].ScreenType != screenType);
        }

        [Fact]
        public void Should_GetHallsFromTheList_WhenGettingHalls()
        {
            //Arrange
            var hallLogic = new HallLogic(new HallContextMock(), _mapper);
            HallModel hall = new HallModel { Id = 10, Price = 5, ScreenType = "GetTest", Seats = 30, SeatsTaken = 0 };
            hallLogic.AddHall(hall);
            bool found = false;

            //Act
            if (hallLogic.GetHalls()[4].Id == 10 && hallLogic.GetHalls()[4].ScreenType == "GetTest")
            {
                found = true;
            }

            //Assert
            Assert.True(found);
        }
    }
}
