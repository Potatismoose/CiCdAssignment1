using NUnit.Framework;
using CiCdInlämning1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiCdInlämning1.Models.Users;

namespace CiCdInlämning1.Utilities.Tests
{
    [TestFixture()]
    public class ReadWriteTests
    {
        [Test()]
        public void DeserializeTest()
        {
            // Act
            ReadWrite.Serialize(new User(1, "Johan falk", "testar123", "bad@bad.com", 55000, "Astronaut"));
            ReadWrite.Deserialize();

            // Arrange
            var actual = ReadWrite.GetListOfUsers();

            // Assert
            Assert.That(actual, Is.Not.Null);
        }
    }
}