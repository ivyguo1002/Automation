﻿using OpenQA.Selenium;
using Framework.Extensions;
using Talent.Tests;

namespace Talent.Pages
{
    public class ProfilePage : BasePage
    {

        public override string Title { get; set; } = "Profile";
        public override string Url { get; set; } = "/profile";

        public Skills Skills { get; set; }

        public ProfilePage(IWebDriver driver) : base(driver)
        {
            Skills = new Skills(Driver);
        }

    }
}