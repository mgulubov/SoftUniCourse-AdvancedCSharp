using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SortArrayOfNumbers
{
    class SortArrayOfNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the numbers please that we will please be sorting please: "); //Gotta be polite
            String[] strArray = Console.ReadLine().Split(' ');
            int[] intArray = new int[strArray.Length];

            try
            {
                intArray = strArray.Select(int.Parse).OrderBy(a => a).ToArray();
            }
            catch (Exception)
            {
                Console.WriteLine("You broke it! You fuckin' broke it. You will have to restart the program, as punishment!"); //No need to be polite
                Environment.Exit(1);
            }

            Console.WriteLine("Please thank you please!\nPlease your result please is please:"); //A little OVERpolite perhaps?!

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.Write(intArray[i]);
                if (i != intArray.Length - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}
