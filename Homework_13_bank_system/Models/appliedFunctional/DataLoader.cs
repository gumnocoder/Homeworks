using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace Homework_13_bank_system.Models.appliedFunctional
{
    public static class DataLoader<T> where T : ISerializible
    {
        public static void LoadingChain(string outputFile)
        {
            //usersList = new();
            UsersLists<T>.usersList = LoadFromJson(outputFile);
        }

        public static List<T> LoadFromJson(string outputFile)
        {
            if (File.Exists(outputFile))
            {
                List<T> tmp = new();
                using (FileStream fs = new FileStream(outputFile, FileMode.Open, FileAccess.Read))
                {
                    string json = File.ReadAllText(outputFile);
                    tmp = JsonConvert.DeserializeObject<List<T>>(json);
                }

                return tmp;
            }
            else
            {
                Debug.WriteLine(File.Exists(outputFile));
                return new List<T>();
            }
        }

    }
}
