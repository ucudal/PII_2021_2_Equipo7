using System;
using System.Collections.Generic;
using System.Collections;
using ClassLibrary;

namespace Library
{
    /// <summary>
    /// Esta clase representa la administracion de Entrepreneur.
    /// </summary>
    public class EntrepreneurAdmin: DataAdmin<Entrepreneur>
    {
        /// <summary>
        /// creamos un objeto de Entrepreneur
        /// </summary>
        /// <returns>retornamos un objeto vacio de Entrepreneur</returns>
        public override Entrepreneur New()
        {
            Entrepreneur xretorno=new Entrepreneur();
            return xretorno;
        }
        /// <summary>
        /// Calculamos el ultimo indice de la lista
        /// </summary>
        /// <returns>ultimo indice de la lista</returns>
        private int CalculadoraDeIndice()
        {
            int xretorno=Items.Count;
            return xretorno;
        }

        /// <summary>
        /// insertamos el emprendedor en la ultima posicion de la lista
        /// </summary>
        /// <param name="entrepreneur">emprendedor nuevo que quiero ingresar</param>
        public override void Insert(Entrepreneur entrepreneur)
        {
            entrepreneur.Id=CalculadoraDeIndice();
            if(!Items.Contains(entrepreneur))
            {
                Items.Add(entrepreneur);
            }
        }

        /// <summary>
        /// metodo para eliminar un emprendedor
        /// </summary>
        /// <param name="entrepreneur">emprendedor que quiero eliminar</param>
        public override void Delete(Entrepreneur entrepreneur)
        {
            if(Items.Contains(entrepreneur))
            {
                Items[Items.IndexOf(entrepreneur)].Deleted=true;
            }
        }
        /// <summary>
        /// Modificamos un elemento de tipo Entrepreneur de la lista Items. Esto pasa si y solo si el objeto  esta agregado previamente
        /// </summary>
        /// <param name="entrepreneur">objeto de tipo Entrepreneur</param>
        public override void Update(Entrepreneur entrepreneur)
        {
            Items[Items.IndexOf(this.GetById(entrepreneur.Id))]=entrepreneur;
        }      
        /// <summary>
        /// metodo para buscar un emprendedor por id 
        /// </summary>
        /// <param name="eId">int que corresponde al id del emprendedor</param>
        /// <returns>objeto de tipo Entrepreneur</returns>
        public override Entrepreneur GetById(int eId)
        {
            Entrepreneur emprendedorfinal=null;
            int i=0;
            bool esesta =false;
            
            while(i<Items.Count && esesta==false)
            {
                if(Items[i].Id==eId)
                {
                    esesta=true;
                    emprendedorfinal=Items[i];
                }
            }
            return emprendedorfinal;
        }
        /// <summary>
        /// buscamos el emprendedor por nombre
        /// </summary>
        /// <param name="Nombre">nombre de emprendedor</param>
        /// <returns>objeto de tipo Entrepreneur</returns>
        public override Entrepreneur GetByName(string Nombre)
        {
            Entrepreneur nombreFinal=null;
            int i=0;
            bool esesta=false;
            
            while(i<Items.Count && !esesta)
            {
                if(Items[i].Name==Nombre)
                {
                    esesta=true;
                    nombreFinal=Items[i];
                }
            }
            return nombreFinal;
        }


    }
    

}
