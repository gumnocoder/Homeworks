using System;
using System.IO;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
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
        
        /// <summary>
        /// сценарий отправки файлов на сервере
        /// </summary>
        /// <param name="e"></param>
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
        /// <summary>
        /// при получении изображения вызывает клавиатуру с кнопками для выбора формата
        /// </summary>
        /// <param name="e"></param>
        [Obsolete]
        public static async void SendKeyboard(MessageEventArgs e)
        {
            await bot.SendTextMessageAsync(
                e.Message.Chat.Id.ToString(),
                "Выберите формат в который хотите конвертировать изображение",
                replyMarkup: SendFileOnRequest.keyboard);
        }

        /// <summary>
        /// клавиатура с кнопками выбора формата
        /// </summary>
        [Obsolete]

        public static ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup
        {
            Keyboard = new[] {
                    new[]
                    {
                        new KeyboardButton("BMP"),
                        new KeyboardButton("PNG"),
                        new KeyboardButton("GIF"),
                        new KeyboardButton("TIFF"),
                    },
                },
            ResizeKeyboard = true,
            OneTimeKeyboard = true,
        };

        /// <summary>
        /// проверяет наличие и запускает 
        /// соответствующий сценарий
        /// </summary>
        /// <param name="file"></param>
        /// <param name="e"></param>
        [Obsolete]
        public static void CheckFile(string file, MessageEventArgs e)
        {
            if (File.Exists(file)) SendFileFromServer(file, e);
            else SendFileError(file, e);
        }

        /// <summary>
        /// отправляет ошибку при отсутствии файла
        /// </summary>
        /// <param name="file"></param>
        /// <param name="e"></param>
        [Obsolete]
        public static void SendFileError(string file, MessageEventArgs e)
        {
            bot.SendTextMessageAsync(
                e.Message.Chat.Id, 
                $"{file} не существует! Запрос отменён");
            StartMessage.FlagToGetFile = false;
        }

        /// <summary>
        /// отправляет запрошенный файл
        /// </summary>
        /// <param name="file">имя файла с расширением</param>
        /// <param name="e"></param>
        [Obsolete]
        public static async void SendFileFromServer(string file, MessageEventArgs e)
        {
            string path = Path.Combine(Environment.CurrentDirectory + @"\" + file);
            /// поток отправляющий файл
            using (Stream stream = File.OpenRead(path))
            {
                StartMessage.FlagToGetFile = false;
                await bot.SendDocumentAsync(
                    chatId: e.Message.Chat.Id.ToString(),
                    document: new InputOnlineFile(
                        content: stream, 
                        fileName: file),
                    caption: file
                );
            }
        }
    }

    /// <summary>
    /// Отправляет приветствие и инструкции
    /// </summary>
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
                "/getfile отправляет запрос на отправку файла с сервера\n\n" +
                "Внимание, регистр букв учитывается!");
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
