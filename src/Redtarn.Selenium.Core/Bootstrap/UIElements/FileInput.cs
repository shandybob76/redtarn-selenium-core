// <copyright file="FileInput.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using OpenQA.Selenium;

namespace RedTarn.Selenium.Core.Bootstrap.UIElements
{
    /// <summary>
    /// The file input element.
    /// </summary>
    public class FileInput : Element
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileInput"/> class.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="webElement">The web element.</param>
        public FileInput(IWebDriver webDriver, IWebElement webElement)
            : base(webDriver, webElement)
        {
        }

        /// <summary>
        /// Set the file of the file input.
        /// </summary>
        /// <param name="filePath">The absolute file path.</param>
        public void SetFile(string filePath)
        {
            SendKeys(filePath);
        }
    }
}
