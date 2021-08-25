using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using static Homework_9.TurnConversionFlag;
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

        public static string outputFormat = "";
        public void Listen(object sender, MessageEventArgs e)
        {
            var ee = e.Message.Text;
            switch (ee)
            {
                case "/start":
                    new SendHelp().SendMessage(e.Message.Chat.Id.ToString(), bot);
                    break;
                case "BMP":
                    if (inputImageExists) outputFormat = ".bmp";
                    break;
                case "PNG":
                    if (inputImageExists) outputFormat = ".png";
                    break;
                case "GIF":
                    if (inputImageExists) outputFormat = ".gif";
                    break;
                case "TIFF":
                    if (inputImageExists) outputFormat = ".tiff";
                    break;
            }
            Console.WriteLine($"{inputImageExists} {outputFormat}");
        }
    }

    public class ImageMessage : MessageListener
    {
        public delegate void ImageSended(object sender, MessageEventArgs e);

        public event ImageSended onPhoto;
        public void Listen(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == MessageType.Photo) { Console.WriteLine("photo"); onPhoto(sender, e); }
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
