using System.IO;

namespace Homework_13_bank_system
{
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
}
