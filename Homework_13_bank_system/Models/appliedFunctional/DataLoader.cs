using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Homework_13_bank_system.Models.personsBin;
using Newtonsoft.Json;

namespace Homework_13_bank_system.Models.appliedFunctional
{
    public static class DataLoader<T> where T : ISerializible
    {
        public static void LoadFromJson(List<T> targetList, string inputFile)
        {
            if (File.Exists(inputFile))
            {
                List<T> tmp = new();
                using (FileStream fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                {
                    string json = File.ReadAllText(inputFile);
                    tmp = JsonConvert.DeserializeObject<List<T>>(json);
                }

                targetList = tmp;
            }
            else
            {
                Debug.WriteLine(File.Exists(inputFile));
                targetList = new List<T>();
            }
        }
    }
}
