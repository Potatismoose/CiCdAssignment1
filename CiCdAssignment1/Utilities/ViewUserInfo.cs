using CiCdAssignment1.Interfaces;
using CiCdAssignment1.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiCdAssignment1.Utilities
{
    class ViewUserInfo
    {
        public static void Salary(ISaveable user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                Console.WriteLine(user.Salary);
            }
        }

        public static void CompanyRole(ISaveable user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                Console.WriteLine(user.Role);
            }
        }
    }
}
