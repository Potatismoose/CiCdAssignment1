using CiCdAssignment1.Models.Users;
using NUnit.Framework;
using System;

namespace CiCdAssignment1.Utilities.Tests
{
    [TestFixture()]
    public class ReadWriteTests
    {
        [Test()]
        public void GetListOfUsersTest()
        {
            Random rand = new();
            var randomNr = rand.Next();
            ReadWrite.AddUserToList(new User(randomNr, "Börje Blekfis", "blekis1", "blekarn@hotmail.com", 15000, "Städare"));
            var actual = ReadWrite.GetListOfUsers();
            Assert.That(actual.Count, Is.AtLeast(1));
        }
    }
}