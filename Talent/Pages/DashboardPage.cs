using OpenQA.Selenium;
using Framework.Extensions;
using System;

namespace Talent.Pages
{
    public class DashboardPage : BasePage
    {
        public override string Title { get; set; } = "Dashboard";
        public override string Url { get; set; } = "/dashboard";
        public DashboardPage(IWebDriver driver) : base(driver) { }

        public void GoToProfilePage()
        {
            Driver.FindElement(By.XPath("//li/a[@href='/profile']")).Click();
        }
    }
}