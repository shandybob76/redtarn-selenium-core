using System.Linq;
using NUnit.Framework;
using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;
using RedTarn.Selenium.Core.NUnitExample.UI;
using TechTalk.SpecFlow;

namespace RedTarn.Selenium.Core.NUnitExample.UISteps
{
    [Binding]
    public class SearchResultsPageSteps : BaseSteps
    {
        private readonly SearchResultsPage searchResultsPage;

        public SearchResultsPageSteps(
            IContext context,
            SearchResultsPage searchResultsPage) : base(context)
        {
            this.searchResultsPage = searchResultsPage;
        }

        [When(@"I am taken to the search results page")]
        public void WhenIAmTakenToTheSearchResultsPage()
        {
            Assert.IsTrue(this.Context.UI.IsUrl("search"));
        }

        [When(@"I select the first item in the results list")]
        public void WhenISelectTheFirstItemInTheResultsList()
        {
            this.searchResultsPage.SearchResults.First().Click();
        }
    }
}
