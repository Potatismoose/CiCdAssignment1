using CiCdAssignment1.Controllers;
using CiCdAssignment1.Interfaces;
using CiCdAssignment1.Models.Users;
using CiCdAssignment1.Utilities;
using System;
using System.Collections.Generic;

namespace CiCdAssignment1.Menues
{
    class MainMenu
    {
        readonly private string wrongChoice = "Error, wrong menu choice.";
        private List<string> MenuOptions = new() { "Lön", "Anställning", "Ta bort användare", "Logga ut", "Avsluta programmet" };
        ISaveable Activeuser;

        public MainMenu(ISaveable user)
        {
            Activeuser = user;
        }

        public void Start()
        {
            bool exit = false;
            string errorMsg = default;
            do
            {
                Console.Clear();
                Console.Write($"Inloggad som: {Activeuser.Name} ");
                if (Activeuser.IsAdmin)
                {
                    PrintFormating.PrintTextInGreen("(Admin)");
                }
                else
                {
                    Console.WriteLine("\n");
                }
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    PrintFormating.PrintTextInRed(errorMsg);
                    errorMsg = default;
                }
                for (int i = 0; i < MenuOptions.Count; i++)
                {
                    if (Activeuser.IsAdmin && MenuOptions[i].Contains("Ta bort användare"))
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. {MenuOptions[i]}");
                    }
                }

                Console.WriteLine("\n");

                if (Activeuser.IsAdmin)
                {
                    AdminMenu am = new(Activeuser);
                    am.Start();

                }

                Console.Write("Gör ditt val > ");
                var userChoice = Console.ReadLine();
                var choiceIsNumber = int.TryParse(userChoice, out int menuChoice);
                if (choiceIsNumber)
                {
                    switch (menuChoice)
                    {
                        case 1:
                            ViewUserInfo.Salary(Activeuser);
                            break;
                        case 2:
                            ViewUserInfo.CompanyRole(Activeuser);
                            break;
                        case 3:
                            if (Activeuser.IsAdmin)
                            {
                                errorMsg = wrongChoice;
                            }
                            else
                            { 
                            //TODO: Implement remove user
                            }
                            break;
                        case 4:
                            exit = true;
                            break;
                        case 5:
                            Environment.Exit(1);
                            break;
                        default:
                            errorMsg = wrongChoice;
                            break;
                    }
                }
                else {
                    if (Activeuser.IsAdmin)
                    {
                        switch (userChoice.ToLower())
                        {
                            case "a":
                                //TODO: Implement see all users
                                break;
                            case "b":
                                UserController uc = new();
                                var createdUser = uc.CreateNewUser();
                                if (createdUser is not null)
                                {
                                    Console.WriteLine($"Skapade användaren: {createdUser.Name}");
                                    Console.WriteLine($"Skapade lösenordet: {createdUser.Password}");
                                    Console.WriteLine($"Skapade email: {createdUser.Email}");
                                    Console.WriteLine($"Skapade lön: {createdUser.Salary}");
                                    Console.WriteLine($"Skapade Id: {createdUser.Id}");
                                }
                                else {
                                    PrintFormating.PrintTextInRed("Användaren kunde inte skapas");
                                }
                                
                                Console.ReadKey();

                                break;
                            case "c":
                                
                                break;
                            default:
                                errorMsg = wrongChoice;
                                break;
                        }
                    }
                    else {
                        errorMsg = wrongChoice;
                    }
                }
                
            } while (!exit);

        }
    }
}
