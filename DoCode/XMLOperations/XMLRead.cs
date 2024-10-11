using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DoCode.XMLOperations
{
    public  class XMLRead
    {
        public static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:\\Projects\\Utilities\\example.xml");

            XmlNode root = xmlDoc.DocumentElement; // Gets the root element
            XmlNode? nodes = root.ParentNode;

            XElement reader = XElement.Load("C:\\Projects\\Utilities\\example.xml");

            IEnumerable<XElement> xElements = reader.Elements();

        }
    }
}
