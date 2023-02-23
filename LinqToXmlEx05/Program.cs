using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace LinqToXmlEx05
{
    /// <summary>
    /// Part 5 Transforming XML to CSV using LINQ to XML
    ///     https://www.youtube.com/watch?v=b93ZT4ecij8&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk&index=5
    /// 將 xml 轉換為 csv 檔或 html 或 xml 格式
    /// </summary>
    class Program
    {
        private static string xmlFile { get; set; } = @"C:\ProgramVS\LSS-580812\Xml\Xml\LinqToXmlEx02\bin\Debug\LinqXml.xml";
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string delimiter = ",";
            XDocument.Load(xmlFile).Descendants("Student").ToList()
                .ForEach(element=> sb.Append(
                    element.Attribute("Id").Value + delimiter + 
                    element.Element("Name").Value + delimiter + 
                    element.Element("Gender").Value + delimiter +
                    element.Element("TotalMarks").Value +"\r\n"
                ));
            StreamWriter sw = new StreamWriter("LinqXml.csv");
            sw.WriteLine(sb.ToString());
            sw.Close();

            /* 執行結果：轉成 csv 檔
                1,Mark1,Male,300
                2,Mark2,Male,800
                3,Mark3,Male,400
                4,Mark4,Male,500  
             */
        }
    }
}
