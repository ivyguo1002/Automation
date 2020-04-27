using Framework.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Extensions
{
    public static class WebDriverExtension
    {
        public static IWebElement WaitForElement(this IWebDriver driver, By by, int TimeOutInSeconds = (int)BrowserSetting.DefaultTimeOut )
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOutInSeconds));
                return wait.Until(d => d.FindElement(by));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Wait for element with locator {by} failed");
            }
        }

        public static void WaitForPageLoad(this IWebDriver driver, string title, int TimeOutInSeconds = (int)BrowserSetting.PageLoadTimeOut)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TimeOutInSeconds));
                wait.Until(ExpectedConditions.TitleContains(title));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverException($"Wait for {title} Page Load failed");
            };
        }
    }
}
