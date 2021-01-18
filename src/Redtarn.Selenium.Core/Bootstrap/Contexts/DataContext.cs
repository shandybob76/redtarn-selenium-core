// <copyright file="DataContext.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using RedTarn.Selenium.Core.Bootstrap.Contexts.Interfaces;

namespace RedTarn.Selenium.Core.Bootstrap.Contexts
{
    /// <summary>
    /// The data context.
    /// </summary>
    public class DataContext : IDataContext
    {
        /// <summary>
        /// Local cache of the items.
        /// </summary>
        private readonly Dictionary<string, object> _items = new Dictionary<string, object>();

        /// <summary>
        /// Finalizes an instance of the <see cref="DataContext"/> class.
        /// </summary>
        ~DataContext()
        {
            Dispose(false);
        }

        /// <summary>
        /// Add a new item to the data context.
        /// </summary>
        /// <typeparam name="T">The type of item to add.</typeparam>
        /// <param name="key">The key of the item.</param>
        /// <param name="item">The item.</param>
        public void Add<T>(string key, T item)
        {
            _items[key] = item;
        }

        /// <summary>
        /// Get an item from the data context.
        /// </summary>
        /// <typeparam name="T">The type of item to get.</typeparam>
        /// <param name="key">The key of the item.</param>
        /// <returns>The item if it exists.</returns>
        public T Get<T>(string key)
        {
            if (!_items.ContainsKey(key))
            {
                return default;
            }

            return (T)_items[key];
        }

        /// <summary>
        /// Remove an item from the test context.
        /// </summary>
        /// <param name="key">The key of the item.</param>
        public void Remove(string key)
        {
            if (_items.ContainsKey(key))
            {
                _items.Remove(key);
            }
        }

        /// <summary>
        /// Add a new list item to the data context.
        /// </summary>
        /// <typeparam name="T">The type of item to add.</typeparam>
        /// <param name="key">The key of the list.</param>
        /// <param name="item">The item to add.</param>
        public void AddListItem<T>(string key, T item)
        {
            if (!_items.ContainsKey(key))
            {
                _items.Add(key, new List<T>());
            }

            ((List<T>)_items[key]).Add(item);
        }

        /// <summary>
        /// Geta list from the data context.
        /// </summary>
        /// <typeparam name="T">The type of the item list to get.</typeparam>
        /// <param name="listKey">The list key.</param>
        /// <returns>The list of items if it exists.</returns>
        public List<T> GetList<T>(string listKey)
        {
            return Get<List<T>>(listKey);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether we are disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
