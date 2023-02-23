using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXmlEx06
{
    /// <summary>
    /// Part 6 Transforming XML to HTML table using LINQ to XML
    ///     https://www.youtube.com/watch?v=nNMiyILom3s&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk&index=6
    /// 
    /// </summary>
    class Program
    {
        private static string xmlFile { get; set; } = @"C:\ProgramVS\LSS-580812\Xml\Xml\LinqToXmlEx02\bin\Debug\LinqXml.xml";
        static void Main(string[] args)
        {
            XDocument xmlDoc = new XDocument(
                new XElement("table", new XAttribute("border", 1),
                    new XElement("thead",
                        new XElement("tr",
                            new XElement("th", "Id"),
                            new XElement("th", "Name"),
                            new XElement("th", "Gender"),
                            new XElement("th", "TotalMarks")
                        )
                    ),
                    new XElement("tbody",
                        from student in XDocument.Load(xmlFile).Descendants("Student")
                        //where student.Attribute("Id").Value == "3"
                        //where (int)student.Element("TotalMarks") >= 400
                        //orderby (int)student.Element("TotalMarks") descending //由 大->小 排序
                        select new XElement("tr",
                            new XElement("td", student.Attribute("Id").Value),
                            new XElement("td", student.Element("Name").Value),
                            new XElement("td", student.Element("Gender").Value),
                            new XElement("td", student.Element("TotalMarks").Value)
                        )
                    )
                )
            );

            xmlDoc.Save("LinqXml.html");
            /* 執行結果：
             * Id	Name	Gender	TotalMarks
                1	Mark1	Male	300
                2	Mark2	Male	800
                3	Mark3	Male	400
                4	Mark4	Male	500
            */
        }
    }
}
