using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa Usuarios.
    /// </summary>
    public class User:IManagableData<User>
    {

        /// <summary>
        /// Identificador de cada Usuario
        /// </summary>
        public int Id{get;set;}

        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        /// <value>Almacenamos el nombre del Usuario en un string</value>
        public string FirstName{get;set;}

        /// <summary>
        /// Apellido del Usuario
        /// </summary>
        /// <value>Almacenamos el apellido del Usuario en un string</value>
        public  string LastName{get;set;}
    
        /// <summary>
        /// Obtiene un valor que indica si el usuario fue eliminado
        /// </summary>
        /// <value><c>true</c> si el usuario fue eliminado, <c>false</c> en caso contrario.</value>
        public bool Deleted{get;set;}
        
        /// <summary>
        /// Rol del Usuario
        /// </summary>
        /// <value>Almacenamos el rol del Usuario en un objeto de tipo Role</value>
        public UserRole Role{get;set;}

        /// <summary>
        /// Lista de cuentas
        /// </summary>
        /// <value>Almacenamos en una lista llamada Accounts todas las cuentas</value>
        
        [JsonInclude]
        public List<Account> Accounts{get;set;}

        /// <summary>
        /// Constructor de la clase.
        /// </summary>

        [JsonConstructor]
        public User(int id, string firstName,string lastName, UserRole role)
        {
            this.Id=id;
            this.FirstName=firstName;
            this.LastName=lastName;
            this.Deleted=false;
            this.Role=role;
            this.Accounts=new List<Account>();

        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public User()
        {

        }

        public void LoadFromJson(string json)
        {
            User user=JsonSerializer.Deserialize<User>(json);
            this.Id=user.Id;
            this.FirstName=user.FirstName;
            this.LastName=user.LastName;
            this.Deleted=user.Deleted;
            this.Role=user.Role;
            this.Accounts=user.Accounts;
        }

        public User Clone()
        {
            User usuario=new User();
            usuario.LoadFromJson(this.ConvertToJson());
            return usuario;
        }

        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}