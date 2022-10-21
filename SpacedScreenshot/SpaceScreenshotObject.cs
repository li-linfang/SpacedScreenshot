using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacedScreenshot
{
    public class SpaceScreenshotObject
    {
        // Screenshot storage folder
        private string _targetFolder;
        private int _folderStructureMethod;

        // Screenshot file
        private int _imageFormat;
        private int _imageQuality;
        private string _imagePrefix;
        private int _imageNamingRule;
        private string _imageSuffix;

        // Timing
        private int _spacedTime;
        private int _notActiveTime;
        private bool _pauseWhenNotActiveEnable;

        // Other options
        private bool _autoCompressEnable;
        private int _compresssDay;
        private bool _autoDeleteCompressedPackageEnable;
        private int _deleteCompressedPackageDay;


        // getter and setter
        public string TargetFolder { get => _targetFolder; set => _targetFolder = value; }
        public int FolderStructureMethod { get => _folderStructureMethod; set => _folderStructureMethod = value; }
        public int ImageFormat { get => _imageFormat; set => _imageFormat = value; }
        public int ImageQuality { get => _imageQuality; set => _imageQuality = value; }
        public string ImagePrefix { get => _imagePrefix; set => _imagePrefix = value; }
        public int ImageNamingRule { get => _imageNamingRule; set => _imageNamingRule = value; }
        public string ImageSuffix { get => _imageSuffix; set => _imageSuffix = value; }
        public int SpacedTime { get => _spacedTime; set => _spacedTime = value; }
        public int NotActiveTime { get => _notActiveTime; set => _notActiveTime = value; }
        public bool PauseWhenNotActiveEnable { get => _pauseWhenNotActiveEnable; set => _pauseWhenNotActiveEnable = value; }
        public bool AutoCompressEnable { get => _autoCompressEnable; set => _autoCompressEnable = value; }
        public int CompresssDay { get => _compresssDay; set => _compresssDay = value; }
        public bool AutoDeleteCompressedPackageEnable { get => _autoDeleteCompressedPackageEnable; set => _autoDeleteCompressedPackageEnable = value; }
        public int DeleteCompressedPackageDay { get => _deleteCompressedPackageDay; set => _deleteCompressedPackageDay = value; }




        // Access the private variables using getters and setters


        public void Start()
        {
            FolderStructureObject folderStructure = new FolderStructureObject(_targetFolder, _folderStructureMethod);
            ScreenshotImageObject  screenshotImage = new ScreenshotImageObject(_imageFormat, _imageQuality, _imagePrefix, _imageNamingRule, _imageSuffix);

            Task takeScreenshotTask = new Task(() => StartTakeScreenshot(_spacedTime, folderStructure, screenshotImage));
            Task pauseTakeScreenWhenNotActiveTask = new Task(() => PauseTakeScreenshotWhenNotActive(_notActiveTime));
            Task autoCompressOrDeleteTask = new Task(() => AutoCompressOrDelete(_targetFolder, _autoCompressEnable, _compresssDay, _autoDeleteCompressedPackageEnable, _deleteCompressedPackageDay));

            takeScreenshotTask.Start();
            if (_pauseWhenNotActiveEnable)
                pauseTakeScreenWhenNotActiveTask.Start();
            if (_autoCompressEnable || _autoDeleteCompressedPackageEnable)
                autoCompressOrDeleteTask.Start();
        }

        private void AutoCompressOrDelete(string targetFolder, bool autoCompress, int compressDay, bool autoDeleteCompressedPackage, int deleteCompressedPackageDay)
        {
            Console.WriteLine("Auto compress or delete");
        }

        private void PauseTakeScreenshotWhenNotActive(int notActiveTime)
        {
            Console.WriteLine("Pause task screenshot when not active");
        }

        private void StartTakeScreenshot(int spaceTime, FolderStructureObject folderStructure, ScreenshotImageObject screenshotImage)
        {
            Console.WriteLine("Start take screenshot");
        }

        private void TakeScreenShotMock(string path, string name)
        {
            // Mock
            Console.WriteLine($"【{path}】Took a screenshot: {name}");
        }

        class FolderStructureObject
        {
            public FolderStructureObject(string targetFolder, int method)
            {
            }
        }


        class ScreenshotImageObject
        {
            public ScreenshotImageObject(int format, int quality, string prefix, int namingRule, string suffix)
            {

            }
        }
    }
}
