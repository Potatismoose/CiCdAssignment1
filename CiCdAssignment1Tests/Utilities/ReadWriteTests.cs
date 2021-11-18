using NUnit.Framework;
using CiCdAssignment1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiCdAssignment1.Models.Users;

namespace CiCdAssignment1.Utilities.Tests
{
    [TestFixture()]
    public class ReadWriteTests
    {
        [Test()]
        public void DeserializeTest()
        {
            // Act
            ReadWrite.Serialize(new User(ReadWrite.ReadLastEmployeeIdFromFile() + 1, "Johan falk", "testar123", "bad@bad.com", 55000, "Astronaut"));
            ReadWrite.Deserialize();

            // Arrange
            var actual = ReadWrite.GetListOfUsers();

            // Assert
            Assert.That(actual, Is.Not.Null);
        }

        [Test()]
        public void GetListOfUsersTest()
        {
            var actual = ReadWrite.GetListOfUsers();
            Assert.That(actual.Count, Is.AtLeast(1));
        }
    }
}