// <copyright file="BootstrapSteps.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using BoDi;
using RedTarn.Selenium.Core.Bootstrap.DependencyInjection;
using TechTalk.SpecFlow;

namespace RedTarn.Selenium.Core.Bootstrap
{
    /// <summary>
    /// Base level bootstrap steps to set up the dependency injection.
    /// </summary>
    [Binding]
    public class BootstrapSteps
    {
        /// <summary>
        /// The object container.
        /// </summary>
        private readonly IObjectContainer _objectContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BootstrapSteps"/> class.
        /// </summary>
        /// <param name="objectContainer">The object container.</param>
        public BootstrapSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        /// <summary>
        /// Initialise the test scenario. This must run before ANY other
        /// scenario steps as it is configuring the dependency injection for
        /// the web driver, configuration and contexts.
        /// </summary>
        [BeforeScenario(Order = int.MinValue)]
        public void Initialise()
        {
            _objectContainer.RegisterWebDrivers();
            _objectContainer.RegisterConfiguration();
            _objectContainer.RegisterContext();
        }
    }
}
