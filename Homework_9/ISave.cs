using System.Drawing;
using System.Drawing.Imaging;

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
    /// Переключает формат и вызывает соответствующий класс ISave
    /// </summary>
    public class SaveImage : ISave
    {

        string outputFormat;
        public  string OutputFormat { get; set; }

        /// <summary>
        /// принимает параметром новый формат
        /// </summary>
        /// <param name="OutputFormat">новый формат</param>
        public SaveImage(string OutputFormat)
        {
            this.outputFormat = OutputFormat;
        }
        
        /// <summary>
        /// Вызывает нужный метод сохранения
        /// </summary>
        /// <param name="outputFile"></param>
        /// <param name="img"></param>
        public void SaveToFile(string outputFile, Image img)
        {
            switch (this.outputFormat)
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
        }
    }
}
