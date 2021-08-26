using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using static Homework_9.TurnConversionFlag;
using static Homework_9.SaveImage;
using static Homework_9.SaveImageFromUser;
using System.Drawing;

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
                    if (inputImageExists)
                    {
                        outputFormat = ".bmp";
                        Console.WriteLine($"inputImageExists {inputImageExists} outputFormat ({outputFormat})");
                        StartSave(e);
                    }
                    break;
                case "PNG":
                    if (inputImageExists)
                    {
                        outputFormat = ".png";
                        Console.WriteLine($"inputImageExists {inputImageExists} outputFormat ({outputFormat})");
                        StartSave(e);
                    }
                    break;
                case "GIF":
                    if (inputImageExists)
                    {
                        outputFormat = ".gif";
                        Console.WriteLine($"inputImageExists {inputImageExists} outputFormat ({outputFormat})");
                        StartSave(e);
                    }
                    break;
                case "TIFF":
                    if (inputImageExists)
                    {
                        outputFormat = ".tiff";
                        Console.WriteLine($"inputImageExists {inputImageExists} outputFormat ({outputFormat})");
                        StartSave(e);
                    }
                    break;
            }
        }
    }

    public class ImageMessage : MessageListener
    {
        public delegate void ImageSended(MessageEventArgs e);

        public event ImageSended onPhoto;

        public void Listen(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == MessageType.Photo) { inputImageExists = true; Console.WriteLine($"{e.Message.Type} sended"); OnPhoto(e); }
        }
        public void OnPhoto(MessageEventArgs e)
        {
            onPhoto(e);
            Console.WriteLine($"onPhoto event");
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
