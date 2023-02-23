using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXmlEx01
{
    /// <summary>
    /// 教學資源：[kudvenkat] https://www.youtube.com/@Csharp-video-tutorialsBlogspot
    /// Part 1 LINQ to XML  
    ///     https://www.youtube.com/watch?v=CK2yLQU_hqA&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk
    /// Part 2 Creating an XML document using in memory collection of objects   
    ///     https://www.youtube.com/watch?v=pZU7JSUNcFI&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk&index=2
    /// Part 3 Querying xml document using linq to xml  
    ///     https://www.youtube.com/watch?v=Ii3QSkTiRA8&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk&index=3 
    ///     查詢 Xml 數據資料
    /// Part 4 Modifying xml document using linq to xml 
    ///     https://www.youtube.com/watch?v=OsfVJ485RY4&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk&index=4
    /// Part 5 Transforming XML to CSV using LINQ to XML
    ///     https://www.youtube.com/watch?v=b93ZT4ecij8&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk&index=5
    /// Part 6 Transforming XML to HTML table using LINQ to XML
    ///     https://www.youtube.com/watch?v=nNMiyILom3s&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk&index=6
    /// Part 7 Transform one XML format to another XML format using linq to xml
    ///     https://www.youtube.com/watch?v=Sv8oFcEj0kM&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk&index=7
    /// Part 8 XML validation against XSD
    ///     https://www.youtube.com/watch?v=SGVL_SIYIGA&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk&index=8
    /// Part 10 - C# XML, XSLT, XSD, XmlWriter, XmlReader, XPath
    ///     https://www.youtube.com/watch?v=S0aDXg_tRP0
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            System.Xml.Linq.XDocument xmlDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("註解=使用 Linq to XML"),
                new XElement("Students",
                    new XElement("Student", new XAttribute("Id",001),
                        new XElement("Name", "Mark"),
                        new XElement("Gender", "Male"),
                        new XElement("TotalMarks", "800")),
                    new XElement("Student", new XAttribute("Id", 002),
                        new XElement("Name", "Rosy"),
                        new XElement("Gender", "Female"),
                        new XElement("TotalMarks", "900")),
                    new XElement("Student", new XAttribute("Id", 003),
                        new XElement("Name", "Pam"),
                        new XElement("Gender", "Female"),
                        new XElement("TotalMarks", "850"))
                )
            );
            xmlDoc.Save("LinqXml.xml");

            /* 執行結果：Part 1 LINQ to XML
             * 教學資源：https://www.youtube.com/watch?v=CK2yLQU_hqA&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk
                <?xml version="1.0" encoding="utf-8" standalone="yes"?>
                <!--註解=使用 Linq to XML-->
                <Students>
                  <Student Id="1">
                    <Name>Mark</Name>
                    <Gender>Male</Gender>
                    <TotalMarks>800</TotalMarks>
                  </Student>
                  <Student Id="2">
                    <Name>Rosy</Name>
                    <Gender>Female</Gender>
                    <TotalMarks>900</TotalMarks>
                  </Student>
                  <Student Id="3">
                    <Name>Pam</Name>
                    <Gender>Female</Gender>
                    <TotalMarks>850</TotalMarks>
                  </Student>
                </Students>
            */
        }
    }
}
