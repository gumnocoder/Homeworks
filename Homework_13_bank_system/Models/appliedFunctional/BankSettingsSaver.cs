using System.IO;
using Homework_13_bank_system.Models.structsBin;

namespace Homework_13_bank_system.Models.appliedFunctional
{
    public class BankSettingsSaver
    {
        private readonly string creditIdFile = "credid.ini";
        private readonly string debitIdFile = "debid.ini";
        private readonly string userIdFile = "usid.ini";
        private readonly string clientIdFile = "clid.ini";

        /// <summary>
        /// Записывает в файл порядковый номер параметра банка
        /// </summary>
        /// <param name="outputFile">файл сохранения</param>
        /// <param name="inputNum">входящий параметр</param>
        public void WriteBankSettingsToFile(string outputFile, long inputNum) 
        { 
            using (FileStream fs = new FileStream(outputFile, FileMode.Open, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(inputNum.ToString());
                }
            }
        }

        /// <summary>
        /// выполняет сохранение всех параметров банка
        /// </summary>
        /// <param name="bank">экземпляр банка</param>
        public BankSettingsSaver(Bank bank)
        {
            WriteBankSettingsToFile(creditIdFile, bank.currentCreditID);
            WriteBankSettingsToFile(debitIdFile, bank.currentDebitID);
            WriteBankSettingsToFile(userIdFile, bank.currentUserID);
            WriteBankSettingsToFile(clientIdFile, bank.currentClientID);
        }
    }
}