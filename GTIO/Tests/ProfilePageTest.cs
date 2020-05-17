using API.IdentityAPI;
using API.TalentAPI;
using Framework.WebDriver;
using GTIO.DataModel;
using GTIO.Pages;
using GTIO.Tests.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTIO.Tests
{
    [TestFixture]
    public class ProfilePageTest : BaseTest
    {
        public ProfilePage ProfilePage { get; set; }
        public ProfilePageTest(WebDriverType webDriverType, BrowserType browserType) : base(webDriverType, browserType)
        { }

        [Test]
        public void SetUpForTestClass()
        {
            ProfilePage = new ProfilePage(Driver);
        }

        [TearDown]
        public void TearDownForEveryMethod()
        {
            TalentAPI.ResetProfile();
        }

        [Test]
        public void AddNewSkill()
        {
            //IdentityAPI.SigninAs(Role.talent);
            ProfilePage.Open();
            var skill = new Skill();
            ProfilePage.Skills.AddNewSkill(skill);
            Assert.IsTrue(ProfilePage.Skills.IsAdded(skill));
        }

        [Test]
        public void DeleteSkill()
        {
            //IdentityAPI.SigninAs(Role.talent);
            //var skill = new Skill();
            //TalentAPI.PostSkill(skill);
            //ProfilePage.Open();
            //ProfilePage.Skills.DeleteSkill(skill);
            //Assert.IsTrue(ProfilePage.Skills.IsDeleted(skill));
        }


    }
}
