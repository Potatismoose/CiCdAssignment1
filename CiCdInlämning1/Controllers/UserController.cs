using CiCdInlämning1.Interfaces;
using CiCdInlämning1.Models.Users;
using CiCdInlämning1.Utilities;
using System;
using System.Text.RegularExpressions;

namespace CiCdInlämning1.Controllers
{
    class UserController
    {
        //Add and remove methods for users.
        public ISaveable CreateNewUser()
        {

            Console.Clear();
            Console.WriteLine("Create new user\n");
            ISaveable user;
            string errorMsg = default;
            string username = default;
            string password = default;
            string role = default;
            string email = default;
            int salary = 0;

            int id = ReadWrite.ReadLastEmployeeIdFromFile() + 1;
            username = InputUsername();
            InputPassword(ref password);
            InputEmail(ref email);
            InputRole(ref role);
            errorMsg = default;
            InputSalary(ref errorMsg, ref salary);
            User createdUser = new(id, username, password, email, salary, role);
            ReadWrite.Serialize(createdUser);
            ReadWrite.ReadFromFilesAndAddToListOfUsersAndUpdateEmployeeId();

            return createdUser;
        }

        private void InputSalary(ref string errorMsg, ref int salary)
        {
            do
            {

                if (!string.IsNullOrEmpty(errorMsg))
                {
                    PrintFormating.PrintTextInRed(errorMsg);
                }

                Console.Write("Salary: ");
                var inputIsInt = int.TryParse(Console.ReadLine(), out int usersSalary);

                if (inputIsInt && usersSalary > 0)
                {
                    salary = usersSalary;
                }
                else
                {
                    errorMsg = "Wrong salary or input. Must be more then 0 kr.";
                }

            } while (salary <= 0);
        }
        private void InputRole(ref string role)
        {
            do
            {
                Console.Write("Role: ");
                var userInput = Console.ReadLine();
                role = userInput;

            } while (string.IsNullOrEmpty(role));
        }
        private void InputEmail(ref string email)
        {
            do
            {
                Console.Write("Email: ");
                var userInput = Console.ReadLine();
                var result = ValidateEmail(userInput);
                if (result.result is false)
                {
                    PrintFormating.PrintTextInRed(result.errorMsg);
                }
                else
                {
                    email = userInput;
                    PrintFormating.PrintTextInGreen("Successfully stored");
                    break;
                }
            } while (true);
        }
        private void InputPassword(ref string password)
        {
            bool correctPassword = false;
            do
            {
                Console.Write("Password: ");
                var userInputPassword = Console.ReadLine();
                var result = ValidatePassword(userInputPassword);
                correctPassword = result.result;
                GiveUserFeedbackOnInput(ref password, result, userInputPassword);
            } while (!correctPassword);
        }
        private string InputUsername()
        {
            string username = default;
            do
            {
                Console.Write("Username: ");
                username = Console.ReadLine();
            } while (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username));
            return username;
        }
        private void GiveUserFeedbackOnInput(ref string password, (string errorMsg, bool result) result, string userInputPassword)
        {
            if (result.result is false)
            {
                PrintFormating.PrintTextInRed(result.errorMsg);
            }
            else
            {
                password = userInputPassword;
                PrintFormating.PrintTextInGreen("Successfully stored");
            }
        }
        private (string errorMsg, bool result) ValidatePassword(string input)
        {
            var ErrorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(input))
            {
                return ("Password can not be empty", false);
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasChar = new Regex(@"[A-Öa-ö]+");


            if (!hasChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one letter.";
                return (ErrorMessage, false);
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one numeric value.";
                return (ErrorMessage, false);
            }
            else
            {
                return ("Password matches the password criteria.", true);
            }
        }
        private (string errorMsg, bool result) ValidateEmail(string input)
        {
            var ErrorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(input))
            {
                return ("Email can not be empty", false);
            }

            var hasChar = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$+");

            if (!hasChar.IsMatch(input))
            {
                ErrorMessage = "Email does not match criteria";
                return (ErrorMessage, false);
            }

            else
            {
                return ("Email matches the criteria.", true);
            }
        }

    }
}
