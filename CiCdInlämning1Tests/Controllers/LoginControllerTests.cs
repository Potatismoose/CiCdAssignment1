using CiCdInlämning1.Models.Users;
using CiCdInlämning1.Utilities;
using NUnit.Framework;

namespace CiCdInlämning1.Controllers.Tests
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

        [TestCase("testgubbe1", "password1", TestName = "Login_ValidUsername_ReturnUser")]
        [TestCase("admin1", "admin1234", TestName = "Login_ValidUsername_ReturnAdmin")]
        public void LoginTestSuccessful(string userName, string password)
        {
            Admin user = new Admin(1513212, userName, password, "administrator@admin.com", 13000, "Admin");
            ReadWrite.AddUserToList(user);

            //Act
            var result = LoginController.Login(userName, password);
            ReadWrite.RemoveUserFromList(user);
            //Assert
            Assert.That(result, Is.InstanceOf<Account>());

        }
    }
}