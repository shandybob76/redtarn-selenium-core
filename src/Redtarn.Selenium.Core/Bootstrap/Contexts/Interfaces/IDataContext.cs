// <copyright file="IDataContext.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces
{
    /// <summary>
    /// Interface to define the methods for the data context.
    /// </summary>
    public interface IDataContext : IDisposable
    {
        /// <summary>
        /// Add a new item to the data context.
        /// </summary>
        /// <typeparam name="T">The type of item to add.</typeparam>
        /// <param name="key">The key of the item.</param>
        /// <param name="item">The item.</param>
        void Add<T>(string key, T item);

        /// <summary>
        /// Add a new list item to the data context.
        /// </summary>
        /// <typeparam name="T">The type of item to add.</typeparam>
        /// <param name="key">The key of the list.</param>
        /// <param name="item">The item to add.</param>
        void AddListItem<T>(string key, T item);

        /// <summary>
        /// Get an item from the data context.
        /// </summary>
        /// <typeparam name="T">The type of item to get.</typeparam>
        /// <param name="key">The key of the item.</param>
        /// <returns>The item if it exists.</returns>
        T Get<T>(string key);

        /// <summary>
        /// Remove an item from the test context.
        /// </summary>
        /// <param name="key">The key of the item.</param>
        void Remove(string key);

        /// <summary>
        /// Geta list from the data context.
        /// </summary>
        /// <typeparam name="T">The type of the item list to get.</typeparam>
        /// <param name="listKey">The list key.</param>
        /// <returns>The list of items if it exists.</returns>
        List<T> GetList<T>(string listKey);
    }
}
