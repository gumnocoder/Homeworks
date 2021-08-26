using System;
using System.IO;
using Telegram.Bot;

namespace Homework_9
{
    /// <summary>
    /// Создаёт бота и назначает ему токен
    /// </summary>
    public static class TeleBot
    {
        static readonly string token = "token.ini";

        public static TelegramBotClient bot = new TelegramBotClient(setToken());

        /// <summary>
        /// парсит файл с токеном
        /// </summary>
        /// <returns></returns>
        public static string setToken()
        {
            if (File.Exists(token)) return File.ReadAllText(token);
            /// во избежание ошибок
            else Environment.Exit(0);
            return "end";
        }
    }
}
