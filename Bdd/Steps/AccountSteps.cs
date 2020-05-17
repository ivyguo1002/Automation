using Bdd.DataModel;
using Bdd.Pages;
using Framework.Helper.DataDriven;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Bdd.Steps
{
    [Binding]
    public class AccountSteps
    {
        private IWebDriver _driver;
        private LoginPage _loginPage => new LoginPage(_driver);
        private DashboardPage _dashboardPage => new DashboardPage(_driver);
        private List<User> TestUser => JsonDataHelper.ToObject<List<User>>("TestData\\users.json");
        public AccountSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"a talent user has set an account")]
        public void GivenATalentUserHasSetAnAccount()
        {
            
        }
        
        [When(@"the user log in with the valid credential")]
        public void WhenTheUserLogInWithTheValidCredential()
        {
            var user = TestUser.Where(user => user.Key == "valid").SingleOrDefault();
            _loginPage.Open<LoginPage>().LoginAs(user);
        }
        
        [When(@"the user log in with invalid credential")]
        public void WhenTheUserLogInWithInvalidCredential()
        {
            var user = TestUser.Where(user => user.Key == "invalid").SingleOrDefault();
            _loginPage.Open<LoginPage>().LoginAs(user);
        }
        
        [Then(@"dashboard page should be shown")]
        public void ThenDashboardPageShouldBeShown()
        {
            Assert.That(_dashboardPage.IsLoaded(), Is.True, "Valid User should been logged into system and navigated to Dashboard Page");
        }
        
        [Then(@"dashboard page should not be shown")]
        public void ThenDashboardPageShouldNotBeShown()
        {
            Assert.That(_dashboardPage.IsLoaded(), Is.False, "Invalid User should receive the error message");
        }
    }
}
