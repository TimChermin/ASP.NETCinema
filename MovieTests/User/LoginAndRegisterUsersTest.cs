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
    public class LoginAndRegisterUsersTest
    {
        UserLogic userLogic;
        IMapper _mapper;

        public LoginAndRegisterUsersTest()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            userLogic = new UserLogic(new UserContextMock(), _mapper);
        }


        [Fact]
        public void Should_RegisterAnUser_WhenEverythingIsFilledInCorrectly()
        {
            //Arrange
            UserModel user = new UserModel { Id = 1, Name = "AddName", Password = "AddPassword", ConfirmPassword = "AddPassword", Administrator = 0 };
            
            //Act
            bool userAdded = userLogic.AddUser(user);

            //Assert
            Assert.True(userAdded);
        }
        
        [Fact]
        public void Should_NotRegisterAnUser_WhenNotEverythingIsFilledInCorrectly()
        {
            //Arrange
            UserModel user = new UserModel { Id = 1, Name = "AddName", Password = "NotTheSamePassword", ConfirmPassword = "AddPassword", Administrator = 0 };

            //Act
            bool userAdded = userLogic.AddUser(user);

            //Assert
            Assert.False(userAdded);
        }


        [Fact]
        public void Should_ReturnTrue_WhenTheLoginIsCorrect()
        {
            //Arrange
            userLogic.AddUser(new UserModel { Id = 1, Name = "AddName", Password = "AddPassword", ConfirmPassword = "AddPassword", Administrator = 0 });

            //Act
            bool userLoggedIn = userLogic.CheckIfThisLoginIsCorrect("AddName", "AddPassword");

            //Assert
            Assert.True(userLoggedIn);
        }

        [Fact]
        public void Should_ReturnFalse_WhenThePasswordIsWrongWhenLoggingIn()
        {
            //Arrange
            userLogic.AddUser(new UserModel { Id = 1, Name = "AddName", Password = "AddPassword", ConfirmPassword = "AddPassword", Administrator = 0 });

            //Act
            bool userLoggedIn = userLogic.CheckIfThisLoginIsCorrect("AddName", "WRONGPASSWORD");

            //Assert
            Assert.False(userLoggedIn);
        }

        [Fact]
        public void Should_ReturnFalse_WhenTheNameDoesNotExistWhenLoggingIn()
        {
            //Arrange
            userLogic.AddUser(new UserModel { Id = 1, Name = "AddName", Password = "AddPassword", ConfirmPassword = "AddPassword", Administrator = 0 });

            //Act
            bool userLoggedIn = userLogic.CheckIfThisLoginIsCorrect("NotAName", "AddPassword");

            //Assert
            Assert.False(userLoggedIn);
        }




        [Fact]
        public void Should_HashPassword_WhenHashing()
        {
            //Arrange
            var hash = LogicLayer.SecurePasswordHasher.Hash("mypassword");
            var hash2 = LogicLayer.SecurePasswordHasher.Hash("SOMETHINGRANDOM4145");
            string hash3 = "$MYHASH$V1$10000$sgoGDeKC4L2yrnVoyPfyxZHh4WrKyimN6uztpEOHd8gEJ9+/";


            Assert.True(LogicLayer.SecurePasswordHasher.Verify("mypassword", hash));
            Assert.False(LogicLayer.SecurePasswordHasher.Verify("mypassworde", hash));
            Assert.False(LogicLayer.SecurePasswordHasher.Verify("mypasswor", hash));
            Assert.False(LogicLayer.SecurePasswordHasher.Verify(hash, hash));

            Assert.True(LogicLayer.SecurePasswordHasher.Verify("SOMETHINGRANDOM4145", hash2));
            Assert.False(LogicLayer.SecurePasswordHasher.Verify("SOMETHINGRANDOM41", hash2));
            Assert.False(LogicLayer.SecurePasswordHasher.Verify("SOMERANDOM4145", hash2));
            Assert.False(LogicLayer.SecurePasswordHasher.Verify(hash, hash2));

            Assert.False(LogicLayer.SecurePasswordHasher.Verify("SOMETHINGRANDOM4145", hash3));
            Assert.False(LogicLayer.SecurePasswordHasher.Verify("mypassword", hash3));
            Assert.False(LogicLayer.SecurePasswordHasher.Verify(hash3, hash3));
        }
    }
}
