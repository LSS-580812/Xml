using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XmlSerializerEx01
{
    class Program
    {
        static void Main(string[] args)
        {
            SerializeDataSet("xml01.xml");
            SerializeElement("xml02.xml");
            SerializeNode("xml03.xml");

            

            Console.ReadKey();
        }

        public static void SerializeDataSet(string filename)
        {
            //除了序列化公用類別的實例之外，您也可以序列化 的 DataSet 實例，如下列程式碼範例所示：

            XmlSerializer ser = new XmlSerializer(typeof(DataSet));
            // Creates a DataSet; adds a table, column, and ten rows.
            DataSet ds = new DataSet("myDataSet");
            DataTable t = new DataTable("table1");
            DataColumn c = new DataColumn("thing");
            t.Columns.Add(c);
            ds.Tables.Add(t);
            DataRow r;

            for (int i = 0; i < 10; i++)
            {
                r = t.NewRow();
                r[0] = "Thing " + i;
                t.Rows.Add(r);
            }

            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, ds);
            writer.Close();

            /* 執行結果：    https://learn.microsoft.com/zh-tw/dotnet/standard/serialization/examples-of-xml-serialization
            <DataSet>
            <xs:schema xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" id="myDataSet">
                <xs:element name="myDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">
                    <xs:complexType>
                        <xs:choice minOccurs="0" maxOccurs="unbounded">
                            <xs:element name="table1">
                                <xs:complexType>
                                    <xs:sequence>
                                        <xs:element name="thing" type="xs:string" minOccurs="0"/>
                                    </xs:sequence>
                                </xs:complexType>
                            </xs:element>
                        </xs:choice>
                    </xs:complexType>
                </xs:element>
            </xs:schema>
            <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
                <myDataSet>
                    <table1 diffgr:id="table11" msdata:rowOrder="0" diffgr:hasChanges="inserted">
                        <thing>Thing 0</thing>
                    </table1>
                    <table1 diffgr:id="table12" msdata:rowOrder="1" diffgr:hasChanges="inserted">
                        <thing>Thing 1</thing>
                    </table1>
                    <table1 diffgr:id="table13" msdata:rowOrder="2" diffgr:hasChanges="inserted">
                        <thing>Thing 2</thing>
                    </table1>
                    <table1 diffgr:id="table14" msdata:rowOrder="3" diffgr:hasChanges="inserted">
                        <thing>Thing 3</thing>
                    </table1>
                    <table1 diffgr:id="table15" msdata:rowOrder="4" diffgr:hasChanges="inserted">
                        <thing>Thing 4</thing>
                    </table1>
                    <table1 diffgr:id="table16" msdata:rowOrder="5" diffgr:hasChanges="inserted">
                        <thing>Thing 5</thing>
                    </table1>
                    <table1 diffgr:id="table17" msdata:rowOrder="6" diffgr:hasChanges="inserted">
                        <thing>Thing 6</thing>
                    </table1>
                    <table1 diffgr:id="table18" msdata:rowOrder="7" diffgr:hasChanges="inserted">
                        <thing>Thing 7</thing>
                    </table1>
                    <table1 diffgr:id="table19" msdata:rowOrder="8" diffgr:hasChanges="inserted">
                        <thing>Thing 8</thing>
                    </table1>
                    <table1 diffgr:id="table110" msdata:rowOrder="9" diffgr:hasChanges="inserted">
                        <thing>Thing 9</thing>
                    </table1>
                </myDataSet>
            </diffgr:diffgram>
            </DataSet>
            */
         
        }

        public static void SerializeElement(string filename)
        { //序列化 XmlElement 與 XmlNode
            XmlSerializer ser = new XmlSerializer(typeof(XmlElement));
            XmlElement myElement =
            new XmlDocument().CreateElement("MyElement", "ns");
            myElement.InnerText = "Hello World";
            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, myElement);
            writer.Close();

            /* 執行結果：
             * <MyElement xmlns="ns">Hello World</MyElement>
            */
        }

        public static void SerializeNode(string filename)
        { //序列化 XmlElement 與 XmlNode
            XmlSerializer ser = new XmlSerializer(typeof(XmlNode));
            XmlNode myNode = new XmlDocument().
            CreateNode(XmlNodeType.Element, "MyNode", "ns");
            myNode.InnerText = "Hello Node";
            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, myNode);
            writer.Close();
            /* 執行結果：
             * <MyNode xmlns="ns">Hello Node</MyNode>
            */
        }
    

    }

    public class PurchaseOrder
    {
        public Item[] ItemsOrders;
    }

    public class Item
    {
        public string ItemID;
        public decimal ItemPrice;
    }

}
