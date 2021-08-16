using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_8
{
    class CompareLastName : IComparer<Staff>
    {
        public int Compare(Staff a, Staff b)
        {
            /// ссылка для доступа к словарю с "весами" букв
            Dictionary<string, int> symb_dict = Program.dict;

            /// если словарь с "весами" букв не заполнен по какой-то причине - заполняем
            if (symb_dict.Count == 0) Program.fillDict();

            /// поле экземпляра а и б по которому идёт сортировка
            var aName = a.LastName;
            var bName = b.LastName;

            /// выбираем самую короткую строку для цикла, чтобы не ловить exeption
            int len;
            if (aName.Length < bName.Length) len = aName.Length;
            else len = bName.Length;


            for (int i = 0; i < len; i++)
            {
                /// "вес" текущего символа из строки экземпляра а и б соответственно
                var symbolFromA = symb_dict[aName[i].ToString()];
                var symbolFromB = symb_dict[bName[i].ToString()];

                /// проверяет значение текущей буквы строки экземпляра а и 
                /// строки экземпляра б в словаре с алфавитом
                /// если у буквы из строки а значение больше 
                /// И при этом длина строки а больше или равна длине строки б
                /// то поднимаем вверх строку б
                if (symbolFromA > symbolFromB & aName.Length >= bName.Length)
                {
                    return 1;
                }
                /// если символ а меньше символа б и длина б меньше или == длине а
                /// поднимаем вверх строку а
                else if (symbolFromA < symbolFromB & bName.Length <= aName.Length)
                {
                    return -1;
                }
                /// если символы равны и б длиннее а - поднимаем строку а
                else if (symbolFromA == symbolFromB & bName.Length > aName.Length)
                {
                    return -1;
                }
                /// если символы равны и б короче а - поднимаем б
                else if (symbolFromA == symbolFromB & bName.Length < aName.Length)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
