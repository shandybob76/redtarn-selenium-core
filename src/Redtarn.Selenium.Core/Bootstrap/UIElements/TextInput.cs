// <copyright file="TextInput.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace RedTarn.Selenium.Core.Bootstrap.UIElements
{
    /// <summary>
    /// The input UI element.
    /// </summary>
    public class TextInput : Element
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextInput"/> class.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="webElement">The web element.</param>
        public TextInput(IWebDriver webDriver, IWebElement webElement)
            : base(webDriver, webElement)
        {
        }
    }
}
