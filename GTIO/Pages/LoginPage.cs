using OpenQA.Selenium;
using Framework.Extensions;
using Framework.Helper;
using GTIO.DataModel;

namespace GTIO.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }
        public override string Title { get; set; } = "Login";
        private IWebElement EmailTextBox => Driver.Find(By.Id("email"));
        private IWebElement PasswordTextBox => Driver.Find(By.Id("password"));
        private IWebElement LoginBtn => Driver.Find(By.Id("btn_login"));


        public DashboardPage LoginAs(User user)
        {
            ReportHelper.LogTestStepInfo($"Log in as user Email: {user.Email} Password:{user.Password}");
            EmailTextBox.SendKeys(user.Email);
            PasswordTextBox.SendKeys(user.Password);
            LoginBtn.Click();
            return new DashboardPage(Driver);
        }
    }
}