// <copyright file="TinyMceTextEditor.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace RedTarn.Selenium.Core.Bootstrap.UIElements
{
    /// <summary>
    /// The Tiny MCE Text Editor UI Element.
    /// </summary>
    public class TinyMceTextEditor : Element
    {
        /// <summary>
        /// Tiny MCS component ID.
        /// </summary>
        private const string TinyMceComponentId = "tinymce";

        /// <summary>
        /// Initializes a new instance of the <see cref="TinyMceTextEditor"/> class.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="webElement">The web element.</param>
        public TinyMceTextEditor(IWebDriver webDriver, IWebElement webElement)
            : base(webDriver, webElement)
        {
        }

        /// <summary>
        /// Send keys to the element.
        /// </summary>
        /// <param name="text">The text to send.</param>
        public override void SendKeys(string text)
        {
            WebDriver.SwitchTo().Frame(WebElement);
            var tinyMceEditor = WebDriver.FindElement(By.Id(TinyMceComponentId));
            tinyMceEditor.Clear();
            tinyMceEditor.Click();
            tinyMceEditor.SendKeys(text);

            WebDriver.SwitchTo().ParentFrame();
        }
    }
}
