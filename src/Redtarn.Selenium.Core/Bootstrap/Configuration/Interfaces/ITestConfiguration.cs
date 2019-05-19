// <copyright file="ITestConfiguration.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using RedTarn.Selenium.Core.Bootstrap.Enums;

namespace RedTarn.Selenium.Core.Bootstrap.Configuration.Interfaces
{
    /// <summary>
    /// Interface to define the test configuration properties.
    /// </summary>
    public interface ITestConfiguration
    {
        /// <summary>
        /// Gets the base URL for the site being tested.
        /// </summary>
        string BaseUrl { get; }

        /// <summary>
        /// Gets the browser type to instantiate for the tests.
        /// </summary>
        BrowserType BrowserType { get; }

        /// <summary>
        /// Gets the device type for the tests.
        /// </summary>
        DeviceType DeviceType { get; }

        /// <summary>
        /// Gets the UI timeout to use when waiting for elements to become
        /// available in the page in milliseconds.
        /// </summary>
        int UiTimeout { get; }

        /// <summary>
        /// Gets the polling inteval to use while waiting for element to become
        /// available in the page in milliseconds.
        /// </summary>
        int UiPollingInterval { get; }

        /// <summary>
        /// Gets the folder to use to write failure screenshots into.
        /// </summary>
        string ScreenshotFolder { get; }
    }
}
