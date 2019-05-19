// <copyright file="TestConfiguration.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using RedTarn.Selenium.Core.Bootstrap.Configuration.Interfaces;
using RedTarn.Selenium.Core.Bootstrap.Enums;

namespace RedTarn.Selenium.Core.Bootstrap.Configuration
{
    /// <summary>
    /// The test configuration class.
    /// </summary>
    public class TestConfiguration : ITestConfiguration
    {
        /// <summary>
        /// Gets or sets the base URL for the site being tested.
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the browser type to instantiate for the tests.
        /// </summary>
        public BrowserType BrowserType { get; set; }

        /// <summary>
        /// Gets or sets the device type for the tests.
        /// </summary>
        public DeviceType DeviceType { get; set; }

        /// <summary>
        /// Gets or sets the UI timeout to use when waiting for elements to become
        /// available in the page in milliseconds.
        /// </summary>
        public int UiTimeout { get; set; }

        /// <summary>
        /// Gets or sets the polling inteval to use while waiting for element to become
        /// available in the page in milliseconds.
        /// </summary>
        public int UiPollingInterval { get; set; }

        /// <summary>
        /// Gets or sets the folder to use to write failure screenshots into.
        /// </summary>
        public string ScreenshotFolder { get; set; }
    }
}
