using System;
using System.Collections.Generic;
using System.Collections;
using ClassLibrary;

namespace Library

{    
    /// <summary>
    /// Esta clase representa Entrepreneur.
    /// </summary>
    public class Entrepreneur
    {
        /// <summary>
        /// constructor de emprendedor
        /// </summary>
        /// <param name="name">nombre del emprendedor</param>
        /// <param name="user">usuario del emprendedor</param>
        /// <param name="id">id del emprendedor</param>
        /// <param name="trade">en que se especializa el emprendedor</param>
        public Entrepreneur(string name,Entrepreneur user,int id, string trade
        )
        {
            this.Name =Name;
            this.User= User;
            this.Id = Id;
            this.Trade = Trade;
            this.Deleted= false;
        }

        /// <summary>
        /// constructor de emprendedor vacio
        /// </summary>
        public Entrepreneur()
        {

        }
        /// <summary>
        /// lista de la locacion georeferenciada de el emprendedor
        /// </summary>
        /// <typeparam name="Locations">Locacion</typeparam>
        /// <returns>lista de ubicaciones</returns>
        public List<Locations> Locations  = new List<Locations>();
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





        
    }
}