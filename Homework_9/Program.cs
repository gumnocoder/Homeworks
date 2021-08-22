using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using ImageMagick;
using Newtonsoft.Json.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using static Homework_9.imageConverter;
using static Homework_9.TeleBot;

namespace Homework_9
{
    class imageConverter
    {
        public static string inputImage;

        public static string outputImage;

        public static string outputFormat;

        public static string chatId;
        public static async void Download(TelegramBotClient bot)
        {
            //string id = inputImage;
            string FileName = inputImage + ".jpg";
            Console.WriteLine(FileName);
            using (FileStream fs = new FileStream(FileName, FileMode.Create))
            {
                Console.WriteLine("FileCreated");
                await bot.GetInfoAndDownloadFileAsync(inputImage, fs);
                Image img = Image.FromStream(fs);

                while (true)
                {
                    InlineKeyboardMarkup keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(new[]
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
                        bot.OnCallbackQuery += async (object sc, CallbackQueryEventArgs ev) =>
                        {
                            var message = ev.CallbackQuery.Message;
                            if (ev.CallbackQuery.Data == ".jpg")
                            {
                                outputFormat = ".jpg";
                                ev.CallbackQuery.Data = "";
                                flag = true;
                            }
                            else
                            if (ev.CallbackQuery.Data == ".gif")
                            {
                                outputFormat = ".gif";
                                ev.CallbackQuery.Data = "";
                                flag = true;
                            }
                            else
                            if (ev.CallbackQuery.Data == ".png")
                            {
                                outputFormat = ".png";
                                ev.CallbackQuery.Data = "";
                                flag = true;
                            }
                            else
                            if (ev.CallbackQuery.Data == ".tiff")
                            {
                                outputFormat = ".tiff";
                                ev.CallbackQuery.Data = "";
                                flag = true;
                            }
                        };
                        if (flag == true) break;
                    }

                    outputImage = inputImage + outputFormat;

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
                //ConvertImage();

                //outputFormat = Console.ReadLine();
            }
            Console.WriteLine("getted");
        }

/*        public static async void ConvertImage()
        {
            Image img;
            await using (FileStream file = File.Open(inputImage + ".jpg", FileMode.Open, FileAccess.Read))
            {
                img = Image.FromStream(file);

                outputImage = inputImage + outputFormat;

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
            }
        }*/
    }

    public class TeleBot
    {

        /*             void MessageListener(object sender, MessageEventArgs e)
            {
                string text = $"{DateTime.Now.ToLongTimeString()} {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text} {e.Message.Type} end";

                Console.WriteLine(text);

                var message = e.Message.Text;
                var messageType = e.Message.Type.ToString();
                Console.WriteLine(message);

                Thread task = new Thread(Download);
                task.Start();

                if (e.Message.Type == MessageType.Photo)
                {
                    Console.WriteLine("загружаю изображение");
                    Download(e.Message.Photo[^1].FileId);
                    *//*                    using (var img = new MagickImage("tmp.jpg"))
                                        {
                                            // -fuzz XX%
                                            //img.ColorFuzz = new Percentage(10);
                                            // -transparent white
                                            //img.Transparent(MagickColors.White);
                                            img.Write("image.png");
                                        }*/
        /*
                        }

                        if (e.Message.Text != null)
                        {
                            var ee = e.Message.Text.ToLower();
                            if (ee == "спой")
                            {
                                Program.bot.SendTextMessageAsync(e.Message.Chat.Id, "ла ла ла ла");
                            }
                            else if (ee == "привет" | ee == "hi")
                            {

                                Program.bot.SendTextMessageAsync(e.Message.Chat.Id, "Привет!");
                                var Filename = "hi.jpeg";
                                var FilePath = Path.Combine(Environment.CurrentDirectory, Filename);
                                using (var stream = File.OpenRead(FilePath))
                                {
                                    var r = Program.bot.SendPhotoAsync(e.Message.Chat.Id, new InputOnlineFile(stream)).Result;
                                }
                            }
                            else if (ee == "опрос")
                            {
                                var pollMessage = Program.bot.SendPollAsync(
                                        e.Message.Chat.Id,
                                        question: "Нравится бот?",
                                        options: new[]
                                        {
                                                    "да!",
                                                    "нет"
                                        }
                                    );
                            }
                            else
                            {
                                Program.bot.SendTextMessageAsync(e.Message.Chat.Id, @"Не понял ¯\_(ツ)_/¯");
                            }
                        }

        */
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
                if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Photo)
                {
                    chatId = e.Message.Chat.Id.ToString();
                    //string a = e.Message.Chat.Id.ToString()
                    bot.SendTextMessageAsync(e.Message.Chat.Id, "Это что, фотка?");
                    inputImage = e.Message.Photo[^1].FileId.ToString();
                    Console.WriteLine(inputImage);
                    Download(bot);

                    //using (FileStream fs = File.Create("tmp"))
                    //bot.DownloadFileAsync(e.Message.Photo[^1].FileId, fs);
                    //File.Delete("tmp");
                    //using (FileStream fs = new FileStream("tmp", FileMode.Create))
                    //    bot.GetInfoAndDownloadFileAsync(e.Message.Photo[^1].FileId, fs);




                    //Upload();

                }
            }

            bot.OnMessage += MessageListener;
            bot.StartReceiving();
            Console.ReadKey();
        }

        /*public static string message = null;

        //public static long messageChatId;

        

        
        static Stream ConvertImage(this Stream originalStream, ImageFormat format)
        {
            var image = Image.FromStream(originalStream);

            var stream = new MemoryStream();
            image.Save(stream, format);
            stream.Position = 0;
            return stream;
        }
        static void Main()
        {

             //WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };

             
             //string startUrl = $@"https://api.telegram.org/bot{token}/";
             //int update_id = 0;
             //string photo = @"C:\Users\user0\source\repos\Homeworks\Homework_9\bin\Debug\netcoreapp3.1\hi.jpeg";

            



            void SavePhoto()
            {




                string path = "tmp.jpg";
                Image img = null;

                using (var file = File.Open(path, FileMode.Open, FileAccess.Read))
                    img = Image.FromStream(file);
                string path2 = "tmp.png";
                img.Save(path2, ImageFormat.Png);
                

                //img.Save(path2, ImageFormat.Png);
                //img.Dispose();

            *//*                string FileName = "tmp.jpg";
                            string oFileName = "tmp.png";

                            var image = new MagickImage(FileName);

                                image.Format = MagickFormat.Png;
                                image.Write(oFileName);*//*

            }



                async void Download(string id)
                {
                    FileStream fs = new FileStream("tmp.jpg", FileMode.Create);
                    await Program.bot.GetInfoAndDownloadFileAsync(id, fs);
                    fs.Close();
                    fs.Dispose();
                }
            }

            //SavePhoto();

*/



            //Console.ReadKey();
        /*
                }*/
    }
}
