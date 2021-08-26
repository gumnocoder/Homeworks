using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Telegram.Bot;
using static Homework_9.SendArchive;

namespace Homework_9

{
    class FileToZip
    {
        public static string ArchiveWithConvertedFile = "";
        public void StartCompressing()
        {
            CompressFile(SaveImage.outputFile);
        }

        public void CompressFile(string outputImage)
        {
            using (FileStream save = new FileStream(outputImage, FileMode.OpenOrCreate))
            {
                ArchiveWithConvertedFile = outputImage + ".zip";

                using (FileStream save2 = File.Create(ArchiveWithConvertedFile))
                {
                    using (GZipStream save3 = new GZipStream(save2, CompressionMode.Compress))
                    {
                        save.CopyTo(save3);
                        readyToSendArchiveFlag = true;
                        ToSendMessage();
                        Console.WriteLine($"readyToSendArchiveFlag {readyToSendArchiveFlag} switched");
                        Console.WriteLine($"SendArchive.ToSendMessage()");
                        Console.WriteLine($"file {outputImage + ".zip"} zipped");
                    }
                }
            }
        }
    }
}
