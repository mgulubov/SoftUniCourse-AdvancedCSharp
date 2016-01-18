using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SubsetSums
{
    class SubsetSums
    {
        private static List<List<int>> _results;
        private static int[] _intArray;
        private static int _n;

        static void Main(string[] args)
        {
            Console.Write("_n: ");
            _n = int.Parse(Console.ReadLine());
            Console.Write("_intArray: ");
            _intArray = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();
            _results = new List<List<int>>();

            //I admit it- algorithm copied and re-factored a bit, from here:
            //http://stackoverflow.com/questions/1952153/what-is-the-best-way-to-find-all-combinations-of-items-in-an-array
            //SUE ME! I DOUBLE-DARE YOU! :P

            var subSeq = new List<int>();
            GetSubSequences(0, subSeq);
            PrintResults();
        }

        private static void GetSubSequences(int index, List<int> list)
        {   //Now this makes little sense, doesn't it?! A bottom-up recursive algorithm :)
            //Anyway, I wasn't able to convert it to an iterative form
            if (list.Sum() == _n)
            {
                _results.Add(new List<int>(list));
                return;
            }

            for (int i = index; i < _intArray.Length; i++)
            {
                list.Add(_intArray[i]);
                GetSubSequences(i + 1, list);
                list.RemoveAt(list.Count - 1); //Ugly fix because of the bottom-up form of the recursion. Fuck it - it works!
            }
        }

        private static void PrintResults()
        {
            if (_results.Count > 0 && _results[0].Count > 0) //There's a bug here. _results.Count is always >= 1 :)
            {
                foreach (var list in _results)
                {
                    Console.WriteLine("{0} = {1}", String.Join(" + ", list), _n);
                }
            }
            else
            {
                Console.WriteLine("No matching subsets.");
            }
        }
    }
}
