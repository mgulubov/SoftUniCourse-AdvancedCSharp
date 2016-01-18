using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01CommandInterpreter
{
    class Program
    {
        private static String[] _charArray;

        static void Main(string[] args)
        {
            String str = Console.ReadLine().Trim();
            str = Regex.Replace(str, @"([ ]{2,})", " ");
            _charArray = str.Split(' ');

            while (true)
            {
                String[] command = Console.ReadLine().Split(' ');
                if (command[0] == "end")
                {
                    break;
                }

                switch (command[0])
                {
                    case "reverse":
                        if (StartIsValid(int.Parse(command[2])) && CounIsValid(int.Parse(command[2]), int.Parse(command[4])))
                        {
                            DoReverse(int.Parse(command[2]), int.Parse(command[4]));
                        }
                        else
                        {
                            PrintError();
                        }
                        break;
                    case "sort":
                        if (StartIsValid(int.Parse(command[2])) && CounIsValid(int.Parse(command[2]), int.Parse(command[4])))
                        {
                            DoSort(int.Parse(command[2]), int.Parse(command[4]));
                        }
                        else
                        {
                            PrintError();
                        }
                        break;
                    case "rollLeft":
                        if (IsValid(int.Parse(command[1])))
                        {
                            DoRollLeft(int.Parse(command[1]));
                        }
                        else
                        {
                            PrintError();
                        }

                        break;

                    case "rollRight":
                        if (IsValid(int.Parse(command[1])))
                        {
                            DoRollRight(int.Parse(command[1]));
                        }
                        else
                        {
                            PrintError();
                        }

                        break;
                }
            }

            PrintResult(_charArray);
        }

        private static bool IsValid(int i)
        {
            return i >= 0;
        }

        private static void DoRollRight(int count)
        {
            int length = _charArray.Length;
            int n = count % length;

            String[] newArr = new String[_charArray.Length];
            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[n] = _charArray[i];
                n++;
                if (n >= newArr.Length)
                {
                    n = 0;
                }
            }

            _charArray = newArr;
        }

        private static void DoRollLeft(int count)
        {
            int length = _charArray.Length;
            int n = count % length;

            if (n != 0)
            {
                n = _charArray.Length - n;
            }

            String[] newArr = new String[_charArray.Length];
            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[n] = _charArray[i];
                n++;
                if (n >= newArr.Length)
                {
                    n = 0;
                }
            }

            _charArray = newArr;

        }

        private static void DoSort(int start, int count)
        {
            String[] tmp = new String[count];
            int index = 0;
            int fIndex = start;
            for (int i = 0; i < count; i++)
            {
                tmp[i] = _charArray[fIndex];
                index++;
                fIndex++;
            }

            Array.Sort(tmp);

            index = 0;
            fIndex = start;
            for (int i = 0; i < count; i++)
            {
                _charArray[fIndex] = tmp[i];
                index++;
                fIndex++;
            }
        }

        private static void DoReverse(int start, int count)
        {
            String[] tmp = new String[count];
            int index = 0;

            int fIndex = start;
            for (int i = 0; i < count; i++)
            {
                tmp[i] = _charArray[fIndex];
                index++;
                fIndex++;
            }

            tmp = tmp.Reverse().ToArray();

            index = 0;
            fIndex = start;
            for (int i = 0; i < count; i++)
            {
                _charArray[fIndex] = tmp[i];
                index++;
                fIndex++;
            }
        }

        private static bool StartIsValid(int start)
        {
            return (start >= 0) && (start < _charArray.Length);
        }

        private static bool CounIsValid(int start, int length)
        {
            return (start + length >= 0) && ((start + length) <= _charArray.Length);
        }

        private static void PrintError()
        {
            Console.WriteLine("Invalid input parameters.");
        }

        private static void PrintResult(String[] arr)
        {
            Console.Write("[");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i != arr.Length - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine("]");
        }
    }
}
