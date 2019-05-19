// <copyright file="Element.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace RedTarn.Selenium.Core.Bootstrap.UIElements
{
    /// <summary>
    /// Abstract base UI element.
    /// </summary>
    public class Element : IWebElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Element"/> class.
        /// </summary>
        /// <param name="webDriver">The web driver.</param>
        /// <param name="webElement">The web element.</param>
        public Element(IWebDriver webDriver, IWebElement webElement)
        {
            this.WebDriver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
            this.WebElement = webElement ?? throw new ArgumentNullException(nameof(webElement));
        }

        /// <summary>
        /// Gets the tag name.
        /// </summary>
        public virtual string TagName => this.WebElement.TagName;

        /// <summary>
        /// Gets the text.
        /// </summary>
        public virtual string Text => this.WebElement.Text;

        /// <summary>
        /// Gets a value indicating whether the UI element is enabled or not.
        /// </summary>
        public virtual bool Enabled => this.WebElement.Enabled;

        /// <summary>
        /// Gets a value indicating whether the UI element is selected or not.
        /// </summary>
        public virtual bool Selected => this.WebElement.Selected;

        /// <summary>
        /// Gets the location of the UI element.
        /// </summary>
        public virtual Point Location => this.WebElement.Location;

        /// <summary>
        /// Gets the size of the UI element.
        /// </summary>
        public virtual Size Size => this.WebElement.Size;

        /// <summary>
        /// Gets a value indicating whether the UI element is displayed or not.
        /// </summary>
        public virtual bool Displayed => this.WebElement.Displayed;

        /// <summary>
        /// Gets the web driver.
        /// </summary>
        protected IWebDriver WebDriver { get; }

        /// <summary>
        /// Gets the web element.
        /// </summary>
        protected IWebElement WebElement { get; }

        /// <summary>
        /// Clear the UI element.
        /// </summary>
        public virtual void Clear() => this.WebElement.Clear();

        /// <summary>
        /// Click the UI element.
        /// </summary>
        public virtual void Click()
        {
            var actions = new Actions(this.WebDriver);
            actions.MoveToElement(this.WebElement);
            actions.Perform();
            this.WebElement.Click();
        }

        /// <summary>
        /// Find a child element using the by clause.
        /// </summary>
        /// <param name="by">The by clause.</param>
        /// <returns>The web element if it exists.</returns>
        public virtual IWebElement FindElement(By by) => this.WebElement.FindElement(by);

        /// <summary>
        /// Find child elements using the by clause.
        /// </summary>
        /// <param name="by">The by clause.</param>
        /// <returns>A collection of elements if they exist.</returns>
        public virtual ReadOnlyCollection<IWebElement> FindElements(By by) => this.WebElement.FindElements(by);

        /// <summary>
        /// Get the attribute value.
        /// </summary>
        /// <param name="attributeName">The attribute name.</param>
        /// <returns>The attribute value.</returns>
        public virtual string GetAttribute(string attributeName) => this.WebElement.GetAttribute(attributeName);

        /// <summary>
        /// Get the css value.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The css value.</returns>
        public virtual string GetCssValue(string propertyName) => this.WebElement.GetCssValue(propertyName);

        /// <summary>
        /// Get the property.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The property value.</returns>
        public virtual string GetProperty(string propertyName) => this.WebElement.GetProperty(propertyName);

        /// <summary>
        /// Send keys to the element.
        /// </summary>
        /// <param name="text">The text to send.</param>
        public virtual void SendKeys(string text) => this.WebElement.SendKeys(text);

        /// <summary>
        /// Submit the element.
        /// </summary>
        public virtual void Submit() => this.WebElement.Submit();

        /// <summary>
        /// Gets whether the UI element has the specified class or not.
        /// </summary>
        /// <param name="className">The class name.</param>
        /// <returns>True if the element has the class.</returns>
        public virtual bool HasClass(string className) => this.GetAttribute("class").Contains(className);
    }
}
