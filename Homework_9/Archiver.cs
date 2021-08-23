using System.IO;
using System.IO.Compression;
using Telegram.Bot;

namespace Homework_9
{
    public interface Archiver
    {
        void CompressFile(TelegramBotClient bot, string outputImage);
    }

    class FileToZip : Archiver
    {
        public void CompressFile(TelegramBotClient bot, string outputImage)
        {
            using (FileStream save = new FileStream(outputImage, FileMode.OpenOrCreate))
            {
                using (FileStream save2 = File.Create(outputImage + ".zip"))
                {
                    using (GZipStream save3 = new GZipStream(save2, CompressionMode.Compress))
                    {
                        save.CopyTo(save3);
                    }
                }
            }
        }
    }
}
