using CiCdAssignment1.Menues;
using CiCdAssignment1.Utilities;

namespace CiCdAssignment1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ReadWrite.CreateDummyData();
            Login.Start();
        }
    }
}