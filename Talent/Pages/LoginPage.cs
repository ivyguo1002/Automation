using OpenQA.Selenium;
using Talent.DataModel;
using Framework.Extensions;
using Framework.Helper;

namespace Talent.Pages
{
    public class LoginPage : BasePage
    {
        public override string Title { get; set; } = "Login";
        private IWebElement EmailTextBox => Driver.Find(By.Id("email"));
        public LoginPage(IWebDriver driver) : base(driver) { }

        public DashboardPage LoginAs(User user)
        {
            ReportManager.LogTestStepInfo($"Log in as user Email: {user.Email} Password:{user.Password}");
           EmailTextBox.SendKeys(user.Email);
            Driver.Find(By.Id("password")).SendKeys(user.Password);
            Driver.Find(By.Id("btn_login")).Click();
            return new DashboardPage(Driver);
        }
    }
}