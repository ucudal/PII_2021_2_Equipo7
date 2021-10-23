using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa las categorias de los materialesEmpresa.
    /// </summary>
    public class MaterialCategory
    {
        
        /// <summary>
        /// Identificador de cada Categoria de Material 
        /// </summary>
        /// <value>Almacenamos un numero el cual va a identificar cada Categoria de Material.</value>
        public int Id{get; set;}

        /// <summary>
        /// Nombre de cada Categoria de Material 
        /// </summary>
        /// <value>Almacenamos un nombre de cada Categoria de Material.</value>
        public string Name{get;set;}

        /// <summary>
        /// Obtiene un valor que indica si el MaterialCategory fue eliminado
        /// </summary>
        /// <value><c>true</c> si el MaterialCategory fue eliminado, <c>false</c> en caso contrario.</value>
        public bool Deleted{get;set;}

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public MaterialCategory(int id,string name)
        {
            this.Id=id;
            this.Name=name;
        }

        /// <summary>
        /// Constructor de la clase vacio
        /// </summary>
        public MaterialCategory()
        {

        }
    }
}