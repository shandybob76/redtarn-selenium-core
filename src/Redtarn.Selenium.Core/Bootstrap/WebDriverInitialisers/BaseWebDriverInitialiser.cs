// <copyright file="BaseWebDriverInitialiser.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using OpenQA.Selenium;
using RedTarn.Selenium.Core.Bootstrap.Enums;
using RedTarn.Selenium.Core.Bootstrap.WebDriverInitialisers.Interfaces;

namespace RedTarn.Selenium.Core.Bootstrap.WebDriverInitialisers
{
    /// <summary>
    /// The base web driver initialiser.
    /// </summary>
    public abstract class BaseWebDriverInitialiser : IWebDriverInitialiser
    {
        /// <summary>
        /// Initialise the web driver.
        /// </summary>
        /// <param name="deviceType">The device type.</param>
        /// <returns>The web driver.</returns>
        public IWebDriver Initialise(DeviceType deviceType)
        {
            switch (deviceType)
            {
                case DeviceType.Phone:
                    return this.InitialisePhone();
                case DeviceType.Tablet:
                    return this.InitialiseTablet();
                default:
                    return this.InitialiseDesktop();
            }
        }

        /// <summary>
        /// Initialise the web driver as a desktop device.
        /// </summary>
        /// <returns>The web driver.</returns>
        protected abstract IWebDriver InitialiseDesktop();

        /// <summary>
        /// Initialise the web driver as a tablet device.
        /// </summary>
        /// <returns>The web driver.</returns>
        protected abstract IWebDriver InitialiseTablet();

        /// <summary>
        /// Initialise the web driver as a phone device.
        /// </summary>
        /// <returns>The web driver.</returns>
        protected abstract IWebDriver InitialisePhone();
    }
}
