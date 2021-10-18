using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Homework_13_bank_system.Models.appliedFunctional;

namespace Homework_13_bank_system.Models.structsBin
{

    public class BankSettingsLoader
    {
        private readonly string creditIdFile = "credid.ini";
        private readonly string debitIdFile = "debid.ini";
        private readonly string userIdFile = "usid.ini";
        private readonly string clientIdFile = "clid.ini";

        public string GetIniContent(string path)
        {
            string a = string.Empty;
            if (File.Exists(path))
            {
                using (StreamReader sw = new(path))
                {
                    a = sw.ReadToEnd();
                }
            }
            else File.Create(path);
            return a;
        }

        public void SetId(ref long idGetter, string path, long defaultValue)
        {
            if (long.TryParse(GetIniContent(path), out long tmp))
            {
                Debug.WriteLine("path parsed");
                idGetter = tmp;
                Debug.WriteLine(tmp);
                Debug.WriteLine(idGetter);
            }

            else
            {
                Debug.WriteLine("path don`t parsed");
                idGetter = defaultValue;
            }

            // idGetter =  long.TryParse(GetIniContent(path), out long tmp) ? tmp : defaultValue;
        }

        public BankSettingsLoader(Bank bank)
        {
            SetId(ref bank.currentCreditID, creditIdFile, (long)10000);
            SetId(ref bank.currentDebitID, debitIdFile, (long)10000000);
            SetId(ref bank.currentClientID, clientIdFile, (long)100000);
            SetId(ref bank.currentUserID, userIdFile, (long)0);
        }
    }

    public class BankSettingsSaver
    {
        private readonly string creditIdFile = "credid.ini";
        private readonly string debitIdFile = "debid.ini";
        private readonly string userIdFile = "usid.ini";
        private readonly string clientIdFile = "clid.ini";


    }

    public sealed class Bank : ISerializible
    {
        public long currentCreditID;
        public long currentDebitID;
        public long currentClientID;
        public long currentUserID;
        public long CurrentCreditID
        { get; set; }
        public long CurrentDebitID
        { get; set; }
        public long CurrentClientID
        { get; set; }
        public long CurrentUserID
        { get; set; }

        public string Name { get; set; }
        public static Bank instance = null;
        private Bank() { Name = "ЗАО 'Банк России'"; }

        static Bank thisBank = null;
        public static Bank ThisBank
        {
            get
            {
                if (thisBank == null) thisBank = new();
                return thisBank;
            }
        }
    }
}