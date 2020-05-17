using BoDi;
using Framework.Helper;
using Framework.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Bdd
{
    [Binding]
    public class DriverSetup
    {
        private IObjectContainer _objectContainer;
        public DriverSetup(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }
        public IWebDriver InitDriver()
        {
            var webDriver = TestContext.Parameters["WebDriverType"];
            var webDriverType = String.IsNullOrEmpty(webDriver) ? WebDriverType.Local : (WebDriverType)Enum.Parse(typeof(WebDriverType), webDriver);
            var browser = TestContext.Parameters["Browser"];
            var browserType = String.IsNullOrEmpty(browser) ? BrowserType.Chrome : (BrowserType)Enum.Parse(typeof(BrowserType), browser);

            return WebDriverFactory.CreateDriver(webDriverType, browserType, TestContext.CurrentContext);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            ReportHelper.AddScenarioInfo(scenarioContext.ScenarioInfo.Title);
            var driver = InitDriver();
            _objectContainer.RegisterInstanceAs(driver);
        }

    }
}