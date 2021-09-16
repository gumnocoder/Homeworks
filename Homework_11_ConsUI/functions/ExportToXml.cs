using System.IO;
using System.Xml.Serialization;
using Homework_11_ConsUI.structBin;

namespace Homework_11_ConsUI.functions
{
    class ExportToXml
    {
        static string xmlData = "company_struct.xml";

        /// <summary>
        /// сохраняет структуру в XML
        /// </summary>
        /// <param name="comp"></param>
        public static void CompanyToXml(Company comp)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Company));
            using (Stream fstream = new FileStream(
                xmlData, FileMode.Create, FileAccess.Write)
                )
            {
                xmlSerializer.Serialize(fstream, comp);
            }
        }
    }
}
