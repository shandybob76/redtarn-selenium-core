// <copyright file="BaseSteps.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;

namespace RedTarn.Selenium.Core
{
    /// <summary>
    /// The base steps class.
    /// </summary>
    public class BaseSteps
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSteps"/> class.
        /// </summary>
        /// <param name="context">The test context.</param>
        public BaseSteps(IContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Gets the test context.
        /// </summary>
        protected IContext Context { get; }
    }
}
