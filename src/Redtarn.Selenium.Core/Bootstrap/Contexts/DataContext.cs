// <copyright file="DataContext.cs" company="Red Tarn Technology Ltd">
// Copyright (c) Red Tarn Technology Ltd. All rights reserved.
// </copyright>

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
        private readonly Dictionary<string, object> items = new Dictionary<string, object>();

        /// <summary>
        /// Add a new item to the data context.
        /// </summary>
        /// <typeparam name="T">The type of item to add.</typeparam>
        /// <param name="key">The key of the item.</param>
        /// <param name="item">The item.</param>
        public void Add<T>(string key, T item)
        {
            this.items[key] = item;
        }

        /// <summary>
        /// Get an item from the data context.
        /// </summary>
        /// <typeparam name="T">The type of item to get.</typeparam>
        /// <param name="key">The key of the item.</param>
        /// <returns>The item if it exists.</returns>
        public T Get<T>(string key)
        {
            if (!this.items.ContainsKey(key))
            {
                return default(T);
            }

            return (T)this.items[key];
        }

        /// <summary>
        /// Remove an item from the test context.
        /// </summary>
        /// <param name="key">The key of the item.</param>
        public void Remove(string key)
        {
            if (this.items.ContainsKey(key))
            {
                this.items.Remove(key);
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
            if (!this.items.ContainsKey(key))
            {
                this.items.Add(key, new List<T>());
            }

            ((List<T>)this.items[key]).Add(item);
        }

        /// <summary>
        /// Geta list from the data context.
        /// </summary>
        /// <typeparam name="T">The type of the item list to get.</typeparam>
        /// <param name="listKey">The list key.</param>
        /// <returns>The list of items if it exists.</returns>
        public List<T> GetList<T>(string listKey)
        {
            return this.Get<List<T>>(listKey);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
