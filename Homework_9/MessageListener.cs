using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace Homework_9
{
    public interface MessageListener
    {
        void Listen(object sender, MessageEventArgs e);
    }

    public class StartMessage : MessageListener
    {
        public TelegramBotClient bot;
        public TelegramBotClient Bot { get; set; }

        public StartMessage(TelegramBotClient Bot)
        {
            this.bot = Bot;
        }

        public void Listen(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "/start")
            {
                new SendHelp().SendMessage(e.Message.Chat.Id.ToString(), bot);
            }
        }
    }

    public class ImageMessage : MessageListener
    {
        public delegate void ImageSended(object sender, MessageEventArgs e);

        public event ImageSended onPhoto;
        public void Listen(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == MessageType.Photo) onPhoto(sender, e);
        }
    }

    public class ImageChecked : MessageListener
    {
        public TelegramBotClient bot;

        public TelegramBotClient Bot { get; set; }

        public ImageChecked(TelegramBotClient Bot)
        {
            this.bot = Bot;
        }

        public void Listen(object sender, MessageEventArgs e)
        {
            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), "Изображение!");
        }
    }

}
