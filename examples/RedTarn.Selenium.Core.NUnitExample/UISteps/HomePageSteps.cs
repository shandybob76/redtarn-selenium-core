using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;
using RedTarn.Selenium.Core.NUnitExample.UI;
using TechTalk.SpecFlow;

namespace RedTarn.Selenium.Core.NUnitExample.UISteps
{
    [Binding]
    public class HomePageSteps : BaseSteps
    {
        private readonly HomePage _homePage;
        
        public HomePageSteps(
            IContext context,
            HomePage homePage) : base(context)
        {
            _homePage = homePage;
        }

        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            this.Context.UserInterface.GoToUrl("");
        }

        [Given(@"I have entered '(.*)' into the search box")]
        public void GivenIHaveEnteredIntoTheSeaerchBox(string searchText)
        {
            _homePage.SearchInput.SendKeys(searchText);
        }

        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            _homePage.SearchButton.Click();
        }
    }
}
