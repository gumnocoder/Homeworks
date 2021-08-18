using System;
using System.Collections.Generic;
using System.Text;
using static Homework_8.Program;

namespace Homework_8
{
    class menu_3
    {

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
        public static bool menu()
        {
            ShowMenu_3();
            int input = TakeMenuInput(1, 5);
            switch (input)
            {
                /// вывод структуры организации
                case 1:
                    Console.Clear();
                    com.PrintCompanyDeps();
                    delay();
                    return false;
                /// вывод всех сотрудников
                case 2:
                    Console.Clear();
                    com.PrintCompanyStaff();
                    delay();
                    return false;
                /// вывод сотрудников определенного отдела
                case 3:
                    Console.Clear();
                    if (com.deps.Count != 0)
                    {
                        com.PrintCompanyDeps();
                        input = TakeMenuInput(0, com.deps.Count - 1);
                        if (com.deps[input].staff.Count == 0)
                        {
                            Console.Clear();
                            Departments.Errors(7);
                            delay();
                            return false;
                        }
                        else com.deps[input].PrintDepContent();
                        delay();
                        return false;
                    }
                    else
                    {
                        Console.Clear();
                        Departments.Errors(6);
                        delay();
                        return false;
                    }
                /// сортировка
                case 4:
                    Console.Clear();
                    /// если департаменты есть
                    if (com.deps.Count != 0)
                    {
                        com.PrintCompanyDeps();
                        Console.WriteLine("Выберите отдел с сотрудниками");
                        input = TakeMenuInput(0, com.deps.Count - 1);
                        /// если выбранный департамент пуст
                        if (com.deps[input].staff.Count == 0)
                        {
                            Console.Clear();
                            Departments.Errors(7);
                            delay();
                            return false;
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
                            return false;
                        }
                    }
                    /// если департаментов нет выводим ошибку
                    else
                    {
                        Console.Clear();
                        Departments.Errors(6);
                        delay();
                        return false;
                    }
                /// в главное меню
                case 5:
                    return false;
            }
            return false;
        }
    }
}
