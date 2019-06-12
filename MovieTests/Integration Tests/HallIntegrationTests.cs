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

namespace HallTests
{
    public class HallIntegrationTests
    {
        HallLogic hallLogic;
        IMapper _mapper;
        
        public HallIntegrationTests()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            hallLogic = new HallLogic(new HallRepository(new DatabaseHall(new DatabaseConnection("Server = mssql.fhict.local; Database = dbi409997; User Id = dbi409997; Password = Ikbencool20042000!;"))), _mapper);
        }
        
        [Fact]
        public void Should_ReturnAHall_WhenGettingAHallById()
        {
            //Arrange
            //Id = 1010 and ScreenType = Special

            //Act
            var hall = hallLogic.GetHallById(1010);

            //Assert
            Assert.True(hall.Id == 1010);
        }

        [Fact]
        public void Should_ReturnNull_WhenGettingAHallByIdThatDoesntExist()
        {
            //Arrange
            //Not In DB

            //Act
            var hall = hallLogic.GetHallById(99999999);

            //Assert
            Assert.True(hall == null);
        }
    }
}
