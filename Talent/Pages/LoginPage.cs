using OpenQA.Selenium;
using Talent.DataModel;
using Framework.Extensions;
using Framework.Helper;

namespace Talent.Pages
{
    public class LoginPage : BasePage
    {
        public override string Title { get; set; } = "Login";
        public LoginPage(IWebDriver driver) : base(driver) { }

        public void Login(User user)
        {
            ReportManager.LogTestStepInfo($"Log in as user Email: {user.Email} Password:{user.Password}");
            Driver.WaitForElement(By.Id("email")).SendKeys(user.Email);
            Driver.WaitForElement(By.Id("password")).SendKeys(user.Password);
            Driver.WaitForElement(By.Id("btn_login")).Click();
        }
    }
}