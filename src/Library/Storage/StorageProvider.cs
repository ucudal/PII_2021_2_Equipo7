using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Proveedor de storage In Process.
    /// </summary>
    public class StorageProvider
    {
        private Dictionary<Type, List<dynamic>> tables;

        /// <summary>
        /// Conseguir un listado de los registros
        /// almacenados del tipo recibido.
        /// </summary>
        /// <typeparam name="T">
        /// Tipo que indica el listado de registros a devolver.
        /// </typeparam>
        /// <returns>
        /// Listado de registros del tipo T.
        /// </returns>
        public List<T> GetTable<T>()
        {
            Type type = typeof(T);
            return tables[type] as List<T>;
        }
    }    
}