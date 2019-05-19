// <copyright file="UIContext.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RedTarn.Selenium.Core.Bootstrap.Configuration.Interfaces;
using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;
using RedTarn.Selenium.Core.Bootstrap.UIElements;
using RedTarn.Selenium.Core.Bootstrap.WebDriverInitialisers.Interfaces;
using TechTalk.SpecFlow;

namespace RedTarn.Selenium.Core.Bootstrap.Contexts
{
    /// <summary>
    /// UI context class.
    /// </summary>
    public class UIContext : IUIContext
    {
        /// <summary>
        /// The base URL for the site being tested.
        /// </summary>
        private readonly string baseUrl;

        /// <summary>
        /// The test configuration.
        /// </summary>
        private readonly ITestConfiguration testConfiguration;

        /// <summary>
        /// The default wait for interacting with elements in the site.
        /// </summary>
        private IWait<IWebDriver> defaultWait;

        /// <summary>
        /// The web driver.
        /// </summary>
        private IWebDriver webDriver;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIContext"/> class.
        /// </summary>
        /// <param name="webDriverInitialiser">The web driver initialiser.</param>
        /// <param name="testConfiguration">The test configuration.</param>
        public UIContext(IWebDriverInitialiser webDriverInitialiser, ITestConfiguration testConfiguration)
        {
            this.webDriver = webDriverInitialiser.Initialise(testConfiguration.DeviceType);

            this.defaultWait = new WebDriverWait(this.webDriver, TimeSpan.FromMilliseconds(testConfiguration.UiTimeout))
            {
                PollingInterval = TimeSpan.FromMilliseconds(testConfiguration.UiPollingInterval)
            };

            this.baseUrl = testConfiguration.BaseUrl;
            this.testConfiguration = testConfiguration;

            if (!this.baseUrl.EndsWith("/"))
            {
                this.baseUrl += "/";
            }
        }

        /// <summary>
        /// Go to a specified relative url.
        /// </summary>
        /// <param name="url">The relative URL.</param>
        public void GoToUrl(string url)
        {
            if (url.StartsWith("/"))
            {
                url = url.Substring(1);
            }

            this.webDriver.Navigate().GoToUrl(this.baseUrl + url);
        }

        /// <summary>
        /// Get an element base on the by clause.
        /// </summary>
        /// <param name="by">The by clause.</param>
        /// <returns>The element if it exists.</returns>
        public IWebElement GetElement(By by)
        {
            try
            {
                return this.defaultWait.Until(d => d.FindElement(by));
            }
            catch (Exception)
            {
                return default(IWebElement);
            }
        }

        /// <summary>
        /// Get an element base on the by clause.
        /// </summary>
        /// <typeparam name="T">The type of element to get.</typeparam>
        /// <param name="by">The by clause.</param>
        /// <param name="container">The container to search in.</param>
        /// <returns>The element if it exists.</returns>
        public T GetElement<T>(By by, IWebElement container)
            where T : Element
        {
            try
            {
                var element = container != null
                    ? this.defaultWait.Until(d => container.FindElement(by))
                    : this.defaultWait.Until(d => d.FindElement(by));

                return this.Element<T>(element);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// Get elements based on the by clause.
        /// </summary>
        /// <typeparam name="T">The type of element.</typeparam>
        /// <param name="by">The by clause.</param>
        /// <param name="container">The container.</param>
        /// <returns>A list of elements if they exist.</returns>
        public IEnumerable<T> GetElements<T>(By by, IWebElement container)
            where T : Element
        {
            try
            {
                var elements = container != null
                    ? this.defaultWait.Until(d => container.FindElements(by))
                    : this.defaultWait.Until(d => d.FindElements(by));

                return this.Elements<T>(elements);
            }
            catch (Exception)
            {
                return new T[0];
            }
        }

        /// <summary>
        /// Check whether an element does not exist based on the by clause.
        /// </summary>
        /// <param name="by">The by clause.</param>
        /// <param name="container">The container.</param>
        /// <returns>True if the element does not exist.</returns>
        public bool NotExists(By by, IWebElement container)
        {
            return this.defaultWait.Until(driver =>
            {
                try
                {
                    if (container != null)
                    {
                        container.FindElement(by);
                    }
                    else
                    {
                        driver.FindElement(by);
                    }

                    return false;
                }
                catch (Exception)
                {
                    return true;
                }
            });
        }

        /// <summary>
        /// Check whether the current URL is the one specified.
        /// </summary>
        /// <param name="url">The relative URL.</param>
        /// <returns>True if the current URL is the one specified.</returns>
        public bool IsUrl(string url)
        {
            try
            {
                return this.defaultWait.Until(d => this.webDriver.Url.Replace(this.baseUrl, string.Empty).Split('?')[0] == url);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Refresh the current window.
        /// </summary>
        public void Refresh()
        {
            this.webDriver.Navigate().Refresh();
        }

        /// <summary>
        /// Navigate back in the browser.
        /// </summary>
        public void Back()
        {
            this.webDriver.Navigate().Back();
        }

        /// <summary>
        /// Navigate forward in the browser.
        /// </summary>
        public void Forward()
        {
            this.webDriver.Navigate().Forward();
        }

        /// <summary>
        /// Take a screenshot of the current browser.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        public void TakeScreenshot(ScenarioContext scenarioContext)
        {
            if (string.IsNullOrEmpty(this.testConfiguration.ScreenshotFolder))
            {
                return;
            }

            var bytes = ((ITakesScreenshot)this.webDriver).GetScreenshot().AsByteArray;

            var path = $"{this.testConfiguration.ScreenshotFolder}\\{this.testConfiguration.DeviceType}\\{this.testConfiguration.BrowserType}\\{scenarioContext.ScenarioInfo.Title}\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path += $"\\{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.jpg";

            File.WriteAllBytes(path, bytes);

            scenarioContext.TestError.Data["Screenshot"] = path;
        }

        /// <summary>
        /// Dispose of the UI context.
        /// </summary>
        public void Dispose()
        {
            if (this.webDriver != null)
            {
                this.webDriver.Quit();
                this.webDriver = null;
                this.defaultWait = null;
            }
        }

        /// <summary>
        /// Map the element to the specified UI Element type.
        /// </summary>
        /// <typeparam name="T">The UI element type.</typeparam>
        /// <param name="webElement">The web element.</param>
        /// <returns>UI element of the specified type.</returns>
        private T Element<T>(IWebElement webElement)
            where T : Element
        {
            return (T)Activator.CreateInstance(typeof(T), this.webDriver, webElement);
        }

        /// <summary>
        /// Map the elements to the specified UI Element type.
        /// </summary>
        /// <typeparam name="T">The UI element type.</typeparam>
        /// <param name="webElements">The web elements.</param>
        /// <returns>Collection of UI elements of the specified type.</returns>
        private IEnumerable<T> Elements<T>(IEnumerable<IWebElement> webElements)
            where T : Element
        {
            return webElements.Select(this.Element<T>);
        }
    }
}
