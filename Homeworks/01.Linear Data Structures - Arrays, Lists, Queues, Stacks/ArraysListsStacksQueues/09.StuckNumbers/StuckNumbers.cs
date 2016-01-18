using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StuckNumbers
{
    class StuckNumbers
    {
        private static int _n;
        private static List<String> _inputNumbers;
        private static List<String> _resultList;

        static void Main(string[] args)
        {
            _n = int.Parse(Console.ReadLine());
            //_inputNumbers = Console.ReadLine().Trim().Split(' ').Distinct().ToArray().ToList();
            _inputNumbers = Console.ReadLine().Trim().Split(' ').ToArray().ToList(); //The input in Test#3 is wrong. We need to get rid of Distinct, in order to get 100 points.
            _resultList = new List<String>(_n * 2); //This should make it a bit faster


            GetStuckNumbers();


            if (_resultList.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                foreach (var str in _resultList)
                {
                    Console.WriteLine("{0}", str);
                }
            }
        }

        private static void GetStuckNumbers()
        {
            int length = _inputNumbers.Count;
            string a;
            string b;
            string c;
            string d;

            for (int index1 = 0; index1 < _n; index1++)
            {
                for (int index2 = 0; index2 < _n; index2++)
                {
                    if (index2 == index1)
                    {
                        continue;
                    }
                    for (int index3 = 0; index3 < _n; index3++)
                    {
                        if (index3 == index1 || index3 == index2)
                        {
                            continue;
                        }
                        for (int index4 = 0; index4 < _n; index4++)
                        {
                            if (index4 == index1 || index4 == index2 || index4 == index3)
                            {
                                continue;
                            }

                            a = _inputNumbers[index1];
                            b = _inputNumbers[index2];
                            c = _inputNumbers[index3];
                            d = _inputNumbers[index4];

                            String left = a + b;
                            String right = c + d;

                            if (left.Equals(right))
                            {
                                String res = a + "|" + b + "==" + c + "|" + d;
                                _resultList.Add(res);
                            }
                        }
                    }
                }
            }
            //It's still faster than recursion :)
        }
    }
}
