﻿using OpenQA.Selenium;
using Framework.Extensions;
using System;

namespace GTIO.Pages
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver driver) : base(driver) { }
        public override string Title => "Dashboard";
        public override string Url => "/dashboard";
        //public IWebElement JobsMenu => Driver.Find(By.XPath("//*[@class='ant-menu-submenu-title']")).Contains("Jobs");
        private IWebElement JobsMenu => Driver.Find(By.XPath("//*[@class='ant-menu-submenu-title'][contains(.,'Jobs')]"));

        public IWebElement ExploreJobsMenu => Driver.Find(By.CssSelector("a[href='/jobs/explore']"));

        private IWebElement ProfileMenu => Driver.Find(By.XPath("//li/a[@href='/profile']"));

        public ProfilePage GoToProfilePage()
        {
            ProfileMenu.Click();
            return new ProfilePage(Driver);
        }

        public JobsPage GoToJobsPage()
        {
            JobsMenu.Hover(Driver);
            Driver.WaitForDisplayed(By.CssSelector("a[href='/jobs/explore']")).Click();

            return new JobsPage(Driver);
        }
    }
}