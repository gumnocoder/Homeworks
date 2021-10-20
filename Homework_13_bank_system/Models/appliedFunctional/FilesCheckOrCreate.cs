using System.IO;

namespace Homework_13_bank_system.Models.appliedFunctional
{
    /// <summary>
    /// Проверяетналичие файла и создает его в случае отстутствия
    /// </summary>
    public class FilesCheckOrCreate
    {
        public static string GetIniContent(string path)
        {
            string a = string.Empty;
            if (File.Exists(path))
            {
                using (StreamReader sw = new(path))
                { a = sw.ReadToEnd(); }
            }
            else File.Create(path);
            return a;
        }
    }
}