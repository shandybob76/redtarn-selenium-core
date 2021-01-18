using NUnit.Framework;
using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;
using RedTarn.Selenium.Core.NUnitExample.UI;
using TechTalk.SpecFlow;

namespace RedTarn.Selenium.Core.NUnitExample.UISteps
{
    [Binding]
    public class CompanyDetailsPageSteps : BaseSteps
    {
        private readonly CompanyDetailsPage _companyDetailsPage;

        public CompanyDetailsPageSteps(
            IContext context,
            CompanyDetailsPage companyDetailsPage) : base(context)
        {
            _companyDetailsPage = companyDetailsPage;
        }

        [Then(@"I am taken to the correct company details")]
        public void ThenIAmTakenToTheCorrectCompanyDetails()
        {
            Assert.IsNotNull(_companyDetailsPage.GetContainer());
            Assert.IsTrue(this.Context.UserInterface.IsUrl("company/09009606"));
        }
    }
}
