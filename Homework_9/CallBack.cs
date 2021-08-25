using System;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Homework_9
{
    class CallBack
    {
        public delegate void CallBackContent();

        public event CallBackContent GetCallbackContent; 

        public static string outputFormat;

        public static bool queryContentFlag = false;

        

        /// <summary>
        /// кнопки выбора конечного формата
        /// при нажатии кнопки отправляет запрос боту
        /// </summary>
        /// <returns></returns>
        public static InlineKeyboardMarkup keyboard()
        {
            return new InlineKeyboardMarkup(new[]
                        {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("BMP", ".bmp"),
                        InlineKeyboardButton.WithCallbackData("GIF", ".gif"),
                        InlineKeyboardButton.WithCallbackData("PNG", ".png"),
                        InlineKeyboardButton.WithCallbackData("TIFF", ".tiff"),
                    }
                });
        }

        /// <summary>
        /// В зависимости от нажатой кнопки записывает
        /// в переменную нужный формат, затем очищает запрос
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        public static void ChooseOutputFormat(object s, CallbackQueryEventArgs e)
        {
            var ee = e.CallbackQuery.Data;
            if (ee == ".bmp") { outputFormat = ".bmp"; }
            else if (ee == ".gif") { outputFormat = ".gif"; }
            else if (ee == ".png") { outputFormat = ".png"; }
            else if (ee == ".tiff") { outputFormat = ".tiff"; }
            //Console.WriteLine(outputFormat);
            //Console.Write($"({e.CallbackQuery.Data})");
            
            //e.CallbackQuery.Data.Remove(0);
            e.CallbackQuery.Data = "";

            string[] str = e.CallbackQuery.Data.Split();
            foreach (var elem in str)
            {
                Console.WriteLine(elem);
            }
            queryContentFlag = true;
        }

    }
}
