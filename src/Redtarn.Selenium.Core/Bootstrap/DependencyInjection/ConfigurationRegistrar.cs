// <copyright file="ConfigurationRegistrar.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using System;
using BoDi;
using Microsoft.Extensions.Configuration;
using RedTarn.Selenium.Core.Bootstrap.Configuration;
using RedTarn.Selenium.Core.Bootstrap.Configuration.Interfaces;

namespace RedTarn.Selenium.Core.Bootstrap.DependencyInjection
{
    /// <summary>
    /// Configuration registrar.
    /// </summary>
    public static class ConfigurationRegistrar
    {
        /// <summary>
        /// Register the configuration with the dependency injection container.
        /// </summary>
        /// <param name="objectContainer">The object container.</param>
        public static void RegisterConfiguration(this IObjectContainer objectContainer)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", true)
                .Build();

            var testConfiguration = new TestConfiguration();

            var testConfigurationSection = configuration.GetSection("TestConfiguration");
            testConfigurationSection.Bind(testConfiguration);

            objectContainer.RegisterInstanceAs(testConfiguration, typeof(ITestConfiguration));
        }
    }
}
