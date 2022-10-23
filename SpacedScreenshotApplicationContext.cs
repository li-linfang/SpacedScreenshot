using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpacedScreenshot
{
    public class SpacedScreenshotApplicationContext:ApplicationContext
    {
        NotifyIcon notifyIcon = new NotifyIcon();
        string targetFolder = "D:\\";
        public SpacedScreenshotApplicationContext(string targetFolder)
        {
            this.targetFolder = targetFolder;

            MenuItem screenshotMenuItem = new MenuItem("Screenshot", new EventHandler(Screenshot));
            MenuItem configMenuItem = new MenuItem("Config", new EventHandler(Config));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            // Icon is from: <a href="https://www.flaticon.com/free-icons/screenshot" title="screenshot icons">Screenshot icons created by HJ Studio - Flaticon</a>
            notifyIcon.Icon = SpacedScreenshot.Properties.Resource1.AppIcon;
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] {screenshotMenuItem, configMenuItem,exitMenuItem });
            notifyIcon.Text = "SpacedScreenshot";
            
            notifyIcon.Visible = true;
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
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}
