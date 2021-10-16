using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using static Homework_13_bank_system.UsersLists;

namespace Homework_13_bank_system.Models.appliedFunctional
{
    public static class DataSaver
    {
        private static void savingBtn_Click(object sender, RoutedEventArgs e)
        {
            SavingChain();
        }

        public static void SavingChain()
        {
            JsonSeralize(usersList, "users.json");
        }

        private static void DeleteIfExists(string path)
        {
            string pathToFile = Path.Combine(Environment.CurrentDirectory + @"\" + path);
            if (File.Exists(path))
            {
                Debug.WriteLine(File.Exists(path));
                File.Delete(path);
                Debug.WriteLine(File.Exists(path));
            }
        }
        public static void JsonSeralize(object serializibleObject, string path)
        {
            DeleteIfExists(path);
            string json = JsonConvert.SerializeObject(serializibleObject);
            File.WriteAllText(path, json);
        }
    }
}
