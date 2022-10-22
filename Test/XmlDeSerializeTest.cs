using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacedScreenshot.Test
{
    public class XmlDeSerializeTest
    {
        public class Book
        {
            public String title;
        }

        public static void ReadXML()
        {
            // First write something so that there is something to read ...  
            var b = new Book { title = "Serialization Overview" };
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(Book));
            var wfile = new System.IO.StreamWriter(@"d:\ScreenshotTest\SerializationOverview.xml");
            writer.Serialize(wfile, b);
            wfile.Close();

            // Now we can read the serialized book ...  
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Book));
            System.IO.StreamReader file = new System.IO.StreamReader(
                @"d:\ScreenshotTest\SerializationOverview.xml");
            Book overview = (Book)reader.Deserialize(file);
            file.Close();

            Console.WriteLine(overview.title);

        }
    }
}
