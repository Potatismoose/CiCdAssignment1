using System;

namespace CiCdInlämning1.Models.Users
{

    [Serializable]
    public class Admin : User
    {
        public Admin(int id, string name, string password, string email, int salary, string role) : base(id, name, password, email, salary, role)
        {
            base.IsAdmin = true;
        }
    }
}
