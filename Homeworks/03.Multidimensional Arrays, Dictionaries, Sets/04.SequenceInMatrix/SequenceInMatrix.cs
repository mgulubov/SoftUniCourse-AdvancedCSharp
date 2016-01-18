using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SequenceInMatrix
{
    class SequenceInMatrix
    {
        private static String[,] _matrix;
        private static int _rows;
        private static int _cols;
        private static List<String> _result;

        static void Main(string[] args)
        {
            Console.WriteLine("Using matrix from example A");
            InstantiateMatrixFromExampleA();
            FindLongestSequenceOfEqualStrings();
            PrintResult();

            Console.WriteLine("Using matrix from example B");
            InstantiateMatrixFromExampleB();
            FindLongestSequenceOfEqualStrings();
            PrintResult();

            Console.WriteLine("You can test me with your own matrix, if you want.");
            InstantiateCustomMatrix();
            FindLongestSequenceOfEqualStrings();
            PrintResult();
        }

        private static void InstantiateMatrixFromExampleA()
        {
            _rows = 3;
            _cols = 4;
            _matrix = new String[,] 
                                    {
                                        {"ha", "fifi", "ho", "hi"},
                                        {"fo", "ha", "hi", "xx"},
                                        {"xxx", "ho", "ha", "xx"},
                                    };
            _result = new List<String>();
        }

        private static void InstantiateMatrixFromExampleB()
        {
            _rows = 3;
            _cols = 3;
            _matrix = new String[,] 
                                    {
                                        {"s", "qq", "s"},
                                        {"pp", "pp", "s"},
                                        {"pp", "qq", "s"}
                                    };
            _result = new List<String>();
        }

        private static void InstantiateCustomMatrix()
        {
            int[] rowsCols = GetRowsColsFromConsole();
            _rows = rowsCols[0];
            _cols = rowsCols[1];
            _matrix = new String[_rows, _cols];
            _result = new List<String>();

            PopulateMatrixFromConsole();
        }

        private static int[] GetRowsColsFromConsole()
        {
            int[] rowsCols = new int[2];

            Console.Write("Rows: ");
            rowsCols[0] = int.Parse(Console.ReadLine());

            Console.Write("Cols: ");
            rowsCols[1] = int.Parse(Console.ReadLine());

            return rowsCols;
        }

        private static void PopulateMatrixFromConsole()
        {
            for (int row = 0; row < _rows; row++)
            {
                Console.Write("Enter the " + (_cols+ 1) + " elements for row " + (row + 1) + " separated by space: ");
                String[] input = Console.ReadLine().Split(' ');
                int inputIndex = 0;
                for (int col = 0; col < _cols; col++)
                {
                    _matrix[row, col] = input[inputIndex];
                    inputIndex++;
                }
            }
        }

        private static void FindLongestSequenceOfEqualStrings()
        {
            List<String> sequence = new List<String>();
            for (int row = 0; row < _rows; row++)
            {
                for (int col = 0; col < _cols; col++)
                {
                    sequence = GetSequenceRight(row, col, sequence);
                    CopySeqToResultIfCountIsBigger(sequence);
                    sequence.Clear();

                    sequence = GetSequenceRightDown(row, col, sequence);
                    CopySeqToResultIfCountIsBigger(sequence);
                    sequence.Clear();

                    sequence = GetSequenceDown(row, col, sequence);
                    CopySeqToResultIfCountIsBigger(sequence);
                    sequence.Clear();

                    sequence = GetSequenceLeftDown(row, col, sequence);
                    CopySeqToResultIfCountIsBigger(sequence);
                    sequence.Clear();

                    sequence = GetSequenceLeft(row, col, sequence);
                    CopySeqToResultIfCountIsBigger(sequence);
                    sequence.Clear();

                    sequence = GetSequenceLeftUp(row, col, sequence);
                    CopySeqToResultIfCountIsBigger(sequence);
                    sequence.Clear();

                    sequence = GetSequenceUp(row, col, sequence);
                    CopySeqToResultIfCountIsBigger(sequence);
                    sequence.Clear();

                    sequence = GetSequenceRightUp(row, col, sequence);
                    CopySeqToResultIfCountIsBigger(sequence);
                    sequence.Clear();
                }
            }
        }

        private static List<String> GetSequenceRight(int row, int col, List<String> sequence)
        {
            String expected = _matrix[row, col];
            sequence.Add(expected);
            String element;
            for (int c = col + 1; c < _cols; c++)
            {
                element = _matrix[row, c];
                if (expected.Equals(element))
                {
                    sequence.Add(element);
                }
                else
                {
                    break;
                }
            }

            return sequence;
        }

        private static List<String> GetSequenceRightDown(int row, int col, List<String> sequence)
        {
            String expected = _matrix[row, col];
            sequence.Add(expected);
            String element;
            int r = row + 1;
            int c = col + 1;
            while (r < _rows && c < _cols)
            {
                element = _matrix[r, c];
                if (expected.Equals(element))
                {
                    sequence.Add(expected);
                    r++;
                    c++;
                }
                else
                {
                    break;
                }
            }

            return sequence;
        }

        private static List<String> GetSequenceDown(int row, int col, List<String> sequence)
        {
            String expected = _matrix[row, col];
            sequence.Add(expected);
            String element;
            for (int r = row + 1; r < _rows; r++)
            {
                element = _matrix[r, col];
                if (expected.Equals(element))
                {
                    sequence.Add(element);
                }
                else
                {
                    break;
                }
            }

            return sequence;
        }

        private static List<String> GetSequenceLeftDown(int row, int col, List<String> sequence)
        {
            String expected = _matrix[row, col];
            sequence.Add(expected);
            String element;
            int r = row + 1;
            int c = col - 1;
            while (r < _rows && c >= 0)
            {
                element = _matrix[r, c];
                if (expected.Equals(element))
                {
                    sequence.Add(element);
                    r++;
                    c--;
                }
                else
                {
                    break;
                }
            }

            return sequence;
        }

        private static List<String> GetSequenceLeft(int row, int col, List<String> sequence)
        {
            String expected = _matrix[row, col];
            sequence.Add(expected);
            String element;
            for (int c = col - 1; c >= 0; c--)
            {
                element = _matrix[row, c];
                if (expected.Equals(element))
                {
                    sequence.Add(element);
                }
                else
                {
                    break;
                }
            }

            return sequence;
        }

        private static List<String> GetSequenceLeftUp(int row, int col, List<String> sequence)
        {
            String expected = _matrix[row, col];
            sequence.Add(expected);
            String element;
            int r = row - 1;
            int c = col - 1;
            while (r >= 0 && c >= 0)
            {
                element = _matrix[r, c];
                if (expected.Equals(element))
                {
                    sequence.Add(element);
                    r--;
                    c--;
                }
                else
                {
                    break;
                }
            }

            return sequence;
        }

        private static List<String> GetSequenceUp(int row, int col, List<String> sequence)
        {
            String expected = _matrix[row, col];
            sequence.Add(expected);
            String element;
            for (int r = row - 1; r >= 0; r--)
            {
                element = _matrix[r, col];
                if (expected.Equals(element))
                {
                    sequence.Add(element);
                }
                else
                {
                    break;
                }
            }

            return sequence;
        }

        private static List<String> GetSequenceRightUp(int row, int col, List<String> sequence)
        {
            String expected = _matrix[row, col];
            sequence.Add(expected);
            String element;
            int r = row - 1;
            int c = col + 1;
            while (r >= 0 && c < _cols)
            {
                element = _matrix[r, c];
                if (expected.Equals(element))
                {
                    sequence.Add(element);
                    r--;
                    c++;
                }
                else
                {
                    break;
                }
            }

            return sequence;
        }

        private static void CopySeqToResultIfCountIsBigger(List<String> sequence)
        {
            if (sequence.Count > _result.Count)
            {
                _result = new List<String>(sequence);
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine("{0}", string.Join(", ", _result));
        }
    }
}
