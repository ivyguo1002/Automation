using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;
using System.Configuration;
using System.Collections.Specialized;

namespace Framework.WebDriver
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateDriver(WebDriverType webDriverType, BrowserType browserType, TestContext currentContext)
        {
            switch (webDriverType)
            {
                case WebDriverType.Local:
                    return CreateLocalDriver(browserType);

                case WebDriverType.Grid:
                    return CreateRemoteDriver(browserType);

                case WebDriverType.Sauce:
                    return CreateSauceDriver(browserType, currentContext);
                default:
                    throw new ArgumentOutOfRangeException("The web driver type isn't supported");
            }
        }
        public static IWebDriver CreateLocalDriver(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    return new ChromeDriver(chromeOptions);

                case BrowserType.Edge:
                    break;
                case BrowserType.Firefox:
                    var profile = new FirefoxProfile();
                    profile.SetPreference("intl.accept_languages", "en,en-US");
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.Profile = profile;
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    return new FirefoxDriver(firefoxOptions);
                    
                case BrowserType.Safari:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("The browser type isn't supported");

            }

            return null;
        }

        public static IWebDriver CreateRemoteDriver(BrowserType browserType)
        {
            var remoteWebDriverUrl = ConfigurationManager.AppSettings["RemoteWebDriverHub"];
            switch (browserType)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    return new RemoteWebDriver(new Uri(remoteWebDriverUrl), chromeOptions);
                    
                case BrowserType.Edge:
                    break;
                case BrowserType.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    return new RemoteWebDriver(new Uri(remoteWebDriverUrl), firefoxOptions);
                case BrowserType.Safari:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("The browser type isn't supported");
            }

            return null;
           
        }

        public static IWebDriver CreateSauceDriver(BrowserType browserType, TestContext currentContext)
        {
            //var sauceUserName = Environment.GetEnvironmentVariable("SAUCE_USERNAME");
            //var sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");
            var sauceUserName = "ivy.jian.guo";
            var sauceAccessKey = "6eff0f7a-02a0-438d-8cf1-ef33bed304fd";

            var sauceLabUrl = ConfigurationManager.AppSettings["SauceLabWebDriverHub"];

            /*
              * In this section, we will configure our test to run on some specific
              * browser/os combination in Sauce Labs
              */
            var sauceOptions = new Dictionary<string, object>();
            sauceOptions.Add("username", sauceUserName);
            sauceOptions.Add("accessKey", sauceAccessKey);
            sauceOptions.Add("name", currentContext.Test.Name);
            
            switch (browserType)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    var chromeCaps = ConfigurationManager.GetSection("environments/chrome") as NameValueCollection;
                    chromeOptions.UseSpecCompliantProtocol = true;
                    chromeOptions.PlatformName = chromeCaps["platform"];
                    chromeOptions.BrowserVersion = chromeCaps["browser_version"];
                    chromeOptions.AddAdditionalCapability("sauce:options", sauceOptions, true);
                    
                    return new RemoteWebDriver(new Uri(sauceLabUrl),
                      chromeOptions);
                    
                case BrowserType.Edge:
                    break;
                case BrowserType.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    var firefoxCaps = ConfigurationManager.GetSection("environments/firefox") as NameValueCollection;
                    firefoxOptions.PlatformName = firefoxCaps["platform"];
                    firefoxOptions.BrowserVersion = firefoxCaps["browser_version"];
                    firefoxOptions.AddAdditionalCapability("sauce:options", sauceOptions, true);

                    return new RemoteWebDriver(new Uri(sauceLabUrl), firefoxOptions);
                    
                case BrowserType.Safari:
                    break;
                default:
                    break;
            }

            return null;
        }


    }
}