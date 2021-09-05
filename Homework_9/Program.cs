using System;
using Telegram.Bot.Args;
using static Homework_9.TeleBot;

namespace Homework_9
{
    class Program
    {
        [Obsolete]
        static void Main()
        {
            SaveImage.convertedImageSavedNotify += new FileToZip().StartCompressing;
            SaveImageFromUser si = new SaveImageFromUser();
            SaveImage si_2 = new SaveImage();
            ImageMessage im = new ImageMessage();

            /// запуск бота
            bot.StartReceiving();
            /// подписка на получение сообщения 
            bot.OnMessage += new StartMessage().Listen;
            bot.OnMessage += im.Listen;
            /// подписка на получение фото-сообщения
            im.onPhoto += SendFileOnRequest.SendKeyboard;
            im.onPhoto += si.SaveFromStream;

            Console.ReadKey();
        }
    }
}
