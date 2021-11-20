using NUnit.Framework;
using CiCdAssignment1.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiCdAssignment1.Models.Users.Tests
{
    [TestFixture()]
    public class AccountTests
    {
        User user = null;

        [SetUp]
        public void SetUp()
        {
            user = new(38, "Brian Deegan", "dangerboy38", "deegans@motox.com", 1600000, "Rider");
        }

        [TearDown]
        public void TearDown()
        {
            user = null;
        }

        [Test()]
        public void ToStringTest()
        {
            // Act
            var result = user.ToString();
            // Assert
            Assert.That(result, Does.Contain("Har adminbehörighet"));
        }

        [Test()]
        public void UserSalaryTest()
        {
            // Act
            var result = user.Salary;
            // Assert
            Assert.That(result, Is.EqualTo(1600000));
        }

        [Test()]
        public void CompanyRoleTest()
        {
            // Act
            var result = user.Role;
            // Assert
            Assert.That(result, Is.EqualTo("Rider"));
        }

        [Test()]
        public void ViewActiveUsersAndPasswordsTest()
        {
            // Act
            var result = user.ToString();
            // Assert
            Assert.That(result, Does.Contain("Har adminbehörighet"));
        }
    }
}