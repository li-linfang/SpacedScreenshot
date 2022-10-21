// See https://aka.ms/new-console-template for more information
using SpacedScreenshot;

Console.WriteLine("Hello, World!");





// Initialize object and it fileds
SpaceScreenshotObject spaceScreenshotObj =  new SpaceScreenshotObject();

spaceScreenshotObj.TargetFolder = "D:\\";
spaceScreenshotObj.FolderStructureMethod = 1;

spaceScreenshotObj.ImageFormat = 0;
spaceScreenshotObj.ImageQuality = 90;
spaceScreenshotObj.ImagePrefix = "prefix";
spaceScreenshotObj.ImageNamingRule = 0;
spaceScreenshotObj.ImageSuffix = "suffix";

spaceScreenshotObj.SpacedTime = 2;

spaceScreenshotObj.PauseWhenNotActiveEnable = true;
spaceScreenshotObj.NotActiveTime = 60;

spaceScreenshotObj.AutoCompressEnable = true;
spaceScreenshotObj.CompresssDay = 7;
spaceScreenshotObj.AutoDeleteCompressedPackageEnable = true;
spaceScreenshotObj.DeleteCompressedPackageDay = 30;

spaceScreenshotObj.Start();
