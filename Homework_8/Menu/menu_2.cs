using System;
using System.Collections.Generic;
using System.Text;
using static Homework_8.Program;

namespace Homework_8
{
    class menu_2
    {

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
                $"\n4. Перемещение всех в другой департамент" +
                $"\n\n5. Главное меню\n");
        }
        public static bool menu()
        {
            Random rnd = new Random();

            ShowMenu_2();
            int input = TakeMenuInput(1, 5);
            switch (input)
            {
                /// добавление сотрудников
                case 1:
                    /// проверка наличия департаментов в компании
                    if (com.deps.Count == 0)
                    {
                        Console.WriteLine("Сначала добавьте департамент!");
                        delay();
                    }
                    else
                    {
                        Console.Clear();
                        com.PrintCompanyDeps();
                        Console.WriteLine("\nвыберите департамент\n");
                        input = TakeMenuInput(0, com.deps.Count - 1);
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
                    }
                    else
                    {
                        Console.Clear();
                        com.PrintCompanyDeps();
                        Console.WriteLine("\nвыберите департамент с сотрудниками\n");
                        input = TakeMenuInput(0, com.deps.Count - 1);
                        /// если департамент пуст
                        if (com.deps[input].staff.Count == 0)
                        {
                            Console.Clear();
                            Departments.Errors(7);
                            delay();
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
                                    break;
                                }
                                com.deps[input].PrintDepContent();
                                Console.WriteLine("\nВведите номер сотрудника согласно индексу\n");
                                int localInput = TakeMenuInput(0, com.deps[input].staff.Count - 1);
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
                    }
                    /// если департаменты есть
                    else
                    {
                        Console.Clear();
                        com.PrintCompanyDeps();
                        Console.WriteLine("\nвыберите департамент с сотрудниками\n");
                        input = TakeMenuInput(0, com.deps.Count - 1);
                        /// если нет сотрудников в департаменте
                        if (com.deps[input].staff.Count == 0)
                        {
                            Console.Clear();
                            Departments.Errors(7);
                            delay();
                        }
                        /// если сотрудники есть
                        else
                        {
                            Console.WriteLine("\nВведите номер сотрудника согласно индексу\n");
                            int localInput = TakeMenuInput(0, com.deps[input].staff.Count - 1);
                            com.deps[input].RemoveStaff(localInput);
                            Console.WriteLine("\nСотрудник удалён\n");
                            delay();
                            break;
                        }
                    }
                    break;
                case 4:
                    /// если нет департаментов
                    if (com.deps.Count == 0)
                    {
                        Console.Clear();
                        Departments.Errors(6);
                        delay();
                    }
                    /// если департаменты есть
                    else
                    {
                        Console.Clear();
                        com.PrintCompanyDeps();
                        Console.WriteLine("\nвыберите департамент с сотрудниками\n");
                        input = TakeMenuInput(0, com.deps.Count - 1);
                        /// если нет сотрудников в департаменте
                        if (com.deps[input].staff.Count == 0)
                        {
                            Console.Clear();
                            Departments.Errors(7);
                            delay();
                        }
                        /// если сотрудники есть
                        else
                        {
                            Console.Clear();
                            com.PrintCompanyDeps();
                            Console.WriteLine("\nвыберите департамент для перевода\n");
                            int localInput = TakeMenuInput(0, com.deps.Count);
                            com.deps[input].AllChangeDep(com.deps[localInput]);
                            Console.WriteLine("\nГотово\n");
                        }
                    }
                    return false;
                /// выход в главное меню
                case 5:
                    return false;
            }
            return false;
        }
    }
}
