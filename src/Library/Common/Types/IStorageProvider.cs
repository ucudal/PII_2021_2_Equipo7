using System.Collections.ObjectModel;

namespace ClassLibrary
{
    /// <summary>
    /// Interface para implementar proveedores de almacenamiento
    /// de datos.
    /// </summary>
    public interface IStorageProvider
    {
        /// <summary>
        /// Interface para implementar proveedores de almacenamiento
        /// de datos.
        /// </summary>
        ReadOnlyCollection<T> SelectAll<T>() where T : class, IManagableData<T>;

            /// <summary>
            /// Inserta un registro en el 
            /// alacenamiento.
            /// </summary>
            /// <typeparam name="T">
            /// Clase de datos del registro.
            /// Asociado a la tabla en si.
            /// </typeparam>
        int Insert<T>(T record) where T : class, IManagableData<T>;

        /// <summary>
        /// Modifica un registro segun su id.
        /// </summary>
        /// <typeparam name="T">
        /// Clase de datos del registro.
        /// Asociado a la tabla en si.
        /// </typeparam>
        bool Update<T>(T record) where T : class, IManagableData<T>;

        /// <summary>
        /// Elimina un registro por su id.
        /// </summary>
        /// <typeparam name="T">
        /// Clase de datos del registro.
        /// Asociado a la tabla en si.
        /// </typeparam>
        bool Delete<T>(int recordId) where T : class, IManagableData<T>;
     
    }
}