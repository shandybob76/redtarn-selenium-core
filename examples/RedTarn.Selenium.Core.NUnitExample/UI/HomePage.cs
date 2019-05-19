using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;
using RedTarn.Selenium.Core.Bootstrap.UIElements;
using TechTalk.SpecFlow;

namespace RedTarn.Selenium.Core.MSTestExample.UI
{
    [Binding]
    public class HomePage : BaseUiItem
    {
        public HomePage(IContext context) : base(context, By.Id("page-container"))
        {
        }

        public Input SearchInput => GetElementById<Input>("site-search-text");

        public Button SearchButton => GetElementById<Button>("search-submit");
    }
}
