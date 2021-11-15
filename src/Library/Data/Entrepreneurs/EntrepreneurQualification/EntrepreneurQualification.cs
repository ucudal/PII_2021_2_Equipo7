using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor de asociacion entre un emprendedor y sus
    /// habilitaciones.
    /// </summary>
    public class EntrepreneurQualification : IManagableData<EntrepreneurQualification>
    {
        private int id;
        private bool deleted;
        private int entrepreneurId;
        private int qualificationId;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CompanyMaterialQualification"/>.
        /// </summary>
        [JsonConstructor]
        public EntrepreneurQualification()
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
        /// Id del material de la compania.
        /// </summary>
        public int EntrepreneurId
        { 
            get => this.entrepreneurId;
            set => this.entrepreneurId = value;
        }

        /// <summary>
        /// Habilitacion asociada al material de la compania.
        /// </summary>
        public int QualificationId
        { 
            get => this.qualificationId;
            set => this.qualificationId = value;
        }

        /// <inheritdoc/>
        public EntrepreneurQualification Clone()
        {
            EntrepreneurQualification entrepreneurQualification = new EntrepreneurQualification();
            entrepreneurQualification.LoadFromJson(this.ConvertToJson());
            return entrepreneurQualification;
        }

        /// <inheritdoc/>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <inheritdoc/>
        public void LoadFromJson(string json)
        {
            EntrepreneurQualification qualification = JsonSerializer.Deserialize<EntrepreneurQualification>(json);
            this.Id = qualification.Id;
            this.Deleted = qualification.Deleted;
            this.EntrepreneurId = qualification.entrepreneurId;
            this.QualificationId = qualification.QualificationId;
        }

    }

}