using System;
using System.Collections.Generic;
using System.Collections;
using ClassLibrary;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary

{    
    /// <summary>
    /// clase que representa los emprendedores
    /// </summary>
    public class Entrepreneur: IManagableData<Entrepreneur>
    {
        /// <summary>
        /// constructor de emprendedor
        /// </summary>
        /// <param name="name">nombre del emprendedor</param>
        /// <param name="user">usuario del emprendedor</param>
        /// <param name="id">id del emprendedor</param>
        /// <param name="trade">en que se especializa el emprendedor</param>
        public Entrepreneur(string name,User user,int id, string trade)
        {
            this.Name =name;
            this.User= user;
            this.Id = id;
            this.Trade = trade;
            this.Deleted= false;
        }
        /// <summary>
        /// constructor vacio de emprendedor
        /// </summary>
        public Entrepreneur()
        {

        }
        /// <summary>
        /// lista de la locacion georeferenciada de el emprendedor
        /// </summary>
    
        /// <returns>lista de ubicaciones</returns>
        [JsonInclude]
        public List<Location> Locations  = new List<Location>();
        /// <summary>
        /// usuario del emprendedor
        /// </summary>
        /// <value>Almacenamos el usuario en un objeto tipo user</value>
        public User User {get;set;}
        /// <summary>
        /// nombre del emprendedor
        /// </summary>
        /// <value>almacenamos el nombre en un string</value>

        public string Name  {get;set;}
        /// <summary>
        /// oficio del emprendedor
        /// </summary>
        /// <value>almacenamos el oficio en un String</value>
        public string Trade {get;set;}
        /// <summary>
        /// id del emprendedor
        /// </summary>
        /// <value>almacenamos el id en un int</value>
        public int Id {get;set;}
        /// <summary>
        /// verificar si esta activo o no
        /// </summary>
        /// <value>si la compania fue eliminada<c>true</c>
        ///  en caso contrario <c>false</c> </value>
        public bool Deleted {get;set;}
        /// <summary>
        /// metodo para añadir una ubicacion a la company
        /// </summary>
        /// <param name="Location">location de la company</param>
        public void AddLocation(Location Location)
        {
            this.Locations.Add(Location);
        }
        /// <summary>
        /// quitar de la lista la ubicacion de la empresa
        /// </summary>
        /// <param name="Location">ex location de la company</param>
        public void RemoveLocation(Location Location)
        {
            this.Locations.Remove(Location);
        }   

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            Entrepreneur emprendedor=JsonSerializer.Deserialize<Entrepreneur>(json);
            this.Id=emprendedor.Id;
            this.Name=emprendedor.Name;
            this.User= emprendedor.User;            
            this.Deleted=emprendedor.Deleted;
            this.Trade=emprendedor.Trade;
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Entrepreneur Clone()
        {
            Entrepreneur emprendedor =new Entrepreneur();
            emprendedor.LoadFromJson(this.ConvertToJson());
            return emprendedor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }   
    }
}