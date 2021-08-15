using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Homework_8
{
    class Program
    {
        public static string DepsXml = "deps_list.xml";
        public static string AllStaffXml = "all_staff_list.xml";
        public static string jsonDepsData = "deps_list.json";
        public static string jsonStaffData = "staff_list.json";

        public static Company com = new Company("Horns&Hooves");

        public static Dictionary<string, int> dict = new Dictionary<string, int>();
        public static string nums = " 0123456789";
        public static string liters = "аАбБвВгГдДеЕёЁжЖзЗ" +
            "иИкКлЛмМнНоОпПрРсСтТуУфФхХцЦчЧшШщЩъЪьЬэЭыЫюЮяЯ" +
            "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ-_=+/*";

        public static void fillDict()
        {
            for (int i = 0; i < 11; i++)
            {
                dict.Add(nums[i].ToString(), i);
            }
            for (int i = 1; i < liters.Length + 1; i++)
            {
                if (i % 2 != 0 | i == 0) dict.Add(liters[i - 1].ToString(), i + 10);
                else
                {
                    dict.Add(liters[i - 1].ToString(), i + 9);
                }
            }
        }

        /// <summary>
        /// задержка
        /// </summary>
        public static void delay()
        {
            Console.WriteLine($"press anykey");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        ///  общая коллекция работников
        /// </summary>
        static List<Staff> allStaff;

        /// <summary>
        /// при необходимости сериализации создаёт общую коллекцию работников
        /// </summary>
        /// <param name="comp">выбранной компании</param>
        public static void fillAllStaffList(Company comp)
        {
            /// чтобы данные были актуальны сначала стирает старые
            allStaff.Clear();
            /// перебирает департаменты
            foreach (var dep in comp.deps)
            {
                /// в них работников
                foreach (var staff in dep.staff)
                {
                    /// добавляет в коллекцию
                    allStaff.Add(staff);
                }
            }
        }

        #region XML (де)сериализация

        /// <summary>
        /// XML сериализация коллекции департаментов
        /// </summary>
        /// <param name="thisDepsList">выбранной компании</param>
        public static void DepsXmlSerial(Company comp)
        {
            /// создаёт экземпляр сериализатора
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Departments>));
            /// создаёт поток и записывает элементы коллекции в файл
            using (Stream fstream = new FileStream(DepsXml, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fstream, comp.deps);
            }
        }

        /// <summary>
        /// XML сериализация всех работников 
        /// </summary>
        /// <param name="comp">выбранной компании</param>
        public static void AllStaffXmlSerial(Company comp)
        {
            /// актуализирует данные
            fillAllStaffList(comp);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Staff>));
            using (Stream fstream = new FileStream(AllStaffXml, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fstream, allStaff);
            }
        }

        /// <summary>
        /// десериализация XML департаментов и вывод на консоль
        /// </summary>
        static void DeSerialDepsXML()
        {
            /// создаёт временную компанию для хранения списка департаментов
            Company tmpComp = new Company("tmp");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Departments>));
            using (Stream fStream = new FileStream(DepsXml, FileMode.Open, FileAccess.Read))
            {
                tmpComp.deps = xmlSerializer.Deserialize(fStream) as List<Departments>;
            }
            /// выводит данные на консоль
            tmpComp.PrintCompanyDeps();
        }

        /// <summary>
        /// десериализация XML всех работников и вывод на консоль
        /// </summary>
        /// <param name="comp"></param>
        static void DeSerialAllStaffXML()
        {
            /// создаёт временный департамент для хранения коллекции работников
            Departments tmpDep = new Departments();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Staff>));
            using (Stream fStream = new FileStream(AllStaffXml, FileMode.Open, FileAccess.Read))
            {
                tmpDep.staff = xmlSerializer.Deserialize(fStream) as List<Staff>;
            }
            /// выводит на консоль
            tmpDep.PrintDepContent();
        }

        #endregion

        #region JSON (де)сериализация

        /// <summary>
        /// Сериализация персонала
        /// </summary>
        /// <param name="comp"></param>
        public static void AllStaffJsonSerial(Company comp)
        {
            /// актуализация данных
            fillAllStaffList(comp);
            /// создаём сериализатор
            var json = JsonConvert.SerializeObject(allStaff);
            /// записываем данные в джейсон
            File.WriteAllText("all_staff_list.json", json);
        }

        /// <summary>
        /// Сериализация департаментов
        /// </summary>
        /// <param name="thisDepsList"></param>
        public static void DepsJsonSerial(List<Departments> thisDepsList)
        {
            var json = JsonConvert.SerializeObject(thisDepsList);
            File.WriteAllText("deps_list.json", json);
        }

        /// <summary>
        /// Десериализация департаментов
        /// </summary>
        public static void DepsJsonDeSerial()
        {
            /// читаем файл
            string json = File.ReadAllText("deps_list.json");
            /// создаём коллекцию элементов
            List<Departments> list = JsonConvert.DeserializeObject<List<Departments>>(json);
            /// перебираем элементы и выводим на консоль
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Print()}");
            }
        }

        /// <summary>
        /// десериализация персонала
        /// </summary>
        public static void StaffJsonDeSerial()
        {
            string json = File.ReadAllText("all_staff_list.json");
            List<Staff> list = JsonConvert.DeserializeObject<List<Staff>>(json);
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Print()}");
            }
        }

        #endregion


        public static void ShowStartMenu()
        {
            Console.WriteLine($"\nКомпания {com.Print()}" +
                $"\nГЛАВНОЕ МЕНЮ" +
                $"\nвведите пункт меню и нажмите enter\n" +
                $"\n1. ");
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 9; i++)
            {
                com.AddDep(new Departments($"отдел_{i}", Convert.ToDateTime($"1.01.200{i}")));
            }
            com.PrintCompanyDeps();
            delay();
            Random rnd = new Random();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    com.deps[i].AddStaff(new Staff($"Сотрудник_{rnd.Next(1, 20)}", $"номер_{j}", 10 + j, com.deps[i].DepName, rnd.Next(10_000, 20_000), i));
                }
            }
            com.PrintCompanyStaff();
            delay();
            com.deps[8].PrintDepContent();
            Console.WriteLine();
            CompareName cn = new CompareName();
            CompareAge ca = new CompareAge();
            CompareNumber cnu = new CompareNumber();

            //com.deps[8].staff.Sort(ca);
            //com.deps[8].PrintDepContent();
            com.deps[8].staff.Sort(cn);
            com.deps[8].PrintDepContent();
            //com.deps[8].staff.Sort(cnu);
            //com.deps[8].PrintDepContent();
            delay();

            foreach (Departments dep in com.deps) dep.staff.Sort(cn);
            com.PrintCompanyStaff();

            delay();
        }
    }
}
