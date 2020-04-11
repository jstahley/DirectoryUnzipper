using System;
using System.IO;
namespace DirectoryUnzipper
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = "D:\\MyPlex\\MyShows";
            // string textPath = "E:\\ZipTest";

            string[] files =
                    Directory.GetFiles(textPath, "*.rar", SearchOption.AllDirectories);

            foreach (string dir in files)
            {
                CompressedFile compressedFile = new CompressedFile(dir);
                FileDecompresser decompresser = new FileDecompresser(compressedFile);
                try
                {
                    Console.WriteLine("Writing RAR");
                    decompresser.Decompress();
                    Console.WriteLine("Success");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed: " + e.Message);
                    throw;
                }
                decompresser.Decompress();
            }

        }
    }
}
