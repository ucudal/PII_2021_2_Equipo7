
using System;
using System.Collections.Generic;
using System.Collections;

namespace Library
{

    /// <summary>
    /// clase para el rol de los usuarios
    /// </summary>
    public class Role
    {
        /// <summary>
        /// nombre del rol
        /// </summary>
        /// <value>guardo el nombre en un string</value>
        public string Name {get;set;}
        /// <summary>
        /// guardo el id en un int
        /// </summary>
        /// <value>guardo el id en un int</value>
        public string Id {get;set;}
        /// <summary>
        /// constructor de role
        /// </summary>
        /// <param name="name">nobre del rol</param>
        /// <param name="id">id del rol</param>
        public Role(String name, string id)
        {
            this.Name=name;
            this.Id=id;
        }
    }
}