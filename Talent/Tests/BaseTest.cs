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
            var testCategories = GetCategories();
            ReportManager.AddTestMethodMetadataToReport(TestContext, testCategories);
            //Driver = new WebDriverFactory().CreateDriver(WebDriverType.Local, BrowserType.Chrome, TestContext);
        }

        private List<string> GetCategories()
        {
            var methodTestCategoryAttributes = GetType().GetMethod(TestContext.TestName)
                .GetCustomAttributes<TestCategoryAttribute>(true);
            var classTestCategoryAttributes = GetType().GetCustomAttributes<TestCategoryAttribute>(true);

            var attributes = methodTestCategoryAttributes.Concat(classTestCategoryAttributes);
            var testCategories = new List<String>();
            if (attributes != null)
            {
                foreach (var attribute in attributes)
                {
                    testCategories.AddRange(attribute.TestCategories);
                }
            }
            return testCategories;
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
