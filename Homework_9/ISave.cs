using System.Drawing;
using System.Drawing.Imaging;
using static Homework_9.ImageMessage;
using Telegram.Bot.Args;
using System.IO;
using Telegram.Bot;
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

    /// <summary>
    /// Загружает картинку отправленную пользователем
    /// </summary>
    public class SaveImageFromUser
    {
        /// <summary>
        /// 
        /// </summary>
        public static string inputFile;
        /// <summary>
        /// 
        /// </summary>
        public static string InputFileJpg;
        /// <summary>
        /// 
        /// </summary>
        public static string inputImageId;


        public ITelegramBotClient bot;
        public ITelegramBotClient Bot { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="Bot"></param>
        public SaveImageFromUser(ITelegramBotClient Bot)
        {
            this.bot = Bot;
        }

        /// <summary>
        /// для создания события уведомляющего 
        /// об окончании сохранения изображения от пользователя
        /// </summary>
        public delegate void ImageFromUserSavedNotify();
        /// <summary>
        /// событие окончания сохранения файла от пользователя
        /// </summary>
        public event ImageFromUserSavedNotify imageFromUserSavedNotify;

        public static bool flag = true;

        /// <summary>
        /// событие окончания сохранения пользовательского изображения
        /// </summary>
        /// <param name="e"></param>
        [Obsolete]
        public async void ImageSavedFlag(MessageEventArgs e)
        {
            await Task.Run(delegate ()
            {
                if (File.Exists(InputFileJpg) 
                & new FileInfo(InputFileJpg).Length > 0 
                & imageFromUserSavedNotify != null 
                & flag == true)
                {
                    imageFromUserSavedNotify();
                }
            });
        }

        /// <summary>
        /// содержит логику сохранения изобрадения от пользователя
        /// </summary>
        /// <param name="e"></param>
        [Obsolete]
        public async void SaveFromStream(MessageEventArgs e)
        {
            inputFile = e.Message.MessageId.ToString();
            InputFileJpg = e.Message.MessageId.ToString() + ".jpg";
            inputImageId = e.Message.Photo[^1].FileId.ToString();

            /// поток для загрузки изображения
            using (FileStream fs = new FileStream(InputFileJpg, FileMode.Create))
            {
                await bot.GetInfoAndDownloadFileAsync(inputImageId, fs);
                ImageSavedFlag(e);
            }
        }
    }

    /// <summary>
    /// Переключает формат и вызывает соответствующий класс ISave
    /// </summary>
    public class SaveImage
    {
        /// <summary>
        /// выйл выходного изображения
        /// </summary>
        public static string outputFile;

        /// <summary>
        /// для события оповещающего об успешной конвертации
        /// </summary>
        /// <param name="e"></param>
        [Obsolete]
        public delegate void ConvertedImageSavedNotify(MessageEventArgs e);
        /// <summary>
        /// событие успешной конвертации
        /// </summary>
        [Obsolete]
        public static event ConvertedImageSavedNotify convertedImageSavedNotify;

        /// <summary>
        /// метод содержащий логику конвертирования
        /// </summary>
        /// <param name="e"></param>
        [Obsolete]
        public static async void StartSave(MessageEventArgs e)
        {
            /// полное название конечного рисунка
            outputFile = SaveImageFromUser.inputFile + StartMessage.outputFormat;
            /// загружает в переменную изображение из исходного файла
            var img = Image.FromFile(SaveImageFromUser.InputFileJpg);

            /// вызывает подходящий метод сохранения в зависимости от выбранного формата
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
                    if (convertedImageSavedNotify != null & outputFile != "") 
                    { 
                        convertedImageSavedNotify(e);
                        FileToZip.ArchiveWithConvertedFile = outputFile + ".zip";
                    }
                }
            });
        }
    }
}
