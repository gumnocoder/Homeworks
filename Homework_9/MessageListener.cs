using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using static Homework_9.ImageMessage;
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
        public static string outputFormat = "";
        public void Listen(object sender, MessageEventArgs e)
        {
            
            var ee = e.Message.Text;
            if (ee == "/start") new SendHelp().SendMessage(e);
            if (inputImageExists)
            {
                switch (ee)
                {
                    case "BMP":
                        outputFormat = ".bmp";
                        break;
                    case "PNG":
                        outputFormat = ".png";
                        break;
                    case "GIF":
                        outputFormat = ".gif";
                        break;
                    case "TIFF":
                        outputFormat = ".tiff";
                        break;
                }
                Console.WriteLine($"inputImageExists {inputImageExists} outputFormat ({outputFormat})");
                StartSave(e);
            }
        }
    }

    public class ImageMessage : MessageListener
    {
        public static bool inputImageExists = false;

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
}
