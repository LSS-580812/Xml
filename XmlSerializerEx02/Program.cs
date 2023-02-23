using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XmlSerializerEx02
{
    class Program
    {
        static void Main(string[] args)
        {
            var serilizer = new XmlSerializer(typeof(XmlDTO));
            System.IO.FileStream file = System.IO.File.Create(Environment.CurrentDirectory + @"\DTO.xml");
            serilizer.Serialize(file, new XmlDTO
            {
                Element1 = "Value1",
                Element2 = "Value2"
            });
            file.Close();
            InitXml();
            Console.ReadKey();
        }


        public static void InitXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load("DTO.xml");
            XmlNodeList xmlDevice = doc.SelectNodes("XmlDTO"); //解析<Device>
            Console.WriteLine(xmlDevice);
            foreach (var item in xmlDevice)
            {
                Console.WriteLine(item);
            }
            string PayCashInformat = doc.SelectSingleNode("XmlDTO").InnerText;
            Console.WriteLine(PayCashInformat);

        }

        private void ReadPO(string filename)
        {
            // 建立serializer物件，並指定反序列化物件的型別
            XmlSerializer serializer = new XmlSerializer(typeof(Orgs));
            // 宣告一個要被反序列化的型別的物件變數
            Orgs orgs;
            // 建立FileStream物件，讀取XML檔案
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                //反序列化XML
                orgs = (Orgs)serializer.Deserialize(fs);
            }
            Console.Write(orgs.Frg.Org);
        }


    }

    public class XmlDTO
    {
        [XmlAttribute]
        public string Element1 { get; set; }

        [XmlElement]
        public string Element2 { get; set; }
    }
}
