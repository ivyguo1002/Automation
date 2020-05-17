using API.IdentityAPI;
using Framework.Extensions;
using Framework.WebDriver;
using GTIO.Pages;
using GTIO.Tests.Base;
using GTIO.Token;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GTIO.Tests
{
    [Category("Dashboard")]
    [TestFixture]
    public class DashboardPageTest : BaseTest
    {
        public DashboardPageTest(WebDriverType webDriverType, BrowserType browserType) : base(webDriverType, browserType)
        { }

        [SetUp]
        public void SetUpForTestClass()
        {
            Driver.SigninWith(TokenManager.TalentToken);
        }

        [Test]
        public void NavigateToProfilePage()
        {
            var profilePage = new DashboardPage(Driver)
                .Open<DashboardPage>()
                .GoToProfilePage();
            Assert.That(profilePage.IsLoaded(), Is.True);
        }

        [Test]
        public void NavigateToJobWatchListPage()
        {
            var jobsPage = new DashboardPage(Driver)
                .Open<DashboardPage>()
                .GoToJobsPage();
            Assert.That(jobsPage.IsLoaded(), Is.True);
        }


    }
}
