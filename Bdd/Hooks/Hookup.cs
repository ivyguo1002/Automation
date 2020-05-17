using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Framework.Config;
using Framework.Helper;
using NUnit.Framework;
using Bdd.Token;
using TechTalk.SpecFlow;
using Framework.WebDriver;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(3)]
namespace Bdd.Hooks
{
    [Binding]
    public class Hookup
    {
        private IWebDriver _driver;
        public Hookup( IWebDriver driver)
        {
            _driver = driver;
        }

        [BeforeTestRun]
        public static void AssemblySetup()
        {
            ConfigManager.LoadConfiguration();

            ReportHelper.StartReporter();

            TokenManager.InitializeToken();
        }

        [AfterTestRun]
        public static void AssemblyTearDown()
        {
            ReportHelper.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            ReportHelper.AddFeatureInfo(featureContext.FeatureInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }

        [AfterStep]
        public void BeforeStep(ScenarioContext scenarioContext)
        {
            ReportHelper.AddStepInfo(scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString(), scenarioContext.StepContext.StepInfo.Text);

            if (scenarioContext.TestError != null)
            {
                ScreenshotHelper.TakeAndSaveScreenshot(_driver);
                ReportHelper.AddTestResult(scenarioContext.TestError);
            }
        }
    }
}
