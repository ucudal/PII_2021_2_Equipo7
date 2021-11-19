// -----------------------------------------------------------------------
// <copyright file="Publication.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Clase creada para crear una publicación y publicar los materiales para vender.
    /// </summary>
    public class Publication : IManagableData<Publication>
    {
        /// <summary>
        /// Constructor vacio para PublicationAdmin.
        /// </summary>
        [JsonConstructor]
        public Publication()
        {
            this.Id = 0;
            this.Deleted = false;
        }

        /// <summary>
        /// Publication tiene una property de Company.
        /// </summary>
        /// <value>.</value>
        public int CompanyId { get; set; }

        /// <summary>
        /// Id del material de empresa publicado.
        /// </summary>
        public int CompanyMaterialId { get; set; }

        /// <summary>
        /// Id que se la da a cada publicación.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// DateTime con la fecha de activación.
        /// </summary>
        public DateTime ActiveFrom { get; set; }

        /// <summary>
        /// Datetime con la fecha de desactivación de la publicación.
        /// </summary>
        public DateTime ActiveUntil { get; set; }

        /// <summary>
        /// Precio de lo que se vende en la publicación, ya sea un material o varios.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Cantidad del material.
        /// </summary>
        /// <value>.</value>
        public int Quantity { get; set; }

        /// <summary>
        /// Divisa del precio del material o materiales.
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        ///  Deleted sirve para saber si la publicación se borra o no.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        ///  Location sirve para saber donde se encuentran los materiales de la publicacion.
        /// </summary>
        public int CompanyLocationId { get; set; }

        /// <summary>
        /// Titulo de la publicacion.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Descripcion de la publicacion.
        /// </summary>
        public string Description { get; set; }

        /// <inheritdoc/>
        public void LoadFromJson(string json)
        {
            Publication publication = JsonSerializer.Deserialize<Publication>(json);
            this.Id = publication.Id;
            this.ActiveFrom = publication.ActiveFrom;
            this.ActiveUntil = publication.ActiveUntil;
            this.Deleted = publication.Deleted;
            this.Currency = publication.Currency;
            this.Price = publication.Price;
            this.CompanyId = publication.CompanyId;
            this.CompanyMaterialId = publication.CompanyMaterialId;
            this.Title = publication.Title;
            this.Description = publication.Description;
            this.CompanyLocationId = publication.CompanyLocationId;
            this.Quantity = publication.Quantity;
        }

        /// <inheritdoc/>
        public Publication Clone()
        {
            Publication publication = new Publication();
            publication.LoadFromJson(this.ConvertToJson());
            return publication;
        }

        /// <inheritdoc/>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}