using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;

namespace Homework_9
{
    public interface ITalk
    {
        void SendMessage(string chatId, TelegramBotClient bot);
    }

    public class SendHelp : ITalk
    {
        public void SendMessage(string chatId, TelegramBotClient bot)
        {
            bot.SendTextMessageAsync(chatId, "Добро пожаловать в конвертер изображений!\n\n");
            bot.SendTextMessageAsync(chatId, "Вы можете отправить в чат изображение, после чего Вам будет \n" +
                "предложен формат для конвертирования, на выбор.\n" +
                "В результате конвертирования Вам вернётся \n" +
                "заархивированное изображение в заказанном формате.\n" +
                "Приятного использования!");
        }
    }

    public class SendArchive : ITalk
    {
        public string path;
        public string Path { get; set; }

        public string archive;
        public string Archive { get; set; }

        public SendArchive(string Path, string Archive)
        {
            this.path = Path;
            this.archive = Archive;
        }
        public async void SendMessage(string chatId, TelegramBotClient bot)
        {
            await using (Stream stream = File.OpenRead(this.path))
            {
                await bot.SendDocumentAsync(
                    chatId: chatId,
                    document: new InputOnlineFile(content: stream, fileName: this.archive),
                    caption: this.archive
                );
            }

            
        }
    }
}
