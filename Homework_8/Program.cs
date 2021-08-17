using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
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

        /// <summary>
        /// словарь для сортировщика в алфавитном порядке
        /// </summary>
        public static Dictionary<string, int> dict = new Dictionary<string, int>();
        public static string nums = " 0123456789";
        public static string liters = "аАбБвВгГдДеЕёЁжЖзЗ" +
            "иИкКлЛмМнНоОпПрРсСтТуУфФхХцЦчЧшШщЩъЪьЬэЭыЫюЮяЯ" +
            "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ-_=+/*";

        /// <summary>
        /// заполнение словаря для сортировщика
        /// </summary>
        public static void fillDict()
        {
            /// цифры имеют меньший вес
            for (int i = 0; i < 11; i++)
            {
                dict.Add(nums[i].ToString(), i);
            }
            /// строчные и прописные буквы одинаковый, сначала русский алфавит затем английский
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
            Console.WriteLine($"\nНажмите любую клавишу...\n");
            Console.ReadKey();
            Console.Clear();
        }

        #region XML (де)сериализация

        public static bool fileError = false;

        public static string xmlData = "company_struct.xml";

        /// <summary>
        /// сохраняет структуру в xml
        /// </summary>
        /// <param name="comp"></param>
        public static void CompanyToXml(Company comp)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Company));
            using (Stream fstream = new FileStream(xmlData, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fstream, comp);
            }
        }

        /// <summary>
        /// загружает струткуру из xml
        /// </summary>
        /// <returns></returns>
        public static Company CompanyFromXml()
        {
            /// проверка наличия файла
            if (File.Exists(xmlData))
            {
                /// создаём поток
                FileStream fs = new FileStream(xmlData, FileMode.Open);
                /// создаём парсер
                XmlReader xmlReader = XmlReader.Create(fs);
                /// создаём сериализатор
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Company));
                Company tmpComp;
                /// парсим данные во временную переменную
                tmpComp = (Company)xmlSerializer.Deserialize(xmlReader);
                /// закрываем поток
                fs.Close();
                /// возвращаем данные
                return tmpComp;
            }
            else
            {
                fileError = true;
                /// в случае отсутствия файла возвращаем текущую компанию
                return com;
            }
        }

        #endregion

        #region JSON (де)сериализация

        public static string jsonData = "company_struct.json";

        /// <summary>
        /// сохраняет структуру в json
        /// </summary>
        /// <param name="comp"></param>
        public static void CompanyToJson(Company comp)
        {
            string json = JsonConvert.SerializeObject(comp);
            File.WriteAllText(jsonData, json);
        }

        /// <summary>
        /// Загружает структуру из json
        /// </summary>
        /// <returns></returns>
        public static Company CompanyFromJson()
        {
            if (File.Exists(jsonData))
            {
                Company tmpComp = new Company();
                string json = File.ReadAllText(jsonData);
                tmpComp = JsonConvert.DeserializeObject<Company>(json);
                return tmpComp;
            }
            else
            {
                fileError = true;
                return com;
            }
        }

        #endregion

        #region МЕНЮ

        /// <summary>
        /// главное меню
        /// </summary>
        public static void ShowStartMenu()
        {
            Console.Clear();
            Console.WriteLine($"\nКомпания {com.Print()}" +
                $"\nГЛАВНОЕ МЕНЮ" +
                $"\nвведите пункт меню и нажмите enter\n" +
                $"\n1. Работа с департаментами" +
                $"\n2. Работа с сотрудниками" +
                $"\n3. Вывод на экран" +
                $"\n4. Сохранение в файл" +
                $"\n5. Загрузка из файла" +
                $"\n\n0. Завершить работу приложения\n");
        }

        #endregion

        #region МЕТОДЫ ВВОДА-ВЫВОДА

        /// <summary>
        /// проверяет является ли пользовательский ввод int
        /// </summary>
        /// <param name="input"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool checkIntInput(string input, int a, int b)
        {
            if (int.TryParse(input, out int tmp) & tmp >= a & tmp <= b) return true;
            else return false;
        }

        /// <summary>
        /// парсит пользовательский ввод в указанном диапазоне
        /// </summary>
        /// <param name="minNum"></param>
        /// <param name="maxNum"></param>
        /// <returns></returns>
        public static int TakeMenuInput(int minNum, int maxNum)
        {
            while (true)
            {
                string text = Console.ReadLine();
                if (checkIntInput(text, minNum, maxNum)) return int.Parse(text);
                Departments.Errors(5);
            }
        }

        /// <summary>
        /// парсит ввод даты
        /// </summary>
        /// <returns></returns>
        public static DateTime TakeDateInput()
        {
            while (true)
            {
                string text = Console.ReadLine();
                if (DateTime.TryParse(text, out DateTime tmp)) return tmp;
                Departments.Errors(5);
            }
        }

        #endregion

        #region МЕТОДЫ СОРТИРОВКИ

        /// <summary>
        /// Сортировщик по номеру
        /// </summary>
        /// <returns>возвращает экземпляр сортировщика</returns>
        public static IComparer<Staff> CompareNumber()
        {
            CompareNumber cnu = new CompareNumber();
            return cnu;
        }

        /// <summary>
        /// сортировщик по имени
        /// </summary>
        /// <returns>возвращает экземпляр сортировщика</returns>
        public static IComparer<Staff> CompareName()
        {
            CompareName cn = new CompareName();
            return cn;
        }

        /// <summary>
        /// сортировщик по фамилии
        /// </summary>
        /// <returns>возвращает экземпляр сортировщика</returns>
        public static IComparer<Staff> CompareLastName()
        {
            CompareLastName cln = new CompareLastName();
            return cln;
        }

        /// <summary>
        /// сортировщик по возрасту
        /// </summary>
        /// <returns>возвращает экземпляр сортировщика</returns>
        public static IComparer<Staff> CompareAge()
        {
            CompareAge ca = new CompareAge();
            return ca;
        }

        /// <summary>
        /// сортировщик по отделу
        /// </summary>
        /// <returns>возвращает экземпляр сортировщика</returns>
        public static IComparer<Staff> CompareDep()
        {
            CompareDep cd = new CompareDep();
            return cd;
        }

        /// <summary>
        /// Сортировщик по проектам
        /// </summary>
        /// <returns>возвращает экземпляр сортировщика</returns>
        public static IComparer<Staff> CompareProjects()
        {
            CompareProjects cp = new CompareProjects();
            return cp;
        }

        /// <summary>
        /// сортировщик по зарплате
        /// </summary>
        /// <returns>возвращает экземпляр сортировщика</returns>
        public static IComparer<Staff> CompareSalary()
        {
            CompareSalary cs = new CompareSalary();
            return cs;
        }

        #endregion

        
        static void Main(string[] args)
        {

            Random rnd = new Random();
            fillDict();

            #region МЕНЮ

            while (true)
            {
                ShowStartMenu();
                bool flag = true;
                while (flag == true)
                {
                    
                    int input = TakeMenuInput(0, 5);

                    switch (input)
                    {
                        case 0:
                            System.Environment.Exit(1);
                            break;
                        /// работа с департаментами
                        case 1:
                            flag = menu_1.menu();
                            break;
                        /// работа с сотрудниками
                        case 2:
                            flag = menu_2.menu();
                            break;
                        /// вывод на экран
                        case 3:
                            flag = menu_3.menu();
                            break;
                        /// сохранение в файл
                        case 4:
                            flag = menu_4.menu();
                            break;
                        /// загрузка из файла
                        case 5:
                            flag = menu_5.menu();
                            break;
                        }
                }
            }
        }
        #endregion
    }
}
