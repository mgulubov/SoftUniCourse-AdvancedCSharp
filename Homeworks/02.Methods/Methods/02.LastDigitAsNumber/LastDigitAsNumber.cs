using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LastDigitAsNumber
{
    class LastDigitAsNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Number: ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("Last Digit Is: {0}", GetLastDigitAsWord(num));
        }

        private static String GetLastDigitAsWord(int num)
        {
            char lastDigit = num.ToString()[num.ToString().Length - 1];
            switch (lastDigit)
            {
                case '1':
                    return "One";
                case '2':
                    return "Two";
                case '3':
                    return "Three";
                case '4':
                    return "Four";
                case '5':
                    return "Five";
                case '6':
                    return "Six";
                case '7':
                    return "Seven";
                case '8':
                    return "Eight";
                case '9':
                    return "Nine";
                default:
                    return "Zero";
            }
        }
    }
}
