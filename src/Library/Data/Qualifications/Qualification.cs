using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Clase para definir habilitaciones.
    /// </summary>
    public class Qualification : IManagableData<Qualification>
    {
        /// <summary>
        /// Id de habilitaciones.
        /// </summary>
        /// <value></value>
        public int Id{get; set;}

        /// <summary>
        /// Nombre de la habilitacion.
        /// </summary>
        /// <value></value>
        public string Name{get; set;}


        /// <summary>
        /// Habilita la habilitación.
        /// </summary>
        /// <value></value>
        public bool Deleted{get; set;}

        /// <summary>
        /// Constructor de Qualification.
        /// </summary>
        /// <param name="Name"></param>
        [JsonConstructor]
        public Qualification(string Name)
        {
            this.Name = Name;
            this.Deleted = false;
        }

        /// <summary>
        /// Constructor para la utilización de Qualification Admin
        /// </summary>
        public Qualification()
        {
            this.Id = 0;
            this.Deleted = false; 

        }

        /// <inheritdoc/>
        public void LoadFromJson(string json)
        {
            Qualification qualification=JsonSerializer.Deserialize<Qualification>(json);
            this.Id=qualification.Id;
            this.Name=qualification.Name;
            this.Deleted=qualification.Deleted;
        
        }
        

        /// <inheritdoc/>
        public Qualification Clone()
        {
            Qualification qualification =new Qualification();
            qualification.LoadFromJson(this.ConvertToJson());
            return qualification;
        }
        

        /// <inheritdoc/>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    
}