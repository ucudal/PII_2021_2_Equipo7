using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase para definir habilitaciones.
    /// </summary>
    public class Qualification : IManagableData
    {
        /// <summary>
        /// Id de habilitaciones.
        /// </summary>
        /// <value></value>
        public int Id{get; set;}

        /// <summary>
        /// Nombre de la habilitacion.
        /// </summary>
        /// <value></value>
        public string Name{get; set;}


        /// <summary>
        /// Habilita la habilitación.
        /// </summary>
        /// <value></value>
        public bool Deleted{get; set;}

        /// <summary>
        /// Constructor de Qualification.
        /// </summary>
        /// <param name="Name"></param>
        public Qualification(string Name)
        {
            this.Name = Name;
            this.Deleted = false;
        }

        /// <summary>
        /// Constructor vacio para la utilización de Qualification Admin
        /// </summary>
        public Qualification()
        {

        }
    }
}