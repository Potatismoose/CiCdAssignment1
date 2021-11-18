using CiCdInlämning1.Menues;
using CiCdInlämning1.Models.Users;
using CiCdInlämning1.Utilities;

namespace CiCdInlämning1
{
    class Program
    {
        static void Main(string[] args)
        {

            ReadWrite.Deserialize();
            if (ReadWrite.GetListOfUsers().Count == 0)
            {
                ReadWrite.Serialize(new Admin(1, "admin1", "admin1234", "admin@admin.com", 55000, "VD"));
                ReadWrite.Serialize(new User(2, "testgubbe1", "password1", "testgubbe1@notadmin.com", 29500, "Magister"));
                ReadWrite.Serialize(new User(3, "testgubbe2", "password2", "testgubbe2@notadmin.com", 19700, "Lunch tant"));
                ReadWrite.Serialize(new User(4, "testgubbe3", "password3", "testgubbe3@notadmin.com", 25000, "Pilot"));
                ReadWrite.Deserialize();
            }

            Login.Start();
        }
    }
}
