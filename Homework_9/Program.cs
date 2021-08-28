using System;
using Telegram.Bot.Args;
using static Homework_9.TeleBot;
using Telegram.Bot.Types.ReplyMarkups;
using System.IO;

namespace Homework_9
{
    class Program
    {
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
        /// при получении изображения вызывает клавиатуру с кнопками для выбора формата
        /// </summary>
        /// <param name="e"></param>
        [Obsolete]
        public static async void SendKeyboard(MessageEventArgs e)
        {
            await bot.SendTextMessageAsync(
                e.Message.Chat.Id.ToString(), 
                "Выберите формат в который хотите конвертировать изображение",
                replyMarkup: keyboard);
        }


        [Obsolete]
        static void Main()
        {
            SaveImage.convertedImageSavedNotify += new FileToZip().StartCompressing;
            SaveImageFromUser si = new SaveImageFromUser(bot);
            SaveImage si_2 = new SaveImage();
            ImageMessage im = new ImageMessage();

            /// запуск бота
            bot.StartReceiving();
            /// подписка на получение сообщения 
            bot.OnMessage += new StartMessage().Listen;
            bot.OnMessage += im.Listen;
            /// подписка на получение фото-сообщения
            im.onPhoto += SendKeyboard;
            im.onPhoto += si.SaveFromStream;


            

            Console.ReadKey();
        }
    }
}
