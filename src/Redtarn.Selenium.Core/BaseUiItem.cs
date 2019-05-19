// <copyright file="BaseUIItem.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using System.Collections.Generic;
using OpenQA.Selenium;
using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;
using RedTarn.Selenium.Core.Bootstrap.UIElements;

namespace RedTarn.Selenium.Core
{
    /// <summary>
    /// Base UI Item - abstract class to supply helper methods for surfacing
    /// UI elements.
    /// </summary>
    public abstract class BaseUIItem
    {
        /// <summary>
        /// The container selector.
        /// </summary>
        private readonly By containerSelector;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseUIItem"/> class.
        /// </summary>
        /// <param name="context">The test context.</param>
        /// <param name="containerSelector">The container selector.</param>
        protected BaseUIItem(IContext context, By containerSelector)
        {
            this.Context = context;
            this.containerSelector = containerSelector;
        }

        /// <summary>
        /// Gets the test context.
        /// </summary>
        protected IContext Context { get; }

        /// <summary>
        /// Get a single element for the given class name.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="className">The class name of the element.</param>
        /// <returns>The UI element if it exists.</returns>
        public T GetElementByClassName<T>(string className)
            where T : Element
        {
            return this.Context.UI.GetElement<T>(By.ClassName(className), this.GetContainer());
        }

        /// <summary>
        /// Get a list of elements for the given class name.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="className">The class name of the elements.</param>
        /// <returns>The UI elements if they exists.</returns>
        public IEnumerable<T> GetElementsByClassName<T>(string className)
            where T : Element
        {
            return this.Context.UI.GetElements<T>(By.ClassName(className), this.GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given class name.
        /// </summary>
        /// <param name="className">The class name of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByClassName(string className)
        {
            return this.Context.UI.NotExists(By.ClassName(className), this.GetContainer());
        }

        /// <summary>
        /// Get a single element for the given CSS selector.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="cssSelector">The CSS selector of the element.</param>
        /// <returns>The UI element if it exists.</returns>
        public T GetElementByCssSelector<T>(string cssSelector)
            where T : Element
        {
            return this.Context.UI.GetElement<T>(By.CssSelector(cssSelector), this.GetContainer());
        }

        /// <summary>
        /// Get a list of elements for the given CSS selector.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="cssSelector">The CSS selector of the elements.</param>
        /// <returns>The UI elements if they exists.</returns>
        public IEnumerable<T> GetElementsByCssSelector<T>(string cssSelector)
            where T : Element
        {
            return this.Context.UI.GetElements<T>(By.CssSelector(cssSelector), this.GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given CSS selector.
        /// </summary>
        /// <param name="cssSelector">The CSS selector of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByCssSelector(string cssSelector)
        {
            return this.Context.UI.NotExists(By.CssSelector(cssSelector), this.GetContainer());
        }

        /// <summary>
        /// Get a single element for the given ID.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="id">The ID of the element.</param>
        /// <returns>The UI element if it exists.</returns>
        public T GetElementById<T>(string id)
            where T : Element
        {
            return this.Context.UI.GetElement<T>(By.Id(id), this.GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given ID.
        /// </summary>
        /// <param name="id">The ID of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsById(string id)
        {
            return this.Context.UI.NotExists(By.Id(id), this.GetContainer());
        }

        /// <summary>
        /// Get a single element for the given link text.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="linkText">The link text of the element.</param>
        /// <returns>The UI element if it exists.</returns>
        public T GetElementByLinkText<T>(string linkText)
            where T : Element
        {
            return this.Context.UI.GetElement<T>(By.LinkText(linkText), this.GetContainer());
        }

        /// <summary>
        /// Get a list of elements for the given link text.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="linkText">The link text of the elements.</param>
        /// <returns>The UI elements if they exists.</returns>
        public IEnumerable<T> GetElementsByLinkText<T>(string linkText)
            where T : Element
        {
            return this.Context.UI.GetElements<T>(By.LinkText(linkText), this.GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given link text.
        /// </summary>
        /// <param name="linkText">The link text of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByLinkText(string linkText)
        {
            return this.Context.UI.NotExists(By.LinkText(linkText), this.GetContainer());
        }

        /// <summary>
        /// Get a single element for the given name.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="name">The name of the element.</param>
        /// <returns>The UI element if it exists.</returns>
        public T GetElementByName<T>(string name)
            where T : Element
        {
            return this.Context.UI.GetElement<T>(By.Name(name), this.GetContainer());
        }

        /// <summary>
        /// Get a list of elements for the given name.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="name">The name of the elements.</param>
        /// <returns>The UI elements if they exists.</returns>
        public IEnumerable<T> GetElementsByName<T>(string name)
            where T : Element
        {
            return this.Context.UI.GetElements<T>(By.Name(name), this.GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given name.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByName(string name)
        {
            return this.Context.UI.NotExists(By.Name(name), this.GetContainer());
        }

        /// <summary>
        /// Get a single element for the given partial link text.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="partialLinkText">The partial link text of the element.</param>
        /// <returns>The UI element if it exists.</returns>
        public T GetElementByPartialLinkText<T>(string partialLinkText)
            where T : Element
        {
            return this.Context.UI.GetElement<T>(By.PartialLinkText(partialLinkText), this.GetContainer());
        }

        /// <summary>
        /// Get a list of elements for the given partial link text.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="partialLinkText">The partial link text of the elements.</param>
        /// <returns>The UI elements if they exists.</returns>
        public IEnumerable<T> GetElementsByPartialLinkText<T>(string partialLinkText)
            where T : Element
        {
            return this.Context.UI.GetElements<T>(By.PartialLinkText(partialLinkText), this.GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given partial link text.
        /// </summary>
        /// <param name="partialLinkText">The partial link text of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByPartialLinkText(string partialLinkText)
        {
            return this.Context.UI.NotExists(By.PartialLinkText(partialLinkText), this.GetContainer());
        }

        /// <summary>
        /// Get a single element for the given tag name.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="tagName">The tag name of the element.</param>
        /// <returns>The UI element if it exists.</returns>
        public T GetElementByTagName<T>(string tagName)
            where T : Element
        {
            return this.Context.UI.GetElement<T>(By.TagName(tagName), this.GetContainer());
        }

        /// <summary>
        /// Get a list of elements for the given tag name.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="tagName">The tag name of the elements.</param>
        /// <returns>The UI elements if they exists.</returns>
        public IEnumerable<T> GetElementsByTagName<T>(string tagName)
            where T : Element
        {
            return this.Context.UI.GetElements<T>(By.TagName(tagName), this.GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given tag name.
        /// </summary>
        /// <param name="tagName">The tag name of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByTagName(string tagName)
        {
            return this.Context.UI.NotExists(By.TagName(tagName), this.GetContainer());
        }

        /// <summary>
        /// Get a single element for the given XPath.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="xPath">The XPath of the element.</param>
        /// <returns>The UI element if it exists.</returns>
        public T GetElementByXPath<T>(string xPath)
            where T : Element
        {
            return this.Context.UI.GetElement<T>(By.XPath(xPath), this.GetContainer());
        }

        /// <summary>
        /// Get a list of elements for the given class XPath.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="xPath">The XPath of the elements.</param>
        /// <returns>The UI elements if they exists.</returns>
        public IEnumerable<T> GetElementsByXPath<T>(string xPath)
            where T : Element
        {
            return this.Context.UI.GetElements<T>(By.XPath(xPath), this.GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given XPath.
        /// </summary>
        /// <param name="xPath">The XPath of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByXPath(string xPath)
        {
            return this.Context.UI.NotExists(By.XPath(xPath), this.GetContainer());
        }

        /// <summary>
        /// Get a single element for the given attribute.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        /// <returns>The UI element if it exists.</returns>
        public T GetElementByAttribute<T>(string name, string value)
            where T : Element
        {
            return this.Context.UI.GetElement<T>(this.GetAttributeXPath(name, value), this.GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given attribute.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByAttribute(string name, string value)
        {
            return this.Context.UI.NotExists(this.GetAttributeXPath(name, value), this.GetContainer());
        }

        /// <summary>
        /// Get the attribute XPath for the given name and value.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        /// <returns>The attribute XPath to use.</returns>
        private By GetAttributeXPath(string name, string value)
        {
            return By.XPath($"//*[@{name}='{value}']");
        }

        /// <summary>
        /// Get the container.
        /// </summary>
        /// <returns>The container.</returns>
        private IWebElement GetContainer()
        {
            return this.Context.UI.GetElement(this.containerSelector);
        }
    }
}
