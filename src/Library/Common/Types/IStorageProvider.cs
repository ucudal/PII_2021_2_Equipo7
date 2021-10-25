using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Interface para implementar proveedores de almacenamiento
    /// de datos.
    /// </summary>
    public interface IStorageProvider
    {
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
        public List<T> GetTable<T>();
    }
}