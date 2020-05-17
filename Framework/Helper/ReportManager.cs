using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Framework.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Framework.Helper
{
    public class ReportManager
    {
        public static AventStack.ExtentReports.ExtentReports Extent { get; private set; }
        public static ExtentTest CurrentTest { get; set; }

        public static string CreateReportDirectory()
        {
            var reportFolder = PathHelper.BaseDir() + ConfigManager.Settings.ReportPath;
            return Directory.CreateDirectory(reportFolder + "Report" + 
                DateTime.Now.ToString("_MM_dd_yyyy_HH-mm")+ "\\").ToString();
        }

        public static void LogTestStepInfo(string message)
        {
            CurrentTest.Info(message);
        }

        public static void StartReporter()
        {
            var reportDirectory = CreateReportDirectory();
            var htmlReporter = new ExtentHtmlReporter(reportDirectory);
            Extent = new AventStack.ExtentReports.ExtentReports();
            Extent.AttachReporter(htmlReporter);
        }

        public static void AddErrorLogToReport(Exception e)
        {
            CurrentTest.Fail(e);
        }

        public static void AddTestMethodMetadataToReport(TestContext testContext, List<string> testCategories)
        {
            CurrentTest = Extent.CreateTest(testContext.TestName);
            if (testCategories.Any())
            {
                foreach (var category in testCategories)
                {
                    CurrentTest.AssignCategory(category);
                }
            }
            else
            {
                return;
            }
        }
        public static void AddTestOutcomeToReport(TestContext testContext)
        {
            var result = testContext.CurrentTestOutcome;
            var fullTestName = testContext.FullyQualifiedTestClassName + testContext.TestName;
            
            switch (result)
            {
                case UnitTestOutcome.Failed:
                    CurrentTest.Fail($"Test Failed: {fullTestName}")
                        .AddScreenCaptureFromPath(ScreenshotHelper.ScreenshotFilePath);
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    CurrentTest.Pass($"Test Passed: {fullTestName}");
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    CurrentTest.Skip($"Test Skipped: {fullTestName}");
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;
            }
        }

        public static void Flush()
        {
            Extent.Flush();
        }
    }
}
