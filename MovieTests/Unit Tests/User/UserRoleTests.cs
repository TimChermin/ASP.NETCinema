using ASPNETCinema;
using ASPNETCinema.Logic;
using ASPNETCinema.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTests.User.MockContext;
using Xunit;

namespace UserTests
{
    public class UserRoleTests
    {
        UserLogic userLogic;
        IMapper _mapper;

        public UserRoleTests()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            userLogic = new UserLogic(new UserContextMock(), _mapper);
        }

        [Fact]
        public void Should_ReturnEmployeeRole_WhenGettingUserRole()
        {
            //Arrange
            UserModel user = new UserModel { Id = 3, Name = "RoleName", Password = "RolePassword", ConfirmPassword = "RolePassword", Role = "Employee" };

            //Act
            userLogic.AddUser(user);

            //Assert
            Assert.True(userLogic.GetRoleUser(3) == "Employee");
        }


        [Fact]
        public void Should_ReturnNormalRole_WhenGettingUserRole()
        {
            //Arrange
            UserModel user = new UserModel { Id = 2, Name = "RoleName", Password = "RolePassword", ConfirmPassword = "RolePassword", Role = "Normal" };

            //Act
            userLogic.AddUser(user);

            //Assert
            Assert.True(userLogic.GetRoleUser(2) == "Normal");
        }


        [Fact]
        public void Should_ReturnAdminRole_WhenGettingUserRole()
        {
            //Arrange
            UserModel user = new UserModel { Id = 1, Name = "RoleName", Password = "RolePassword", ConfirmPassword = "RolePassword", Role = "Admin" };

            //Act
            userLogic.AddUser(user);

            //Assert
            Assert.False(userLogic.GetRoleUser(1) == "Normal" || userLogic.GetRoleUser(1) == "Employee");
        }
    }
}
