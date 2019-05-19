// <copyright file="CheckBox.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace RedTarn.Selenium.Core.Bootstrap.UIElements
{
    /// <summary>
    /// The checkbox UI element.
    /// </summary>
    public class Checkbox : Element
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Checkbox"/> class.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="webElement">The web element.</param>
        public Checkbox(IWebDriver webDriver, IWebElement webElement)
            : base(webDriver, webElement)
        {
        }

        /// <summary>
        /// Gets a value indicating whether the checkbox is checked.
        /// </summary>
        public bool Checked => this.GetAttribute("checked") != null;

        /// <summary>
        /// Check the checkbox.
        /// </summary>
        public void Check()
        {
            if (!this.Checked)
            {
                this.Click();
            }
        }

        /// <summary>
        /// Uncheck the checkbox.
        /// </summary>
        public void UnCheck()
        {
            if (this.Checked)
            {
                this.Click();
            }
        }
    }
}
