using OpenQA.Selenium;
using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;
using RedTarn.Selenium.Core.Bootstrap.UIElements;
using TechTalk.SpecFlow;

namespace RedTarn.Selenium.Core.XUnitExample.UI
{
    [Binding]
    public class HomePage : BaseUIItem
    {
        public HomePage(IContext context) : base(context, By.Id("page-container"))
        {
        }

        public TextInput SearchInput => GetElementById<TextInput>("site-search-text");

        public Button SearchButton => GetElementById<Button>("search-submit");
    }
}
