// <copyright file="BaseUiItem.cs" company="Red Tarn Technology Ltd">
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
        private readonly By _containerSelector;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseUIItem"/> class.
        /// </summary>
        /// <param name="context">The test context.</param>
        /// <param name="containerSelector">The container selector.</param>
        protected BaseUIItem(IContext context, By containerSelector)
        {
            Context = context;
            _containerSelector = containerSelector;
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
            return Context.UserInterface.GetElement<T>(By.ClassName(className), GetContainer());
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
            return Context.UserInterface.GetElements<T>(By.ClassName(className), GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given class name.
        /// </summary>
        /// <param name="className">The class name of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByClassName(string className)
        {
            return Context.UserInterface.NotExists(By.ClassName(className), GetContainer());
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
            return Context.UserInterface.GetElement<T>(By.CssSelector(cssSelector), GetContainer());
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
            return Context.UserInterface.GetElements<T>(By.CssSelector(cssSelector), GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given CSS selector.
        /// </summary>
        /// <param name="cssSelector">The CSS selector of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByCssSelector(string cssSelector)
        {
            return Context.UserInterface.NotExists(By.CssSelector(cssSelector), GetContainer());
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
            return Context.UserInterface.GetElement<T>(By.Id(id), GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given ID.
        /// </summary>
        /// <param name="id">The ID of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsById(string id)
        {
            return Context.UserInterface.NotExists(By.Id(id), GetContainer());
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
            return Context.UserInterface.GetElement<T>(By.LinkText(linkText), GetContainer());
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
            return Context.UserInterface.GetElements<T>(By.LinkText(linkText), GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given link text.
        /// </summary>
        /// <param name="linkText">The link text of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByLinkText(string linkText)
        {
            return Context.UserInterface.NotExists(By.LinkText(linkText), GetContainer());
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
            return Context.UserInterface.GetElement<T>(By.Name(name), GetContainer());
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
            return Context.UserInterface.GetElements<T>(By.Name(name), GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given name.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByName(string name)
        {
            return Context.UserInterface.NotExists(By.Name(name), GetContainer());
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
            return Context.UserInterface.GetElement<T>(By.PartialLinkText(partialLinkText), GetContainer());
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
            return Context.UserInterface.GetElements<T>(By.PartialLinkText(partialLinkText), GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given partial link text.
        /// </summary>
        /// <param name="partialLinkText">The partial link text of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByPartialLinkText(string partialLinkText)
        {
            return Context.UserInterface.NotExists(By.PartialLinkText(partialLinkText), GetContainer());
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
            return Context.UserInterface.GetElement<T>(By.TagName(tagName), GetContainer());
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
            return Context.UserInterface.GetElements<T>(By.TagName(tagName), GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given tag name.
        /// </summary>
        /// <param name="tagName">The tag name of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByTagName(string tagName)
        {
            return Context.UserInterface.NotExists(By.TagName(tagName), GetContainer());
        }

        /// <summary>
        /// Get a single element for the given XPath.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="path">The XPath of the element.</param>
        /// <returns>The UI element if it exists.</returns>
        public T GetElementByXPath<T>(string path)
            where T : Element
        {
            return Context.UserInterface.GetElement<T>(By.XPath(path), GetContainer());
        }

        /// <summary>
        /// Get a list of elements for the given class XPath.
        /// </summary>
        /// <typeparam name="T">The type of UI element to return.</typeparam>
        /// <param name="path">The XPath of the elements.</param>
        /// <returns>The UI elements if they exists.</returns>
        public IEnumerable<T> GetElementsByXPath<T>(string path)
            where T : Element
        {
            return Context.UserInterface.GetElements<T>(By.XPath(path), GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given XPath.
        /// </summary>
        /// <param name="path">The XPath of the element.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByXPath(string path)
        {
            return Context.UserInterface.NotExists(By.XPath(path), GetContainer());
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
            return Context.UserInterface.GetElement<T>(GetAttributeXPath(name, value), GetContainer());
        }

        /// <summary>
        /// Check the element does not exist for the given attribute.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExistsByAttribute(string name, string value)
        {
            return Context.UserInterface.NotExists(GetAttributeXPath(name, value), GetContainer());
        }

        /// <summary>
        /// Get the container.
        /// </summary>
        /// <returns>The container.</returns>
        public IWebElement GetContainer()
        {
            return Context.UserInterface.GetElement(_containerSelector);
        }

        /// <summary>
        /// Get the attribute XPath for the given name and value.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        /// <returns>The attribute XPath to use.</returns>
        private static By GetAttributeXPath(string name, string value)
        {
            return By.XPath($"//*[@{name}='{value}']");
        }
    }
}
