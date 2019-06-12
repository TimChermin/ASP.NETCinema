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


namespace TaskTests
{
    public class TaskIntegrationTests
    {
        TaskLogic taskLogic;
        IMapper _mapper;

        public TaskIntegrationTests()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            taskLogic = new TaskLogic(new TaskRepository(new DatabaseTask(new DatabaseConnection("Server = mssql.fhict.local; Database = dbi409997; User Id = dbi409997; Password = Ikbencool20042000!;"))), _mapper);
        }

        [Fact]
        public void Should_ReturnATask_WhenGettingATaskById()
        {
            //Arrange
            //Id = 5 and TaskType = TEST

            //Act
            var task = taskLogic.GetTaskById(5);

            //Assert
            Assert.True(task.Id == 5 && task.TaskType == "TEST");
        }

        [Fact]
        public void Should_ReturnNull_WhenGettingATaskByIdThatDoesntExist()
        {
            //Arrange
            //Not In DB

            //Act
            var task = taskLogic.GetTaskById(99999999);

            //Assert
            Assert.True(task == null);
        }
    }
}
