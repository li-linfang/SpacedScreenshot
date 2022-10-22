using SpacedScreenshot.Test;
using SpacedScreenshot.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacedScreenshot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");



            // Initialize object and it fileds
            SpaceScreenshotObject spaceScreenshotObj= XmlUtils.Deserialize<SpaceScreenshotObject>("SpacedScreenshot_Config.xml");

            // if dont exist config xml file, then create object with default value;
            if (spaceScreenshotObj == null) { 
                spaceScreenshotObj = new SpaceScreenshotObject("D:\\ScreenshotTest", 0, 1, 90, "prefix", 2, "suffix", 2, true, 60, true, 7, true, 30);
                XmlUtils.Serialize<SpaceScreenshotObject>(spaceScreenshotObj);
            }

            spaceScreenshotObj.Start();


            // Some method test
            //ScreenshotTest.testTakeScreenshot();
            //XmlDeSerializeTest.ReadXML();

            //Task.Delay(300000).Wait();
            Console.ReadKey();
        }
    }
}
