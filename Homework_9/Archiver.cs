using System;
using System.IO;
using System.IO.Compression;
using Telegram.Bot.Args;
using static Homework_9.SendArchive;

namespace Homework_9

{
    class FileToZip
    {

        public static string ArchiveWithConvertedFile = "";

        [Obsolete]
        public void StartCompressing(MessageEventArgs e)
        {
            CompressFile(SaveImage.outputFile, e);
        }

        [Obsolete]
        public void CompressFile(string outputImage, MessageEventArgs e)
        {
            using (FileStream save = new FileStream(outputImage, FileMode.OpenOrCreate))
            {
                using (FileStream save2 = File.Create(SaveImage.outputFile + ".zip"))
                {
                    using (GZipStream save3 = new GZipStream(save2, CompressionMode.Compress))
                    {
                        save.CopyTo(save3);
                        Console.WriteLine($"readyToSendArchiveFlag {readyToSendArchiveFlag} switched");
                        Console.WriteLine($"SendArchive.ToSendMessage()");
                        Console.WriteLine($"file {outputImage + ".zip"} zipped");
                        
                    }
                }
                readyToSendArchiveFlag = true;
                SendMessageWithArchive(e);
            }
        }
    }
}
