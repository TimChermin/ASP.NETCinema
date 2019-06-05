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
    public class HashingTests
    {
        [Fact]
        public void Should_VerifyPassword_WhenGivingTheCorrectPassword()
        {
            //Arrange
            var hash = LogicLayer.SecurePasswordHasher.Hash("mypassword");

            //Act
            bool correctPassword = LogicLayer.SecurePasswordHasher.Verify("mypassword", hash);

            //Assert
            Assert.True(correctPassword);
        }

        [Fact]
        public void Should_NotVerifyPassword_WhenGivingTheWrongPassword()
        {
            //Arrange
            var hash = LogicLayer.SecurePasswordHasher.Hash("mypassword");

            //Act
            bool correctPassword = LogicLayer.SecurePasswordHasher.Verify("mypassworde", hash);

            //Assert
            Assert.False(correctPassword);
        }

        [Fact]
        public void Should_NotVerifyPassword_WhenGivingTheHashAsPassword()
        {
            //Arrange
            var hash = LogicLayer.SecurePasswordHasher.Hash("mypassword");

            //Act
            bool correctPassword = LogicLayer.SecurePasswordHasher.Verify(hash, hash);

            //Assert
            Assert.False(correctPassword);
        }
    }
}
