// <copyright file="IWebDriverInitialiser.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using OpenQA.Selenium;
using RedTarn.Selenium.Core.Bootstrap.Enums;

namespace RedTarn.Selenium.Core.Bootstrap.WebDriverInitialisers.Interfaces
{
    /// <summary>
    /// Interface to define the methods for the web driver initialisers.
    /// </summary>
    public interface IWebDriverInitialiser
    {
        /// <summary>
        /// Initialise the web driver.
        /// </summary>
        /// <param name="deviceType">The device type.</param>
        /// <returns>The web driver.</returns>
        IWebDriver Initialise(DeviceType deviceType);
    }
}
