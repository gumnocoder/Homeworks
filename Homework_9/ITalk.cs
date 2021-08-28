using System;
using System.IO;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;
using static Homework_9.TeleBot;

namespace Homework_9
{
    public interface ITalk
    {
        [Obsolete]
        void SendMessage(MessageEventArgs e);
    }

    /// <summary>
    /// выводит список файлов для скачивания
    /// </summary>
    public class GetFilesOnServer
    {
        
        public static string path = Environment.CurrentDirectory;
        public static DirectoryInfo di = new DirectoryInfo(path);
        /// <summary>
        /// для промежуточного хранения списка файлов в директории
        /// </summary>
        public static string files = "";
        
        public static void getFilesOnServer(MessageEventArgs e)
        {
            GetDirectory(e);
            SendDirectory(e);
        }

        /// <summary>
        /// получает содержимое директории и записывает в строку
        /// </summary>
        /// <param name="e"></param>
        public static void GetDirectory(MessageEventArgs e)
        {
            foreach (var file in di.GetFiles())
            {
                files += file.Name + "\n";
            }
        }

        /// <summary>
        /// отправляет список файлов и очищает временную строку
        /// </summary>
        /// <param name="e"></param>
        public static void SendDirectory(MessageEventArgs e)
        {
            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(),
            "Список файлов доступных к скачиванию:\n\n" + files);
            files = "";
        }
    }

    public class SendFileOnRequest
    {
        public static void CheckFile(string file, MessageEventArgs e)
        {
            if (File.Exists(file)) SendFileFromServer(file, e);
            else SendFileError(file, e);
        }

        public static void SendFileError(string file, MessageEventArgs e)
        {
            bot.SendTextMessageAsync(e.Message.Chat.Id, $"{file} не существует! Запрос отменён");
            StartMessage.FlagToGetFile = false;
        }
        public static async void SendFileFromServer(string file, MessageEventArgs e)
        {
            string path = Path.Combine(Environment.CurrentDirectory + @"\" + file);
            /// поток отправляющий файл
            using (Stream stream = File.OpenRead(path))
            {
                StartMessage.FlagToGetFile = false;
                await bot.SendDocumentAsync(
                    chatId: e.Message.Chat.Id.ToString(),
                    document: new InputOnlineFile(content: stream, fileName: file),
                    caption: file
                );
            }
        }
    }

    public class SendHelp : ITalk
    {
        [Obsolete]

        public void SendMessage(MessageEventArgs e)
        {
            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), 
                "Добро пожаловать в конвертер изображений!\n\n" +
                "Отправьте изображение, которое хотите сохранить в другой формат, " +
                "выберите конечный формат и бот отправит Вам " +
                "заархивированный файл в нужном формате. " +
                "Доступные форматы JPEG, PNG, BMP и GIF." +
                "Обратите внимание что фотографии необходимо " +
                "присылать по одной, в противном случае будет " +
                "конвертировано только последнее изображение.\n\n" +
                "Список команд:\n\n" +
                "/start инструкция по использованию\n" +
                "/getdir список файлов для скачивания\n" +
                "/getfile отправляет запрос на отправку файла с сервера");
        }
    }

    /// <summary>
    /// отправляет архив с конвертированным файлом
    /// </summary>
    public class SendArchive
    { 
        public static bool readyToSendArchiveFlag = false;

        /// <summary>
        /// 
        /// </summary>
        [Obsolete]
        public static async void SendMessageWithArchive(MessageEventArgs e)
        {
            /// название архива
            string archive = SaveImage.outputFile + ".zip";
            /// путь к архиву
            string path = Path.Combine(Environment.CurrentDirectory + @"\" + SaveImage.outputFile + ".zip");
            /// поток отправляющий архив
            using (Stream stream = File.OpenRead(path))
            {
                await bot.SendDocumentAsync(
                    chatId: e.Message.Chat.Id.ToString(),
                    document: new InputOnlineFile(content: stream, fileName: archive),
                    caption: archive
                );
            }
        }
    }
}
