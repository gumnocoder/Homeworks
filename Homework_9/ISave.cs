using System.Drawing;
using System.Drawing.Imaging;
using static Homework_9.TurnConversionFlag;
using static Homework_9.Program;
using Telegram.Bot.Args;
using System.IO;
using Telegram.Bot;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace Homework_9
{
    /// <summary>
    /// Принимает название конечного файла и 
    /// изображение над которым работаем
    /// </summary>
    public interface ISave
    {
        void SaveToFile(string outputFile, Image img);
    }

    /// <summary>
    /// конвертирует в BMP
    /// </summary>
    public class SaveToBmp : ISave
    {
        public void SaveToFile(string outputFile, Image img)
        {
            img.Save(outputFile, ImageFormat.Bmp);
        }
    }

    /// <summary>
    ///  конвертирует в GIF
    /// </summary>
    public class SaveToGif : ISave
    {
        public void SaveToFile(string outputFile, Image img)
        {
            img.Save(outputFile, ImageFormat.Gif);
        }
    }

    /// <summary>
    ///  конвертирует в PNG
    /// </summary>
    public class SaveToPng : ISave
    {
        public void SaveToFile(string outputFile, Image img)
        {
            img.Save(outputFile, ImageFormat.Png);
        }
    }

    /// <summary>
    ///  конвертирует в TIFF
    /// </summary>
    public class SaveToTiff : ISave
    {
        public void SaveToFile(string outputFile, Image img)
        {
            img.Save(outputFile, ImageFormat.Tiff);
        }
    }

    public class SaveImageFromUser

    {
        public static string inputFile;

        public static string InputFileJpg;

        public static string inputImageId;


        public ITelegramBotClient bot;

        public ITelegramBotClient Bot { get; set; }


        public SaveImageFromUser(ITelegramBotClient Bot)
        {
            this.bot = Bot;
        }

        public delegate void ImageFromUserSavedNotify();

        public event ImageFromUserSavedNotify imageFromUserSavedNotify;

        public async void SaveFromStream(MessageEventArgs e)
        {
            inputFile = e.Message.MessageId.ToString();
            InputFileJpg = e.Message.MessageId.ToString() + ".jpg";
            inputImageId = e.Message.Photo[^1].FileId.ToString();

            Console.WriteLine($"inputFile {inputFile}");
            Console.WriteLine($"inputImageId {inputImageId}");

            using (FileStream fs = new FileStream(InputFileJpg, FileMode.Create))
            {
                await bot.GetInfoAndDownloadFileAsync(inputImageId, fs);
                ImageSavedFlag(e); 
                Console.WriteLine($"!File.Exists(InputFileJpg) {!File.Exists(InputFileJpg)} FileInfo(inputFile).Length {new FileInfo(InputFileJpg).Length}");
            }
        }

        public static bool flag = true;

        public async void ImageSavedFlag(MessageEventArgs e)
        {
            await Task.Run(delegate ()
            {
                if (File.Exists(InputFileJpg) & new FileInfo(InputFileJpg).Length > 0 & imageFromUserSavedNotify != null & flag == true)
                {
                    imageFromUserSavedNotify();
                    Console.WriteLine("ImageSaved");
                }
            });
        }
    }

    /// <summary>
    /// Переключает формат и вызывает соответствующий класс ISave
    /// </summary>
    public class SaveImage
    {
/*        string outputFormat;
        public  string OutputFormat { get; set; }

        /// <summary>
        /// принимает параметром новый формат
        /// </summary>
        /// <param name="OutputFormat">новый формат</param>
        public SaveImage(string OutputFormat)
        {
            this.outputFormat = OutputFormat;
        }*/

        public async void ReadyToSaving()
        {
            await Task.Run(() =>
            {
                SaveImageFromUser.flag = false;
            });
        }
        public static string outputFile;

        public delegate void ConvertedImageSavedNotify();

        public static event ConvertedImageSavedNotify convertedImageSavedNotify;

        public static async void StartSave(MessageEventArgs e)
        {

            outputFile = SaveImageFromUser.inputFile + StartMessage.outputFormat;
            Console.WriteLine($"StartSave outputFile {outputFile}");
            var img = Image.FromFile(SaveImageFromUser.InputFileJpg);

            await Task.Run(() =>
            {
                if (StartMessage.outputFormat != null & StartMessage.outputFormat != "")
                {
                    switch (StartMessage.outputFormat)
                    {
                        case ".bmp":
                            new SaveToBmp().SaveToFile(outputFile, img);
                            break;
                        case ".png":
                            new SaveToPng().SaveToFile(outputFile, img);
                            break;
                        case ".gif":
                            new SaveToGif().SaveToFile(outputFile, img);
                            break;
                        case ".tiff":
                            new SaveToTiff().SaveToFile(outputFile, img);
                            break;
                    }

                    inputImageExists = false;
                    StartMessage.outputFormat = "";
                    Console.WriteLine($"image {outputFile} saved");
                    if (convertedImageSavedNotify != null & outputFile != "") 
                    { 
                        convertedImageSavedNotify(); 
                    }
                }
            });
        }
    }
}
