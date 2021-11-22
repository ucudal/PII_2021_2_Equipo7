// -----------------------------------------------------------------------
// <copyright file="Company.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ClassLibrary
{

        public Company( int id, string name, string trade)
        {
            this.Name =name;
            this.Id = id;
            this.Trade = trade;
            this.Deleted= false;
            
        }
        /// <summary>
        /// constructor vacio de company
        /// </summary>
        [JsonConstructor]
        public Company()
        {
            this.Id = 0;
            this.Deleted = false;
        }
    /// <summary>
    /// esta clase representa a la compania
    /// </summary>
    public class Company : IManagableData<Company>
    {
        /// <summary>
        /// nombre de la compania.
        /// </summary>

        /// <value>
        /// nombre de la compania.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// trade de la compania.
        /// </summary>

        /// <value>
        /// trade de la compania.
        /// </value>
        public string Trade { get; set; }

        /// <summary>
        /// identificador de la compania para ser identificado adentro del programa.
        /// </summary>
        /// <value>identificador de la compania para ser identificado adentro del programa</value>
        public int Id { get; set; }

        /// <summary>
        /// para saber si una compania esta eliminada.
        /// </summary>
        /// <value>compania esta eliminada. </value>
        public bool Deleted { get; set; }

        /// <summary>
        /// constructor de la clase Company.
        /// </summary>
        /// <param name="name"> nombre de la company. </param>
        /// <param name="id">id de la company. </param>
        /// <param name="trade">trade de la company. </param>

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            Company compania=JsonSerializer.Deserialize<Company>(json);
            this.Id=compania.Id;
            this.Name=compania.Name;
            this.Deleted=compania.Deleted;
            this.Trade=compania.Trade;
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Company Clone()
        {
            Company company =new Company();
            company.LoadFromJson(this.ConvertToJson());
            return company;
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
