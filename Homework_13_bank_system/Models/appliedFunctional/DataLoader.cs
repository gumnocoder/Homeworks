using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using static Homework_13_bank_system.Models.appliedFunctional.JsonDataLoadSave;
using static Homework_13_bank_system.UsersLists;

namespace Homework_13_bank_system.Models.appliedFunctional
{
    public static class DataLoader
    {
        public static void LoadingChain()
        {
            //usersList = new();
            usersList = UsersFromJson();
        }

        public static List<User> UsersFromJson()
        {
            string data = "users.json";

            if (File.Exists(data))
            {
                Debug.WriteLine(File.Exists(data));
                List<User> tmp = new();
                using (FileStream fs = new FileStream(data, FileMode.Open, FileAccess.Read))
                {
                    string json = File.ReadAllText(data);
                    tmp = JsonConvert.DeserializeObject<List<User>>(json);
                    Debug.WriteLine(tmp.Count);
                }
                
                return tmp;
            }
            else
            {
                Debug.WriteLine(File.Exists(data));
                return new List<User>();
            }
        }

    }
}
