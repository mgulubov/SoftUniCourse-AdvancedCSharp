using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02.LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            String fileName = "dante.txt";
            String newFileName = "copyWithLines.txt";
            String path = Directory.GetCurrentDirectory() + "../../../../";

            Console.WriteLine("Original File:");
            ReadAndPrintFile(path + fileName);
            InsertLineNumbersInFile(path + fileName, path + newFileName);
            Console.WriteLine("\nWith Lines:");
            ReadAndPrintFile(path + newFileName);

            //Clean up
            DeleteFile(path + newFileName);
        }

        private static void ReadAndPrintFile(String filePath)
        {
            StreamReader reader = new StreamReader(filePath);

            Console.WriteLine(reader.ReadToEnd());

            reader.Close();
        }

        private static void InsertLineNumbersInFile(String sourcePath, String resultPath)
        {
            //We will create a copy of the file and insert the lines in it instead, so that we can keep the original
            StreamReader reader = new StreamReader(sourcePath);
            StreamWriter writer = new StreamWriter(resultPath);

            StringBuilder strBld = new StringBuilder();
            int lineNumber = 1;
            while (true)
            {
                if (reader.Peek() == -1)
                {
                    writer.Flush();
                    break;
                }

                writer.WriteLine(lineNumber + "." + reader.ReadLine());
                lineNumber++;
            }

            reader.Close();
            writer.Close();
        }

        private static void DeleteFile(String filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine(filePath + " deleted successfully");
            }
        }
    }
}
