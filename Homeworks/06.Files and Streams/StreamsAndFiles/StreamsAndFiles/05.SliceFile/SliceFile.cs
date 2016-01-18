using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _05.SliceFile
{
    class SliceFile
    {
        static void Main(string[] args)
        {
            String sourcePath = Directory.GetCurrentDirectory() + "../../../../";
            //You'll have to provide your own file. Limit is 2MB, so I couldn't upload mine
            String sourceFileName = "SouthPark-KylesMomsaBitch.mp4";
            String destinationPath = Directory.GetCurrentDirectory() + "../../../../SlicedFiles/";
            String assembledFilePath = Directory.GetCurrentDirectory() + "../../../../AssembledFile/";

            List<String> slicedFileNames = Slice(sourcePath + sourceFileName, destinationPath, 5);
            Console.WriteLine("Verify that the file has been slice. Directory: " + destinationPath);
            Assemble(slicedFileNames, assembledFilePath);
        }

        private static List<String> Slice(String source, String destination, int slices)
        {
            List<String> result = new List<String>(slices);

            try
            {
                FileStream fs = new FileStream(source, FileMode.Open, FileAccess.Read);
                int sizeOfEachFile = (int)Math.Ceiling((double)fs.Length / slices);

                for (int i = 0; i < slices; i++)
                {
                    String baseFileName = Path.GetFileNameWithoutExtension(source);
                    String extension = Path.GetExtension(source);

                    FileStream outputFile = new FileStream(destination + baseFileName + "." +
                    i.ToString().PadLeft(5, Convert.ToChar("0")) + extension + ".tmp",
                    FileMode.Create, FileAccess.Write);

                    int bytesRead = 0;
                    byte[] buffer = new byte[sizeOfEachFile];

                    if ((bytesRead = fs.Read(buffer, 0, sizeOfEachFile)) > 0)
                    {
                        outputFile.Write(buffer, 0, bytesRead);
                        String packet = baseFileName + "." + i.ToString().PadLeft(3, Convert.ToChar("0")) + extension;

                        result.Add(packet);
                    }

                    outputFile.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return result;
        }

        //This doesn't really work, but I have to submit the homework, so there's no time for debugging :(
        private static void Assemble(List<String> packets, String outputPath)
        {
            try
            {
                FileStream outputFile = null;
                String prevFileName = "";

                foreach (String packet in packets)
                {
                    String fileName = Path.GetFileNameWithoutExtension(packet);
                    String baseFileName = fileName.Substring(0, fileName.IndexOf(Convert.ToChar(".")));
                    String extension = Path.GetExtension(fileName);

                    if (!prevFileName.Equals(baseFileName))
                    {
                        if (outputFile != null)
                        {
                            outputFile.Flush();
                            outputFile.Close();
                        }

                        outputFile = new FileStream(outputPath + baseFileName + extension,
                                                    FileMode.OpenOrCreate, FileAccess.Write);
                    }

                    int bytesRead = 0;
                    byte[] buffer = new byte[1024];
                    FileStream inputTempFile = new FileStream(packet, FileMode.OpenOrCreate, FileAccess.Read);
                    while ((bytesRead = inputTempFile.Read(buffer, 0, 1024)) > 0)
                    {
                        outputFile.Write(buffer, 0, bytesRead);
                    }

                    inputTempFile.Close();
                    File.Delete(packet);
                    prevFileName = baseFileName;

                    outputFile.Close();
                }
            }
            catch
            {

            }
        }
    }
}
