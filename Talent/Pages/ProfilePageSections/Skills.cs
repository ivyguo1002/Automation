using OpenQA.Selenium;
using System;
using Talent.DataModel;
using Talent.Pages;

namespace Talent.Tests
{
    public class Skills : BasePage
    {
        public Skills(IWebDriver driver) : base(driver) { }

        internal void AddNewSkill(Skill skill)
        {
            throw new NotImplementedException();
        }

        internal bool IsAdded(Skill skill)
        {
            throw new NotImplementedException();
        }

        internal void DeleteSkill(Skill skill)
        {
            throw new NotImplementedException();
        }

        internal bool IsDeleted(Skill skill)
        {
            throw new NotImplementedException();
        }
    }
}