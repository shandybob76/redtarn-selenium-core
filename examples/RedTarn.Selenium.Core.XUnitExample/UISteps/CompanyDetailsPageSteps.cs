using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;
using RedTarn.Selenium.Core.XUnitExample.UI;
using TechTalk.SpecFlow;
using Xunit;

namespace RedTarn.Selenium.Core.XUnitExample.UISteps
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
            Assert.NotNull(_companyDetailsPage.GetContainer());
            Assert.True(this.Context.UserInterface.IsUrl("company/09009606"));
        }
    }
}
