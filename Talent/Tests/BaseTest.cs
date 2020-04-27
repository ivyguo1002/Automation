using Framework.Helper;
using Framework.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver.Core.WireProtocol.Messages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Talent.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }
        public TestContext TestContext { get; set; }

        public List<string> TestCategories { get; set; } = new List<string>();

        [TestInitialize]
        public void SetUpForEveryTestMethod()
        {
            GetCategories();
            ReportManager.AddTestMethodMetadataToReport(TestContext, TestCategories);
            Driver = new WebDriverFactory().CreateDriver(BrowserType.Chrome);
        }

        private void GetCategories()
        {
            var methodTestCategoryAttributes = GetType().GetMethod(TestContext.TestName)
                .GetCustomAttributes<TestCategoryAttribute>(true);
            var classTestCategoryAttributes = GetType().GetCustomAttributes<TestCategoryAttribute>(true);

            var attributes = methodTestCategoryAttributes.Concat(classTestCategoryAttributes);

            if (attributes != null)
            {
                foreach (var attribute in attributes)
                {
                    TestCategories.AddRange(attribute.TestCategories);
                }
            }
        }


        [TestCleanup]
        public void TearDownForEveryTestMethod()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                ScreenshotHelper.TakeAndSaveScreenshot(Driver);
            }
            ReportManager.AddTestOutcomeToReport(TestContext);
            

            if (Driver != null)
            {
                Driver.Quit();
            }
        }
        
    }
}
