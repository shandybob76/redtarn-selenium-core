// <copyright file="ChromeWebDriverInitialiser.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RedTarn.Selenium.Core.Bootstrap.WebDriverInitialisers
{
    /// <summary>
    /// The Google Chrome web driver initialiser.
    /// </summary>
    public class ChromeWebDriverInitialiser : BaseWebDriverInitialiser
    {
        /// <summary>
        /// Initialise the web driver as a desktop device.
        /// </summary>
        /// <returns>The web driver.</returns>
        protected override IWebDriver InitialiseDesktop()
        {
            var webDriver = new ChromeDriver(Environment.CurrentDirectory);

            webDriver.Manage().Window.Size = new Size(1280, 1024);

            return webDriver;
        }

        /// <summary>
        /// Initialise the web driver as a tablet device.
        /// </summary>
        /// <returns>The web driver.</returns>
        protected override IWebDriver InitialiseTablet()
        {
            var tabletChromeOptions = new ChromeOptions();
            tabletChromeOptions.EnableMobileEmulation("iPad");

            var webDriver = new ChromeDriver(Environment.CurrentDirectory, tabletChromeOptions);

            webDriver.Manage().Window.Size = new Size(768, 1024);

            return webDriver;
        }

        /// <summary>
        /// Initialise the web driver as a phone device.
        /// </summary>
        /// <returns>The web driver.</returns>
        protected override IWebDriver InitialisePhone()
        {
            var phoneChromeOptions = new ChromeOptions();
            phoneChromeOptions.EnableMobileEmulation("iPhone 6/7/8 Plus");

            var webDriver = new ChromeDriver(Environment.CurrentDirectory, phoneChromeOptions);

            webDriver.Manage().Window.Size = new Size(414, 736);

            return webDriver;
        }
    }
}
