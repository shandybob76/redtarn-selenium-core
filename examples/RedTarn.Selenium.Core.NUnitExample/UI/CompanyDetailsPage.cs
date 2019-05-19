using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;

namespace RedTarn.Selenium.Core.MSTestExample.UI
{
    public class CompanyDetailsPage : BaseUiItem
    {
        public CompanyDetailsPage(IContext context) : base(context, By.Id("page-container"))
        {
        }
    }
}
