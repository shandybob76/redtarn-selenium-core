using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;
using RedTarn.Selenium.Core.MSTestExample.UI;
using TechTalk.SpecFlow;

namespace RedTarn.Selenium.Core.MSTestExample.UISteps
{
    [Binding]
    public class HomePageSteps : BaseSteps
    {
        private readonly HomePage homePage;

        
        public HomePageSteps(
            IContext context,
            HomePage homePage) : base(context)
        {
            this.homePage = homePage;
        }

        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            this.Context.UI.GoToUrl("");
        }

        [Given(@"I have entered '(.*)' into the seaerch box")]
        public void GivenIHaveEnteredIntoTheSeaerchBox(string searchText)
        {
            this.homePage.SearchInput.SendKeys(searchText);
        }

        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            this.homePage.SearchButton.Click();
        }
    }
}
