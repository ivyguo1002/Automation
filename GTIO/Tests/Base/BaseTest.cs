using Framework.Helper;
using Framework.WebDriver;
using MongoDB.Driver.Core.WireProtocol.Messages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(3)]
namespace GTIO.Tests.Base
{
    //[TestFixture(WebDriverType.Local, BrowserType.Firefox)]
    //[TestFixture(WebDriverType.Local, BrowserType.Chrome)]
    //[TestFixture(WebDriverType.Sauce, BrowserType.Chrome)]
    //[TestFixture(WebDriverType.Sauce, BrowserType.Firefox)]

    public class BaseTest
    {
        public IWebDriver Driver { get; set; }
        public WebDriverType WebDriverType { get; set; }
        public BrowserType BrowserType { get; set; }
        //Cross Browser Setting
        public BaseTest(WebDriverType webDriverType, BrowserType browserType)
        {
            WebDriverType = webDriverType;
            BrowserType = browserType;
        }
        public BaseTest()
        {

        }
        [SetUp]
        public void SetUpForEveryTestMethod()
        {
            ReportHelper.AddTestMethodMetadataToReport(TestContext.CurrentContext);
            var webDriver = TestContext.Parameters["WebDriverType"];
            WebDriverType = String.IsNullOrEmpty(webDriver) ? WebDriverType.Local : (WebDriverType)Enum.Parse(typeof(WebDriverType), webDriver);
            var browser = TestContext.Parameters["Browser"];
            BrowserType = String.IsNullOrEmpty(browser) ? BrowserType.Chrome : (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            Driver = WebDriverFactory.CreateDriver(WebDriverType, BrowserType, TestContext.CurrentContext);
        }

        [TearDown]
        public void TearDownForEveryTestMethod()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ScreenshotHelper.TakeAndSaveScreenshot(Driver);
            }

            ReportHelper.AddTestOutcomeToReport(TestContext.CurrentContext);


            if (Driver != null)
            {
                Driver.Quit();
            }
        }



    }
}
