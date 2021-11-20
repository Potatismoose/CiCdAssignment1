using CiCdAssignment1.Interfaces;
using System;
using System.Collections.Generic;

namespace CiCdAssignment1.Menues
{
    internal class AdminMenu
    {
        private List<char> MenuLetter = new() { 'A', 'B', 'C', 'D', 'E', 'F' };
        private List<string> MenuOptions = new() { "Visa användare", "Skapa användare", "Ta bort användare" };
        private ISaveable User;

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