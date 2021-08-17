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

        /// <summary>
        /// работа с департаментами
        /// </summary>
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

        /// <summary>
        /// работа с сотрудниками
        /// </summary>
        public static void ShowMenu_2()
        {
            Console.Clear();
            Console.WriteLine($"\nРабота с сотрудниками\n" +
                $"\n1. Создание одного или нескольких сотрудников" +
                $"\n2. Редактирование сотрудника" +
                $"\n3. Удаление сотрудника" +
                $"\n\n4. Главное меню\n");
        }

        /// <summary>
        /// вывод на экран
        /// </summary>
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

        /// <summary>
        /// вывод в файл
        /// </summary>
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

        /// <summary>
        /// загрузка из файла
        /// </summary>
        public static void ShowMenu_5()
        {
            Console.Clear();
            Console.WriteLine($"\nЗагрузка из файла\n" +
                $"\n1. Загрузка департаментов из XML" +
                $"\n2. Загрузка департаментов из Json" +
                $"\n3. Загрузка сотрудников из XML" +
                $"\n4. Загрузка сотрудников из Json" +
                $"\n\n5. Главное меню\n");
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
                        case 1:
                            ShowMenu_1();
                            input = TakeMenuInput(1, 5);
                            switch (input)
                            {
                                /// создание отделов
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
                                /// редактирование отдела
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
                                                /// выход из текущего меню
                                                case 0:
                                                    localFlag = false;
                                                    flag = false;
                                                    break;
                                                /// изменение названия отдела
                                                case 1:
                                                    Console.WriteLine("Введите новое название");
                                                    string newName = Console.ReadLine();
                                                    com.EditDepName(input, newName);
                                                    Console.WriteLine("Готово");
                                                    delay();
                                                    break;
                                                /// изменение даты создания отдела
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
                                /// удаление отдела
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
                                /// вывод списка сотрудников на экран
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
                                /// выход в главное меню
                                case 5:
                                    flag = false;
                                    break;
                            }
                            break;
                        /// работа с сотрудниками
                        case 2:
                            ShowMenu_2();
                            input = TakeMenuInput(1, 4);
                            switch (input)
                            {
                                /// добавление сотрудников
                                case 1:
                                    /// проверка наличия департаментов в компании
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
                                /// редактирование сотрудников
                                case 2:
                                    /// если нет департаментов
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
                                        /// если департамент пуст
                                        if (com.deps[input].staff.Count == 0)
                                        {
                                            Console.Clear();
                                            Departments.Errors(7);
                                            delay();
                                            flag = false;
                                        }
                                        /// если не пуст
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
                                                Console.WriteLine($"будем редактировать сотрудника " +
                                                    $"{com.deps[input].staff[localInput].Print()}");
                                                Console.WriteLine("для изменения поля введите:" +
                                                    "\n1 Имя" +
                                                    "\n2 Фамилия" +
                                                    "\n3 Возраст" +
                                                    "\n4 Зарплата" +
                                                    "\n5 Количество открытых проектов" +
                                                    "\n6 Сменить департамент" +
                                                    "\n\n7 Завершить редактирование");

                                                int editInput = TakeMenuInput(1, 7);
                                                bool editResult = false;
                                                Departments curDep = com.deps[input];
                                                if (editInput > 0 & editInput < 7)
                                                {
                                                    Console.WriteLine("\nВведите новое значение\n");
                                                    switch (editInput)
                                                    {
                                                        case 1:
                                                            string newName = Console.ReadLine();
                                                            editResult = curDep.ChangeStaffName(localInput, newName);
                                                            break;
                                                        case 2:
                                                            newName = Console.ReadLine();
                                                            editResult = curDep.ChangeStaffLastName(localInput, newName);
                                                            break;
                                                        case 3:
                                                            Console.WriteLine("\n(от 18 до 75 лет)\n");
                                                            int newAge = TakeMenuInput(18, 75);
                                                            editResult = curDep.ChangeAge(localInput, newAge);
                                                            break;
                                                        case 4:
                                                            Console.WriteLine("\n(не более 1 000 000)\n");
                                                            int newSalary = TakeMenuInput(0, 1000000);
                                                            editResult = curDep.ChangeSalary(localInput, newSalary);
                                                            break;
                                                        case 5:
                                                            int newProjects = TakeMenuInput(0, 1000);
                                                            editResult = curDep.ChangeProjects(localInput, newProjects);
                                                            break;
                                                        case 6:
                                                            com.PrintCompanyDeps();
                                                            int depIndex = TakeMenuInput(0, com.deps.Count);
                                                            editResult = curDep.ChangeDep(localInput, com.deps[depIndex]);
                                                            break;
                                                    }
                                                    delay();
                                                }
                                                else
                                                {
                                                    localFlag = false;
                                                    flag = false;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                /// удаление сотрудника
                                case 3:
                                    /// если нет департаментов
                                    if (com.deps.Count == 0)
                                    {
                                        Console.Clear();
                                        Departments.Errors(6);
                                        delay();
                                        flag = false;
                                    }
                                    /// если департаменты есть
                                    else
                                    {
                                        Console.Clear();
                                        com.PrintCompanyDeps();
                                        Console.WriteLine("\nвыберите департамент с сотрудниками\n");
                                        input = TakeMenuInput(0, com.deps.Count);
                                        /// если нет сотрудников в департаменте
                                        if (com.deps[input].staff.Count == 0)
                                        {
                                            Console.Clear();
                                            Departments.Errors(7);
                                            delay();
                                            flag = false;
                                        }
                                        /// если сотрудники есть
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
                                /// выход в главное меню
                                case 4:
                                    flag = false;
                                    break;
                            }
                            break;
                        /// вывод на экран
                        case 3:
                            ShowMenu_3();
                            input = TakeMenuInput(1, 5);
                            switch (input)
                            {
                                /// вывод структуры организации
                                case 1:
                                    Console.Clear();
                                    com.PrintCompanyDeps();
                                    delay();
                                    flag = false;
                                    break;
                                /// вывод всех сотрудников
                                case 2:
                                    Console.Clear();
                                    com.PrintCompanyStaff();
                                    delay();
                                    flag = false;
                                    break;
                                /// вывод сотрудников определенного отдела
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
                                /// сортировка
                                case 4:
                                    Console.Clear();
                                    /// если департаменты есть
                                    if (com.deps.Count != 0)
                                    {
                                        com.PrintCompanyDeps();
                                        Console.WriteLine("Выберите отдел с сотрудниками");
                                        input = TakeMenuInput(0, com.deps.Count);
                                        /// если выбранный департамент пуст
                                        if (com.deps[input].staff.Count == 0)
                                        {
                                            Console.Clear();
                                            Departments.Errors(7);
                                            delay();
                                            flag = false;
                                        }
                                        /// если не пуст запускается сортировка
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
                                            var switchTemp = CompareNumber();


                                            switch (localInput)
                                            {
                                                case 1:
                                                    switchTemp = CompareNumber();
                                                    break;
                                                case 2:
                                                    switchTemp = CompareName();
                                                    break;
                                                case 3:
                                                    switchTemp = CompareLastName();
                                                    break;
                                                case 4:
                                                    switchTemp = CompareAge();
                                                    break;
                                                case 5:
                                                    switchTemp = CompareDep();
                                                    break;
                                                case 6:
                                                    switchTemp = CompareProjects();
                                                    break;
                                                case 7:
                                                    switchTemp = CompareSalary();
                                                    break;
                                            }

                                            Console.WriteLine("\nСписок до сортировки:\n");
                                            com.deps[input].PrintDepContent();
                                            com.deps[input].staff.Sort(switchTemp);
                                            Console.WriteLine("\nСписок после сортировки:\n");
                                            com.deps[input].PrintDepContent();
                                            delay();

                                        }
                                    }
                                    /// если департаментов нет выводим ошибку
                                    else
                                    {
                                        Console.Clear();
                                        Departments.Errors(6);
                                        delay();
                                        flag = false;
                                    }
                                    break;
                                /// в главное меню
                                case 5:
                                    flag = false;
                                    break;
                            }
                            break;
                        /// сохранение в файл
                        case 4:
                            ShowMenu_4();
                            input = TakeMenuInput(1, 5);
                            switch (input)
                            {
                                /// департаменты в XML
                                case 1:
                                    DepsXmlSerial(com);
                                    Console.WriteLine($"\nФайл {DepsXml} сохранен\n");
                                    flag = false;
                                    delay();
                                    break;
                                /// департаменты в json
                                case 2:
                                    DepsJsonSerial(com.deps);
                                    Console.WriteLine($"\nФайл {jsonDepsData} сохранен\n");
                                    flag = false;
                                    delay();
                                    break;
                                /// работники в XML
                                case 3:
                                    AllStaffXmlSerial(com);
                                    Console.WriteLine($"\nФайл {AllStaffXml} сохранен\n");
                                    flag = false;
                                    delay();
                                    break;
                                /// работники в JSON
                                case 4:
                                    AllStaffJsonSerial(com);
                                    Console.WriteLine($"\nФайл {jsonStaffData} сохранен\n");
                                    flag = false;
                                    delay();
                                    break;
                                /// в главное меню
                                case 5:
                                    flag = false;
                                    break;
                            }
                            break;
                        /// загрузка из файла
                        case 5:
                            ShowMenu_5();
                            input = TakeMenuInput(1, 5);
                            switch (input)
                            {
                                /// департаменты из xml
                                case 1:
                                    DeSerialDepsXML();
                                    Console.WriteLine($"\nФайл {DepsXml} загружен\n");
                                    flag = false;
                                    delay();
                                    break;
                                /// из json
                                case 2:
                                    DepsJsonDeSerial();
                                    Console.WriteLine($"\nФайл {jsonDepsData} загружен\n");
                                    flag = false;
                                    delay();
                                    break;
                                /// сотрудники их xml
                                case 3:
                                    DeSerialAllStaffXML();
                                    Console.WriteLine($"\nФайл {AllStaffXml} загружен\n");
                                    flag = false;
                                    delay();
                                    break;
                                /// из json
                                case 4:
                                    StaffJsonDeSerial();
                                    Console.WriteLine($"\nФайл {jsonStaffData} загружен\n");
                                    flag = false;
                                    delay();
                                    break;
                                /// в главное меню
                                case 5:
                                    flag = false;
                                    break;
                            }
                            break;
                        }
                }
            }
        }
        #endregion
    }
}
