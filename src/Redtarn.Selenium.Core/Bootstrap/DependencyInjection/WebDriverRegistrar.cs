// <copyright file="WebDriverRegistrar.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using System;
using BoDi;
using RedTarn.Selenium.Core.Bootstrap.Configuration.Interfaces;
using RedTarn.Selenium.Core.Bootstrap.Enums;
using RedTarn.Selenium.Core.Bootstrap.WebDriverInitialisers;
using RedTarn.Selenium.Core.Bootstrap.WebDriverInitialisers.Interfaces;

namespace RedTarn.Selenium.Core.Bootstrap.DependencyInjection
{
    /// <summary>
    /// The web driver registrar.
    /// </summary>
    public static class WebDriverRegistrar
    {
        /// <summary>
        /// Register the web driver with the dependency injection container.
        /// </summary>
        /// <param name="objectContainer">The object container.</param>
        public static void RegisterWebDrivers(this IObjectContainer objectContainer)
        {
            objectContainer.RegisterFactoryAs(GetWebDriverInitialiser);
        }

        /// <summary>
        /// Get the web driver initialiser for the configured browser type.
        /// </summary>
        /// <param name="arg">The object container.</param>
        /// <returns>The web driver intialiser.</returns>
        private static IWebDriverInitialiser GetWebDriverInitialiser(IObjectContainer arg)
        {
            var testConfiguration = arg.Resolve<ITestConfiguration>();
            switch (testConfiguration.BrowserType)
            {
                case BrowserType.Chrome: return new ChromeWebDriverInitialiser();
                case BrowserType.Edge: return new EdgeWebDriverInitialiser();
                case BrowserType.InternetExplorer: return new InternetExporerWebDriverInitialiser();
                case BrowserType.Firefox: return new FirefoxWebDriverInitialiser();
                default: throw new Exception($"Browser type {testConfiguration.BrowserType} is not configured.");
            }
        }
    }
}
