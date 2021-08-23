using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Homework_9
{
    class CallBack
    {
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
            switch (e.CallbackQuery.Data)
            {
                case ".bmp":
                    outputFormat = ".bmp";
                    break;
                case ".gif":
                    outputFormat = ".gif";
                    break;
                case ".png":
                    outputFormat = ".png";
                    break;
                case ".tiff":
                    outputFormat = ".tiff";
                    break;
            }
            e.CallbackQuery.Data = "";
            queryContentFlag = true;
        }

    }
}
