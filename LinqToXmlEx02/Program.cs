using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXmlEx02
{
    /// <summary>
    /// 使用陣列-> 製作 Xml
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            System.Xml.Linq.XDocument xmlDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("註解=使用 Linq to XML"),
                new XElement("Students",
                    from student in Student.getAllStudent()
                    select new XElement("Student", new XAttribute("Id", student.Id),
                        new XElement("Name", student.Name),
                        new XElement("Gender", student.Gender),
                        new XElement("TotalMarks", student.TotalMarks)
                    )
                    /*
                    new XElement("Student", new XAttribute("Id",001),
                        new XElement("Name", "Mark"),
                        new XElement("Gender", "Male"),
                        new XElement("TotalMarks", "800")),
                    */
                )
            );
            xmlDoc.Save("LinqXml.xml");
            /* 執行結果：Part 2 Creating an XML document using in memory collection of objects
             * 教學資源：https://www.youtube.com/watch?v=pZU7JSUNcFI&list=PL6n9fhu94yhX-U0Ruy_4eIG8umikVmBrk&index=2
                <?xml version="1.0" encoding="utf-8" standalone="yes"?>
                <!--註解=使用 Linq to XML-->
                <Students>
                  <Student Id="1">
                    <Name>Mark1</Name>
                    <Gender>Male</Gender>
                    <TotalMarks>800</TotalMarks>
                  </Student>
                  <Student Id="2">
                    <Name>Mark2</Name>
                    <Gender>Male</Gender>
                    <TotalMarks>800</TotalMarks>
                  </Student>
                  <Student Id="3">
                    <Name>Mark3</Name>
                    <Gender>Male</Gender>
                    <TotalMarks>800</TotalMarks>
                  </Student>
                  <Student Id="4">
                    <Name>Mark4</Name>
                    <Gender>Male</Gender>
                    <TotalMarks>800</TotalMarks>
                  </Student>
                </Students>
            */
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int TotalMarks { get; set; }

        public static Student[] getAllStudent()
        { //使用陣列
            Student[] students = new Student[4];
            students[0] = new Student { Id = 001, Name = "Mark1", Gender = "Male", TotalMarks = 300 };
            students[1] = new Student { Id = 002, Name = "Mark2", Gender = "Male", TotalMarks = 800 };
            students[2] = new Student { Id = 003, Name = "Mark3", Gender = "Male", TotalMarks = 400 };
            students[3] = new Student { Id = 004, Name = "Mark4", Gender = "Male", TotalMarks = 500 };
            return students;
        }
    }

}
