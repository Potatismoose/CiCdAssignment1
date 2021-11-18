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