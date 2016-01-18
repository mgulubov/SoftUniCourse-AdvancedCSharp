using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _04.CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            String path = Directory.GetCurrentDirectory() + "../../../../";
            String originalBinFileName = "binFileOne.jpg";
            String newBinFileName = "binFileTwo.jpg";

            CopyBinFile(path + originalBinFileName, path + newBinFileName);
            Console.WriteLine("Check that file was created successfully and press 'Enter' to continue");
            Console.ReadLine();
            DeleteFile(path + newBinFileName);
        }

        private static void CopyBinFile(String fileOne, String fileTwo)
        {
            FileStream readerStream = new FileStream(fileOne, FileMode.Open);
            FileStream writerStream = new FileStream(fileTwo, FileMode.Create);

            while (true)
            {
                int b = readerStream.ReadByte();
                if (b == -1) {
                    break;
                }

                writerStream.WriteByte((byte)b);
            }

            writerStream.Flush();

            readerStream.Close();
            writerStream.Close();
        }

        private static void DeleteFile(String path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine(path + " was deleted successfully");
            }
        }
    }
}
