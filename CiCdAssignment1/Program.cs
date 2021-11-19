using CiCdAssignment1.Menues;
using CiCdAssignment1.Models.Users;
using CiCdAssignment1.Utilities;
using System;
using System.IO;
using System.Reflection;

namespace CiCdAssignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadWrite.CreateDummyData();
            Login.Start();
        }
    }
}
