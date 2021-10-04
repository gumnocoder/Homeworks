using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Homework_13_bank_system.UsersLists;
using static Homework_13_bank_system.IdSetter;
using Newtonsoft.Json;
using static Homework_13_bank_system.JsonDataLoadSave;
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

        public static void JsonSeralize(object e, string path)
        {
            string json = JsonConvert.SerializeObject(e);
            File.WriteAllText(path, json);
        }
    }
    class IdSetter
    {

        public static int currentUsersId;

        public static int ReturnCurrentId()
        {
            CheckOrder();
            SetOrder();
            return currentUsersId++;
        }
        public static void CheckOrder()
        {
            string source = "number.ini";

            if (!File.Exists(source))
            {
                CreateOrder();
                SetFirstNumber();
            }
        }

        public static void CreateOrder()
        {
            string source = "number.ini";
            using FileStream fs = File.Create(source);
        }

        public static void SetFirstNumber()
        {
            string source = "number.ini";
            File.WriteAllText(source, "10000");
        }

        public static void SetOrder()
        {
            string source = File.ReadAllText("number.ini");
            if (int.TryParse(source, out int tmp))
                currentUsersId = tmp;
        }

        public static void writeOrderToFile()
        {
            string source = "number.ini";
            File.WriteAllText(source, currentUsersId.ToString());
        }
    }

    class UsersLists
    {
        public static List<User> usersList;

        public User this[int Id]
        {
            get 
            {
                User u = null;

                if (usersList.Count > 0)
                {
                    foreach (User t in usersList)
                    {  if (t.UserId == Id) { u = t; } }
                }

                return u;
            }
        }
        public User this[string Name]
        {
            get
            {
                User u = null;

                if (usersList.Count > 0)
                {
                    foreach (User t in usersList)
                    { if (t.Name.ToLower() == Name.ToLower()) { u = t; } }
                }

                return u;
            }
        }

        public UsersLists()
        {
            usersList = new();
        }

        public static void AddToList(User user)
        {
            usersList.Add(user);
        }

        
    }
    class User
    {
        //static List<User> usersList;


        int userId;
        public int UserId { get => userId; set => userId = value; }

        public string Name { get ; set; }

        string pass;
        public string Pass { get => pass; set => pass = value; }

        public User(string Name, string Pass)
        {
            this.Name = Name;
            this.Pass = Pass;
            UserId = ReturnCurrentId();
            AddToList(this);
            writeOrderToFile();
            //if (usersList == null) usersList = new();
            //usersList.Add(this);
        }

        public void ReName(string newName)
        {
            Name = newName;
        }

        public void ResetPass(string newPass)
        {
            Pass = newPass;
        }
        public override string ToString()
        {
            return $"{Name} {Pass} {UserId}";
        }
    }
}
