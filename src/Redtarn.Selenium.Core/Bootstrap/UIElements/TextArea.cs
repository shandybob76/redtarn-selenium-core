// <copyright file="TextArea.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace RedTarn.Selenium.Core.Bootstrap.UIElements
{
    /// <summary>
    /// The text area element.
    /// </summary>
    public class TextArea : Element
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextArea"/> class.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="webElement">The web element.</param>
        public TextArea(IWebDriver webDriver, IWebElement webElement)
            : base(webDriver, webElement)
        {
        }
    }
}
