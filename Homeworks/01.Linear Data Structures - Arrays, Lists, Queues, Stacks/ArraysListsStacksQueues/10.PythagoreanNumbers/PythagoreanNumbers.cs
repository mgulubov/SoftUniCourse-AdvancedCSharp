using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PythagoreanNumbers
{
    class PythagoreanNumbers
    {
        private static int _n;
        private static int[] _numbersArray;
        private static List<String> _resultsList;

        static void Main(string[] args)
        {
            _n = int.Parse(Console.ReadLine());
            _numbersArray = new int[_n];
            _resultsList = new List<String>();

            PopulateNumbersArray();

            GetPythagorianNumbers();

            PrintResults();
        }

        private static void PrintResults()
        {
            if (_resultsList.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                foreach (var str in _resultsList)
                {
                    Console.WriteLine(str);
                }
            }
        }

        private static void PopulateNumbersArray()
        {
            for (int i = 0; i < _n; i++)
            {
                _numbersArray[i] = int.Parse(Console.ReadLine());
            }
        }

        private static void GetPythagorianNumbers()
        {
            int a;
            int b;
            int c;
            for (int index1 = 0; index1 < _n; index1++)
            {
                for (int index2 = 0; index2 < _n; index2++)
                {
                    for (int index3 = 0; index3 < _n; index3++)
                    {
                        a = _numbersArray[index1];
                        b = _numbersArray[index2];
                        c = _numbersArray[index3];

                        if (a > b)
                        {
                            break;
                        }

                        if (PythagorTheoremMatch(a, b, c))
                        {
                            _resultsList.Add(FormResultString(a, b, c));
                        }
                    }
                }
            }
        }

        private static bool PythagorTheoremMatch(int a, int b, int c)
        {
            return Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2);
        }

        private static String FormResultString(int a, int b, int c)
        {
            return a + "*" + a + " + " + b + "*" + b + " = " + c + "*" + c;
        }
    }
}
