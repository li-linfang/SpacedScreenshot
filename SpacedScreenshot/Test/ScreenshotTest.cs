using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpacedScreenshot.Test
{
    internal class ScreenshotTest
    {
        public static void testTakeScreenshot()
        {
            //Bitmap bm = new Bitmap();
            var width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;



            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
        }
    }
}
