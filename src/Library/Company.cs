using System;
using System.Collections.Generic;
using System.Collections;

namespace Library
{    public class Company 
    {
        /// <summary>
        /// la Lista locations es una list en la cual se guardan strings
        /// que referencian a una geolocalizacion la cual se va a ser 
        /// la zona en donde se encuentre la empresa.
        /// </summary>
        /// <typeparam name="string"> parametro string</typeparam>
        /// <returns>lista de localizaciones </returns>
        private List<Locations> Locations  = new List<Locations>();
        /// <summary>
        /// constructor de la clase Company
        /// </summary>
        /// <param name="Name"> nombre de la company</param>
        /// <param name="Id">id de la company</param>
        /// <param name="Trade">trade de la company</param>
        
        public Company(string Name, int Id, string Trade)
        {
            this.Name =Name;
            this.Id = Id;
            this.Trade = Trade;
            this.Deleted= false;
            this.Companys.Add(this);
        }
        /// <summary>
        /// Lista de todas las companias disponibles
        /// </summary>
        /// <typeparam name="Company">aca que pongo</typeparam>
        /// <returns>aca que pongo</returns>
        private List<Company> Companys  = new List<Company>();
        /// <summary>
        /// lista de los materiales de la compania 
        /// </summary>
        /// <typeparam name="CompanyMaterial"></typeparam>
        /// <returns>lista de los materiales de la compania</returns>
        private List<CompanyMaterial> CompanyMaterials  = new List<CompanyMaterial>();
        /// <summary>
        /// lista de la categoria de los materiales de la compania
        /// para saber las categorias que hay en enta compania
        /// </summary>
        /// <typeparam name="CompanyMaterialCategory"></typeparam>
        /// <returns>lista de la categoria de los materiales</returns>
        
        private List<CompanyMaterialCategory> CompanyMaterialCategorys  = new List<CompanyMaterialCategory>();
        /// <summary>
        /// lista de los usuarios que van a ser los administradores de la compania
        /// </summary>
        /// <typeparam name="User"></typeparam>
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
        /// añadir a la lista la ubicacion de la empresa
        /// </summary>
        /// <param name="Location"></param>

        public void AddLocation(Location Location)
        {
            this.Locations.Add(Location);
        }
        /// <summary>
        /// quitar de la lista la ubicacion de la empresa
        /// </summary>
        /// <param name="Location"></param>
        public void RemoveLocation(Location Location)
        {
            this.Locations.Remove(Location);
        }
        /// <summary>
        /// agrega a la lista de usuarios administradores de company
        /// </summary>
        /// <param name="user"></param>
         public void AddAdminUser(User user)

        {
            this.ListAdminUsers.Add(user);
        }
        /// <summary>
        /// remueve lso usuarios de administradores
        /// </summary>
        /// <param name="user"></param>
        public void RemoveAdminUser(User user)

        {
            this.ListAdminUsers.Remove(user);
        }
        /// <summary>
        /// remueve company de la lista poniendo el valor de Deleted como true
        /// </summary>
        public void RemoveCompany()
        {
            this.Deleted= true;
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
            this.CompanyMaterials.Remove(material);
        }
        /// <summary>
        /// agrega uan nueva categoria de materiales para la empresa
        /// </summary>
        /// <param name="categoria"></param>
        public void AddCompanyMaterialCategory(CompanyMaterialCategory categoria)

        {
            this.CompanyMaterialCategorys.Add(categoria);
        }
        /// <summary>
        /// remueve las la categoria del material 
        /// </summary>
        /// <param name="categoria"></param>
        public void RemoveCompanyMaterialCategory(CompanyMaterialCategory categoria)

        {
            this.CompanyMaterialCategorys.Remove(categoria);
        }
       

    }
}
