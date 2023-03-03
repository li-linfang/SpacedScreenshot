using SpacedScreenshot.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpacedScreenshot
{
    public class SpacedScreenshotApplicationContext:ApplicationContext
    {
        private static NotifyIcon s_notifyIcon = new NotifyIcon();
        string targetFolder;


        public SpacedScreenshotApplicationContext(string targetFolder)
        {
            this.targetFolder = targetFolder;

            ToolStripMenuItem statusItem = new ToolStripMenuItem("Number: 0", Resource1.AppIcon.ToBitmap());
            ToolStripMenuItem screenshotMenuItem = new ToolStripMenuItem("Screenshot", Resource1.FolderIcon.ToBitmap(), Screenshot);
            ToolStripMenuItem configMenuItem = new ToolStripMenuItem("Config", Resource1.FolderIcon.ToBitmap(), Config);
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit", Resource1.ExitIcon.ToBitmap(), Exit);

            // Icon is from: <a href="https://www.flaticon.com/free-icons/screenshot" title="screenshot icons">Screenshot icons created by HJ Studio - Flaticon</a>
            // Icon is from: <a href="https://www.flaticon.com/free-icons/folder" title="folder icons">Folder icons created by Freepik - Flaticon</a>
            // Icon is from: <a href="https://www.flaticon.com/free-icons/logout" title="logout icons">Logout icons created by Freepik - Flaticon</a>

            s_notifyIcon.Icon = SpacedScreenshot.Properties.Resource1.AppIcon;


            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.Add(statusItem);
            cms.Items.Add(screenshotMenuItem);
            cms.Items.Add(configMenuItem);
            cms.Items.Add(exitMenuItem);


            s_notifyIcon.ContextMenuStrip = cms;
            s_notifyIcon.Text = "SpacedScreenshot";
            
            s_notifyIcon.Visible = true;
            
        }

        void Screenshot(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer", targetFolder);
        }
        void Config(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer", System.Environment.CurrentDirectory);
        }
        void Exit(object sender, EventArgs e)
        {
            s_notifyIcon.Visible = false;
            Application.Exit();
        }

        public static void UpdateMenuItem(int index, string text)
        {
            ToolStripItem toolStripItem = s_notifyIcon.ContextMenuStrip.Items[index];
            toolStripItem.Text = text;
        }
    }
}
