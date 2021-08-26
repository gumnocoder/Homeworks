using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using static Homework_9.SendArchive;
using static Homework_9.ITalk;

namespace Homework_9

{
    class FileToZip : MessageListener
    {
        public void Listen(object sender, MessageEventArgs e)
        {

        }

        public static string ArchiveWithConvertedFile = "";
        public void StartCompressing(MessageEventArgs e)
        {
            CompressFile(SaveImage.outputFile, e);
        }

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
