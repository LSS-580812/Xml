using System;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace LinqToXmlEx03
{
    /// <summary>
    /// Part 3 Querying xml document using linq to xml  https://www.youtube.com/watch?v=Ii3QSkTiRA8&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk&index=3 
    ///     查詢 Xml 數據資料
    /// </summary>
    class Program
    {
        public static string xmlFile { get; set; } = @"C:\ProgramVS\LSS-580812\Xml\Xml\LinqToXmlEx02\bin\Debug\LinqXml.xml";
        //public static string xmlFile { get; set; } = Environment.CurrentDirectory + "";
        static void Main(string[] args)
        {
            /* 方法1：
            IEnumerable<string> names = 
                from student in XDocument.Load(xmlFile).Descendants("Student") 
                where (int)student.Element("TotalMarks") >= 400
                orderby (int)student.Element("TotalMarks") descending
                select student.Element("Name").Value;
            */
            // 方法2:
            IEnumerable<string> names =
                from student in XDocument.Load(xmlFile).Element("Students").Elements("Student")
                where (int)student.Element("TotalMarks") >= 400
                orderby (int)student.Element("TotalMarks") descending
                select student.Element("Name").Value;

            foreach (var item in names)
            {
                Console.WriteLine($"Name={item}");
            }

            Console.ReadKey();

            /* 執行結果：查詢 Xml 數據資料-> 成續大於 400分，且由大至小排序
             Name=Mark2
             Name=Mark4
             Name=Mark3
            */
        }
    }
}
