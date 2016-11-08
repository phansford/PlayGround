using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlJoin
{
    static class Program
    {
        static void Main(string[] args)
        {
            string folderPath = @"D:\Temp\ECM_Mappings";
            int mappingsPerFile = 10000;
            

            var files = Directory.EnumerateFiles(folderPath, @"ecm-*.xml");

            XmlDocument resultingXml = new XmlDocument();
            XmlElement mappingsElement = resultingXml.CreateElement(string.Empty, "MAPPINGS", string.Empty);
            resultingXml.AppendChild(mappingsElement);

            foreach (var file in files)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                
                foreach (var xmlNode in doc.GetElementsByTagName("MAPPING"))
                {
                    //necessary for crossing XmlDocument contexts
                    XmlNode importNode = mappingsElement.OwnerDocument.ImportNode((xmlNode as XmlNode), true);

                    mappingsElement.AppendChild(importNode);
                }
            }

            resultingXml.Save(Path.Combine(folderPath, "resulting.xml"));
        }
    }
}
