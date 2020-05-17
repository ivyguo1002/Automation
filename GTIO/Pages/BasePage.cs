
using OpenQA.Selenium;
using Framework.Extensions;
using System;
using Framework.Config;
using AventStack.ExtentReports;
using Framework.Helper;

namespace GTIO.Pages
{
    public class BasePage
    {
        public string BaseUrl => ConfigManager.Settings.BaseUrl;
        public virtual string Url { get; set; }
        public virtual string Title { get; set; }
        public IWebDriver Driver { get; set; }
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public TPage Open<TPage>() where TPage : BasePage
        {
            ReportHelper.LogTestStepInfo($"Navigate to {Title} page: {BaseUrl}{Url}");
            Driver.Navigate().GoToUrl(BaseUrl + Url);
            Driver.WaitForPageLoad(Title);
            return this as TPage;
        }

        public void Open()
        {
            ReportHelper.LogTestStepInfo($"Navigate to {Title} page: {BaseUrl}{Url}");
            Driver.Navigate().GoToUrl(BaseUrl + Url);
            Driver.WaitForPageLoad(Title);
        }

        public bool IsLoaded()
        {
            ReportHelper.LogTestStepInfo($"Check if the {Title} page is loaded successully");
            try
            {
                Driver.WaitForPageLoad(Title);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}