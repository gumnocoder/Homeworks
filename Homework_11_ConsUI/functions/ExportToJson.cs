using System.IO;
using Homework_11_ConsUI.structBin;
using Newtonsoft.Json;

namespace Homework_11_ConsUI.functions
{
    public class ExportToJson
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
