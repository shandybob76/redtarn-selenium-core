// <copyright file="UserInterfaceContext.cs" company="Red Tarn Technology Ltd">
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
    public class UserInterfaceContext : IUserInterfaceContext
    {
        /// <summary>
        /// The base URL for the site being tested.
        /// </summary>
        private readonly string _baseUrl;

        /// <summary>
        /// The test configuration.
        /// </summary>
        private readonly ITestConfiguration _testConfiguration;

        /// <summary>
        /// The default wait for interacting with elements in the site.
        /// </summary>
        private IWait<IWebDriver> _defaultWait;

        /// <summary>
        /// The web driver.
        /// </summary>
        private IWebDriver _webDriver;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserInterfaceContext"/> class.
        /// </summary>
        /// <param name="webDriverInitialiser">The web driver initialiser.</param>
        /// <param name="testConfiguration">The test configuration.</param>
        public UserInterfaceContext(IWebDriverInitialiser webDriverInitialiser, ITestConfiguration testConfiguration)
        {
            _webDriver = webDriverInitialiser.Initialise(testConfiguration.DeviceType);

            _defaultWait = new WebDriverWait(_webDriver, TimeSpan.FromMilliseconds(testConfiguration.UiTimeout))
            {
                PollingInterval = TimeSpan.FromMilliseconds(testConfiguration.UiPollingInterval)
            };

            _baseUrl = testConfiguration.BaseUrl;
            _testConfiguration = testConfiguration;

            if (!_baseUrl.EndsWith("/"))
            {
                _baseUrl += "/";
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="UserInterfaceContext"/> class.
        /// </summary>
        ~UserInterfaceContext()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        /// <summary>
        /// Go to a specified relative url.
        /// </summary>
        /// <param name="url">The relative URL.</param>
        public void GoToUrl(string url)
        {
            if (url.StartsWith("/"))
            {
                url = url[1..];
            }

            _webDriver.Navigate().GoToUrl(_baseUrl + url);
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
                return _defaultWait.Until(d => d.FindElement(by));
            }
            catch (Exception)
            {
                return default;
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
                    ? _defaultWait.Until(d => container.FindElement(by))
                    : _defaultWait.Until(d => d.FindElement(by));

                return Element<T>(element);
            }
            catch (Exception)
            {
                return default;
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
                    ? _defaultWait.Until(d => container.FindElements(by))
                    : _defaultWait.Until(d => d.FindElements(by));

                return Elements<T>(elements);
            }
            catch (Exception)
            {
                return Array.Empty<T>();
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
            return _defaultWait.Until(driver =>
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
                return _defaultWait.Until(d => _webDriver.Url.Replace(_baseUrl, string.Empty).Split('?')[0] == url);
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
            _webDriver.Navigate().Refresh();
        }

        /// <summary>
        /// Navigate back in the browser.
        /// </summary>
        public void Back()
        {
            _webDriver.Navigate().Back();
        }

        /// <summary>
        /// Navigate forward in the browser.
        /// </summary>
        public void Forward()
        {
            _webDriver.Navigate().Forward();
        }

        /// <summary>
        /// Take a screenshot of the current browser.
        /// </summary>
        /// <param name="scenarioContext">The scenario context.</param>
        public void TakeScreenshot(ScenarioContext scenarioContext)
        {
            if (string.IsNullOrEmpty(_testConfiguration.ScreenshotFolder))
            {
                return;
            }

            var bytes = ((ITakesScreenshot)_webDriver).GetScreenshot().AsByteArray;

            var path = $"{_testConfiguration.ScreenshotFolder}\\{_testConfiguration.DeviceType}\\{_testConfiguration.BrowserType}\\{scenarioContext.ScenarioInfo.Title}\\";
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of the UI context.
        /// </summary>
        /// <param name="disposing">Whether currently disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_webDriver == null)
            {
                return;
            }

            if (disposing)
            {
                _webDriver.Quit();
                _webDriver.Dispose();
                _webDriver = null;
                _defaultWait = null;
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
            return (T)Activator.CreateInstance(typeof(T), _webDriver, webElement);
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
            return webElements.Select(Element<T>);
        }
    }
}
