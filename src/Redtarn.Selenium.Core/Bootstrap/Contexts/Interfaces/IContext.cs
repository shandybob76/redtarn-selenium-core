// <copyright file="IContext.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using System;
using RedTarn.Selenium.Core.Bootstrap.Configuration.Interfaces;

namespace RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces
{
    /// <summary>
    /// Interface to define the properties of the test context.
    /// </summary>
    public interface IContext : IDisposable
    {
        /// <summary>
        /// Gets the data context.
        /// </summary>
        IDataContext Data { get; }

        /// <summary>
        /// Gets the User interface context.
        /// </summary>
        IUserInterfaceContext UserInterface { get; }

        /// <summary>
        /// Gets the test configuration.
        /// </summary>
        ITestConfiguration Config { get; }
    }
}
