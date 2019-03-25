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
            bool found = false;
            var userLogic = new UserLogic(new UserContextMock());
            if (userLogic.GetUser("AddName", "AddPassword") != null)
            {
                Assert.True(false);
            }
            

            //Act
            userLogic.AddUser(1, "AddName", "AddPassword", "AddPassword", 0);
            var user = userLogic.GetUser("AddName", "AddPassword");
            if (user.Id == 1 && user.Name == "AddName" && user.Administrator == 0)
            {
                found = true;
            }

            //Assert
            Assert.True(found);
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

        /*
        [Fact]
        public void Should_EditAnUserFromTheList_WhenEditingAnUser()
        {
            //Arrange
            var userLogic = new UserLogic(new UserContextMock());
            users = userLogic.GetUsers().ToList();
            int id = users[0].Id;
            string name = users[0].Name;
            bool found = false;
            bool count = false;

            //Act
            userLogic.EditUser(users[0].Id, "Edited");
            users2 = userLogic.GetUsers().ToList();

            if (users.Count() == users2.Count())
            {
                count = true;
            }

            foreach (var user in users2)
            {
                if (user.Id == id && user.Name == "Edited")
                {
                    found = true;
                }
            }

            //Assert
            Assert.True(count);
            Assert.True(found);
        }
        */

        /*[Fact]
        public void Should_DeleteAnUserFromTheList_WhenDeleteingAnUser()
        {
            //Arrange
            var userLogic = new UserLogic(new UserContextMock());
            users = userLogic.GetUsers().ToList();
            int id = users[0].Id;
            string name = users[0].Name;
            bool found = false;
            bool count = false;

            //Act
            userLogic.DeleteUser(users[0].Id);
            users2 = userLogic.GetUsers().ToList();

            if (users.Count() != users2.Count())
            {
                count = true;
            }

            foreach (var user in users2)
            {
                if (user.Id == id && user.Name == name)
                {
                    found = true;
                }
            }

            Assert.False(found);
            Assert.True(count);
        }
        */



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
