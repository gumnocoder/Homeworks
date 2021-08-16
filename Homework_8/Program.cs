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
            Console.WriteLine($"\nНажмите любую клавишу...\n");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        ///  общая коллекция работников
        /// </summary>
        static List<Staff> allStaff = new List<Staff>();

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
            if (!File.Exists(DepsXml))
            {
                Departments.Errors(8);
            }
            else
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
        }

        /// <summary>
        /// десериализация XML всех работников и вывод на консоль
        /// </summary>
        /// <param name="comp"></param>
        static void DeSerialAllStaffXML()
        {
            if (!File.Exists(AllStaffXml))
            {
                Departments.Errors(8);
            }
            else
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
            File.WriteAllText(jsonStaffData, json);
        }

        /// <summary>
        /// Сериализация департаментов
        /// </summary>
        /// <param name="thisDepsList"></param>
        public static void DepsJsonSerial(List<Departments> thisDepsList)
        {
            var json = JsonConvert.SerializeObject(thisDepsList);
            File.WriteAllText(jsonDepsData, json);
        }

        /// <summary>
        /// Десериализация департаментов
        /// </summary>
        public static void DepsJsonDeSerial()
        {
            if (!File.Exists(jsonDepsData))
            {
                Departments.Errors(8);
            }
            else
            {
                /// читаем файл
                string json = File.ReadAllText(jsonDepsData);
                /// создаём коллекцию элементов
                List<Departments> list = JsonConvert.DeserializeObject<List<Departments>>(json);
                /// перебираем элементы и выводим на консоль
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.Print()}");
                }
            }
        }

        /// <summary>
        /// десериализация персонала
        /// </summary>
        public static void StaffJsonDeSerial()
        {
            if (!File.Exists(jsonStaffData))
            {
                Departments.Errors(8);
            }
            else
            {
                string json = File.ReadAllText(jsonStaffData);
                List<Staff> list = JsonConvert.DeserializeObject<List<Staff>>(json);
                foreach (var item in list)
                {
                    Console.WriteLine($"{item.Print()}");
                }
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
                $"\n5. Загрузка из файла" +
                $"\n\n0. Завершить работу приложения\n");
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
                    int input = TakeMenuInput(0, 5);
                    switch (input)
                    {
                        case 0:
                            System.Environment.Exit(1);
                            break;
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
                                    for (int i = 0; i < input; i++) com.AddDep(new Departments($"Отдел_{com.deps.Count}", DateTime.Now));
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
                                    if (com.deps.Count == 0)
                                    {
                                        Console.Clear();
                                        Departments.Errors(6);
                                        delay();
                                        flag = false;
                                    }
                                    else
                                    {
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
                                                Console.WriteLine("\n1 для продолжения 2 для выхода\n");
                                                int staffEditMenu = TakeMenuInput(1, 2);
                                                if (staffEditMenu == 2)
                                                {
                                                    flag = false;
                                                    break;
                                                }
                                                com.deps[input].PrintDepContent();
                                                Console.WriteLine("\nВведите номер сотрудника согласно индексу\n");
                                                int localInput = TakeMenuInput(0, com.deps[input].staff.Count);
                                                Console.Clear();
                                                Console.WriteLine($"будем редактировать сотрудника {com.deps[input].staff[localInput].Print()}");
                                                Console.WriteLine("для изменения поля введите:" +
                                                    "\n1 Имя" +
                                                    "\n2 Фамилия" +
                                                    "\n3 Возраст" +
                                                    "\n4 Зарплата" +
                                                    "\n5 Количество открытых проектов" +
                                                    "\n6 Сменить департамент" +
                                                    "\n\n7 Завершить редактирование");
                                                int editInput = TakeMenuInput(1, 7);
                                                switch (editInput)
                                                {
                                                    case 1:
                                                        /// ChangeStaffName(int pos, string newName)
                                                        Console.WriteLine("\nВведите новое имя\n");
                                                        string newName = Console.ReadLine();
                                                        com.deps[input].ChangeStaffName(localInput, newName);
                                                        Console.WriteLine("\nГотово\n");
                                                        delay();
                                                        break;
                                                    case 2:
                                                        /// ChangeStaffLastName(int pos, string newLastName)
                                                        Console.WriteLine("\nВведите новую фамилию\n");
                                                        newName = Console.ReadLine();
                                                        com.deps[input].ChangeStaffLastName(localInput, newName);
                                                        Console.WriteLine("\nГотово\n");
                                                        delay();
                                                        break;
                                                    case 3:
                                                        /// ChangeAge(int pos, int newAge)
                                                        Console.WriteLine("\nВведите новый возраст (от 18 до 75 лет)\n");
                                                        int newAge = TakeMenuInput(18, 75);
                                                        com.deps[input].ChangeAge(localInput, newAge);
                                                        Console.WriteLine("\nГотово\n");
                                                        delay();
                                                        break;
                                                    case 4:
                                                        /// ChangeSalary(int pos, int newSalary)
                                                        Console.WriteLine("\nВведите новую зарплату\n");
                                                        int newSalary = TakeMenuInput(0, 1000000);
                                                        com.deps[input].ChangeSalary(localInput, newSalary);
                                                        Console.WriteLine("\nГотово\n");
                                                        delay();
                                                        break;
                                                    case 5:
                                                        /// ChangeProjects(int pos, int newProjects)
                                                        Console.WriteLine("\nВведите новую зарплату\n");
                                                        int newProjects = TakeMenuInput(0, 1000);
                                                        com.deps[input].ChangeProjects(localInput, newProjects);
                                                        Console.WriteLine("\nГотово\n");
                                                        delay();
                                                        break;
                                                    case 6:
                                                        /// ChangeDep(int pos, Departments otherDep)
                                                        com.PrintCompanyDeps();
                                                        Console.WriteLine("\nВведите индекс департамента для перевода\n");
                                                        int depIndex = TakeMenuInput(0, com.deps.Count);
                                                        com.deps[input].ChangeDep(localInput, com.deps[depIndex]);
                                                        Console.WriteLine("\nГотово\n");
                                                        delay();
                                                        break;
                                                    case 7:
                                                        localFlag = false;
                                                        flag = false;
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case 3:
                                    if (com.deps.Count == 0)
                                    {
                                        Console.Clear();
                                        Departments.Errors(6);
                                        delay();
                                        flag = false;
                                    }
                                    else
                                    {
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
                                            Console.WriteLine("\nВведите номер сотрудника согласно индексу\n");
                                            int localInput = TakeMenuInput(0, com.deps[input].staff.Count);
                                            com.deps[input].RemoveStaff(localInput);
                                            Console.WriteLine("\nСотрудник удалён\n");
                                            flag = false;
                                            delay();
                                            break;
                                        }
                                    }
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
                                case 3:
                                    Console.Clear();
                                    if (com.deps.Count !=0)
                                    {
                                        com.PrintCompanyDeps();
                                        input = TakeMenuInput(0, com.deps.Count);
                                        if (com.deps[input].staff.Count == 0)
                                        {
                                            Console.Clear();
                                            Departments.Errors(7);
                                            delay();
                                            flag = false;
                                        }
                                        else com.deps[input].PrintDepContent();
                                        delay();
                                        flag = false;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Departments.Errors(6);
                                        delay();
                                        flag = false;
                                    }
                                    break;
                                case 4:
                                    CompareNumber cnu = new CompareNumber();
                                    CompareName cn = new CompareName();
                                    CompareLastName cln = new CompareLastName();
                                    CompareAge ca = new CompareAge();
                                    CompareDep cp = new CompareDep();
                                    CompareProjects cpr = new CompareProjects();
                                    CompareSalary cs = new CompareSalary(); 
                                    Console.Clear();
                                    if (com.deps.Count != 0)
                                    {
                                        com.PrintCompanyDeps();
                                        Console.WriteLine("Выберите отдел с сотрудниками");
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
                                            Console.WriteLine("Выберите поле сортировки " +
                                                "\n{0} - ID " +
                                                "\n{1} - имя " +
                                                "\n{2} - фамилия " +
                                                "\n{3} - возраст " +
                                                "\n{4} - департамент " +
                                                "\n{5} - проекты " +
                                                "\n{6} - зарплата",
                                                1, 2, 3, 4, 5, 6, 7);
                                            int localInput = TakeMenuInput(1, 7);
                                            switch (localInput)
                                            {
                                                case 1:
                                                    Console.WriteLine("\nСписок до сортировки:\n");
                                                    com.deps[input].PrintDepContent();
                                                    com.deps[input].staff.Sort(cnu);
                                                    Console.WriteLine("\nСписок после сортировки:\n");
                                                    com.deps[input].PrintDepContent();

                                                    break;
                                                case 2:
                                                    Console.WriteLine("\nСписок до сортировки:\n");
                                                    com.deps[input].PrintDepContent();
                                                    com.deps[input].staff.Sort(cn);
                                                    Console.WriteLine("\nСписок после сортировки:\n");
                                                    com.deps[input].PrintDepContent();
                                                    flag = false;
                                                    delay();
                                                    break;
                                                case 3:
                                                    Console.WriteLine("\nСписок до сортировки:\n");
                                                    com.deps[input].PrintDepContent();
                                                    com.deps[input].staff.Sort(cln);
                                                    Console.WriteLine("\nСписок после сортировки:\n");
                                                    com.deps[input].PrintDepContent();
                                                    flag = false;
                                                    delay();
                                                    break;
                                                case 4:
                                                    Console.WriteLine("\nСписок до сортировки:\n");
                                                    com.deps[input].PrintDepContent();
                                                    com.deps[input].staff.Sort(ca);
                                                    Console.WriteLine("\nСписок после сортировки:\n");
                                                    com.deps[input].PrintDepContent();
                                                    flag = false;
                                                    delay();
                                                    break;
                                                case 5:
                                                    Console.WriteLine("\nСписок до сортировки:\n");
                                                    com.deps[input].PrintDepContent();
                                                    com.deps[input].staff.Sort(cp);
                                                    Console.WriteLine("\nСписок после сортировки:\n");
                                                    com.deps[input].PrintDepContent();
                                                    flag = false;
                                                    delay();
                                                    break;
                                                case 6:
                                                    Console.WriteLine("\nСписок до сортировки:\n");
                                                    com.deps[input].PrintDepContent();
                                                    com.deps[input].staff.Sort(cpr);
                                                    Console.WriteLine("\nСписок после сортировки:\n");
                                                    com.deps[input].PrintDepContent();
                                                    flag = false;
                                                    delay();
                                                    break;
                                                case 7:
                                                    Console.WriteLine("\nСписок до сортировки:\n");
                                                    com.deps[input].PrintDepContent();
                                                    com.deps[input].staff.Sort(cs);
                                                    Console.WriteLine("\nСписок после сортировки:\n");
                                                    com.deps[input].PrintDepContent();
                                                    flag = false;
                                                    delay();
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Departments.Errors(6);
                                        delay();
                                        flag = false;
                                    }
                                    break;
                                case 5:
                                    flag = false;
                                    break;
                            }
                            break;
                        case 4:

                            ShowMenu_4();
                            input = TakeMenuInput(1, 5);
                            switch (input)
                            {
                                case 1:
                                    DepsXmlSerial(com);
                                    Console.WriteLine($"\nФайл {DepsXml} сохранен\n");
                                    flag = false;
                                    delay();
                                    break;
                                case 2:
                                    DepsJsonSerial(com.deps);
                                    Console.WriteLine($"\nФайл {jsonDepsData} сохранен\n");
                                    flag = false;
                                    delay();
                                    break;
                                case 3:
                                    AllStaffXmlSerial(com);
                                    Console.WriteLine($"\nФайл {AllStaffXml} сохранен\n");
                                    flag = false;
                                    delay();
                                    break;
                                case 4:
                                    AllStaffJsonSerial(com);
                                    Console.WriteLine($"\nФайл {jsonStaffData} сохранен\n");
                                    flag = false;
                                    delay();
                                    break;
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
                                case 1:
                                    DeSerialDepsXML();
                                    Console.WriteLine($"\nФайл {DepsXml} загружен\n");
                                    flag = false;
                                    delay();
                                    break;
                                case 2:
                                    DepsJsonDeSerial();
                                    Console.WriteLine($"\nФайл {jsonDepsData} загружен\n");
                                    flag = false;
                                    delay();
                                    break;
                                case 3:
                                    DeSerialAllStaffXML();
                                    Console.WriteLine($"\nФайл {AllStaffXml} загружен\n");
                                    flag = false;
                                    delay();
                                    break;
                                case 4:
                                    StaffJsonDeSerial();
                                    Console.WriteLine($"\nФайл {jsonStaffData} загружен\n");
                                    flag = false;
                                    delay();
                                    break;
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
