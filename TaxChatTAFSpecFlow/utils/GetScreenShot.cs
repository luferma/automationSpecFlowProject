using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaxChatTAF;

namespace TaxChatTAFSpecFlow.utils
{
    public class GetScreenShot
    {
        public static string Capture(IWebDriver driver, string screenShotNameImage)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string screenShotName = screenShotNameImage + DateTime.Now.ToString("MM-dd-yyyy");
            string screenShotNamerep1 = screenShotName.Replace("/", "_");
            string screenShotNamerep2 = screenShotNamerep1.Replace(" ", "_");
            string screenShotNamerep3 = screenShotNamerep2.Replace(":", "_");
            string screenShotNamerep4 = screenShotNamerep3.Replace("-", "_");            
            string finalpth = Utilities.getRelativePathRoute(configConstants.PATH_IMAGES_ERROR_EXECUTION);
            string screenshotDir = finalpth + screenShotNamerep4 + ".png";
            Uri uri = new Uri(screenshotDir);
            string localpath = uri.LocalPath;
            screenshot.SaveAsFile(localpath);
            return localpath;
        }
    }
}
