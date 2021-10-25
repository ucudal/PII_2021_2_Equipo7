using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Proveedor de storage In Process.
    /// </summary>
    public class StorageProviderInProcess : IStorageProvider
    {
        private Dictionary<Type, List<dynamic>> tables;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="StorageProviderInProcess"/>.
        /// </summary>
        public StorageProviderInProcess()
        {
            this.tables = new Dictionary<Type, List<dynamic>>();
        }

        /// <inheritdoc/>
        public List<T> GetTable<T>()
        {
            Type type = typeof(T);
            if (!this.tables.ContainsKey(type))
            {
                this.tables[type] = new List<dynamic>();
            }
            return this.tables[type] as List<T>;
        }
    }    
}