using OpenQA.Selenium;

namespace Bdd.Pages
{
    public class JobsPage : BasePage
    {
        public JobsPage(IWebDriver driver) : base(driver) { }
        public override string Title => "Jobs";
        public override string Url => "/jobs/explore";




    }
}