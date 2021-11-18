using CiCdInlämning1.Interfaces;
using CiCdInlämning1.Utilities;
using System.Linq;

namespace CiCdInlämning1.Controllers
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
