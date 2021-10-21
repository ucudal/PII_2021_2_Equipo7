using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa la administracion de Usuarios.
    /// </summary>
    public class UserAdmin : DataAdmin<User>
    {
        /// <summary>
        /// Agregar a la lista 
        /// </summary>
        ///<value>Agregamos a la lista Items, el objeto de tipo User. Esto pasa si y solo si el objeto no esta agregado previamente</value>
        /// <param name="pElemento ">Se pasa el objeto de tipo User</param>
        public override void Insert(User pElemento)
        {
            pElemento.Id=IndexCalculator();
            if(!Items.Contains(pElemento))
            {
                Items.Add(pElemento);
            }
        }

        private int IndexCalculator()
        {
            int xretorno=Items.Count;
            return xretorno;
        }
         /// <summary>
        /// Modificar elemento de la lista 
        /// </summary>
        ///<value>Modificamos un elemento de tipo User de la lista Items. Esto pasa si y solo si el objeto  esta agregado previamente</value>
        /// <param name="pElemento ">Se pasa el objeto de tipo User</param>
        public override void Update(User pElemento)
        {
            Items[Items.IndexOf(this.GetById(pElemento.Id))]=pElemento;
        }

        /// <summary>
        /// Eliminar de la lista al objeto de tipo T 
        /// </summary>
        ///<value>Eliminamos de la lista Items, el objeto de tipo User. Esto pasa si y solo si el objeto esta agregado previamente</value>
        /// <param name="pElemento ">Se pasa el objeto de tipo User</param>
        public override void Delete(User pElemento)
        {
            if(Items.Contains(pElemento))
            {
                Items[Items.IndexOf(pElemento)].Deleted=true;
            }
        }

        /// <summary>
        /// Busca un obejto de tipo User
        /// </summary>
        ///<value>Recorremos la lista y devolvemos el objeto de tipo User que tenga el id pasado por parametro. Esto pasa si y solo si el objeto esta agregado previamente</value>
        ///<result>Retorna un elemento de tipo User </result>
        /// <param name="pId ">Se pasa el objeto de tipo User</param>
        public override User GetById(int pId)
        {
            User xretorno=null;
            int i=0;
            bool xEsta=false;
            
            while(i<Items.Count && xEsta==false)
            {
                if(Items[i].Id==pId)
                {
                    xEsta=true;
                    xretorno=Items[i];
                }
            }
            return xretorno;
        }

        /// <summary>
        /// Busca un obejto de tipo User
        /// </summary>
        ///<value>Recorremos la lista y devolvemos el objeto de tipo User que tenga el nombre pasado por parametro. Esto pasa si y solo si el objeto esta agregado previamente</value>
        ///<result>Retorna un elemento de tipo User </result>
        /// <param name="pNombre ">Se pasa el objeto de tipo User</param>

        public override User GetByName(string pNombre)
        {
            User xretorno=null;
            int i=0;
            bool xEsta=false;
            
            while(i<Items.Count && !xEsta)
            {
                if(Items[i].Name==pNombre)
                {
                    xEsta=true;
                    xretorno=Items[i];
                }
            }
            return xretorno;
        }

        /// <summary>
        /// Crea un objeto de tipo User vacio
        /// </summary>
        ///<result>Retorna un elemento de tipo User vacio </result>
        public override User New()
        {
            User xretorno=new User();
            return xretorno;
        }
    }
}