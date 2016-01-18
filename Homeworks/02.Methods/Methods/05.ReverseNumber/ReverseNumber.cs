using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ReverseNumber
{
    class ReverseNumber
    {
        static void Main(string[] args)
        {
            Console.Write("Double Number: ");
            double doubleNum = double.Parse(Console.ReadLine());

            double reversedNum = GetReversedNum(doubleNum);
            Console.WriteLine("Reversed: {0}", reversedNum);
        }

        private static double GetReversedNum(double num)
        {
            return double.Parse(new String(num.ToString().ToCharArray().Reverse().ToArray()));
        }
    }
}
