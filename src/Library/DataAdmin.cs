using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Esta es una clase abstacta de la cual van a heredar todas las clases admin. Su funcion es almacenar y manipular los elementos de tipo T
    /// </summary>
    public abstract class DataAdmin <T> where T : IManagableData, new()
    {
        /// <summary>
        /// Conexion con la base de datos
        /// </summary>
        private IStorageProvider storage=Singleton<StorageProviderInProcess>.Instance;

        /// <summary>
        /// Lista de objetos de tipo T 
        /// </summary>
        /// <value>Almacenamos en la lista Item objetos de tipo T.</value>
        public List<T> Items 
        {
            get
            {
                return this.storage.GetTable<T>();
            }
        }
        
        /// <summary>
        /// Agregar a la lista 
        /// </summary>
        ///<value>Agregamos a la lista Items, el objeto de tipo T. Esto pasa si y solo si el objeto no esta agregado previamente</value>
        /// <param name="pElemento ">Se pasa el objeto de tipo T</param>
        public virtual void Insert(T pElemento)
        {
            pElemento.Id=IndexCalculator();
            if(!Items.Contains(pElemento))
            {
                Items.Add(pElemento);
            }
        }
        private int IndexCalculator()
        {
            int xretorno=this.Items.Max(obj=>obj.Id)+1;
            return xretorno;
        }
       
        /// <summary>
        /// Modificar elemento de la lista 
        /// </summary>
        ///<value>Modificamos un elemento de tipo T de la lista Items. Esto pasa si y solo si el objeto  esta agregado previamente</value>
        /// <param name="pElemento ">Se pasa el objeto de tipo T</param>
        public virtual void Update(T pElemento)
        {
            Items[Items.IndexOf(this.GetById(pElemento.Id))]=pElemento;
        }

        /// <summary>
        /// Eliminar de la lista al objeto de tipo T 
        /// </summary>
        ///<value>Eliminamos de la lista Items, el objeto de tipo T. Esto pasa si y solo si el objeto esta agregado previamente</value>
        /// <param name="pId ">Se pasa el el id del objeto a eliminar</param>
        public virtual void Delete(int pId)
        {
             this.Items.RemoveAll(obj=>obj.Id==pId);
        }
        
        /// <summary>
        /// Busca un obejto de tipo T 
        /// </summary>
        ///<value>Recorremos la lista y devolvemos el objeto de tipo T que tenga el id pasado por parametro. Esto pasa si y solo si el objeto esta agregado previamente</value>
        ///<result>Retorna un elemento de tipo T </result>
        /// <param name="pId ">Se pasa el objeto de tipo T</param>
        public virtual T GetById(int pId)
        {
            return this.Items.Find(obj=>obj.Id==pId);
        }
        
        /// <summary>
        /// Crea un objeto de tipo User vacio
        /// </summary>
        ///<result>Retorna un elemento de tipo User vacio </result>
        public virtual T New()
        {
            T xretorno=new T();
            return xretorno;
        }
        public virtual List<T> GetItemPage(int page,int itemCount)
        {
            List<T> xlista= new List<T>();
            int indice=page*itemCount;
            this.Items.GetRange(indice,itemCount);
            if(!(indice>=this.Items.Count))
            {
                xlista=this.Items.GetRange(indice,itemCount);
            }
            return xlista;
        }        

    }
    
}