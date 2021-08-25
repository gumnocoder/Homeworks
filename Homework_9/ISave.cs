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

    public interface IStreamSave
    {
        void SaveFromStream(MessageEventArgs e);
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

    public class SaveImageFromUser : IStreamSave

    {
        public static string inputFile;

        public static string inputImageId;


        public ITelegramBotClient bot;

        public ITelegramBotClient Bot { get; set; }


        public SaveImageFromUser(ITelegramBotClient Bot)
        {
            this.bot = Bot;
        }

        public delegate void imageSaved(MessageEventArgs e);

        public event imageSaved ImageSaved;

        public async void SaveFromStream(MessageEventArgs e)
        {
            inputFile = e.Message.MessageId.ToString() + ".jpg";
            Console.WriteLine($"inputFile {inputFile}");
            inputImageId = e.Message.Photo[^1].FileId.ToString();
            Console.WriteLine($"inputImageId {inputImageId}");
            using (FileStream fs = new FileStream(inputFile, FileMode.Create))
            {
                await bot.GetInfoAndDownloadFileAsync(inputImageId, fs);
                ImageSavedFlag(e); Console.WriteLine($"!File.Exists(inputFile) {!File.Exists(inputFile)} FileInfo(inputFile).Length {new FileInfo(inputFile).Length}");
            }
        }

        public static bool flag = true;

        public async void ImageSavedFlag(MessageEventArgs e)
        {
            await Task.Run(delegate ()
            {
                if (File.Exists(inputFile) & new FileInfo(inputFile).Length > 0 & ImageSaved != null & flag == true)
                {
                    ImageSaved(e);
                    Console.WriteLine("ImageSaved");
                }
            });
        }
    }

    /// <summary>
    /// Переключает формат и вызывает соответствующий класс ISave
    /// </summary>
    public class SaveImage : ISave
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

        public async void ReadyToSaving(MessageEventArgs e)
        {
            await Task.Run(() =>
            {
                SaveImageFromUser.flag = false;
                Console.WriteLine("ReadyToSaving");
                Image img = Image.FromFile(SaveImageFromUser.inputFile);
                Console.WriteLine(StartMessage.outputFormat);
            });

            //SaveToFile(inputImage + StartMessage.outputFormat, img);
        }
        
        /// <summary>
        /// Вызывает нужный метод сохранения
        /// </summary>
        /// <param name="outputFile"></param>
        /// <param name="img"></param>
        public void SaveToFile(string outputFile, Image img)
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
        }
    }
}
