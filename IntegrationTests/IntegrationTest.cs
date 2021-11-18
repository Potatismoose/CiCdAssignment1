using CiCdAssignment1.Controllers;
using CiCdAssignment1.Models.Users;
using CiCdAssignment1.Utilities;
using NUnit.Framework;
using System.Linq;
using System.Reflection;

namespace IntegrationTests
{
    [TestFixture()]
    public class Tests
    {
        [Test]
        public void CreateLoginRemoveUser()
        {
            //Arrage
            
            User createdUser = new(
                ReadWrite.ReadLastEmployeeIdFromFile() + 1,
                "Helge",
                "Gubbstrutt1",
                "helge@fullgubbe.nu",
                12000,
                "Vaktmästare"
                );


            //Act
            ReadWrite.Serialize(createdUser);
            ReadWrite.ReadFromFilesAndAddToListOfUsersAndUpdateEmployeeId();
            ReadWrite.Deserialize();
            
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