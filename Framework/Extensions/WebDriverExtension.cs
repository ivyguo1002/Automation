using Framework.Config;
using Framework.WebDriver;
using Newtonsoft.Json.Linq;
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
        public static void SigninWith(this IWebDriver driver, JToken tokenObject)
        {
            driver.Navigate().GoToUrl(ConfigManager.Settings.BaseUrl);
            var js = driver as IJavaScriptExecutor;
            string script = "localStorage.setItem(arguments[0], arguments[1])";

            js.ExecuteScript(script, "access_token", tokenObject["token"].ToString());
            js.ExecuteScript(script, "username", tokenObject["username"].ToString());
            js.ExecuteScript(script, "expiry_on", tokenObject["expires"].ToString());
            js.ExecuteScript(script, "talent-permission-scope", $"[\"{tokenObject["userRole"]}\"]");
        }

        public static IWebElement Find(this IWebDriver driver, By by, int timeOutInSeconds = (int)BrowserSetting.DefaultTimeOut )
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                return wait.Until(d => d.FindElement(by));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Find element with locator {by} failed");
            }
        }

        public static void WaitForPageLoad(this IWebDriver driver, string title, int timeOutInSeconds = (int)BrowserSetting.PageLoadTimeOut)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until((x) =>
                {
                    return (x.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static IWebElement WaitForDisplayed(this IWebDriver driver, By by, int timeOutInSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(d => d.FindElement(by).Displayed);
                return driver.FindElement(by);
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Wait for element displayed with locator {by} failed");
            }
        }

        public static IWebElement WaitForEnabled(this IWebDriver driver, By by, int timeOutInSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(d => d.FindElement(by).Enabled);
                return driver.FindElement(by);
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Wait for element enabled with locator {by} failed");
            }
        }

    }
}
