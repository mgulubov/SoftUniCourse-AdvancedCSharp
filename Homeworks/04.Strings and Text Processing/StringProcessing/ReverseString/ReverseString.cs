using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            Console.Write("String to reverse: ");
            String str = Console.ReadLine().Trim();

            PrintString("Original: ", str);
            str = ReverseTheString(str);
            PrintString("Reversed: ", str);
        }

        private static String ReverseTheString(String strToReverse)
        {
            StringBuilder strBuild = new StringBuilder();
            for (int i = strToReverse.Length - 1; i >= 0; i--)
            {
                strBuild.Append(strToReverse[i]);
            }

            return strBuild.ToString();
        }

        private static void PrintString(String message, String strToPrint)
        {
            Console.WriteLine("{0}{1}", message, strToPrint);
        }
    }
}
