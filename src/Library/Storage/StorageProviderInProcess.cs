//-----------------------------------------------------------------------------------
// <copyright file="StorageProviderInProcess.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-----------------------------------------------------------------------------------

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
        /// Initializes a new instance of the <see cref="StorageProviderInProcess"/> class.
        /// </summary>
        public StorageProviderInProcess()
        {
            this.tables = new Dictionary<Type, List<dynamic>>();
        }

        /// <inheritdoc/>
        public ReadOnlyCollection<T> SelectAll<T>()
            where T : class, IManagableData<T>
        {
            List<T> table = this.GetTable<T>();
            List<T> tableNotDeleted = table.FindAll(recordItem => !recordItem.Deleted);
            List<T> orderedTable = tableNotDeleted.OrderBy(recordItem => recordItem.Id).ToList<T>();
            return orderedTable.AsReadOnly();
        }

        /// <inheritdoc/>
        public int Insert<T>(T record)
            where T : class, IManagableData<T>
        {
            if (record is null)
            {
                throw new ArgumentNullException(paramName: nameof(record));
            }

            Type type = typeof(T);
            List<T> table = this.GetTable<T>();
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
        public bool Update<T>(T record)
            where T : class, IManagableData<T>
        {
            if (record is null)
            {
                throw new ArgumentNullException(paramName: nameof(record));
            }

            List<T> table = this.GetTable<T>();
            T storedRecord = table.Find(recordItem => recordItem.Id == record.Id);

            if (storedRecord is null)
            {
                return false;
            }

            storedRecord.LoadFromJson(record.ConvertToJson());

            return true;
        }

        /// <inheritdoc/>
        public bool Delete<T>(int recordId)
            where T : class, IManagableData<T>
        {
            if (recordId == 0)
            {
                throw new ArgumentNullException(paramName: nameof(recordId));
            }

            List<T> table = this.GetTable<T>();
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

        private static T ConvertDynToT<T>(dynamic item)
            where T : class
        {
            return item as T;
        }

        private List<T> GetTable<T>()
            where T : class
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
    }
}