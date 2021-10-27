using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase creada para saber que material se va a publicar y su cantidad
    /// </summary>
    public class PublicationItem
    {
        /// <summary>
        /// Atributo para saber la cantidad de material agregado.
        /// </summary>
        /// <value></value>
        public int Quantity{get; set;}


        /// <summary>
        /// Property de CompanyMaterial.
        /// </summary>
        public CompanyMaterial CompanyMaterial{get; set;}

        
        
        /// <summary>
        /// Constructor de la clase PublicationItem para definir el atributo Quantity.
        /// </summary>
        public PublicationItem(int Quantity)
        {
            this.Quantity = Quantity;
        }

    }
}
