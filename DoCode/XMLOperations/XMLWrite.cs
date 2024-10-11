using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DoCode.XMLOperations
{
    public class XMLWrite
    {
        public static void Main()
        {
            using (XmlWriter writer = XmlWriter.Create("C:\\Projects\\Utilities\\example.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Books");

                writer.WriteStartElement("Book");
                writer.WriteElementString("Title", "C# Programming");
                writer.WriteElementString("Author", "John Doe");
                writer.WriteElementString("Year", "2024");
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine("XML file created successfully.");
        }
    }
}
