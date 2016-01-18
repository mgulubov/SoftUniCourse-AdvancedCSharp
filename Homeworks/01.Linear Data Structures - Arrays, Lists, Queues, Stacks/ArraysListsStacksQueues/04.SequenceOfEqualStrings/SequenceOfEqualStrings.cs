using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SequenceOfEqualStrings
{
    class SequenceOfEqualStrings
    {

        private static List<List<String>> _results;

        static void Main(string[] args)
        {
            Console.Write("6TR19G6: ");
            String[] strArray = Console.ReadLine().Split(' '); //I won't be checking for correct input from now on- Pointlezzz

            _results = new List<List<String>>();

            getEqualStrings(strArray);
            printResults();
        }

        private static void getEqualStrings(String[] array)
        {
            var listOfEqualStrings = new List<String>();
            int nextIndex;
            for (int i = 0; i < array.Length; i++)
            {
                String currentStr = array[i];
                listOfEqualStrings.Add(currentStr);
                nextIndex = i + 1;
                while (nextIndex < array.Length && array[nextIndex].Equals(currentStr))
                {
                    listOfEqualStrings.Add(currentStr);
                    nextIndex++;
                    i++;
                }

                _results.Add(new List<String>(listOfEqualStrings));
                listOfEqualStrings.Clear();
            }
        }

        private static void printResults()
        {
            foreach (var list in _results)
            {
                Console.WriteLine("{0}", String.Join(" ", list));
            }
        }
    }
}
