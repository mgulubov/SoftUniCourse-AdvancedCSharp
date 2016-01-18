using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SortedSubsetSums
{
    class SortedSubsetSums
    {
        //I'll get medieval with this one :p
        private static List<List<int>> _sortedResults; //We'll keep the lists sorted at all times
        private static List<int> _sortedSubSeq; //We'll keep the numbers sorted at all times
        private static int[] _intArray;
        private static int _n;

        static void Main(string[] args)
        {
            Console.Write("_n: ");
            _n = int.Parse(Console.ReadLine());
            Console.Write("_intArray: ");
            _intArray = Console.ReadLine().Split(' ').Select(int.Parse).Distinct().ToArray();
            _sortedResults = new List<List<int>>();
            _sortedSubSeq = new List<int>();

            GetSubSequences(0, _sortedSubSeq);
            PrintResults();
        }

        private static void PrintResults()
        {
            if (_sortedResults.Count > 0 && _sortedResults[0].Count > 0) //Same bug :)
            {
                foreach (var list in _sortedResults)
                {
                    Console.WriteLine("{0} = {1}", String.Join(" + ", list), _n);
                }
            }
            else
            {
                Console.WriteLine("No matching subsets.");
            }
            
        }

        private static void GetSubSequences(int index, List<int> list)
        {
            if (list.Sum() == _n)
            {
                _sortedResults.Insert(BinInsertResultList(list), new List<int>(list));
                return;
            }

            for (int i = index; i < _intArray.Length; i++)
            {
                int indexOfInsertedElement = BinInsertSubSeqList(_intArray[i]);
                list.Insert(indexOfInsertedElement, _intArray[i]);
                GetSubSequences(i + 1, list);
                list.RemoveAt(indexOfInsertedElement);
            }
        }

        private static int BinSearchSubSeqList(int value)
        {
            int leftIndex = 0;
            int rightIndex = _sortedSubSeq.Count - 1;
            while (rightIndex >= leftIndex)
            {
                int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;
                int middleElement = _sortedSubSeq[middleIndex];

                if (value == middleElement)
                {
                    return middleIndex;
                }
                else if (value > middleElement)
                {
                    leftIndex = middleIndex + 1;
                }
                else
                {
                    rightIndex = middleIndex - 1;
                }
            }

            return -(leftIndex + 1);
        }

        private static int BinSearchResultList(List<int> value)
        {
            int leftIndex = 0;
            int rightIndex = _sortedResults.Count - 1;
            while (rightIndex >= leftIndex)
            {
                int middleIndex = leftIndex + (rightIndex - leftIndex) / 2;
                List<int> middleList = _sortedResults[middleIndex];

                //The comparison here is a little shitty. 
                //It can be solved with moving the binary inserter to a separate class,
                //which accepts a binary searcher as a constructor argument,
                //which accepts a certain comparator as a constructor argument, 
                //but then we'll need a separate comparator class and so on. In other words - POINTLESS in this current case :)
                if (value.Count == middleList.Count)
                {
                    if (value[0] == middleList[0])
                    {
                        return middleIndex;
                    }
                    else if (value[0] > middleList[0])
                    {
                        leftIndex = middleIndex + 1;
                    }
                    else
                    {
                        rightIndex = middleIndex - 1;
                    }
                }
                else if (value.Count > middleList.Count)
                {
                    leftIndex = middleIndex + 1;
                }
                else
                {
                    rightIndex = middleIndex - 1;
                }
            }

            return -(leftIndex + 1);
        }

        private static int BinInsertSubSeqList(int value)
        {
            int index = BinSearchSubSeqList(value);
            if (index < 0)
            {
                index = -(index + 1);
            }

            return index;
        }

        private static int BinInsertResultList(List<int> value)
        {
            int index = BinSearchResultList(value);
            if (index < 0)
            {
                index = -(index + 1);
            }

            return index;
        }
    }
}
