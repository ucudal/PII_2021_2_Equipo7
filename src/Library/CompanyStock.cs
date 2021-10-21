using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa el stock de cada materialEmpresa.
    /// </summary>
    public class CompanyStock
    {
        /// <summary>
        /// Cantidad de stock del materialEmpresa
        /// </summary>
        /// <value>Se almacena  la cantidad del materialEmpresa que hay.</value>
        public int Stock{get;set;}

        /// <summary>
        /// Lugar del stock del materialEmpresa
        /// </summary>
        /// <value>Se almacena el lugar donde esta el stock del materialEmpresa que hay.</value>
        public Location Location {get;set;}


        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public CompanyStock(int stock,Location location)
        {
            this.Stock=stock;
            this.Location=location;
        }
    }

}

