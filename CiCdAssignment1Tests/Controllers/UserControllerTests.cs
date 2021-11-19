//using NUnit.Framework;
//using CiCdAssignment1.Controllers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using CiCdAssignment1.Models.Users;
//using CiCdAssignment1.Utilities;

//namespace CiCdAssignment1.Controllers.Tests
//{
//    [TestFixture()]
//    public class UserControllerTests
//    {
//        private int tempId;
//        [SetUp]
//        public void Setup() {
//            Random rand = new();
//            tempId = rand.Next();
//        }

//        [TestCase("RemoveThisUser", "Password1", "myemail@gmail.com", 23455, "Like a boss")]
//        public void RemoveUserTest(string name, string password, string email, int salary, string role)
//        {
//            //Arrange
//            User user = new(tempId, name, password, email, salary, role);
//            ReadWrite.AddUserToList(user);
//            //Act
//        }
//    }
//}