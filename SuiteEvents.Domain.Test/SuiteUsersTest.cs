using System;
using NUnit.Framework;
using SuiteEvents.Domain.Entities;

namespace SuiteEvents.Domain.Test
{
    [TestFixture]
    public class SuiteUsersTest
    {

        [Test]
        public void CreateUserCheckUserName()
        {
            var currentUser = new SuiteUsers(Guid.NewGuid(), "SuiteEvents", "username", "secret", "pippo@pippo.it", "nome", "cognome");

            Assert.AreNotEqual(string.Empty, currentUser.UserName);
        }

        [Test]
        public void CreateUserCheckEmail()
        {
            var currentUser = new SuiteUsers(Guid.NewGuid(), "SuiteEvents", "username", "secret", "pippo@pippo.it", "nome", "cognome");

            Assert.AreNotEqual(string.Empty, currentUser.Email);
        }
    }
}
