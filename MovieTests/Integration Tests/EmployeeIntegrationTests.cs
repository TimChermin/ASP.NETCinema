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

namespace EmployeeTests
{
    public class EmployeeIntegrationTests
    {
        EmployeeLogic employeeLogic;
        IMapper _mapper;
        
        public EmployeeIntegrationTests()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            employeeLogic = new EmployeeLogic(new EmployeeRepository(new DatabaseEmployee(new DatabaseConnection("Server = mssql.fhict.local; Database = dbi409997; User Id = dbi409997; Password = Ikbencool20042000!;"))), _mapper);
        }
        
        [Fact]
        public void Should_ReturnAnEmployee_WhenGettingAEmployeeById()
        {
            //Arrange
            //Id = 1012 and Name = Admin

            //Act
            EmployeeModel employee = employeeLogic.GetEmployeeById(1012);

            //Assert
            Assert.True(employee.Id == 1012 && employee.Name == "Admin");
        }

        [Fact]
        public void Should_ReturnNull_WhenGettingAEmployeeByIdThatDoesntExist()
        {
            //Arrange
            //Not in DB

            //Act
            var employee = employeeLogic.GetEmployeeById(9999999);

            //Assert
            Assert.True(employee == null);
        }
    }
}
