using CiCdAssignment1.Controllers;
using CiCdAssignment1.Interfaces;
using CiCdAssignment1.Models.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CiCdAssignment1.Utilities
{
    public static class ReadWrite
    {
        private static readonly string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\CiCD";

        private static List<ISaveable> listOfUsers = new();

        public static void AddUserToList(ISaveable user)
        {
            if (user is not null)
            {
                foreach (var userFromlist in listOfUsers)
                {
                    if (userFromlist.Email == user.Email && userFromlist.Name == user.Name)
                    {
                        break;
                    }
                    else
                    {
                        listOfUsers.Add(user);
                    }
                }
            }
        }

        public static void CreateDummyData()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\CiCD"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\CiCD");
            }
            Deserialize();
            if (GetListOfUsers().Count == 0)
            {
                Serialize(new Admin(1, "admin1", "admin1234", "admin@admin.com", 55000, "VD"));
                Serialize(new User(2, "testgubbe1", "password1", "testgubbe1@notadmin.com", 29500, "Magister"));
                Serialize(new User(3, "testgubbe2", "password2", "testgubbe2@notadmin.com", 19700, "Lunch tant"));
                Serialize(new User(4, "testgubbe3", "password3", "testgubbe3@notadmin.com", 25000, "Pilot"));
                Deserialize();
            }
        }

        public static (bool status, string message) DeleteUserSaveFile(string userName, string password, ISaveable user)
        {
            if (user is not null)
            {
                if (user.IsAdmin
                    && userName == user.Name
                    && password == user.Password)
                {
                    return (false, "You can not remove your own account");
                }
                if (!user.IsAdmin
                    && userName != user.Name
                    )
                {
                    return (false, "No priviliges to delete other users");
                }

                foreach (var userToDelete in listOfUsers)
                {
                    if (userToDelete.Name == userName && userToDelete.Password == password)
                    {
                        UserController uc = new();
                        if (uc.RemoveUser(userToDelete))
                        {
                            Deserialize();
                            return (true, "The account is now deleted");
                        }
                        else
                        {
                            return (false, "Something failed");
                        }
                    }
                }
                return (false, "No such user was found. No one is deleted.");
            }
            return (false, "You are not a valid user for this action");
        }

        public static void Deserialize()
        {
            listOfUsers.Clear();
            foreach (var file in Directory.GetFiles(filePath))
            {
                if (Path.GetExtension(file) == ".user")
                {
                    FileStream fileStream;
                    BinaryFormatter bf = new();
                    fileStream = File.OpenRead(file);
                    listOfUsers.Add((ISaveable)bf.Deserialize(fileStream));
                    fileStream.Close();
                }
            }
        }

        public static string GetFilepath()
        {
            return filePath;
        }

        public static List<ISaveable> GetListOfUsers()
        {
            return listOfUsers;
        }

        public static void ReadFromFilesAndAddToListOfUsersAndUpdateEmployeeId()
        {
            ReadWrite.Deserialize();
            var lastUser = ReadWrite.GetListOfUsers()[^1];
            ReadWrite.WriteLastEmployeeIdToFile(lastUser.Id.ToString());
        }

        public static int ReadLastEmployeeIdFromFile()
        {
            var employeeFile = filePath + "\\" + "employeeId.info";
            return Convert.ToInt32(File.ReadAllText(employeeFile));
        }

        public static void RemoveUserFromList(ISaveable user)
        {
            if (user is not null)
            {
                foreach (var x in listOfUsers)
                {
                    if (x.Id == user.Id)
                    {
                        listOfUsers.Remove(user);
                    }
                }
            }
        }

        public static void Serialize(ISaveable user)
        {
            string fullFilePath = filePath + "\\" + user.Id + ".user";
            FileStream fileStream;
            BinaryFormatter bf = new();
            if (File.Exists(fullFilePath)) File.Delete(fullFilePath);
            fileStream = File.Create(fullFilePath);
            bf.Serialize(fileStream, user);
            fileStream.Close();
            WriteLastEmployeeIdToFile(user.Id.ToString());
        }
        public static async void WriteLastEmployeeIdToFile(string employeeId)
        {
            var employeeFile = filePath + "\\" + "employeeId.info";
            await File.WriteAllTextAsync(employeeFile, employeeId);
        }
    }
}