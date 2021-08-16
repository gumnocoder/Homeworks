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
            Console.WriteLine($"\npress anykey\n");
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
            Console.Clear();
            Console.WriteLine($"\nКомпания {com.Print()}" +
                $"\nГЛАВНОЕ МЕНЮ" +
                $"\nвведите пункт меню и нажмите enter\n" +
                $"\n1. Работа с департаментами" +
                $"\n2. Работа с сотрудниками" +
                $"\n3. Вывод на экран" +
                $"\n4. Сохранение в файл" +
                $"\n5. Загрузка из файла\n");
        }

        public static void ShowMenu_1()
        {
            Console.Clear();
            Console.WriteLine($"\nРабота с департаментами\n" +
                $"\n1. Создание одного или нескольких департаментов" +
                $"\n2. Редактирование департамента" +
                $"\n3. Удаление департамента" +
                $"\n4. Вывод списка сотрудников департамента" +
                $"\n\n5. Главное меню\n");
        }

        public static void ShowMenu_2()
        {
            Console.Clear();
            Console.WriteLine($"\nРабота с сотрудниками\n" +
                $"\n1. Создание одного или нескольких сотрудников" +
                $"\n2. Редактирование сотрудника" +
                $"\n3. Удаление сотрудника" +
                $"\n\n4. Главное меню\n");
        }

        public static void ShowMenu_3()
        {
            Console.Clear();
            Console.WriteLine($"\nВывод на экран\n" +
                $"\n1. Вывод структуры организации" +
                $"\n2. Вывод полного списка сотрудников" +
                $"\n3. Вывод списка сотрудников одного департамента" +
                $"\n4. Сортировка списка сотрудников" +
                $"\n\n5. Главное меню\n");
        }

        public static void ShowMenu_4()
        {
            Console.Clear();
            Console.WriteLine($"\nСохранение в файл\n" +
                $"\n1. Сохранение департаментов в XML" +
                $"\n2. Сохранение департаментов в Json" +
                $"\n3. Сохранение сотрудников в XML" +
                $"\n4. Сохранение сотрудников в Json" +
                $"\n\n5. Главное меню\n");
        }

        public static void ShowMenu_5()
        {
            Console.Clear();
            Console.WriteLine($"\nВывод на экран\n" +
                $"\n1. Загрузка департаментов из XML" +
                $"\n2. Загрузка департаментов из Json" +
                $"\n3. Загрузка сотрудников из XML" +
                $"\n4. Загрузка сотрудников из Json" +
                $"\n\n5. Главное меню\n");
        }

        public static bool checkIntInput(string input, int a, int b)
        {
            if (int.TryParse(input, out int tmp) & tmp >= a & tmp <= b) return true;
            else return false;
        }

        public static int TakeMenuInput(int minNum, int maxNum)
        {
            while (true)
            {
                string text = Console.ReadLine();
                if (checkIntInput(text, minNum, maxNum)) return int.Parse(text);
                Departments.Errors(5);
            }
        }

        public static DateTime TakeDateInput()
        {
            while (true)
            {
                string text = Console.ReadLine();
                if (DateTime.TryParse(text, out DateTime tmp)) return tmp;
                Departments.Errors(5);
            }
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();

            while (true)
            {
                ShowStartMenu();
                bool flag = true;
                while (flag == true)
                {
                    int input = TakeMenuInput(1, 5);
                    switch (input)
                    {
                        case 1:
                            ShowMenu_1();
                            input = TakeMenuInput(1, 5);
                            switch (input)
                            {
                                case 1:
                                    Console.WriteLine("Введите необходимое количество департаментов" +
                                        "\n(отделы будут созданы со значениями по умолчанию, " +
                                        "после создания Вы сможете их отредактировать)\n");
                                    input = TakeMenuInput(1, 100);
                                    for (int i = 0; i < input; i++) com.AddDep(new Departments($"Отдел_{i}", DateTime.Now));
                                    Console.WriteLine("Готово");
                                    delay();
                                    flag = false;
                                    break;
                                case 2:
                                    Console.Clear();
                                    if (com.deps.Count > 0)
                                    {
                                        com.PrintCompanyDeps();
                                        Console.WriteLine("\nВведите номер департамента согласно индексу\n");
                                        input = TakeMenuInput(0, com.deps.Count);
                                        bool localFlag = true;
                                        while (localFlag == true)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"\nРедактируем отдел: {com.deps[input].Print()}\n");
                                            Console.WriteLine("\n1 для изменения названия " +
                                                "\n2 для изменения даты создания " +
                                                "\n0 для выхода из редактора\n");
                                            int localInput = TakeMenuInput(0, 2);
                                            switch (localInput)
                                            {
                                                case 0:
                                                    localFlag = false;
                                                    flag = false;
                                                    break;
                                                case 1:
                                                    Console.WriteLine("Введите новое название");
                                                    string newName = Console.ReadLine();
                                                    com.EditDepName(input, newName);
                                                    Console.WriteLine("Готово");
                                                    delay();
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Введите новую дату");
                                                    DateTime newDate = TakeDateInput();
                                                    com.EditDepDate(input, newDate);
                                                    Console.WriteLine("Готово");
                                                    delay();
                                                    break;
                                            }
                                        }
                                    }
                                    else Departments.Errors(6);
                                    delay();
                                    break;
                                case 3:
                                    Console.Clear();
                                    if (com.deps.Count > 0)
                                    {
                                        com.PrintCompanyDeps();
                                        Console.WriteLine("\nВведите номер департамента согласно индексу\n");
                                        input = TakeMenuInput(0, com.deps.Count);
                                        com.RemoveDep(input);
                                        Console.WriteLine("Удаление завершено");
                                        flag = false;
                                    }
                                    else Departments.Errors(6);
                                    delay();
                                    break;
                                case 4:
                                    Console.Clear();
                                    if (com.deps.Count > 0)
                                    {
                                        bool localFlag = true;
                                        while(localFlag == true)
                                        {
                                            com.PrintCompanyDeps();
                                            Console.WriteLine("\nВведите номер департамента согласно индексу\n");
                                            input = TakeMenuInput(0, com.deps.Count);
                                            if (com.deps[input].staff.Count == 0)
                                            {
                                                Console.Clear();
                                                Departments.Errors(7);
                                                delay();
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                com.deps[input].PrintDepContent();
                                                localFlag = false;
                                                delay();
                                            }
                                        }
                                    }
                                    else Departments.Errors(6);
                                    flag = false;
                                    delay();
                                    break;
                                case 5:
                                    flag = false;
                                    break;
                            }
                            break;
                        case 2:
                            ShowMenu_2();
                            input = TakeMenuInput(1, 4);
                            switch (input)
                            {
                                case 1:
                                    if (com.deps.Count == 0)
                                    {
                                        Console.WriteLine("Сначала добавьте департамент!");
                                        flag = false;
                                        delay();
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        com.PrintCompanyDeps();
                                        Console.WriteLine("\nвыберите департамент\n");
                                        input = TakeMenuInput(0, com.deps.Count);
                                        Console.Clear();
                                        Console.WriteLine("Сколько хотите добавить работников? " +
                                            "\n(отредактировать поля можно после создания");
                                        int localInput = TakeMenuInput(1, 1000000);
                                        for (int i = 0; i < localInput; i++)
                                        {
                                            com.deps[input].AddStaff(new Staff
                                                ($"Сотрудник_{rnd.Next(1, 30)}",
                                                $"номер_{rnd.Next(1, 30)}",
                                                rnd.Next(18, 45),
                                                com.deps[input].DepName,
                                                rnd.Next(10_000, 45_000),
                                                rnd.Next(0, 5)));
                                        }
                                        flag = false;
                                        delay();
                                    }
                                    break;
                                case 2:
                                    Console.Clear();
                                    com.PrintCompanyDeps();
                                    Console.WriteLine("\nвыберите департамент с сотрудниками\n");
                                    input = TakeMenuInput(0, com.deps.Count);
                                    if (com.deps[input].staff.Count == 0)
                                    {
                                        Console.Clear();
                                        Departments.Errors(7);
                                        delay();
                                        flag = false;
                                    }
                                    else
                                    {
                                        bool localFlag = true;
                                        while (localFlag == true)
                                        {
                                            com.deps[input].PrintDepContent();
                                            Console.WriteLine("\nВведите номер сотрудника согласно индексу\n");
                                            input = TakeMenuInput(0, com.deps[input].staff.Count);
                                            switch (input)
                                            {
                                                case 1:
                                                    break;
                                                case 2:
                                                    break;
                                                case 3:
                                                    break;
                                                case 4:
                                                    break;
                                                case 5:
                                                    break;
                                                case 6:
                                                    break;
                                            }
                                        }
                                    }
                                    /// 
                                    /// ChangeStaffName(int pos, string newName)
                                    /// ChangeStaffLastName(int pos, string newLastName)
                                    /// ChangeAge(int pos, string newAge)
                                    /// ChangeSalary(int pos, string newSalary)
                                    /// ChangeProjects(int pos, string newProjects)
                                    /// ChangeDep(int pos, Departments otherDep)
                                    /// 
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    flag = false;
                                    break;
                            }
                            break;
                        case 3:
                            ShowMenu_3();
                            input = TakeMenuInput(1, 5);
                            switch (input)
                            {
                                case 1:
                                    Console.Clear();
                                    com.PrintCompanyDeps();
                                    delay();
                                    flag = false;
                                    break;
                                case 2:
                                    Console.Clear();
                                    com.PrintCompanyStaff();
                                    delay();
                                    flag = false;
                                    break;
                                case 4:
                                    flag = false;
                                    break;
                            }
                            break;
                        case 4:
                            ShowMenu_4();
                            input = TakeMenuInput(1, 5);
                            switch (input)
                            {
                                case 5:
                                    flag = false;
                                    break;
                            }
                            break;
                        case 5:
                            ShowMenu_5();
                            input = TakeMenuInput(1, 5);
                            switch (input)
                            {
                                case 5:
                                    flag = false;
                                    break;
                            }
                            break;
                        }
                    }
                }

                //for (int i = 0; i < 9; i++)
                //{
                //    com.AddDep(new Departments($"отдел_{i}", Convert.ToDateTime($"1.01.200{i}")));
                //}
                //com.PrintCompanyDeps();
                //delay();
                //Random rnd = new Random();
                //for (int i = 0; i < 9; i++)
                //{
                //    for (int j = 0; j < 20; j++)
                //    {
                //        com.deps[i].AddStaff(new Staff($"Сотрудник_{rnd.Next(1, 20)}", $"номер_{j}", 10 + j, com.deps[i].DepName, rnd.Next(10_000, 20_000), i));
                //    }
                //}
                //com.PrintCompanyStaff();
                //delay();
                //com.deps[8].PrintDepContent();
                //Console.WriteLine();
                //CompareName cn = new CompareName();
                //CompareAge ca = new CompareAge();
                //CompareNumber cnu = new CompareNumber();

                ////com.deps[8].staff.Sort(ca);
                ////com.deps[8].PrintDepContent();
                //com.deps[8].staff.Sort(cn);
                //com.deps[8].PrintDepContent();
                ////com.deps[8].staff.Sort(cnu);
                ////com.deps[8].PrintDepContent();
                //delay();

                //foreach (Departments dep in com.deps) dep.staff.Sort(cn);
                //com.PrintCompanyStaff();

                //delay();
        }
    }
}
