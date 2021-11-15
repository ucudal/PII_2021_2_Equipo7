// -----------------------------------------------------------------------
// <copyright file="IStorageProvider.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

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
        /// Obtener todos los registros.
        /// </summary>
        /// <typeparam name="T">
        /// Tipo del dato en la tabla.
        /// </typeparam>
        /// <returns>
        /// Listado de registros.
        /// </returns>
        ReadOnlyCollection<T> SelectAll<T>()
            where T : class, IManagableData<T>;

        /// <summary>
        /// Inserta un registro en el
        /// alacenamiento.
        /// </summary>
        /// <param name="record">
        /// Registro a insertar.
        /// </param>
        /// <typeparam name="T">
        /// Clase de datos del registro.
        /// Asociado a la tabla en si.
        /// </typeparam>
        /// <returns>
        /// Id del registro nuevo.
        /// </returns>
        int Insert<T>(T record)
            where T : class, IManagableData<T>;

        /// <summary>
        /// Modifica un registro segun su id.
        /// </summary>
        /// <param name="record">
        /// Registro a actualizar.
        /// </param>
        /// <typeparam name="T">
        /// Clase de datos del registro.
        /// Asociado a la tabla en si.
        /// </typeparam>
        /// <returns>
        /// Resultado de la operacion.
        /// </returns>
        bool Update<T>(T record)
            where T : class, IManagableData<T>;

        /// <summary>
        /// Elimina un registro por su id.
        /// </summary>
        /// <param name="recordId">
        /// Id del registro a eliminar.
        /// </param>
        /// <typeparam name="T">
        /// Clase de datos del registro.
        /// Asociado a la tabla en si.
        /// </typeparam>
        /// <returns>
        /// Resultado de la operacion.
        /// </returns>
        bool Delete<T>(int recordId)
            where T : class, IManagableData<T>;
    }
}