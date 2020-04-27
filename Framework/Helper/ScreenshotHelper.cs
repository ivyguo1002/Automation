using Framework.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Framework.Helper
{
    public class ScreenshotHelper
    {
        public static string ScreenshotFilePath { get; set; }
        public static void TakeAndSaveScreenshot(IWebDriver driver)
        {
            var screenshotTaker = driver as ITakesScreenshot;
            var screenshot = screenshotTaker.GetScreenshot();
            if (screenshot == null)
            {
                return;
            }
            else
            {
                CreateScreenshotFilePath();
                screenshot.SaveAsFile(ScreenshotFilePath, ScreenshotImageFormat.Png);
            }
        }

        private static void CreateScreenshotFilePath()
        {
            var screenshotFolderPath = PathHelper.BaseDir() + ConfigManager.Settings.ScreenshotPath;
            var screenshotFileName = "screenshot" + DateTime.Now.ToString("_MM_dd_yyyy_HH-mm") +".png";
            ScreenshotFilePath = Path.Combine(screenshotFolderPath, screenshotFileName);
        }
    }
}
