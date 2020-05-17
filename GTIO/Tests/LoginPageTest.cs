using Framework.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using GTIO.Pages;
using Newtonsoft.Json.Linq;
using GTIO.DataModel;
using GTIO.Tests.Base;
using Framework.WebDriver;

namespace GTIO.Tests
{
    [Category("Regression")]
    [Category("Account")]
    [TestFixture]
    public class LoginPageTest : BaseTest
    {
        public LoginPageTest() {}
        public LoginPageTest(WebDriverType webDriverType, BrowserType browserType) : base(webDriverType, browserType) { }

        [Test]
        [Category("Valid")]
        [Category("Login")]
        [Description("Validate that user logs into system with valid credential successfully")]
        [TestCaseSource(typeof(TestCaseData), "CredentialsJson", new object[] { "valid" })]
        public void LoginWithValidCredential(User user)
        {
            var dashBoardPage = new LoginPage(Driver)
                .Open<LoginPage>()
                .LoginAs(user);
            Assert.That(dashBoardPage.IsLoaded(), Is.True, "Valid User should been logged into system and navigated to Dashboard Page");
        }

        [Test]
        [Description("Validate that user fails to log into system with invalid credential")]
        [TestCaseSource(typeof(TestCaseData), "CredentialsJson", new object[] { "invalid" })]
        public void LoginWithInvalidCredential(User user)
        {
            var dashBoardPage = new LoginPage(Driver)
                .Open<LoginPage>()
                .LoginAs(user);
            Assert.That(dashBoardPage.IsLoaded(), Is.False, "Invalid User should receive the error message");
        }

        [Test]
        [TestCaseSource(typeof(TestCaseData), "CredentialsExcel", new object[] { "valid"})]
        [Description("Check Excel Data Reader")]
        public void Login(User user)
        {
            var dashBoardPage = new LoginPage(Driver)
                .Open<LoginPage>()
                .LoginAs(user);
            Assert.That(dashBoardPage.IsLoaded(), Is.True, "Valid User should been logged into system and navigated to Dashboard Page");
        }
    }
}