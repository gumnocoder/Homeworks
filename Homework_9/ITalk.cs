using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;
using static Homework_9.TeleBot;
using static Homework_9.FileToZip;
using System.Threading.Tasks;

namespace Homework_9
{
    public interface ITalk
    {
        void SendMessage(MessageEventArgs e);
    }

    /// <summary>
    /// отправляет инструкции
    /// </summary>
    public class SendHelp : ITalk
    {
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
    public class SendArchive : ITalk
    {
        public static bool readyToSendArchiveFlag = false;
        public static string path;
        public static string archive;

        public delegate void ReadyToSendArchive(MessageEventArgs e);
        public event ReadyToSendArchive Sending;

        //public void ToSendMessage()
        //{

        //    if (readyToSendArchiveFlag)
        //    {
        //        Sending(e);
        //    }
        //}


        public void SendMessage(MessageEventArgs e)
        {

        }



        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="Path">руть к файлу</param>
        /// <param name="Archive">название файла</param>
        public static async void SendMessageWithArchive(MessageEventArgs e)
        {

            await Task.Run(() =>
            {
                using (Stream stream = File.OpenRead(Path.Combine(Environment.CurrentDirectory + @"\" + ArchiveWithConvertedFile)))
                {
                    bot.SendDocumentAsync(
                        chatId: e.Message.Chat.Id.ToString(),
                        document: new InputOnlineFile(content: stream, fileName: ArchiveWithConvertedFile),
                        caption: ArchiveWithConvertedFile
                    );
                }
            });
        }
    }
}
