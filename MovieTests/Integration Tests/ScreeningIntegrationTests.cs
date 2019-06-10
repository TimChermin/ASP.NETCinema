using ASPNETCinema;
using ASPNETCinema.Controllers;
using ASPNETCinema.DAL;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using ASPNETCinema.ViewModels;
using AutoMapper;
using DAL;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Movie.MockContext;
using Xunit;

namespace UnitTests.Integration_Tests
{
    public class ScreeningIntegrationTests
    {
        ScreeningLogic screeningLogic;
        IMapper _mapper;

        public ScreeningIntegrationTests()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            screeningLogic = new ScreeningLogic(new ScreeningRepository(new DatabaseScreening(new DatabaseConnection("Server = mssql.fhict.local; Database = dbi409997; User Id = dbi409997; Password = Ikbencool20042000!;"))), _mapper);
        }

        [Fact]
        public void Should_ReturnAnScreening_WhenGettingAScreeningById()
        {
            //Arrange
            //Id = 1012

            //Act
            ScreeningModel screening = screeningLogic.GetScreeningById(1012);

            //Assert
            Assert.True(screening.Id == 1012);
        }

        [Fact]
        public void Should_ReturnNull_WhenGettingAScreeningByIdThatDoesntExist()
        {
            //Arrange
            //Not in DB

            //Act
            var screening = screeningLogic.GetScreeningById(9999999);

            //Assert
            Assert.True(screening == null);
        }
    }
}
