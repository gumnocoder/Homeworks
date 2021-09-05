using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Args;
using static Homework_9.StartMessage;
namespace Homework_10
{
    class TeleBot
    {
        private MainWindow w;

        /// <summary>
        /// файл содержащий токен
        /// </summary>
        static readonly string token = "token.ini";

        /// <summary>
        /// бот
        /// </summary>
        public static TelegramBotClient bot;

        public static ObservableCollection<MessageLog> BotMessageLog { get; set; }

        /// <summary>
        /// парсит файл с токеном
        /// </summary>
        /// <returns></returns>
        public static string setToken()
        {
            if (File.Exists(token)) return File.ReadAllText(token);
            /// во избежание ошибок при отсутствии токена приложение завершается
            else Environment.Exit(0);
            return "end";
        }

        [Obsolete]
        private void MessageListener(object sender, MessageEventArgs e)
        {
            Console.WriteLine("---");
            Debug.WriteLine("+++---");

            string text = $"{DateTime.Now.ToString()}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";
            var messageText = e.Message.Text;
            Debug.WriteLine($"{text} TypeMessage: {e.Message.Type.ToString()}");


            if (messageText == null & e.Message.Photo != null) messageText = "изображение";
            else if (messageText == null & e.Message.Photo == null) return;
            

            w.Dispatcher.Invoke(() =>
            {
                BotMessageLog.Add(
                new MessageLog(
                    DateTime.Now.ToString(), messageText, e.Message.Chat.FirstName, e.Message.Chat.Id));
            });
        }

        [Obsolete]
        public TeleBot(MainWindow W)
        {
            BotMessageLog = new ObservableCollection<MessageLog>();
            w = W;

            bot = new TelegramBotClient(setToken());

            bot.OnMessage += MessageListener;
            bot.OnMessage += new Homework_9.StartMessage().Listen;

            Homework_9.ImageMessage im = new Homework_9.ImageMessage();
            Homework_9.SaveImageFromUser si = new Homework_9.SaveImageFromUser(bot);
            im.onPhoto += Homework_9.SendFileOnRequest.SendKeyboard;
            im.onPhoto += si.SaveFromStream;

            bot.StartReceiving();
        }
    }
}
