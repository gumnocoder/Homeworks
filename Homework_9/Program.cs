using System;
using System.Drawing;
using System.IO;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using static Homework_9.TeleBot;
using static Homework_9.CallBack;
using static Homework_9.TurnConversionFlag;
using Telegram.Bot.Types.ReplyMarkups;

namespace Homework_9
{
    class TurnConversionFlag
    {
        //public delegate void sendKeyboard(object sender, MessageEventArgs e);

        //public event sendKeyboard sk;

        public static bool inputImageExists = false;
        public static void TurnOff()
        {
            inputImageExists = false;
        }
        public void TurnOn(object sender, MessageEventArgs e)
        {
            Console.WriteLine(inputImageExists);
            inputImageExists = true;
            Console.WriteLine(inputImageExists);
            //sk(sender, e);
        }
    }
    class Program
    {
        public static string inputImage;
        public static string imageName;
        public static string outputImage;
        public static string chatId;
        public static string zippedImage;
        public static bool controlFlag = false;

        [Obsolete]

        public static ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup
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
            ResizeKeyboard = true,
            OneTimeKeyboard = true,
        };
        public static async void SendKeyboard(object sender, MessageEventArgs e)
        {
            await bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), "Выберите формат в который хотите конвертировать изображение", replyMarkup: keyboard);
        }

        /// <summary>
        /// Переключает флаг разрешения на ковертирование после выбора формата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static async void ChooseFormat(object sender, MessageEventArgs e)
        {
            var mt = e.Message.Text;

            if (inputImageExists)
            {
                while (inputImageExists)
                {
                    if (mt == "BMP"
                    | mt == "PNG"
                    | mt == "GIF"
                    | mt == "TIFF")
                    {
                        outputFormat = mt;
                        Console.WriteLine($"{outputFormat} {inputImageExists}");
                        TurnOff();
                    }
                }

                
            }
            
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
            TurnConversionFlag tkf = new TurnConversionFlag();
            bot.StartReceiving();
            bot.OnMessage += new StartMessage(bot).Listen;
            bot.OnMessage += im.Listen;
            im.onPhoto += new ImageChecked(bot).Listen; im.onPhoto += SendKeyboard;
            im.onPhoto += new TurnConversionFlag().TurnOn;
            //im.onPhoto += SendKeyboard;
            //im.onPhoto += ChooseFormat;
            
            //tkf.sk += SendKeyboard;
            /// если присылают сообщение
            /// и сообщение содержит картинку
            /// бот присылает клавиатуру
            /// после нажатия кнопки назначается формат
            /// клавиатура пропадает
            Console.ReadKey();
        }
    }
}
