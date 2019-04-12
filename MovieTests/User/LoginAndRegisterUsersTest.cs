using ASPNETCinema.Logic;
using Interfaces;
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
        ThingEqualityComparer comparer = new ThingEqualityComparer();
        List<IUser> users = new List<IUser>();
        List<IUser> users2 = new List<IUser>();

        public LoginAndRegisterUsersTest()
        {
            _userLogic = new UserLogic(new UserContextMock());
        }

        //other things
        //List
        //Add
        //details
        //Edit
        //Delete

        [Fact]
        public void Should_RegisterAnUser_WhenRegisteringAnUser()
        {
            //Arrange
            var userLogic = new UserLogic(new UserContextMock());
            if (userLogic.GetUser("AddName", "AddPassword") != null)
            {
                Assert.True(false);
            }
            
            //Act
            userLogic.AddUser(1, "AddName", "AddPassword", "AddPassword", 0);
            var user = userLogic.GetUser("AddName", "AddPassword");
            var user2 = userLogic.GetUser("AddName", "AddPassword");

            //Assert
            Assert.True(user.Id == 1 && user.Name == "AddName" && user.Administrator == 0);
            Assert.False(userLogic.AddUser(1, "AddName", "AddPassword", "NotTheSamePassword", 0));
            Assert.False(userLogic.AddUser(1, "AddName", "NotTheSamePassword", "AddPassword", 0));
            Assert.True(user.Equals(user2));
        }

        [Fact]
        public void Should_ReturnTrue_WhenTheLoginIsCorrect()
        {
            var userLogic = new UserLogic(new UserContextMock());
            userLogic.AddUser(1, "AddName", "AddPassword", "AddPassword", 0);

            Assert.True(userLogic.CheckIfThisLoginIsCorrect("AddName", "AddPassword"));
            Assert.False(userLogic.CheckIfThisLoginIsCorrect("AddName", "WRONGPASSWORD"));
            Assert.False(userLogic.CheckIfThisLoginIsCorrect("NotAName", "AddPassword"));
        }

        [Fact]
        public void Should_GetRoleUser_WhenGettingRoleUser()
        {
            var userLogic = new UserLogic(new UserContextMock());
            userLogic.AddUser(1, "RoleName", "RolePassword", "RolePassword", 1);
            userLogic.AddUser(2, "RoleName", "RolePassword", "RolePassword", 0);
            userLogic.AddUser(3, "RoleName", "RolePassword", "RolePassword", 2);
            var user = userLogic.GetUser("RoleName", "RolePassword");
            
            Assert.True(userLogic.GetRoleUser(user.Id) == "Administrator");
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
       
        

        class ThingEqualityComparer : IEqualityComparer<IUser>
        {
            public bool Equals(IUser x, IUser y)
            {
                if (x == null || y == null)
                    return false;

                return (x.Id == y.Id && x.Name == y.Name);
            }

            public int GetHashCode(IUser obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
