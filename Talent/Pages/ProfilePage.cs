using OpenQA.Selenium;
using Talent.Pages;
using Framework.Extensions;

namespace Talent.Tests
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