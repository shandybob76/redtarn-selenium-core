using System.Linq;
using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;
using RedTarn.Selenium.Core.XUnitExample.UI;
using TechTalk.SpecFlow;
using Xunit;

namespace RedTarn.Selenium.Core.XUnitExample.UISteps
{
    [Binding]
    public class SearchResultsPageSteps : BaseSteps
    {
        private readonly SearchResultsPage _searchResultsPage;

        public SearchResultsPageSteps(
            IContext context,
            SearchResultsPage searchResultsPage) : base(context)
        {
            _searchResultsPage = searchResultsPage;
        }

        [When(@"I am taken to the search results page")]
        public void WhenIAmTakenToTheSearchResultsPage()
        {
            Assert.True(this.Context.UserInterface.IsUrl("search"));
        }

        [When(@"I select the first item in the results list")]
        public void WhenISelectTheFirstItemInTheResultsList()
        {
            _searchResultsPage.SearchResults.First().Click();
        }
    }
}
