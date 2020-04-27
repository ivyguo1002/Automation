using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Talent.API;
using Talent.DataModel;

namespace Talent.Tests
{
    [TestClass]
    public class ProfilePageTest : BaseTest
    {
        public IWebDriver Driver { get; set; }
        public ProfilePage ProfilePage { get; set; }

        [ClassInitialize]
        public void SetUpForTestClass()
        {
            ProfilePage = new ProfilePage(Driver);
        }

        [TestCleanup]
        public void TearDownForEveryMethod()
        {
            TalentAPI.ResetProfile();
        }

        [TestMethod]
        public void AddNewSkill()
        {
            IdentityAPI.SigninAs(Role.talent);
            ProfilePage.Open();
            var skill = new Skill();
            ProfilePage.Skills.AddNewSkill(skill);
            Assert.IsTrue(ProfilePage.Skills.IsAdded(skill));
        }

        [TestMethod]
        public void DeleteSkill()
        {
            IdentityAPI.SigninAs(Role.talent);
            var skill = new Skill();
            TalentAPI.PostSkill(skill);
            ProfilePage.Open();
            ProfilePage.Skills.DeleteSkill(skill);
            Assert.IsTrue(ProfilePage.Skills.IsDeleted(skill));
        }

        
    }
}
