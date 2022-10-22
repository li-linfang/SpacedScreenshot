using SpacedScreenshot.Test;
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
            SpaceScreenshotObject spaceScreenshotObj = new SpaceScreenshotObject();

            spaceScreenshotObj.TargetFolder = "D:\\ScreenshotTest";
            spaceScreenshotObj.FolderStructureMethod = 0;

            spaceScreenshotObj.ScreenshotFormat = 1;
            spaceScreenshotObj.ScreenshotQuality = 90;
            spaceScreenshotObj.ScreenshotPrefix = "prefix";
            spaceScreenshotObj.ScreenshotNamingRule = 2;
            spaceScreenshotObj.ScreenshotSuffix = "suffix";

            spaceScreenshotObj.SpacedTime = 2;

            spaceScreenshotObj.PauseWhenNotActiveEnable = true;
            spaceScreenshotObj.NotActiveTime = 60;

            spaceScreenshotObj.AutoCompressEnable = true;
            spaceScreenshotObj.CompresssDay = 7;
            spaceScreenshotObj.AutoDeleteCompressedPackageEnable = true;
            spaceScreenshotObj.DeleteCompressedPackageDay = 30;

            spaceScreenshotObj.Start();
            /**
            **/

            //ScreenshotTest.testTakeScreenshot();

            Console.ReadKey();
        }
    }
}
