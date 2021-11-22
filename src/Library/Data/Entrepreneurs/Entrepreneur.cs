// -----------------------------------------------------------------------
// <copyright file="Entrepreneur.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary

{
    /// <summary>
    /// clase que representa los emprendedores
    /// </summary>
    public class Entrepreneur
    : IManagableData<Entrepreneur>
    {
        /// <summary>
        /// constructor de emprendedor.
        /// </summary>
        /// <param name="name">nombre del emprendedor.</param>
        /// <param name="userId">id de usuario del emprendedor.</param>
        /// <param name="id">id del emprendedor.</param>
        /// <param name="trade">en que se especializa el emprendedor.</param>
        public Entrepreneur(string name, int userId, int id, string trade)
        {
            this.Name = name;
            this.UserId = userId;
            this.Id = id;
            this.Trade = trade;
            this.Deleted = false;
        }

        /// <summary>
        /// constructor vacio de emprendedor.
        /// </summary>
        [JsonConstructor]
        public Entrepreneur()
        {
            this.Id = 0;
            this.Deleted = false;
        }

        /// <summary>
        /// Geo referencia de localizacion del
        /// emprendedor.
        /// </summary>
        public string GeoReference { get; set; }

        /// <summary>
        /// usuario del emprendedor.
        /// </summary>
        /// <value>Almacenamos el usuario en un objeto tipo user. </value>
        public int UserId { get; set; }

        /// <summary>
        /// nombre del emprendedor.
        /// </summary>
        /// <value>almacenamos el nombre en un string.</value>
        public string Name { get; set; }
        /// <summary>
        /// oficio del emprendedor.
        /// </summary>
        /// <value>almacenamos el oficio en un String</value>
        public string Trade { get; set; }

        /// <summary>
        /// id del emprendedor.
        /// </summary>
        /// <value>almacenamos el id en un int</value>
        public int Id { get; set; }

        /// <summary>
        /// verificar si esta activo o no.
        /// </summary>
        /// <value>si la compania fue eliminada<c>true</c>
        ///  en caso contrario <c>false</c>. </value>
        public bool Deleted { get; set; }

        /// <inheritdoc/>
        public void LoadFromJson(string json)
        {
            Entrepreneur emprendedor = JsonSerializer.Deserialize<Entrepreneur>(json);
            this.Id = emprendedor.Id;
            this.Name = emprendedor.Name;
            this.UserId = emprendedor.UserId;
            this.Deleted = emprendedor.Deleted;
            this.Trade = emprendedor.Trade;
            this.GeoReference = emprendedor.GeoReference;
        }

        /// <inheritdoc/>
        public Entrepreneur Clone()
        {
            Entrepreneur emprendedor = new Entrepreneur();
            emprendedor.LoadFromJson(this.ConvertToJson());
            return emprendedor;
        }

        /// <inheritdoc/>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}