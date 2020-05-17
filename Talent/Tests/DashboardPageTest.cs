using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Talent.API;
using Talent.DataModel;
using Talent.Pages;


namespace Talent.Tests
{
    [TestClass]
    [TestCategory("Dashboard")]
    public class DashboardPageTest : BaseTest
    {
        public DashboardPage  DashboardPage { get; set; }

        [TestInitialize]
        public void SetUpForTestClass()
        {
            DashboardPage = new DashboardPage(Driver);
        }

        [TestMethod]
        public void NavigateToProfilePage()
        {
            //IdentityAPI.SigninAs(Role.talent);
            var user = new User { Email = "talent@mvp.studio", Password = "GLobalTalent" };
            var loginPage = new LoginPage(Driver);
            loginPage.Open();

            loginPage.LoginAs(user);
            DashboardPage.Open();
            DashboardPage.GoToProfilePage();
            var profilePage = new ProfilePage(Driver);
            Assert.IsTrue(profilePage.IsLoaded());
        }
    }
}
