using System;
using System.Collections.Generic;
using System.Collections;

namespace ClassLibrary
    
{    
    /// <summary>
    /// esta clase representa a la compania
    /// </summary>
    public class Company : IManagableData
    {
        /// <summary>
        /// la Lista locations es una list en la cual se guardan strings
        /// que referencian a una geolocalizacion la cual se va a ser 
        /// la zona en donde se encuentre la empresa.
        /// </summary>
        /// <returns>lista de localizaciones </returns>
        public List<Location> Locations  = new List<Location>();

        /// <summary>
        /// lista de los materiales de la compania 
        /// </summary>
        
        /// <returns>lista de los materiales de la compania</returns>
        public List<CompanyMaterial> CompanyMaterials  = new List<CompanyMaterial>();

        /// <summary>
        /// lista de los usuarios que van a ser los administradores de la compania
        /// </summary>
        
        /// <returns>lista de usuarios</returns>
        public List<User> ListAdminUsers = new List<User>();


        /// <summary>
        /// nombre de la compania
        /// </summary>
        /// <value></value>
        public string Name  {get;set;}
        /// <summary>
        /// trade de la compania 
        /// </summary>
        /// <value></value>
        public string Trade {get;set;}
        /// <summary>
        /// identificador de la compania para ser identificado adentro del programa
        /// </summary>
        /// <value></value>
        public int Id {get;set;}
        /// <summary>
        /// para saber si una compania esta eliminada 
        /// </summary>
        /// <value></value>
        public bool Deleted {get;set;}



        /// <summary>
        /// constructor de la clase Company
        /// </summary>
        /// <param name="name"> nombre de la company</param>
        /// <param name="id">id de la company</param>
        ///  <param name="trade">trade de la company</param>
        
        public Company(int id, string name, string trade)
        {
            this.Name =name;
            this.Id = id;
            this.Trade = trade;
            this.Deleted= false;
            
        }
        /// <summary>
        /// constructor vacio de company
        /// </summary>
        public Company()
        {

        }


        /// <summary>
        /// añadir locacion de la compania
        /// </summary>
        /// <param name="Location">se le pasa un objeto de tipo location como parametro</param>
        public void AddLocation(Location Location)
        {
            this.Locations.Add(Location);
        }
        /// <summary>
        /// quitar de la lista la ubicacion de la empresa
        /// </summary>
        /// <param name="Location">location pasado por parametro</param>
        public void RemoveLocation(Location Location)
        {
            this.Locations.Remove(Location);
        }
        /// <summary>
        /// agrega a la lista de usuarios administradores de company
        /// </summary>
        /// <param name="user">objeto de user pasado por parametro</param>
         public void AddAdminUser(User user)

        {
            this.ListAdminUsers.Add(user);
        }
        /// <summary>
        /// remueve lso usuarios de administradores
        /// </summary>
        /// <param name="user">objeto de usuario pasado por parametro</param>
        public void RemoveAdminUser(User user)

        {
            this.ListAdminUsers.Remove(user);
        }


        /// <summary>
        /// aggrega un material a la company situandolo en una lista
        /// </summary>
        /// <param name="material"></param>
        public void AddCompanyMaterial(CompanyMaterial material)

        {
            this.CompanyMaterials.Add(material);
        }
        /// <summary>
        /// remueve el material de la compania
        /// </summary>
        /// <param name="material"></param>
        public void RemoveCompanyMaterial(CompanyMaterial material)

        {

            if(CompanyMaterials.Contains(material)){
            this.CompanyMaterials.Remove(material);
            }
        }
      

       

    } 

}
