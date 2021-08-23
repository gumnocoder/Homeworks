using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Homework_9
{
    public interface ISave
    {
        void SaveToFile(string outputFile, Image img);
    }

    public class SaveToBmp : ISave
    {
        public void SaveToFile(string outputFile, Image img)
        {
            img.Save(outputFile, ImageFormat.Bmp);
        }
    }

    public class SaveToGif : ISave
    {
        public void SaveToFile(string outputFile, Image img)
        {
            img.Save(outputFile, ImageFormat.Gif);
        }
    }

    public class SaveToPng : ISave
    {
        public void SaveToFile(string outputFile, Image img)
        {
            img.Save(outputFile, ImageFormat.Png);
        }
    }

    public class SaveToTiff : ISave
    {
        public void SaveToFile(string outputFile, Image img)
        {
            img.Save(outputFile, ImageFormat.Tiff);
        }
    }
}
