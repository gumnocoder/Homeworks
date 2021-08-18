using System;
using System.Collections.Generic;
using System.Text;
using static Homework_8.Program;

namespace Homework_8
{
    class menu_1
    {
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
        public static bool menu()
        {
            ShowMenu_1();
            int input = TakeMenuInput(1, 5);
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
                    break;
                /// редактирование отдела
                case 2:
                    Console.Clear();
                    if (com.deps.Count > 0)
                    {
                        com.PrintCompanyDeps();
                        Console.WriteLine("\nВведите номер департамента согласно индексу\n");
                        input = TakeMenuInput(0, com.deps.Count - 1);
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
                        input = TakeMenuInput(0, com.deps.Count - 1);
                        com.RemoveDep(input);
                        Console.WriteLine("Удаление завершено");
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
                        while (localFlag == true)
                        {
                            com.PrintCompanyDeps();
                            Console.WriteLine("\nВведите номер департамента согласно индексу\n");
                            input = TakeMenuInput(0, com.deps.Count - 1);
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
                    delay();
                    break;
                /// выход в главное меню
                case 5:
                    break;
            }
            return false;
        }
    }
}
