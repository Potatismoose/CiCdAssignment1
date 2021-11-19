using CiCdAssignment1.Interfaces;
using CiCdAssignment1.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiCdAssignment1.Utilities
{
    public static class ViewUserInfo
    {
        public static void Salary(ISaveable user)
        {
            if (user is null)
            {
                return;
            }
            else
            {
                Console.WriteLine(user.Salary);
            }
            Console.ReadKey();
        }

        public static void CompanyRole(ISaveable user)
        {
            if (user is null)
            {
                return;
            }
            else
            {
                Console.WriteLine(user.Role);
            }
            Console.ReadKey();
        }

        public static void ViewActiveUsersAndPasswords()
        {
            var list = ReadWrite.GetListOfUsers();
            if (list is null)
            {
                return;
            }
            else
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"User Id: { item.Id } Username: { item.Name } Password: { item.Password }");
                }
            }
            Console.ReadKey();
        }
    }
}
