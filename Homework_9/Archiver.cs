using System;
using System.IO;
using System.IO.Compression;
using Telegram.Bot.Args;
using static Homework_9.SendArchive;

namespace Homework_9

{
    /// <summary>
    /// для запаковки файла в zip
    /// </summary>
    class FileToZip
    {
        /// <summary>
        /// содержит название архивированного файла
        /// </summary>
        public static string ArchiveWithConvertedFile = "";

        /// <summary>
        /// вызывает метод архивации
        /// </summary>
        /// <param name="e"></param>
        [Obsolete]
        public void StartCompressing(MessageEventArgs e)
        {
            CompressFile(SaveImage.outputFile, e);
        }

        /// <summary>
        /// метод архивации конвертированного изображения
        /// </summary>
        /// <param name="outputImage"></param>
        /// <param name="e"></param>
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
                    }
                }
                readyToSendArchiveFlag = true;
                /// Запускает логику отправки архива
                SendMessageWithArchive(e);
            }
        }
    }
}
