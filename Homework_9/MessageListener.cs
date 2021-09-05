using System;

using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using static Homework_9.ImageMessage;
using static Homework_9.SaveImage;
using static Homework_9.TeleBot;


namespace Homework_9
{
    public interface MessageListener
    {
        [Obsolete]
        void Listen(object sender, MessageEventArgs e);
    }

    /// <summary>
    /// обрабатывает запросы
    /// </summary>
    public class StartMessage : MessageListener
    {
        /// <summary>
        /// флаг начала работы с ботом
        /// </summary>
        public bool firstMessageFlag = true;

        /// <summary>
        /// выбранный формат
        /// </summary>
        public static string outputFormat = "";

        /// <summary>
        /// флаг текущей операции получения файла с сервера
        /// </summary>
        public static bool FlagToGetFile = false;

        [Obsolete]
        public void Listen(object sender, MessageEventArgs e)
        {
            
            var ee = e.Message.Text;

            /// отправляет приветственное сообщение и инструкции
            if (ee == "/start")
            {
                new SendHelp().SendMessage(e);
            }
            /// отправляет список
            else if (ee == "/getdir")
            {
                GetFilesOnServer.getFilesOnServer(e);
            }
            /// для получения файла с сервера
            else if (ee == "/getfile")
            {
                bot.SendTextMessageAsync(
                    e.Message.Chat.Id, 
                    "Введите название файла который хотите получить. " +
                    "Регистр букв учитывается");
                FlagToGetFile = true;
            }
            /// для отправки запрошенного файла или 
            /// при получении неучтённых сообщений
            else
            {
                if (FlagToGetFile)
                {
                    if (ee != null & ee != "")
                    {
                        SendFileOnRequest.CheckFile(ee, e);
                    }
                    else
                    {
                        bot.SendTextMessageAsync(
                            e.Message.Chat.Id,
                            "Невозможно распознать запрос");
                    }
                }
                else if (firstMessageFlag)
                {
                    bot.SendTextMessageAsync(
                    e.Message.Chat.Id,
                    "Воспользуйтесь командой /start");
                    firstMessageFlag = false;
                }
            }

            /// позволяет выбрать формат
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
                /// запускает сохранение в выбранном формате
                StartSave(e);
            }
        }
    }

    /// <summary>
    /// проверяет наличие изображения в сообщении
    /// </summary>
    public class ImageMessage : MessageListener
    {
        /// <summary>
        /// указывает на наличие отсутствии обрабатываемого изображения в логике
        /// </summary>
        public static bool inputImageExists = false;
        /// <summary>
        /// для создания события
        /// </summary>
        /// <param name="e"></param>
        [Obsolete]
        public delegate void ImageSended(MessageEventArgs e);
        /// <summary>
        /// событие оповещающее о наличии изображения
        /// </summary>
        [Obsolete]
        public event ImageSended onPhoto;

        /// <summary>
        /// метод вызывающий событие указывающее на наличие изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Obsolete]
        public void Listen(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == MessageType.Photo) 
            {
                //Console.WriteLine(e.Message.);
                inputImageExists = true;
                onPhoto(e);
            }
        }
    }
}
