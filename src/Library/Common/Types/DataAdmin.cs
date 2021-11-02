using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Esta es una clase abstracta de la cual van
    /// a heredar todas las clases admin. Su funcion 
    /// es almacenar y manipular los elementos de tipo T.
    /// </summary>
    public abstract class DataAdmin<T> where T : class, IManagableData<T>, new()
    {
        /// <summary>
        /// Conexion con la base de datos
        /// </summary>
        private IStorageProvider storage = Singleton<StorageProviderInProcess>.Instance;

        /// <summary>
        /// Lista de objetos de tipo T 
        /// </summary>
        /// <value>Almacenamos en la lista Item objetos de tipo T.</value>
        public ReadOnlyCollection<T> Items 
        {
            get
            {
                return this.storage.SelectAll<T>();
            }
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
        public virtual int Insert(T pElemento)
        {
            return this.storage.Insert<T>(pElemento.Clone());
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
        public virtual bool Update(T pElemento)
        {   
            return this.storage.Update<T>(pElemento.Clone());
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
        public virtual bool Delete(int pId)
        {
            return this.storage.Delete<T>(pId);
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
        public virtual T GetById(int pId)
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
        /// asociado al DataAdmin
        /// </summary>
        /// <returns>
        /// Objeto creado.
        /// </returns>
        public virtual T New()
        {
            T newItem = new T();
            return newItem;
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
        protected List<T> GetItemPage(List<T> items, int itemCount, int page)
        {
            List<T> listForPage = new List<T>();
            int startIndex = page * itemCount;
            if (startIndex < items.Count)
            {
                for (int index = startIndex; index < items.Count && index < (startIndex + itemCount) ; index++)
                {
                    listForPage.Add(items.ElementAt(index));
                }
            }

            return listForPage;
        }        

    }
    
}