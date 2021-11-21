using System;

namespace CiCdAssignment1.Utilities
{
    internal static class PrintFormating
    {
        public static void PrintTextInRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        internal static void PrintTextInGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}