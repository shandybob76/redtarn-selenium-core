using OpenQA.Selenium;

namespace RedTarn.Selenium.Core.Bootstrap.UIElements
{
    /// <summary>
    /// The button UI element.
    /// </summary>
    public class Button : Element
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="webElement">The web element.</param>
        public Button(IWebDriver webDriver, IWebElement webElement)
            : base(webDriver, webElement)
        {
        }
    }
}
