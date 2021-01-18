// <copyright file="ContextRegistrar.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using BoDi;
using RedTarn.Selenium.Core.Bootstrap.Contexts;
using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;

namespace RedTarn.Selenium.Core.Bootstrap.DependencyInjection
{
    /// <summary>
    /// The context registrar.
    /// </summary>
    public static class ContextRegistrar
    {
        /// <summary>
        /// Register the contexts with the dependency injection container.
        /// </summary>
        /// <param name="objectContainer">The object container.</param>
        public static void RegisterContext(this IObjectContainer objectContainer)
        {
            objectContainer.RegisterTypeAs<UserInterfaceContext, IUserInterfaceContext>();
            objectContainer.RegisterTypeAs<DataContext, IDataContext>();
            objectContainer.RegisterTypeAs<Context, IContext>();
        }
    }
}
