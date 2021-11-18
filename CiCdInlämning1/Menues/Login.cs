using CiCdInlämning1.Controllers;
using CiCdInlämning1.Interfaces;
using CiCdInlämning1.Utilities;
using System;

namespace CiCdInlämning1.Menues
{
    static class Login
    {
        public static void Start()
        {
            ISaveable user;
            string errorMsg = default;
            do
            {
                do
                {
                    Console.Clear();
                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        PrintFormating.PrintTextInRed(errorMsg);
                        errorMsg = default;
                    }
                    Console.Write("Användarnamn: ");
                    var username = Console.ReadLine();
                    Console.Write("Lösenord: ");
                    var password = Console.ReadLine();
                    user = LoginController.Login(username, password);
                    if (user is null)
                    {
                        errorMsg = "Felaktigt användarnamn eller lösenord";
                    }

                } while (user is null);

                MainMenu mm = new(user);
                mm.Start();
            } while (true);
            
        }
    }
}
