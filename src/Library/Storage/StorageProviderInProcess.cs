using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
        public ReadOnlyCollection<T> SelectAll<T>() where T : class, IManagableData<T>
        {
            List<T> table = GetTable<T>();
            List<T> orderedTable = table.OrderBy(recordItem => recordItem.Id).ToList<T>();
            return table.AsReadOnly();
        }

        /// <inheritdoc/>
        public int Insert<T>(T record) where T : class, IManagableData<T>
        {
            Type type = typeof(T);
            List<T> table = GetTable<T>();
            T recordAux = record.Clone();
            int newId;
            
            if (table.Count > 0)
            {
                newId = table.Max(obj => obj.Id) + 1;
            }
            else
            {
                newId = 1;
            }

            recordAux.Id = newId;
            recordAux.Deleted = false;
            this.tables[type].Add(recordAux);
            return newId;
        }

        /// <inheritdoc/>
        public bool Update<T>(T record) where T : class, IManagableData<T>
        {
            List<T> table = GetTable<T>();
            T storedRecord = table.Find(recordItem => recordItem.Id == record.Id);
            
            if (storedRecord is null)
            {
                return false;
            }

            storedRecord.LoadFromJson(record.ConvertToJson());

            return true;
        }

        /// <inheritdoc/>
        public bool Delete<T>(int recordId) where T : class, IManagableData<T>
        {
            List<T> table = GetTable<T>();
            T storedRecord = table.Find(recordItem => recordItem.Id == recordId);
            
            if (storedRecord is null)
            {
                return false;
            }

            if (storedRecord.Deleted)
            {
                return false;
            }

            storedRecord.Deleted = true;

            return true;
        }

        private List<T> GetTable<T>() where T : class
        {
            Type type = typeof(T);
            if (!this.tables.ContainsKey(type))
            {
                this.tables[type] = new List<dynamic>();
            }

            Converter<dynamic, T> converter = new Converter<dynamic, T>(ConvertDynToT<T>);
            List<dynamic> result = this.tables[type];
            List<T> resultAsT = result.ConvertAll<T>(converter);
            return resultAsT;
        }

        private T ConvertDynToT<T>(dynamic item) where T : class
        {
            return item as T;
        }
    }    
}