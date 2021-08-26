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
    /// отправляет инструкции
    /// </summary>
    public class SendHelp : ITalk
    {
        [Obsolete]
        public void SendMessage(MessageEventArgs e)
        {
            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), "Добро пожаловать в конвертер изображений!\n\n");
            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), "Вы можете отправить в чат изображение, после чего Вам будет \n" +
                "предложен формат для конвертирования, на выбор.\n" +
                "В результате конвертирования Вам вернётся \n" +
                "заархивированное изображение в заказанном формате.\n" +
                "Приятного использования!");
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
