using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
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

        public static async void ChooseOutputFormat(object s, CallbackQueryEventArgs ev)
        {

            var message = ev.CallbackQuery.Message;

            if (ev.CallbackQuery.Data == ".jpg") outputFormat = ".jpg"; 
            else if (ev.CallbackQuery.Data == ".gif") outputFormat = ".gif";
            else if (ev.CallbackQuery.Data == ".png") outputFormat = ".png";
            else if (ev.CallbackQuery.Data == ".tiff") outputFormat = ".tiff";

            ev.CallbackQuery.Data = "";
            queryContentFlag = true;
        }
        public static async void Download(TelegramBotClient bot, string chatId, MessageEventArgs e)
        {
            string FileName = imageName + ".jpg";
            using (FileStream fs = new FileStream(FileName, FileMode.Create))
            {
                await bot.GetInfoAndDownloadFileAsync(inputImage, fs);
                Image img = Image.FromStream(fs);

                while (true)
                {
                    InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup(new[]
                        {
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("JPG", ".jpg"),
                                InlineKeyboardButton.WithCallbackData("GIF", ".gif"),
                                InlineKeyboardButton.WithCallbackData("PNG", ".png"),
                                InlineKeyboardButton.WithCallbackData("TIFF", ".tiff"),
                            }
                        });

                    await bot.SendTextMessageAsync(chatId, "Выберите формат в который хотите конвертировать изображение", replyMarkup: keyboard);
                    bool flag = false;
                    while (true)
                    {

                        bot.OnCallbackQuery += ChooseOutputFormat;
                        if (queryContentFlag == true) break;
                    }

                    queryContentFlag = false;

                    outputImage = imageName + outputFormat;

                    switch (outputFormat)
                    {
                        case ".jpg":
                            img.Save(outputImage, ImageFormat.Jpeg);
                            break;
                        case ".png":
                            img.Save(outputImage, ImageFormat.Png);
                            break;
                        case ".gif":
                            img.Save(outputImage, ImageFormat.Gif);
                            break;
                        case ".tiff":
                            img.Save(outputImage, ImageFormat.Tiff);
                            break;
                    }
                    break;
                }
            }
            FileToZip(bot, outputImage, chatId);
            returnConvertedAndCompressed(bot, outputImage, chatId);
        }

        public static string zippedImage;

        public static void FileToZip(TelegramBotClient bot, string outputImage, string chatId)
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
        TelegramBotClient bot;
        string token;

        public TelegramBotClient Bot;
        public string Token;

        public static string setToken()
        {
             return File.ReadAllText("token.ini");
        }
    }

    class Program
    {
        static void Main()
        {
            TelegramBotClient bot = new TelegramBotClient(setToken());

            void MessageListener(object sender, MessageEventArgs e)
            {
                if (e.Message.Text != null)
                {
                    bot.SendTextMessageAsync(e.Message.Chat.Id, e.Message.Text);
                }
                if (e.Message.Type == MessageType.Photo)
                {
                    chatId = e.Message.Chat.Id.ToString();
                    bot.SendTextMessageAsync(e.Message.Chat.Id, "Обнаружил изображение, запускаем сценарий");
                    inputImage = e.Message.Photo[^1].FileId.ToString();
                    imageName = e.Message.MessageId.ToString();
                    Download(bot, chatId, e);
                }
            }

            bot.OnMessage += MessageListener;
            bot.StartReceiving();
            Console.ReadKey();
        }
    }
}
