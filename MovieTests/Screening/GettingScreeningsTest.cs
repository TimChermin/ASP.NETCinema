using ASPNETCinema;
using ASPNETCinema.Controllers;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using AutoMapper;
using DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests;
using UnitTests.Screening.MockContext;
using Xunit;

namespace ScreeningTests
{
    public class GettingScreeningsTest
    {
        ScreeningLogic screeningLogic;
        IMapper _mapper;

        public GettingScreeningsTest()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            screeningLogic = new ScreeningLogic(new ScreeningContextMock(), _mapper);
        }

        [Fact]
        public void Should_ReturnFalse_WhenAddingAScreeningOnTheSameTimeInTheSameHall()
        {
            //Arrange
            ScreeningDto screening = new ScreeningDto
            {
                Id = 2,
                MovieId = 1,
                HallId = 1,
                DateOfScreening = new DateTime(2020, 1, 1),
                TimeOfScreening = new TimeSpan(1, 0, 0)
            };
            
            //Act
            bool timeAvailable = screeningLogic.IsThisDateAndTimeAvailable(screening.HallId, screening.DateOfScreening, screening.TimeOfScreening, screening.MovieId, screening.Id);

            //Assert
            Assert.False(timeAvailable);
        }

        [Fact]
        public void Should_ReturnTrue_WhenNotAddingAScreeningOnTheSameTimeInTheSameHall()
        {
            //Arrange
            ScreeningDto screening = new ScreeningDto
            {
                Id = 2,
                MovieId = 1,
                HallId = 1,
                DateOfScreening = new DateTime(2020, 1, 1),
                TimeOfScreening = new TimeSpan(4, 0, 0)
            };

            //Act
            bool timeAvailable = screeningLogic.IsThisDateAndTimeAvailable(screening.HallId, screening.DateOfScreening, screening.TimeOfScreening, screening.MovieId, screening.Id);

            //Assert
            Assert.True(timeAvailable);
        }




        [Fact]
        public void Should_AddAnScreening_WhenAddingAScreening()
        {
            //Arrange
            ScreeningModel screening = new ScreeningModel { Id = 10, DateOfScreening = DateTime.Today.AddYears(100) };

            //Act
            screeningLogic.AddScreening(screening);

            //Assert
            Assert.True(screeningLogic.GetScreeningById(10).DateOfScreening == DateTime.Today.AddYears(100));
        }

        [Fact]
        public void Should_EditAnScreening_WhenEditingAScreening()
        {
            //Arrange
            ScreeningModel screening = new ScreeningModel { Id = 1, DateOfScreening = DateTime.Today.AddYears(101) };

            //Act
            screeningLogic.EditScreening(screening);

            //Assert
            Assert.True(screeningLogic.GetScreenings()[0].DateOfScreening == DateTime.Today.AddYears(101));
        }

        [Fact]
        public void Should_ReturnAScreening_WhenGettingAScreeningById()
        {
            //Arrange
            screeningLogic.AddScreening(new ScreeningModel { Id = 5, DateOfScreening = DateTime.Today.AddYears(102) });

            //Act
            ScreeningModel screening = screeningLogic.GetScreeningById(5);

            //Assert
            Assert.True(screening.Id == 5 && screening.DateOfScreening == DateTime.Today.AddYears(102));
        }

        [Fact]
        public void Should_DeleteAnScreening_WhenDeleteingAScreening()
        {
            //Arrange
            List<ScreeningModel> screenings = new List<ScreeningModel>();
            screenings = screeningLogic.GetScreenings();
            DateTime date = screenings[0].DateOfScreening;

            //Act
            screeningLogic.DeleteScreening(screenings[0].Id);

            //Assert
            Assert.False(screenings[0].DateOfScreening != date);
        }

        [Fact]
        public void Should_GetScreeningsFromTheList_WhenGettingScreenings()
        {
            //Arrange
            ScreeningModel screening = new ScreeningModel { Id = 10, DateOfScreening = DateTime.Today.AddYears(103) };
            screeningLogic.AddScreening(screening);
            bool found = false;

            //Act
            if (screeningLogic.GetScreenings()[4].Id == 10 && screeningLogic.GetScreenings()[4].DateOfScreening == DateTime.Today.AddYears(103))
            {
                found = true;
            }

            //Assert
            Assert.True(found);
        }








    }
}
