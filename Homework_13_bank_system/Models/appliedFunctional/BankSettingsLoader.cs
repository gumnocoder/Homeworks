using System.Diagnostics;
using Homework_13_bank_system.Models.structsBin;

namespace Homework_13_bank_system.Models.appliedFunctional
{
    /// <summary>
    /// Выполняет загрузку параметров для банка
    /// </summary>
    public class BankSettingsLoader
    {
        private readonly string creditIdFile = "credid.ini";
        private readonly string debitIdFile = "debid.ini";
        private readonly string userIdFile = "usid.ini";
        private readonly string clientIdFile = "clid.ini";

        /// <summary>
        /// парсит файл и конвертирует значение в параметр типа long
        /// </summary>
        /// <param name="idGetter">ссылка на параметр банка</param>
        /// <param name="path">входящий файл</param>
        /// <param name="defaultValue">значение по умолчанию возвращается 
        /// в случае неудачного парсинга</param>
        public void SetId(ref long idGetter, string path, long defaultValue)
        {
            if (long.TryParse(FilesCheckOrCreate.GetIniContent(path), out long tmp))
            {
                Debug.WriteLine("path parsed");
                idGetter = tmp;
            }
            else
            {
                Debug.WriteLine("path don`t parsed");
                idGetter = defaultValue;
            }
        }

        /// <summary>
        /// выполняет загрузку всех параметров банка
        /// </summary>
        /// <param name="bank">экземпляр банка</param>
        public BankSettingsLoader(Bank bank)
        {
            SetId(ref bank.currentCreditID, creditIdFile, (long)10000);
            SetId(ref bank.currentDebitID, debitIdFile, (long)10000000);
            SetId(ref bank.currentClientID, clientIdFile, (long)100000);
            SetId(ref bank.currentUserID, userIdFile, (long)0);
        }
    }
}