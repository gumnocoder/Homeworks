using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using static Homework_9.TeleBot;

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

        public ObservableCollection<MessageLog> BotMessageLog { get; set; }

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

        private void MessageListener(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Console.WriteLine("---");
            Debug.WriteLine("+++---");

            string text = $"{DateTime.Now.ToString()}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";
            var messageText = e.Message.Text;
            Debug.WriteLine($"{text} TypeMessage: {e.Message.Type.ToString()}");

            if (e.Message.Text == null) return;

            

            w.Dispatcher.Invoke(() =>
            {
                BotMessageLog.Add(
                new MessageLog(
                    DateTime.Now.ToString(), messageText, e.Message.Chat.FirstName, e.Message.Chat.Id));
            });
        }

        /*[Obsolete]
        private void MessageListener(object sender, MessageEventArgs e)
        {

            string FirstName = e.Message.Chat.FirstName;
            string MsgType = e.Message.Type.ToString();
            long ChatId = e.Message.Chat.Id;
            string Msg;

            if (e.Message.Text == null) Msg = "***empty***";
            else Msg = e.Message.Text;

            string text = $"" +
                    $"{ChatId.ToString()}: " +
                    $"{FirstName} " +
                    $"{ChatId} " +
                    $"{Msg} " +
                    $"Message Type {MsgType}";

            Debug.WriteLine($"{text}");

            w.Dispatcher.Invoke(delegate ()
            {
                BotMessageLog.Add(
                    new MessageLog(
                        DateTime.Now,
                        ChatId,
                        FirstName,
                        Msg,
                        MsgType
                        ));
            });

        }*/

        [Obsolete]
        public TeleBot(MainWindow W)
        {
            this.BotMessageLog = new ObservableCollection<MessageLog>();
            this.w = W;

            bot = new TelegramBotClient(setToken());

            bot.OnMessage += MessageListener;

            bot.StartReceiving();
        }
    }
}
