using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Homework_13_bank_system
{
    class JsonDataLoadSave
    {
        public static List<User> UsersFromJson()
        {
            string data = "users.json";

            if (File.Exists(data))
            {
                List<User> tmp = new();
                string json = File.ReadAllText(data);
                tmp = JsonConvert.DeserializeObject<List<User>>(json);
                return tmp;
            }
            else
            {
                return new List<User>();
            }
        }

        public static void JsonSeralize(object serializibleObject, string path)
        {
            string json = JsonConvert.SerializeObject(serializibleObject);
            File.WriteAllText(path, json);
        }
    }
}
