
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Registro que contiene una asociacion
    /// entre empresea y localizacion por
    /// geo referencia.
    /// </summary>
    public class CompanyLocation : IManagableData<CompanyLocation>
    {
        private int id;
        private bool deleted;
        private int companyId;
        private string geoReference;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CompanyLocation"/>.
        /// </summary>
        [JsonConstructor]
        public CompanyLocation()
        {
            this.Id = 0;
            this.Deleted = false;
        }

        /// <inheritdoc/>
        public int Id
        { 
            get => this.id;
            set => this.id = value;
        }

        /// <inheritdoc/>
        public bool Deleted
        { 
            get => this.deleted;
            set => this.deleted = value;
        }

        /// <summary>
        /// Identificador de la
        /// compania asociada a
        /// la localizacion.
        /// </summary>
        public int CompanyId
        { 
            get => this.companyId;
            set => this.companyId = value;
        }

        /// <summary>
        /// Geo referencia de la
        /// localizacion.
        /// </summary>
        public string GeoReference
        { 
            get => this.geoReference;
            set => this.geoReference = value;
        }

        /// <inheritdoc/>
        public CompanyLocation Clone()
        {
            CompanyLocation location = new CompanyLocation();
            location.LoadFromJson(this.ConvertToJson());
            return location;
        }

        /// <inheritdoc/>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <inheritdoc/>
        public void LoadFromJson(string json)
        {
            CompanyLocation location = JsonSerializer.Deserialize<CompanyLocation>(json);
            this.Id = location.Id;
            this.Deleted = location.Deleted;
            this.CompanyId = location.CompanyId;
            this.GeoReference = location.GeoReference;
        }
    }
}