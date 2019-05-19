// <copyright file="Context.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using RedTarn.Selenium.Core.Bootstrap.Configuration.Interfaces;
using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;

namespace RedTarn.Selenium.Core.Bootstrap.Contexts
{
    /// <summary>
    /// The test context class.
    /// </summary>
    public class Context : IContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// </summary>
        /// <param name="testConfiguration">The test configuration.</param>
        /// <param name="dataContext">The data context.</param>
        /// <param name="uiContext">The UI context.</param>
        public Context(ITestConfiguration testConfiguration, IDataContext dataContext, IUIContext uiContext)
        {
            this.Data = dataContext;
            this.UI = uiContext;
            this.Config = testConfiguration;
        }

        /// <summary>
        /// Gets the data context.
        /// </summary>
        public IDataContext Data { get; }

        /// <summary>
        /// Gets the UI context.
        /// </summary>
        public IUIContext UI { get; }

        /// <summary>
        /// Gets the test configuration.
        /// </summary>
        public ITestConfiguration Config { get; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Data?.Dispose();
            this.UI?.Dispose();
        }
    }
}
