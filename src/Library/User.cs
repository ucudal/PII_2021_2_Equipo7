using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa Usuarios.
    /// </summary>
    public class User
    {

        /// <summary>
        /// Identificador de cada Usuario
        /// </summary>
        /// <value>Almacenamos un numero el cual va a identificar cada materialEmpresa. Este numero se saca de la lista de materialesEmpresa</value>
        public int Id{get;set;}

        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        /// <value>Almacenamos el nombre del Usuario en un string</value>
        public string Name{get;set;}

        /// <summary>
        /// Obtiene un valor que indica si el usuario fue eliminado
        /// </summary>
        /// <value><c>true</c> si el usuario fue eliminado, <c>false</c> en caso contrario.</value>
        public bool Deleted{get;set;}
        
        /// <summary>
        /// Rol del Usuario
        /// </summary>
        /// <value>Almacenamos el rol del Usuario en un objeto de tipo Role</value>
        public Role Role{get;set;}

        /// <summary>
        /// Lista de cuentas
        /// </summary>
        /// <value>Almacenamos en una lista llamada Accounts todas las cuentas</value>
        public List<Account> Accounts{get;set;}

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public User(int id, string name,bool deleted, Role role)
        {
            this.Id=id;
            this.Name=name;
            this.Deleted=deleted;
            this.Role=role;
            this.Accounts=new List<Account>();
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public User()
        {

        }
    }
}