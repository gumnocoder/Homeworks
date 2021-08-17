using System;
using System.Collections.Generic;
using System.Text;
using static Homework_8.Program;

namespace Homework_8
{
    class menu_5
    {
        /// <summary>
        /// загрузка из файла
        /// </summary>
        public static void ShowMenu_5()
        {
            Console.Clear();
            Console.WriteLine($"\nЗагрузка из файла\n" +
                $"\n1. Загрузка из XML" +
                $"\n2. Загрузка из Json" +
                $"\n3. Главное меню\n");
        }
        public static bool menu()
        {
            ShowMenu_5();
            bool fileLoadFlag = false;
            int input = TakeMenuInput(1, 3);
            string file = "";
            switch (input)
            {
                case 1:
                    file = xmlData;
                    com = CompanyFromXml();
                    fileLoadFlag = true;
                    break;
                case 2:
                    file = jsonData;
                    com = CompanyFromJson();
                    fileLoadFlag = true;
                    break;
            }
            if (fileLoadFlag & !fileError)
            {
                Console.WriteLine($"\nФайл {file} загружен\n");
                fileLoadFlag = false;
                delay();
            }
            else
            {
                Console.WriteLine($"\nФайл отсутствует!\n");
                fileError = false;
                delay();
            }
            return false;
        }
    }
}
