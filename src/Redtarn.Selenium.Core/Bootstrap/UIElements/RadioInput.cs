// <copyright file="RadioInput.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace RedTarn.Selenium.Core.Bootstrap.UIElements
{
    /// <summary>
    /// The radio UI element.
    /// </summary>
    public class RadioInput : Element
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadioInput"/> class.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="webElement">The web element.</param>
        public RadioInput(IWebDriver webDriver, IWebElement webElement)
            : base(webDriver, webElement)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the radio is selected.
        /// </summary>
        public bool Checked => GetAttribute("checked") != null;

        /// <summary>
        /// Select the radio.
        /// </summary>
        public void Check()
        {
            if (!Checked)
            {
                Click();
            }
        }
    }
}
