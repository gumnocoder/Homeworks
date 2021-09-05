using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static Homework_10.TeleBot;
namespace Homework_10
{
    class JsonExport
    {
        public static string jsonData = "messages_list.json";

        private static void ArchiveOldJson()
        {
            string outp = $"{DateTime.Now.ToString("d")}_{jsonData}.zip";
            using (FileStream save = new FileStream(jsonData, FileMode.OpenOrCreate))
            {
                using (FileStream save2 = File.Create(outp))
                {
                    using (GZipStream save3 = new GZipStream(save2, CompressionMode.Compress))
                    {
                        save.CopyTo(save3);
                    }
                }
            }
        }
        private static void DeleteOldJson()
        {
            File.Delete(jsonData);
        }
        private static bool CreateJsonFile()
        {
            if (!File.Exists(jsonData))
            {
                using FileStream fs = File.Create(jsonData);
                return true;
            }
            else
            {
                ArchiveOldJson();
                DeleteOldJson();
                return CreateJsonFile();
            }
        }

        public static void MessagesToJson()
        {
            if (CreateJsonFile())
            {
                string json = JsonConvert.SerializeObject(BotMessageLog);
                File.WriteAllText(jsonData, json);
            }
        }
    }
}
