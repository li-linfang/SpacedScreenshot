using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace SpacedScreenshot
{
    public class SpaceScreenshotObject
    {
        // Screenshot storage folder
        private string _targetFolder;
        private int _folderStructureMethod;

        // Screenshot file
        private int _screenshotFormat;
        private int _screenshotQuality;
        private string _screenshotPrefix;
        private int _screenshotNamingRule;
        private string _screenshotSuffix;

        // Timing
        private int _spacedTime;
        private bool _pauseWhenNotActiveEnable;
        private int _notActiveTime;

        // Other options
        private bool _autoCompressEnable;
        private int _compresssDay;
        private bool _autoDeleteCompressedPackageEnable;
        private int _deleteCompressedPackageDay;


        public SpaceScreenshotObject()
        {
        }
        // Constructor
        public SpaceScreenshotObject(string targetFolder, int folderStructureMethod, int screenshotFormat, int screenshotQuality, string screenshotPrefix, int screenshotNamingRule, string screenshotSuffix, int spacedTime, bool pauseWhenNotActiveEnable, int notActiveTime, bool autoCompressEnable, int compresssDay, bool autoDeleteCompressedPackageEnable, int deleteCompressedPackageDay)
        {
            _targetFolder = targetFolder;
            _folderStructureMethod = folderStructureMethod;
            _screenshotFormat = screenshotFormat;
            _screenshotQuality = screenshotQuality;
            _screenshotPrefix = screenshotPrefix;
            _screenshotNamingRule = screenshotNamingRule;
            _screenshotSuffix = screenshotSuffix;
            _spacedTime = spacedTime;
            _pauseWhenNotActiveEnable = pauseWhenNotActiveEnable;
            _notActiveTime = notActiveTime;
            _autoCompressEnable = autoCompressEnable;
            _compresssDay = compresssDay;
            _autoDeleteCompressedPackageEnable = autoDeleteCompressedPackageEnable;
            _deleteCompressedPackageDay = deleteCompressedPackageDay;
        }



        // bitmap object initial
        private Bitmap _bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);



        // getter and setter
        public string TargetFolder { get => _targetFolder; set => _targetFolder = value; }
        public int FolderStructureMethod { get => _folderStructureMethod; set => _folderStructureMethod = value; }
        public int ScreenshotFormat { get => _screenshotFormat; set => _screenshotFormat = value; }
        public int ScreenshotQuality { get => _screenshotQuality; set => _screenshotQuality = value; }
        public string ScreenshotPrefix { get => _screenshotPrefix; set => _screenshotPrefix = value; }
        public int ScreenshotNamingRule { get => _screenshotNamingRule; set => _screenshotNamingRule = value; }
        public string ScreenshotSuffix { get => _screenshotSuffix; set => _screenshotSuffix = value; }
        public int SpacedTime { get => _spacedTime; set => _spacedTime = value; }
        public int NotActiveTime { get => _notActiveTime; set => _notActiveTime = value; }
        public bool PauseWhenNotActiveEnable { get => _pauseWhenNotActiveEnable; set => _pauseWhenNotActiveEnable = value; }
        public bool AutoCompressEnable { get => _autoCompressEnable; set => _autoCompressEnable = value; }
        public int CompresssDay { get => _compresssDay; set => _compresssDay = value; }
        public bool AutoDeleteCompressedPackageEnable { get => _autoDeleteCompressedPackageEnable; set => _autoDeleteCompressedPackageEnable = value; }
        public int DeleteCompressedPackageDay { get => _deleteCompressedPackageDay; set => _deleteCompressedPackageDay = value; }


        public void Start()
        {
            FolderStructureObject folderStructure = new FolderStructureObject(_targetFolder, _folderStructureMethod);
            ScreenshotImageObject screenshotImage = new ScreenshotImageObject(_screenshotFormat, _screenshotQuality, _screenshotPrefix, _screenshotNamingRule, _screenshotSuffix);

            Task startTakeScreenTask = new Task(() => StartTakeScreenshot(_spacedTime, folderStructure, screenshotImage));
            Task pauseTakeWhenUserNotActiveTask = new Task(() => PauseTakeWhenUserNotActive(_notActiveTime));
            Task autoCompressOrDeleteTask = new Task(() => AutoCompressOrDelete(_targetFolder, _autoCompressEnable, _compresssDay, _autoDeleteCompressedPackageEnable, _deleteCompressedPackageDay));

            startTakeScreenTask.Start();

            if (_pauseWhenNotActiveEnable)
                pauseTakeWhenUserNotActiveTask.Start();
            if (_autoCompressEnable || _autoDeleteCompressedPackageEnable)
                autoCompressOrDeleteTask.Start();
        }

        private void AutoCompressOrDelete(string targetFolder, bool autoCompress, int compressDay, bool autoDeleteCompressedPackage, int deleteCompressedPackageDay)
        {
            Console.WriteLine("Auto compress or delete");
        }

        private void PauseTakeWhenUserNotActive(int notActiveTime)
        {
            Console.WriteLine("Pause task screenshot when not active");
        }

        private void StartTakeScreenshot(int spaceTime, FolderStructureObject folderStructure, ScreenshotImageObject screenshotImage)
        {
            Console.WriteLine("Start take screenshot");
            var count = 1;
            while(true)
            {
                Task.Delay(spaceTime*1000).Wait();
                TakeScreenShot(folderStructure.GetScreenshotPath(), screenshotImage.GetScreenshotFilename(), count);
                count++;
            }
        }


        /// <summary>
        /// Start screenshot operation.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        private void TakeScreenShot(string path, string name, int count)
        {
            // Mock
            Console.WriteLine($"[{path}] Took a screenshot: {name}");

            Graphics g = Graphics.FromImage(_bmpScreenshot);
            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

            string format = name.Split('.')[1];
            ImageFormat imageFormat = null;
            switch (format)
            {
                case "jpg": imageFormat = ImageFormat.Jpeg;break;
                case "png": imageFormat = ImageFormat.Png;break;
            }
            _bmpScreenshot.Save($"{path}\\{name}", ImageFormat.Jpeg);

            SpacedScreenshotApplicationContext.UpdateMenuItem(0, $"Number: {count}");
        }

        class FolderStructureObject
        {
            private string _targetFolder;
            // method
            // 0: hour
            // 1: AM/PM
            // 2: working time
            private int _method;

            public string TargetFolder { get => _targetFolder; set => _targetFolder = value; }
            public int Method { get => _method; set => _method = value; }


            public FolderStructureObject(string targetFolder, int method)
            {
                _targetFolder = targetFolder;
                _method = method;
            }


            public string GetScreenshotPath()
            {
                var today = DateTime.Now.ToString("yyyy-MM-dd");
                var subFolder = "";
                switch (_method)
                {
                    case 0: subFolder = $"{DateTime.Now.ToString("HH")}~{DateTime.Now.AddHours(1).ToString("HH")}"; break;
                    case 1: subFolder = int.Parse(DateTime.Now.ToString("HH")) < 12 ? "AM" : "PM"; break;
                    case 2: subFolder = ""; break;
                }
                var path = $"{_targetFolder}\\{today}\\{subFolder}";
                GenerateFolderPath(path);
                return path;
            }


            private void GenerateFolderPath(string path)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
        }


        class ScreenshotImageObject
        {
            // 0: png
            // 1: jpg
            private int _format;
            // 0-100
            private int _quality;
            private string _prefix;
            // 0:seq 
            // 1:time 
            // 2: seq+time
            private int _namingRule;
            private string _suffix;

            private int _seq;


            public int Format { get => _format; set => _format = value; }
            public int Quality { get => _quality; set => _quality = value; }
            public string Prefix { get => _prefix; set => _prefix = value; }
            public int NamingRule { get => _namingRule; set => _namingRule = value; }
            public string Suffix { get => _suffix; set => _suffix = value; }


            public ScreenshotImageObject(int format, int quality, string prefix, int namingRule, string suffix)
            {
                _format = format;
                _quality = quality;
                _prefix = prefix;
                _namingRule = namingRule;
                _suffix = suffix;
                _seq = 1;
            }

            public string GetScreenshotFilename()
            {
                string formatSuffix = null;
                switch (_format)
                {
                    case 0: formatSuffix = "png"; break;
                    case 1: formatSuffix = "jpg"; break;
                }

                string name = null;
                switch (_namingRule)
                {
                    case 0: name = (_seq++)+""; break;
                    case 1: name = DateTime.Now.ToString("yyyy-MM-dd~HH_mm_ss"); break;
                    case 2: name = $"{_seq++}_{DateTime.Now.ToString("yyyy-MM-dd~HH-mm-ss")}"; break;
                }

                return $"{_prefix}_{name}_{_suffix}.{formatSuffix}";
            }
        }

    }
}

