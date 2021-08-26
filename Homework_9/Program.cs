using System;
using Telegram.Bot.Args;
using static Homework_9.TeleBot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Homework_9
{
    class Program
    {

        public static bool controlFlag = false;

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

        [Obsolete]
        public static async void SendKeyboard(MessageEventArgs e)
        {
            await bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), "Выберите формат в который хотите конвертировать изображение", replyMarkup: keyboard);
            Console.WriteLine("keyboard sended");
        }

        [Obsolete]
        static void Main()
        {

            SaveImageFromUser si = new SaveImageFromUser(bot);
            SaveImage si_2 = new SaveImage();
            ImageMessage im = new ImageMessage();

            bot.StartReceiving();
            bot.OnMessage += new StartMessage().Listen;
            bot.OnMessage += im.Listen;
            im.onPhoto += SendKeyboard;
            im.onPhoto += si.SaveFromStream;

            si.imageFromUserSavedNotify += new SaveImage().ReadyToSaving;
            SaveImage.convertedImageSavedNotify += new FileToZip().StartCompressing;

            Console.ReadKey();
        }
    }
}
