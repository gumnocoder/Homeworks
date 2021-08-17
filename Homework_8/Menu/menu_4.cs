using System;
using System.Collections.Generic;
using System.Text;
using static Homework_8.Program;

namespace Homework_8
{
    class menu_4
    {

        /// <summary>
        /// вывод в файл
        /// </summary>
        public static void ShowMenu_4()
        {
            Console.Clear();
            Console.WriteLine($"\nСохранение в файл\n" +
                $"\n1. Сохранение в XML" +
                $"\n2. Сохранение в Json" +
                $"\n3. Главное меню\n");
        }
        public static bool menu()
        {
            ShowMenu_4();

            int input = TakeMenuInput(1, 3);
            string file = "";

            if (input > 0 & input < 3)
            {
                switch (input)
                {
                    case 1:
                        CompanyToXml(com);
                        break;
                    case 2:
                        CompanyToJson(com);
                        delay();
                        break;
                }
                Console.WriteLine($"\nФайл {file} сохранен\n");
                delay();
                return false;
                
            }
            else
            {
                return false;
            }
        }
    }
}
