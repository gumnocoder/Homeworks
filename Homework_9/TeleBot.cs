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
        /// <summary>
        /// файл содержащий токен
        /// </summary>
        static readonly string token = "token.ini";

        /// <summary>
        /// бот
        /// </summary>
        public static TelegramBotClient bot = new TelegramBotClient(@"1903163949:AAF-KO0ar0FsHKgXfgqlYLxPjRWQeoFTPA4"/*setToken()*/);

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
    }
}
