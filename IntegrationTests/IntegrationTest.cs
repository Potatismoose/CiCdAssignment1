using CiCdAssignment1.Controllers;
using CiCdAssignment1.Models.Users;
using CiCdAssignment1.Utilities;
using NUnit.Framework;
using System;
using System.Linq;

namespace IntegrationTests
{
    [TestFixture()]
    public class Tests
    {
        [Test]
        public void CreateAndLoginUser()
        {
            //Arrage
            Random rand = new();
            var randomNr = rand.Next();
            User createdUser = new(
                randomNr,
                "Helge",
                "Gubbstrutt1",
                "helge@fullgubbe.nu",
                12000,
                "Vaktmästare"
                );

            //Act
            ReadWrite.AddUserToList(createdUser);
            var loggedInUser = LoginController.Login("Helge", "Gubbstrutt1");
            var listOfUsers = ReadWrite.GetListOfUsers();

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(loggedInUser, Is.InstanceOf<Account>());
                Assert.That(listOfUsers.Any(p => p.Id == loggedInUser.Id));
            });
        }
    }
}