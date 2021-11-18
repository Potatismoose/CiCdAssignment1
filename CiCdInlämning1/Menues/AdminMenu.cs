using CiCdInlämning1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiCdInlämning1.Menues
{
    class AdminMenu
    {
        private List<string> MenuOptions = new() { "Visa användare", "Skapa användare", "Ta bort användare"};
        private List<char> MenuLetter = new() { 'A', 'B', 'C', 'D', 'E', 'F' };
        ISaveable User;

        public AdminMenu(ISaveable user)
        {
            User = user;
        }

        public void Start()
        {
            bool exit = false;
            
                Console.WriteLine();
                Console.WriteLine($"Adminmeny");
               
                for (int i = 0; i < MenuOptions.Count; i++)
                {
                        Console.WriteLine($"{MenuLetter[i]}. {MenuOptions[i]}");
                }

               

        }
    }
}
