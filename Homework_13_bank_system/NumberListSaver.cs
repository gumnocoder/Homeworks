using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Homework_13_bank_system
{
    class NumberListSaver
    {
        public static void CheckDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public static void CheckFile(string path)
        {
            if (!File.Exists(path))
            {
                using FileStream fs = File.Create(path);
            }
        }

        public static void WriteNumbers<T>(string path, string filePath, T list)
        {
            CheckDirectory(path);
            CheckFile(filePath);
            using (StreamWriter sw = new StreamWriter(filePath)) { 
                foreach (long e in list as ObservableCollection<long>) 
                { sw.WriteLine(e); } }
        }

        public static void ReadNumbers<T>(string path, string filePath, T list)
        {
            using (StreamReader sr = new StreamReader(filePath))
            { foreach (var line in filePath) (list as ObservableCollection<long>).Add(Convert.ToInt64(line)); }
        }
    }
}
