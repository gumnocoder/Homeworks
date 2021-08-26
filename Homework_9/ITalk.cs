using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;

namespace Homework_9
{
    public interface ITalk
    {
        void SendMessage(string chatId, TelegramBotClient bot);
    }

    /// <summary>
    /// отправляет инструкции
    /// </summary>
    public class SendHelp : ITalk
    {
        public void SendMessage(string chatId, TelegramBotClient bot)
        {
            bot.SendTextMessageAsync(chatId, "Добро пожаловать в конвертер изображений!\n\n");
            bot.SendTextMessageAsync(chatId, "Вы можете отправить в чат изображение, после чего Вам будет \n" +
                "предложен формат для конвертирования, на выбор.\n" +
                "В результате конвертирования Вам вернётся \n" +
                "заархивированное изображение в заказанном формате.\n" +
                "Приятного использования!");
        }
    }

    /// <summary>
    /// отправляет архив с конвертированным файлом
    /// </summary>
    public class SendArchive : ITalk
    {
        public static bool readyToSendArchiveFlag = false;
        public static string path;
        public static string archive;

        public delegate void ReadyToSendArchive();
        public static event ReadyToSendArchive readyToSendArchive;

        public static void ToSendMessage()
        {

            if (readyToSendArchiveFlag)
            {
                readyToSendArchiveFlag = false;
                //readyToSendArchive();
                //SendMessage(chatId, bot);
            }
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="Path">руть к файлу</param>
        /// <param name="Archive">название файла</param>
        public async void SendMessage(string chatId, TelegramBotClient bot)
        {
            using (Stream stream = File.OpenRead(path))
            {
                await bot.SendDocumentAsync(
                    chatId: chatId,
                    document: new InputOnlineFile(content: stream, fileName: archive),
                    caption: archive
                );
            }
        }
    }
}
