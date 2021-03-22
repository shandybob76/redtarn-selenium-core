using System.Collections.Generic;
using OpenQA.Selenium;
using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;
using RedTarn.Selenium.Core.Bootstrap.UIElements;

namespace RedTarn.Selenium.Core.XUnitExample.UI
{
    public class SearchResultsPage : BaseUIItem
    {
        public SearchResultsPage(IContext context) : base(context, By.Id("page-container"))
        {
        }

        public IEnumerable<Element> SearchResults => GetElementsByXPath<Element>("//ul[@id='results']/li/h3/a");
    }
}
