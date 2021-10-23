using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase para definir habilitaciones.
    /// </summary>
    public class Qualification
    {
        /// <summary>
        /// Id de habilitaciones.
        /// </summary>
        /// <value></value>
        public int Id{get; private set;}

        /// <summary>
        /// Nombre de la habilitacion.
        /// </summary>
        /// <value></value>
        string Name{get; set;}


        /// <summary>
        /// Habilita la habilitación.
        /// </summary>
        /// <value></value>
        bool Deleted{get; set;}

        /// <summary>
        /// Constructor de Qualification.
        /// </summary>
        /// <param name="Name"></param>
        public Qualification(string Name)
        {
            this.Name = Name;
            this.Deleted = false;
        }
    }
}