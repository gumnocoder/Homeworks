using System;
using System.Drawing;
using System.IO;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using static Homework_9.TeleBot;
using static Homework_9.CallBack;
using Telegram.Bot.Types.ReplyMarkups;

namespace Homework_9
{

    class Program
    {
        public static string inputImage;
        public static string imageName;
        public static string outputImage;
        public static string chatId;
        public static string zippedImage;
        public static bool controlFlag = false;
        public static bool inputImageExists = false;

        [Obsolete]

        public static async void SendKeyboard(object sender, MessageEventArgs e)
        {
            inputImageExists = true;
            chatId = e.Message.Chat.Id.ToString();
            var keyboard = new ReplyKeyboardMarkup
            {
                Keyboard = new[] {
                    new[]
                    {
                        new KeyboardButton("BMP"),
                        new KeyboardButton("PNG"),
                        new KeyboardButton("GIF"),
                        new KeyboardButton("TIFF"),
                    },
                },
                ResizeKeyboard = true, OneTimeKeyboard = true,
                
            };
            await bot.SendTextMessageAsync(chatId, "Выберите формат в который хотите конвертировать изображение", replyMarkup: keyboard);
        }

        [Obsolete]
        static void Main()
        {
            async void MessageListener(object sender, MessageEventArgs e)
            {
                chatId = e.Message.Chat.Id.ToString();

                if (e.Message.Text == "/start")
                {
                    new SendHelp().SendMessage(e.Message.Chat.Id.ToString(), bot);
                }
                if (e.Message.Type == MessageType.Photo)
                {
                    await bot.SendTextMessageAsync(e.Message.Chat.Id, "Обнаружил изображение, запускаем сценарий");
                    inputImage = e.Message.Photo[^1].FileId.ToString();
                    imageName = e.Message.MessageId.ToString();
                    //if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, chatId))) 
                    //    Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, chatId));
                    string path = Path.Combine(Environment.CurrentDirectory, chatId);
                    string FileName = imageName + ".jpg";
                    using (FileStream fs = new FileStream(FileName, FileMode.Create))
                    {
                        await bot.GetInfoAndDownloadFileAsync(inputImage, fs);
                        Image img = Image.FromStream(fs);

                        while (true)
                        {
                            await bot.SendTextMessageAsync(chatId, "Выберите формат в который хотите конвертировать изображение", replyMarkup: CallBack.keyboard());
                            bool flag = false;
                            while (true)
                            {
                                bot.OnCallbackQuery += ChooseOutputFormat;
                                if (queryContentFlag == true) break;
                            }

                            queryContentFlag = false;
                            outputImage = imageName + outputFormat;
                            new SaveImage(outputFormat).SaveToFile(outputImage, img);
                            break;
                        }
                    }
                    new FileToZip().CompressFile(bot, outputImage);
                    zippedImage = outputImage + ".zip";
                    new SendArchive(Path.Combine(Environment.CurrentDirectory, zippedImage), zippedImage).SendMessage(chatId, bot);
                }
            }
            ImageMessage im = new ImageMessage();

            bot.OnMessage += new StartMessage(bot).Listen;
            bot.OnMessage += im.Listen;
            im.onPhoto += new ImageChecked(bot).Listen; im.onPhoto += SendKeyboard;

            bot.StartReceiving();
            Console.ReadKey();
        }
    }
}
