using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01.OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            String fileName = "dante.txt";
            String path = Directory.GetCurrentDirectory() + "../../../../";

            PrintOddLines(path + fileName);
        }

        private static void PrintOddLines(String path)
        {
            StreamReader reader = new StreamReader(path);

            String line;
            int lineNumber = 1;
            while (true)
            {
                line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                if (lineNumber % 2 != 0)
                {
                    Console.WriteLine(lineNumber + ": " + line);
                }

                lineNumber++;
            }

            reader.Close();
        }
    }
}
