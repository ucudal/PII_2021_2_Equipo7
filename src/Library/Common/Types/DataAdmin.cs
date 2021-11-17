// -----------------------------------------------------------------------
// <copyright file="DataAdmin.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Esta es una clase abstracta de la cual van
    /// a heredar todas las clases admin. Su funcion
    /// es almacenar y manipular los elementos de tipo T.
    /// </summary>
    /// <typeparam name="T">
    /// Clase de datos manejados por este admin.
    /// </typeparam>
    public abstract class DataAdmin<T>
        where T : class, IManagableData<T>, new()
    {
        /// <summary>
        /// Conexion con la base de datos.
        /// </summary>
        private IStorageProvider storage = Singleton<StorageProviderSerializedJson>.Instance;

        /// <summary>
        /// Lista de objetos de tipo T.
        /// </summary>
        /// <value>Almacenamos en la lista Item objetos de tipo T.</value>
        public IReadOnlyCollection<T> Items
        {
            get
            {
                return this.Storage.SelectAll<T>();
            }
        }

        /// <summary>
        /// Contenedor de la base de datos.
        /// </summary>
        protected IStorageProvider Storage
        {
            get => this.storage;
            set => this.storage = value;
        }

        /// <summary>
        /// Inserta un registro en el
        /// almacenamiento.
        /// </summary>
        /// <param name="pElemento">
        /// Elemento a insertar.
        /// </param>
        /// <returns>
        /// Id del elemento insertado.
        /// </returns>
        public int Insert(T pElemento)
        {
            if (pElemento is null)
            {
                throw new ArgumentNullException(paramName: nameof(pElemento));
            }

            try
            {
                this.ValidateInsert(pElemento);
                return this.Storage.Insert<T>(pElemento.Clone());
            }
            catch (ValidationException)
            {
                return 0;
            }
        }

        /// <summary>
        /// Actualiza un elemento segun su id.
        /// </summary>
        /// <param name="pElemento">
        /// Elemento a actualizar con sus
        /// datos nuevos.
        /// </param>
        /// <returns>
        /// Confirmacion de la actualizacion.
        /// </returns>
        public bool Update(T pElemento)
        {
            if (pElemento is null)
            {
                throw new ArgumentNullException(paramName: nameof(pElemento));
            }

            try
            {
                this.ValidateUpdate(pElemento);
                return this.Storage.Update<T>(pElemento.Clone());
            }
            catch (ValidationException)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un elemento segun el id
        /// recibido.
        /// </summary>
        /// <param name="pId">
        /// Id del elemento a eliminar.
        /// </param>
        /// <returns>
        /// Confirmacion de la eliminacion.
        /// </returns>
        public bool Delete(int pId)
        {
            return this.Storage.Delete<T>(pId);
        }

        /// <summary>
        /// Obtener un registro por su id.
        /// </summary>
        /// <param name="pId">
        /// Id del registro a obtener.
        /// </param>
        /// <returns>
        /// Registro obtenido o nulo
        /// en caso de no existir.
        /// </returns>
        public T GetById(int pId)
        {
            T recordFound;
            recordFound = this.Items.FirstOrDefault<T>(recordItem => recordItem.Id == pId && !recordItem.Deleted);
            if (recordFound is not null)
            {
                return recordFound.Clone();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Crear un objeto nuevo del tipo
        /// asociado al DataAdmin.
        /// </summary>
        /// <returns>
        /// Objeto creado.
        /// </returns>
        public T New()
        {
            T newItem = new T();
            return newItem;
        }

        /// <summary>
        /// Prueba si un registro existe en
        /// el almacenamiento persistente.
        /// </summary>
        /// <param name="id">
        /// Id del registro a encontrar.
        /// </param>
        /// <returns>
        /// Valor booleano indicando la
        /// existencia del registro.
        /// </returns>
        public bool Exists(int id)
        {
            T record = this.Items.FirstOrDefault(item => item.Id == id);
            return record is not null;
        }

        /// <summary>
        /// Toma una lista de items T, la
        /// separa en paginas de cierta
        /// cantidad de items, y recupera
        /// una pagina concreta de estas.
        /// </summary>
        /// <param name="items">
        /// Listado de items a reducir.
        /// </param>
        /// <param name="itemCount">
        /// Cantidad de items por pagina.
        /// </param>
        /// <param name="page">
        /// Pagina la cual retornar.
        /// </param>
        /// <returns>
        /// Listado de items pertenecientes
        /// a la pagina con el indice provisto
        /// al dividir la lista original
        /// en la grupos de la cantidad de
        /// items especificada.
        /// </returns>
        protected IReadOnlyCollection<T> GetItemPage(ReadOnlyCollection<T> items, int itemCount, int page)
        {
            if (items is null)
            {
                throw new ArgumentNullException(paramName: nameof(items));
            }

            List<T> listForPage = new List<T>();
            int startIndex = page * itemCount;
            if (startIndex < items.Count)
            {
                for (int index = startIndex; index < items.Count && index < (startIndex + itemCount); index++)
                {
                    listForPage.Add(items.ElementAt(index));
                }
            }

            return listForPage.AsReadOnly();
        }

        /// <summary>
        /// Valida los datos a introducir al storage
        /// en un insert.
        /// </summary>
        /// <param name="item">
        /// Item a validar.
        /// </param>
        protected virtual void ValidateInsert(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(paramName: nameof(item));
            }

            if (item.Id != 0)
            {
                throw new ValidationException("Id debe ser vacio.");
            }

            if (item.Deleted == true)
            {
                throw new ValidationException("No se puede crear un usuario eliminado.");
            }

            this.ValidateData(item);
        }

        /// <summary>
        /// Valida los datos a introducir al storage
        /// en un update.
        /// </summary>
        /// <param name="item">
        /// Item a validar.
        /// </param>
        protected virtual void ValidateUpdate(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(paramName: nameof(item));
            }

            if (item.Id == 0 || !this.Exists(item.Id))
            {
                throw new ValidationException("Id no debe ser vacio.");
            }

            this.ValidateData(item);
        }

        /// <summary>
        /// Valida los datos especificos
        /// del data a manipular.
        /// </summary>
        /// <param name="item">
        /// Item a validar.
        /// </param>
        protected abstract void ValidateData(T item);
    }
}