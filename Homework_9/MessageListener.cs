﻿using System;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using static Homework_9.ImageMessage;
using static Homework_9.SaveImage;


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
        /// выбранный формат
        /// </summary>
        public static string outputFormat = "";

        [Obsolete]
        public void Listen(object sender, MessageEventArgs e)
        {
            
            var ee = e.Message.Text;
            /// отправляет приветственное сообщение и инструкции
            if (ee == "/start") new SendHello().SendMessage(e);
            else if (ee == "/getdir")
            {
                GetFilesOnServer.getFilesOnServer(e);
            }

            else if (ee != null | ee != "") new SendHelp().SendMessage(e);
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