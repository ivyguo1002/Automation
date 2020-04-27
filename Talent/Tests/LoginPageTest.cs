using Framework.Helper;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Talent.DataModel;
using Talent.Pages;

namespace Talent.Tests
{
    [TestClass]
    [TestCategory("Regression")]
    [TestCategory("Account")]
    public class LoginPageTest : BaseTest
    {
        public LoginPage LoginPage { get; set; }
        public DashboardPage DashBoardPage { get; set; }
        public List<User> TestUsers { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            LoginPage = new LoginPage(Driver);
            DashBoardPage = new DashboardPage(Driver);
            TestUsers = JsonDataHelper.ToObject<List<User>>("\\TestData\\users.json");
        }

        [TestMethod]
        [TestCategory("Valid")]
        [TestCategory("Login")]
        [Description("Validate that user logs into system with valid credential successfully")]
        public void LoginWithValidCredential()
        {
            try
            {
                LoginPage.Open();
                var validUser = TestUsers.Where(user => user.Key.Equals("valid")).SingleOrDefault();
                LoginPage.Login(validUser);
                Assert.IsTrue(DashBoardPage.IsLoaded());
            }
            catch (Exception e)
            {
                ReportManager.AddErrorLogToReport(e);
                throw;
            }
        }

        [TestMethod]
        [Description("Validate that user fails to log into system with invalid credential")]
        public void LoginWithInvalidCredential()
        {
            LoginPage.Open();
            var invalidUser = TestUsers.Where(user => user.Key.Equals("invalid")).SingleOrDefault();
            LoginPage.Login(invalidUser);
            Assert.IsFalse(DashBoardPage.IsLoaded());
        }
    }
}