using System;
using System.Collections.Generic;
using Library;

namespace ClassLibrary
{
    /// <summary>
    /// Esta es una clase abstacta de la cual van a heredar todas las clases admin. Su funcion es almacenar y manipular los elementos de tipo T
    /// </summary>
    public abstract class DataAdmin <T>
    {
        /// <summary>
        /// Conexion con la base de datos
        /// </summary>
        private StorageProvider storage=Singleton<StorageProvider>.Instance;

        /// <summary>
        /// Lista de objetos de tipo T 
        /// </summary>
        /// <value>Almacenamos en la lista Item objetos de tipo T.</value>
        protected static List<T> Items;
        
        /// <summary>
        /// Agregar a la lista 
        /// </summary>
        ///<value>Agregamos a la lista Items, el objeto de tipo T. Esto pasa si y solo si el objeto no esta agregado previamente</value>
        /// <param name="pElemento ">Se pasa el objeto de tipo T</param>
        public abstract void Insert(T pElemento);
       
        /// <summary>
        /// Modificar elemento de la lista 
        /// </summary>
        ///<value>Modificamos un elemento de tipo T de la lista Items. Esto pasa si y solo si el objeto  esta agregado previamente</value>
        /// <param name="pElemento ">Se pasa el objeto de tipo T</param>
        public abstract void Update(T pElemento);

        /// <summary>
        /// Eliminar de la lista al objeto de tipo T 
        /// </summary>
        ///<value>Eliminamos de la lista Items, el objeto de tipo T. Esto pasa si y solo si el objeto esta agregado previamente</value>
        /// <param name="pElemento ">Se pasa el objeto de tipo T</param>
        public abstract void Delete(T pElemento);
        
        /// <summary>
        /// Busca un obejto de tipo T 
        /// </summary>
        ///<value>Recorremos la lista y devolvemos el objeto de tipo T que tenga el id pasado por parametro. Esto pasa si y solo si el objeto esta agregado previamente</value>
        ///<result>Retorna un elemento de tipo T </result>
        /// <param name="pId ">Se pasa el objeto de tipo T</param>
        public abstract T GetById(int pId);
        
        /// <summary>
        /// Busca un obejto de tipo T 
        /// </summary>
        ///<value>Recorremos la lista y devolvemos el objeto de tipo T que tenga el nombre pasado por parametro. Esto pasa si y solo si el objeto esta agregado previamente</value>
        ///<result>Retorna un elemento de tipo T </result>
        /// <param name="pNombre ">Se pasa el objeto de tipo T</param>
        public abstract T GetByName(string pNombre);

        /// <summary>
        /// Crea un objeto de tipo User vacio
        /// </summary>
        ///<result>Retorna un elemento de tipo User vacio </result>
        public abstract T New();

    }

}