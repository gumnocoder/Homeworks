using System;
using System.Collections.ObjectModel;
using Telegram.Bot.Args;
using static Homework_9.SaveImage;
using static Homework_9.SendFileOnRequest;
using static Homework_9.TeleBot;

namespace Homework_10
{
    class TeleBot
    {
        private MainWindow w;

        /// <summary>
        /// коллекция содержащая сообщения
        /// </summary>
        //public static TelegramBotClient bot;

        public static ObservableCollection<MessageLog> 
            BotMessageLog { get; set; }


        [Obsolete]
        private void MessageListener(object sender, MessageEventArgs e)
        {
            var messageText = e.Message.Text;

            if (
                messageText == null 
                & e.Message.Photo != null
                )
            {
                messageText = "изображение";
            }
            else if (
                messageText == null
                & e.Message.Photo == null
                ) 
            { return; }
            
            /// добавляет новый экземпляр
            /// MessageLog в коллекцию
            /// BotMessageLog
            w.Dispatcher.Invoke(() =>
            {
                BotMessageLog.Add(
                new MessageLog(
                    DateTime.Now.ToString(), 
                    messageText, 
                    e.Message.Chat.FirstName, 
                    e.Message.Chat.Id
                    ));
            });
        }

        [Obsolete]
        public TeleBot(MainWindow W)
        {
            BotMessageLog = new ObservableCollection<MessageLog>();
            w = W;

            bot.StartReceiving();

            bot.OnMessage += MessageListener;
            bot.OnMessage += new Homework_9.StartMessage().Listen;


            Homework_9.ImageMessage im = new();
            Homework_9.SaveImageFromUser si = new();
            bot.OnMessage += im.Listen;
            im.onPhoto += SendKeyboard;
            im.onPhoto += si.SaveFromStream;

            convertedImageSavedNotify += new Homework_9.FileToZip().StartCompressing;
        }
    }
}
