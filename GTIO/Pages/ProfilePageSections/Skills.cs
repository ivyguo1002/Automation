﻿using GTIO.DataModel;
using GTIO.Pages;
using OpenQA.Selenium;
using System;

namespace GTIO.Pages.ProfilePageSections
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