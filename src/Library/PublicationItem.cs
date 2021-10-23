using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase creada para saber la cantidad de publicaciones creadas?
    /// </summary>
    public class PublicationItem
    {
        // Atributo para saber la cantidad de material agregado.
        int Quantity{get; set;}


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
