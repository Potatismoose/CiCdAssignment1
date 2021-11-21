using CiCdAssignment1.Interfaces;
using CiCdAssignment1.Utilities;
using System.Linq;

namespace CiCdAssignment1.Controllers
{
    public static class LoginController
    {
        public static ISaveable Login(string username, string password)
        {
            if (username is null || password is null)
            {
                return null;
            }
            else
            {
                var listOfUsers = ReadWrite.GetListOfUsers();
                return listOfUsers?.FirstOrDefault(x => x.Name == username.Trim() && x.Password == password.Trim());
            }
        }
    }
}