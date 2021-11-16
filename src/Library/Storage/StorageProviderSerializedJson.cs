// -----------------------------------------------------------------------
// <copyright file="StorageProviderSerializedJson.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Proveedor de storage In Process.
    /// </summary>
    public class StorageProviderSerializedJson : IStorageProvider
    {
        /// <inheritdoc/>
        public ReadOnlyCollection<T> SelectAll<T>()
            where T : class, IManagableData<T>
        {
            Dictionary<string, List<dynamic>> tables = GetTables();
            Converter<dynamic, T> converter = new Converter<dynamic, T>(ConvertDynToT<T>);
            string type = typeof(T).Name;
            if (!tables.ContainsKey(type))
            {
                tables[type] = new List<dynamic>();
            }

            List<T> table = tables[type].ConvertAll<T>(converter);
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

            Dictionary<string, List<dynamic>> tables = GetTables();
            Converter<dynamic, T> converter = new Converter<dynamic, T>(ConvertDynToT<T>);
            string type = typeof(T).Name;
            if (!tables.ContainsKey(type))
            {
                tables[type] = new List<dynamic>();
            }

            List<T> table = tables[type].ConvertAll<T>(converter);
            T storedRecord = table.Find(recordItem => recordItem.Id == record.Id);
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
            table.Add(recordAux);
            tables[type] = table.Select(obj => obj as dynamic).ToList();

            bool isOk = StoreData(tables);

            return isOk ? newId : 0;
        }

        /// <inheritdoc/>
        public bool Update<T>(T record)
            where T : class, IManagableData<T>
        {
            if (record is null)
            {
                throw new ArgumentNullException(paramName: nameof(record));
            }

            Dictionary<string, List<dynamic>> tables = GetTables();
            Converter<dynamic, T> converter = new Converter<dynamic, T>(ConvertDynToT<T>);
            string type = typeof(T).Name;
            if (!tables.ContainsKey(type))
            {
                tables[type] = new List<dynamic>();
            }

            List<T> table = tables[type].ConvertAll<T>(converter);
            T storedRecord = table.Find(recordItem => recordItem.Id == record.Id);

            if (storedRecord is null)
            {
                return false;
            }

            storedRecord.LoadFromJson(record.ConvertToJson());
            tables[type] = table.Select(obj => obj as dynamic).ToList();

            return StoreData(tables);
        }

        /// <inheritdoc/>
        public bool Delete<T>(int recordId)
            where T : class, IManagableData<T>
        {
            if (recordId == 0)
            {
                throw new ArgumentNullException(paramName: nameof(recordId));
            }

            Dictionary<string, List<dynamic>> tables = GetTables();
            Converter<dynamic, T> converter = new Converter<dynamic, T>(ConvertDynToT<T>);
            string type = typeof(T).Name;
            if (!tables.ContainsKey(type))
            {
                tables[type] = new List<dynamic>();
            }

            List<T> table = tables[type].ConvertAll<T>(converter);
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
            tables[type] = table.Select(obj => obj as dynamic).ToList();

            return StoreData(tables);
        }

        private static T ConvertDynToT<T>(dynamic item)
            where T : class
        {
            JToken token = item as JToken;
            T objectItem = token.ToObject<T>();
            return objectItem;
        }

        private static Dictionary<string, List<dynamic>> GetTables()
        {
            Dictionary<string, List<dynamic>> tables = new Dictionary<string, List<dynamic>>();

            if (File.Exists(@"database.json"))
            {
                string json = File.ReadAllText(@"database.json");
                tables = JsonConvert.DeserializeObject<Dictionary<string, List<dynamic>>>(json) ?? new Dictionary<string, List<dynamic>>();
            }

            return tables;
        }

        private static bool StoreData(Dictionary<string, List<dynamic>> tables)
        {
            try
            {
                using FileStream fileStream = File.Create(@"database.json");
                using StreamWriter file = new StreamWriter(fileStream, Encoding.UTF8);
                string json = JsonConvert.SerializeObject(tables);
                file.Write(json);
                file.Close();
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }

            return true;
        }
    }
}