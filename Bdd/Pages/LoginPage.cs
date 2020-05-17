using OpenQA.Selenium;
using Framework.Extensions;
using Framework.Helper;
using Bdd.DataModel;

namespace Bdd.Pages
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
            EmailTextBox.SendKeys(user.Email);
            PasswordTextBox.SendKeys(user.Password);
            LoginBtn.Click();
            return new DashboardPage(Driver);
        }
    }
}