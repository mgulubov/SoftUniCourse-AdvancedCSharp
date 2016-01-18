using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BiggerNumber
{
    class BiggerNumber
    {
        static void Main(string[] args)
        {
            Console.Write("First Number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Second Number: ");
            int secondNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Result: {0}", GetMax(firstNumber, secondNumber));
        }

        private static int GetMax(int left, int right)
        {
            if (right > left)
            {
                return right;
            }

            return left;
        }
    }
}
