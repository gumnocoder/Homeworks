using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace Homework_13_bank_system.Models.appliedFunctional
{
    public static class DataSaver<T> where T : ISerializible
    {
        private static void savingBtn_Click(object sender, RoutedEventArgs e)
        {
            SavingChain("users.json");
        }

        public static void SavingChain(string outputFile)
        {
            JsonSeralize(UsersLists<T>.usersList, outputFile);
        }

        private static void DeleteIfExists(string outputFile)
        {
            string pathToFile = Path.Combine(Environment.CurrentDirectory + @"\" + outputFile);
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
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
