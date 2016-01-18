using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.LongestIncreasingSequence
{
    class LongestIncreasingSequence
    {
        private static List<List<int>> _results;
        private static int[] _intArray;

        static void Main(string[] args)
        {
            Console.Write("nUmb3RZZ: ");
            _intArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            _results = new List<List<int>>();

            GetSubSequences();
            PrintResults();
        }

        private static void GetSubSequences()
        {
            var subSequence = new List<int>();
            int nextIndex;
            int current;
            for (int i = 0; i < _intArray.Length; i++)
            {
                current = _intArray[i];
                subSequence.Add(current);
                nextIndex = i + 1;
                while (nextIndex < _intArray.Length && current < _intArray[nextIndex])
                {
                    subSequence.Add(_intArray[nextIndex]);
                    current = _intArray[nextIndex];
                    nextIndex++;
                    i++;
                }

                _results.Add(new List<int>(subSequence));
                subSequence.Clear();
            }
        }

        private static void PrintResults()
        {
            int longestSeq = int.MinValue;
            int longestSeqIndex = 0;

            foreach (var list in _results)
            {
                Console.WriteLine("{0}", String.Join(" ", list));
                if (list.Count > longestSeq)
                {
                    longestSeq = list.Count;
                    longestSeqIndex = _results.IndexOf(list);
                }
            }

            Console.WriteLine("Longest: {0}", String.Join(" ", _results[longestSeqIndex]));
        }
    }
}
