using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Talent.DataModel;
using Talent.Pages;
using Framework.Helper.DataDriven;

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
            TestUsers = JsonDataHelper.ToObject<List<User>>("\\TestData\\users.json");
        }

        [TestMethod]
        [TestCategory("Valid")]
        [TestCategory("Login")]
        [Description("Validate that user logs into system with valid credential successfully")]
        public void LoginWithValidCredential()
        {
            LoginPage.Open();
            var validUser = TestUsers.Where(user => user.Key.Equals("valid")).SingleOrDefault();
            var dashBoardPage = LoginPage.LoginAs(validUser);
            Assert.IsTrue(dashBoardPage.IsLoaded(), "Valid User should been logged into system and navigated to Dashboard Page");
        }

        [TestMethod]
        [Description("Validate that user fails to log into system with invalid credential")]
        public void LoginWithInvalidCredential()
        {
            LoginPage.Open();
            var invalidUser = TestUsers.Where(user => user.Key.Equals("invalid")).SingleOrDefault();
            var dashBoardPage = LoginPage.LoginAs(invalidUser);
            Assert.IsFalse(dashBoardPage.IsLoaded(), "Invalid User should receive the error message");
        }
    }
}