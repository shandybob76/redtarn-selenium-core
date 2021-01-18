// <copyright file="IUserInterfaceContext.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using RedTarn.Selenium.Core.Bootstrap.UIElements;
using TechTalk.SpecFlow;

namespace RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces
{
    /// <summary>
    /// Interface to define the methods on the UI context.
    /// </summary>
    public interface IUserInterfaceContext : IDisposable
    {
        /// <summary>
        /// Go to a specified relative url.
        /// </summary>
        /// <param name="url">The relative URL.</param>
        void GoToUrl(string url);

        /// <summary>
        /// Get the raw element using the by selector.
        /// </summary>
        /// <param name="by">The by clause.</param>
        /// <returns>The web element.</returns>
        IWebElement GetElement(By by);

        /// <summary>
        /// Get an element base on the by clause.
        /// </summary>
        /// <typeparam name="T">The type of element to get.</typeparam>
        /// <param name="by">The by clause.</param>
        /// <param name="container">The container to search in.</param>
        /// <returns>The element if it exists.</returns>
        T GetElement<T>(By by, IWebElement container)
            where T : Element;

        /// <summary>
        /// Get elements based on the by clause.
        /// </summary>
        /// <typeparam name="T">The type of element.</typeparam>
        /// <param name="by">The by clause.</param>
        /// <param name="container">The container.</param>
        /// <returns>A list of elements if they exist.</returns>
        IEnumerable<T> GetElements<T>(By by, IWebElement container)
            where T : Element;

        /// <summary>
        /// Check whether an element does not exist based on the by clause.
        /// </summary>
        /// <param name="by">The by clause.</param>
        /// <param name="container">The container.</param>
        /// <returns>True if the element does not exist.</returns>
        bool NotExists(By by, IWebElement container);

        /// <summary>
        /// Check whether the current URL is the one specified.
        /// </summary>
        /// <param name="url">The relative URL.</param>
        /// <returns>True if the current URL is the one specified.</returns>
        bool IsUrl(string url);

        /// <summary>
        /// Refresh the current window.
        /// </summary>
        void Refresh();

        /// <summary>
        /// Navigate back in the browser.
        /// </summary>
        void Back();

        /// <summary>
        /// Navigate forward in the browser.
        /// </summary>
        void Forward();

        /// <summary>
        /// Take a screenshot of the current browser.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        void TakeScreenshot(ScenarioContext scenarioContext);
    }
}
