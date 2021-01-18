// <copyright file="CheckBoxInput.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace RedTarn.Selenium.Core.Bootstrap.UIElements
{
    /// <summary>
    /// The checkbox UI element.
    /// </summary>
    public class CheckBoxInput : Element
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBoxInput"/> class.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="webElement">The web element.</param>
        public CheckBoxInput(IWebDriver webDriver, IWebElement webElement)
            : base(webDriver, webElement)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the checkbox is checked.
        /// </summary>
        public bool Checked => GetAttribute("checked") != null;

        /// <summary>
        /// Check the checkbox.
        /// </summary>
        public void Check()
        {
            if (!Checked)
            {
                Click();
            }
        }

        /// <summary>
        /// Uncheck the checkbox.
        /// </summary>
        public void UnCheck()
        {
            if (Checked)
            {
                Click();
            }
        }
    }
}
