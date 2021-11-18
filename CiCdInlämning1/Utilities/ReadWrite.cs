using CiCdInlämning1.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace CiCdInlämning1.Utilities
{
    public static class ReadWrite
    {
        readonly static string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        static List<ISaveable> listOfUsers = new();
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

        async public static void WriteLastEmployeeIdToFile(string employeeId)
        {
            var employeeFile = filePath + "\\" + "employeeId.info";
            await File.WriteAllTextAsync(employeeFile, employeeId);
        }

        public static int ReadLastEmployeeIdFromFile()
        {
            var employeeFile = filePath + "\\" + "employeeId.info";
            return Convert.ToInt32(File.ReadAllText(employeeFile));
        }

        public static List<ISaveable> GetListOfUsers()
        {
            return listOfUsers;
        }

        public static void AddUserToList(ISaveable user)
        {
            if (user is not null)
            {
                listOfUsers.Add(user);
            }
        }

        public static void RemoveUserFromList(ISaveable user)
        {
            if (user is not null && listOfUsers.Contains(user))
            {
                listOfUsers.Remove(user);
            }
        }

        public static void ReadFromFilesAndAddToListOfUsersAndUpdateEmployeeId()
        {
            ReadWrite.Deserialize();
            var lastUser = ReadWrite.GetListOfUsers()[^1];
            ReadWrite.WriteLastEmployeeIdToFile(lastUser.Id.ToString());
        }
    }
}
