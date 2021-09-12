using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.structBin.Company;
using Newtonsoft.Json;

namespace Homework_11_ConsUI.functions
{
    class ExportImportJson
    {

        public static string jsonData = "company_struct.json";

        /// <summary>
        /// сохраняет структуру в json
        /// </summary>
        /// <param name="comp"></param>
        public static void CompanyToJson(Company comp)
        {
            string json = JsonConvert.SerializeObject(comp);
            File.WriteAllText(jsonData, json);
        }
    }
}
