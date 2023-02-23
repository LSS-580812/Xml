using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXmlEx04
{
    /// <summary>
    /// Part 4 Modifying xml document using linq to xml https://www.youtube.com/watch?v=OsfVJ485RY4&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk&index=4
    /// 在 Xml 中增加、更新、刪除一筆學生資料
    /// </summary>
    class Program
    {
        private static string xmlFile { get; set; } = @"C:\ProgramVS\LSS-580812\Xml\Xml\LinqToXmlEx02\bin\Debug\LinqXml.xml";
        static void Main(string[] args)
        {
            XDocument xmlDoc = XDocument.Load(xmlFile); //讀取 xml 文件
            /*
            //方法1:加入一筆資料(預設 xml 中最後一筆)
            xmlDoc.Element("Students").Add(
                new XElement("Student", new XAttribute("Id", 005),
                    new XElement("Name", "Mark5"),
                    new XElement("Gender", "Male5"),
                    new XElement("TotalMarks", "700")
                )
            );
            */

            /*
            //方法2:加入一筆資料(在 xml 中第一筆)
            xmlDoc.Element("Students").AddFirst(
                new XElement("Student", new XAttribute("Id", 006),
                    new XElement("Name", "Mark6"),
                    new XElement("Gender", "Male6"),
                    new XElement("TotalMarks", "600")
                )
            );
            */

            /*
            //方法3:加入一筆資料(在特定位置中加入)-> 例：在 Id=3 前
            xmlDoc.Element("Students").Elements("Student")
                .Where(x => x.Attribute("Id").Value == "3").FirstOrDefault()
                .AddBeforeSelf(
                    new XElement("Student", new XAttribute("Id", 007),
                        new XElement("Name", "Mark7"),
                        new XElement("Gender", "Male7"),
                        new XElement("TotalMarks", "700")
                )
            );
            */

            //範例4:更新方法1
            /*
            xmlDoc.Element("Students").Elements("Student")
                .Where(x => x.Attribute("Id").Value == "7").FirstOrDefault()
                .SetElementValue("TotalMarks", 800);
            */
            //範例5:更新方法2
            /*
            xmlDoc.Element("Students").Elements("Student")
                .Where(x => x.Attribute("Id").Value == "7")
                .Select(x => x.Element("TotalMarks")).FirstOrDefault().SetValue(999);
            //*/

            //範例6:更新方法3 -> 註解
            /*
            xmlDoc.Nodes().OfType<XComment>().FirstOrDefault().Value = "註解被更新了";
            //*/

            //範例7:刪除方法1
            //*
            xmlDoc.Root.Elements().Where(x => x.Attribute("Id").Value == "7").Remove(); //刪除全部符合 Id= 7 資料
            //xmlDoc.Root.Elements().Where(x => x.Attribute("Id").Value == "7").FirstOrDefault().Remove(); //刪除第1筆符合 Id= 7 資料
            //*/

            //範例7:刪除方法2-> 根下全部節點資料
            //*
            xmlDoc.Root.Elements().Remove(); //刪除全部節點資料
            //*/

            //範例7:刪除方法3-> 註解資料
            //*
            xmlDoc.Nodes().OfType<XComment>().Remove(); //刪除註解資料
            //*/

            xmlDoc.Save(xmlFile);
            /* 執行結果：
            
            */
        }
    }
}
