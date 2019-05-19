using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;
using RedTarn.Selenium.Core.MSTestExample.UI;
using TechTalk.SpecFlow;

namespace RedTarn.Selenium.Core.MSTestExample.UISteps
{
    [Binding]
    public class CompanyDetailsPageSteps : BaseSteps
    {
        private readonly CompanyDetailsPage companyDetailsPage;

        public CompanyDetailsPageSteps(
            IContext context,
            CompanyDetailsPage companyDetailsPage) : base(context)
        {
            this.companyDetailsPage = companyDetailsPage;
        }

        [Then(@"I am taken to the correct company details")]
        public void ThenIAmTakenToTheCorrectCompanyDetails()
        {
            Assert.IsTrue(this.Context.UI.IsUrl("company/09009606"));
        }
    }
}
