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
        UserLogic _userLogic;
        UserModel user = new UserModel();
        UserModel user2 = new UserModel();
        UserModel user3 = new UserModel();
        UserModel user1 = new UserModel();
        IMapper _mapper;
        List<UserModel> users = new List<UserModel>();
        List<UserModel> users2 = new List<UserModel>();

        public LoginAndRegisterUsersTest()
        {
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = mockMapper.CreateMapper();
            _userLogic = new UserLogic(new UserContextMock(), _mapper);
        }
        

        [Fact]
        public void Should_RegisterAnUser_WhenRegisteringAnUser()
        {
            //Arrange
            var userLogic = new UserLogic(new UserContextMock(), _mapper);
            if (userLogic.GetUser("AddName", "AddPassword") != null)
            {
                Assert.True(false);
            }

            //Act
            UserModel user = new UserModel { Id = 1, Name = "AddName", Password = "AddPassword", ConfirmPassword = "AddPassword", Administrator = 0 };
            UserModel user2 = new UserModel { Id = 1, Name = "AddName", Password = "AddPassword", ConfirmPassword = "AddPassword", Administrator = 0 };
            userLogic.AddUser(user);
            user = userLogic.GetUser("AddName", "AddPassword");
            user2 = userLogic.GetUser("AddName", "AddPassword");

            //Assert
            Assert.True(user.Id == 1 && user.Name == "AddName" && user.Administrator == 0);
            Assert.False(userLogic.AddUser(new UserModel { Id = 1, Name = "AddName", Password = "AddPassword", ConfirmPassword = "NotTheSamePassword", Administrator = 0 }));
            Assert.False(userLogic.AddUser(new UserModel { Id = 1, Name = "AddName", Password = "NotTheSamePassword", ConfirmPassword = "AddPassword", Administrator = 0 }));
        }

        [Fact]
        public void Should_ReturnTrue_WhenTheLoginIsCorrect()
        {
            var userLogic = new UserLogic(new UserContextMock(), _mapper);
            userLogic.AddUser(new UserModel { Id = 1, Name = "AddName", Password = "AddPassword", ConfirmPassword = "AddPassword", Administrator = 0 });

            Assert.True(userLogic.CheckIfThisLoginIsCorrect("AddName", "AddPassword"));
            Assert.False(userLogic.CheckIfThisLoginIsCorrect("AddName", "WRONGPASSWORD"));
            Assert.False(userLogic.CheckIfThisLoginIsCorrect("NotAName", "AddPassword"));
        }

        [Fact]
        public void Should_GetRoleUser_WhenGettingRoleUser()
        {
            var userLogic = new UserLogic(new UserContextMock(), _mapper);
            UserModel user = new UserModel { Id = 1, Name = "RoleName", Password = "RolePassword", ConfirmPassword = "RolePassword", Administrator = 1 };
            UserModel user2 = new UserModel { Id = 2, Name = "RoleName", Password = "RolePassword", ConfirmPassword = "RolePassword", Administrator = 0 };
            UserModel user3 = new UserModel { Id = 3, Name = "RoleName", Password = "RolePassword", ConfirmPassword = "RolePassword", Administrator = 2 };
            userLogic.AddUser(user);
            userLogic.AddUser(user2);
            userLogic.AddUser(user3);

            UserModel user1 = new UserModel();
            user1 = userLogic.GetUser("RoleName", "RolePassword");
            
            Assert.True(userLogic.GetRoleUser(user1.Id) == "Administrator");
            Assert.True(userLogic.GetRoleUser(2) == "Normal");
            Assert.True(userLogic.GetRoleUser(3) == "Employee");
            Assert.False(userLogic.GetRoleUser(1) == "Normal" || userLogic.GetRoleUser(1) == "Employee");
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
