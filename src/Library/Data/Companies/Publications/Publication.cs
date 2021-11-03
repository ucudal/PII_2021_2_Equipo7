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
        /// Publication tiene una property de Company.
        /// </summary>
        /// <value></value>
        public int CompanyId { get; set; }


        /// <summary>
        /// Id que se la da a cada publicación.
        /// </summary>
        public  int Id{get; set;}

        /// <summary>
        /// DateTime con la fecha de activación.
        /// </summary>
        public DateTime ActiveFrom{get; set;}

        /// <summary>
        /// Datetime con la fecha de desactivación de la publicación.
        /// </summary>
        public DateTime ActiveUntil{get; set;}

        /// <summary>
        /// Precio de lo que se vende en la publicación, ya sea un material o varios.
        /// </summary>
        public int Price{get; set;}

        /// <summary>
        /// Divisa del precio del material o materiales.
        /// </summary>
        public Currency Currency{get; set;}


        /// <summary>
        ///  Deleted sirve para saber si la publicación se borra o no.
        /// </summary>
        public bool Deleted{get; set;}

        /// <summary>
        /// Constructor vacio para PublicationAdmin.
        /// </summary>
        [JsonConstructor]
        public Publication()
        {
            this.Id = 0;
            this.Deleted = false;

        }


        /// <inheritdoc/>
        public void LoadFromJson(string json)
        {
            Publication publication=JsonSerializer.Deserialize<Publication>(json);
            this.Id=publication.Id;
            this.ActiveFrom=publication.ActiveFrom;
            this.ActiveUntil=publication.ActiveUntil;
            this.Deleted=publication.Deleted;
            this.Currency=publication.Currency;
            this.Price=publication.Price;
        }

        /// <inheritdoc/>
        public Publication Clone()
        {
            Publication publication =new Publication();
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