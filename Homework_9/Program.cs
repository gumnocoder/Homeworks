using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using static Homework_9.imageConverter;
using static Homework_9.TeleBot;

namespace Homework_9
{
    class imageConverter
    {
        public static string inputImage;
        public static string imageName;
        public static string outputImage;
        public static string outputFormat;
        public static string chatId;
        public static bool controlFlag = false;
        public static bool queryContentFlag = false;

        public static InlineKeyboardMarkup keyboard()
        {
            return new InlineKeyboardMarkup(new[]
                        {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("BMP", ".bmp"),
                        InlineKeyboardButton.WithCallbackData("GIF", ".gif"),
                        InlineKeyboardButton.WithCallbackData("PNG", ".png"),
                        InlineKeyboardButton.WithCallbackData("TIFF", ".tiff"),
                    }
                });
        }
        public static void ChooseOutputFormat(object s, CallbackQueryEventArgs e)
        {
            switch (e.CallbackQuery.Data)
            {
                case ".bmp":
                    outputFormat = ".bmp";
                    break;
                case ".gif":
                    outputFormat = ".gif";
                    break;
                case ".png":
                    outputFormat = ".png";
                    break;
                case ".tiff":
                    outputFormat = ".tiff";
                    break;
            }
            e.CallbackQuery.Data = "";
            queryContentFlag = true;
        }

        public static async void Scenario(TelegramBotClient bot, string chatId, MessageEventArgs e)
        {
            string FileName = imageName + ".jpg";
            using (FileStream fs = new FileStream(FileName, FileMode.Create))
            {
                await bot.GetInfoAndDownloadFileAsync(inputImage, fs);
                Image img = Image.FromStream(fs);

                while (true)
                {
                    await bot.SendTextMessageAsync(chatId, "Выберите формат в который хотите конвертировать изображение", replyMarkup: keyboard());
                    bool flag = false;
                    while (true)
                    {

                        bot.OnCallbackQuery += ChooseOutputFormat;
                        if (queryContentFlag == true) break;
                    }

                    queryContentFlag = false;

                    outputImage = imageName + outputFormat;

                    SaveImageToNewFormat(outputImage, outputFormat, img);

                    break;
                }
                
            }
            FileToZip(bot, outputImage);
            new SendArchive(Path.Combine(Environment.CurrentDirectory, zippedImage), zippedImage).SendMessage(chatId, bot);
            //returnConvertedAndCompressed(bot, outputImage, chatId);
        }
        public static void SaveImageToNewFormat(string outputImage, string outputFormat, Image img)
        {
            switch (outputFormat)
            {
                case ".bmp":
                    new SaveToBmp().SaveToFile(outputImage, img);
                    break;
                case ".png":
                    new SaveToPng().SaveToFile(outputImage, img);
                    break;
                case ".gif":
                    new SaveToGif().SaveToFile(outputImage, img);
                    break;
                case ".tiff":
                    new SaveToTiff().SaveToFile(outputImage, img);
                    break;
            }
        }

        public static string zippedImage;

        public static void FileToZip(TelegramBotClient bot, string outputImage)
        {

            zippedImage = outputImage + ".zip";
            using (FileStream save = new FileStream(outputImage, FileMode.OpenOrCreate))
            {
                using (FileStream save2 = File.Create(zippedImage))
                {
                    using (GZipStream save3 = new GZipStream(save2, CompressionMode.Compress))
                    {
                        save.CopyTo(save3);
                    }
                }
            }
        }

        public static async void returnConvertedAndCompressed(TelegramBotClient bot, string outputImage, string chatId)
        {
            await using (Stream stream = File.OpenRead(Path.Combine(Environment.CurrentDirectory, zippedImage)))
            {
                await bot.SendDocumentAsync(
                    chatId: chatId,
                    document: new InputOnlineFile(content: stream, fileName: zippedImage),
                    caption: zippedImage
                );
            }
        }
    }

    
    public class TeleBot
    {
        public static TelegramBotClient bot = new TelegramBotClient(setToken());
        public static string setToken()
        {
             return File.ReadAllText("token.ini");
        }
    }

    class Program
    {
        static void Main()
        {
            void MessageListener(object sender, MessageEventArgs e)
            {
                if (e.Message.Text == "/start")
                {
                    new SendHelp().SendMessage(e.Message.Chat.Id.ToString(), bot);
                }
                if (e.Message.Type == MessageType.Photo)
                {
                    chatId = e.Message.Chat.Id.ToString();
                    bot.SendTextMessageAsync(e.Message.Chat.Id, "Обнаружил изображение, запускаем сценарий");
                    inputImage = e.Message.Photo[^1].FileId.ToString();
                    imageName = e.Message.MessageId.ToString();
                    Scenario(bot, chatId, e);
                }
            }

            bot.OnMessage += MessageListener;
            bot.StartReceiving();
            Console.ReadKey();
        }
    }
}
