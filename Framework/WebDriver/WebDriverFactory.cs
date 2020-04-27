using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;

namespace Framework.WebDriver
{
    public class WebDriverFactory
    {

        public IWebDriver CreateDriver(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    var options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    return new ChromeDriver(options);

                case BrowserType.Edge:
                    break;
                case BrowserType.Firefox:
                    break;
                case BrowserType.Safari:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("The browser type isn't supported");

            }

            return null;
        }

        public IWebDriver CreateSauceDriver()
        {

            throw new NotImplementedException();
        }
    }
}