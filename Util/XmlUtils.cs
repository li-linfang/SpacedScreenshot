using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SpacedScreenshot.Util
{
    internal class XmlUtils
    {
        public static void Serialize<T>(T obj)
        {
            if (obj == null) return;

            var writer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var wfile = new System.IO.StreamWriter("SpacedScreenshot_Config.xml");
            writer.Serialize(wfile, obj);
            wfile.Close();
        }


        public static T Deserialize<T>(string xmlString)
        {
            if (!File.Exists(xmlString)) return default;

            var reader = new XmlSerializer(typeof(T));
            StreamReader file = new StreamReader(xmlString);
            T obj = (T)reader.Deserialize(file);
            file.Close();

            return obj;
        }
    }
}
