using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Homework_9
{
    class FileToZip
    {
/*        public string outputImage;
        public string OutputImage { get; set ; }*/

        public void StartCompressing()
        {
            CompressFile(SaveImage.outputFile);
            /*this.outputImage = OutputImage;*/
        }

        public void CompressFile(string outputImage)
        {
            using (FileStream save = new FileStream(outputImage, FileMode.OpenOrCreate))
            {
                using (FileStream save2 = File.Create(outputImage + ".zip"))
                {
                    using (GZipStream save3 = new GZipStream(save2, CompressionMode.Compress))
                    {
                        save.CopyTo(save3);
                        Console.WriteLine($"file {outputImage + ".zip"} zipped");
                    }
                }
            }
        }
        /*public async void CompressFile(string outputImage)
        {
            Console.WriteLine($"CompressFile {outputImage}");
            await Task.Run(() =>
            {
                if (outputImage != null)
                {
                    using (FileStream save = new FileStream(outputImage, FileMode.OpenOrCreate))
                    {
                        using (FileStream save2 = File.Create(outputImage + ".zip"))
                        {
                            using (GZipStream save3 = new GZipStream(save2, CompressionMode.Compress))
                            {
                                save.CopyTo(save3);
                            }
                        }
                    }
                }
            });
        }*/
    }
}
