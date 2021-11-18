using NUnit.Framework;
using CiCdAssignment1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CiCdAssignment1.Models.Users;
using CiCdAssignment1.Utilities;

namespace CiCdAssignment1.Controllers.Tests
{
    [TestFixture()]
    public class LoginControllerTests
    {
        [TestCase("S/M Bosse", "HejGummiBralla", TestName = "Login_InvalidUsername_ReturnNull")]
        [TestCase(null, "HejGummiBralla", TestName = "Login_NullUsername_ReturnNull")]
        [TestCase("S/M Bosse", null, TestName = "Login_NullPassword_ReturnNull")]
        [TestCase(null, null, TestName = "Login_NullPasswordAndNullUsername_ReturnNull")]
        public void LoginTestFail(string userName, string password)
        {
            //Act
            var result = LoginController.Login(userName, password);
            //Assert
            Assert.That(result, Is.Null);
        }

        
    }
}