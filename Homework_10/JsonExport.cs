using System;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json;
using static Homework_10.TeleBot;
namespace Homework_10
{
    class JsonExport
    {
        /// <summary>
        /// наименование файла содержащего экспортированные сообщения
        /// </summary>
        public static string jsonData = "messages_list.json";

        /// <summary>
        /// архивация файла json
        /// </summary>
        private static void ArchiveOldJson()
        {
            DateTime now = DateTime.Now;
            string time = now.ToString("t");
            // имя нового архива с датой
            // в формате 1.1.2021_12-00_messages_list.json
            string outp = $"{now.ToString("d")}_" +
                $"{time.Replace(time[2], Convert.ToChar("-"))}_" +
                $"{jsonData}.zip";

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

        /// <summary>
        /// удаление файла json
        /// </summary>
        private static void DeleteOldJson()
        {
            File.Delete(jsonData);
        }

        /// <summary>
        /// проверка наличия файла json
        /// </summary>
        /// <returns></returns>
        private static bool CreateJsonFile()
        {
            /// создаёт в случае отсутствия
            if (!File.Exists(jsonData))
            {
                using FileStream fs = File.Create(jsonData);
                return true;
            }
            /// если файл есть то архивирует старый, 
            /// удаляет старый и создаёт новый 
            else
            {
                ArchiveOldJson();
                DeleteOldJson();
                return CreateJsonFile();
            }
        }

        /// <summary>
        /// Сохраняет лог сообщений в файл
        /// </summary>
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
