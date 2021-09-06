using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_10
{
    /// <summary>
    /// для создания обьекта файл в текущем каталоге
    /// </summary>
    public class RootContent
    {
        /// <summary>
        /// название
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// расширение
        /// </summary>
        public string FileExtension { get; set; }
        /// <summary>
        /// размер
        /// </summary>
        public float FileSize { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="FileName">название</param>
        /// <param name="FileExtension">расширение</param>
        /// <param name="FileSize">размер</param>
        public RootContent(string FileName, string FileExtension, float FileSize)
        {
            this.FileName = FileName;
            this.FileExtension = FileExtension;
            this.FileSize = FileSize;
        }
    }
}
