// -----------------------------------------------------------------------
// <copyright file="CompanyMaterialQualification.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor de asociacion entre un material de empresa y sus
    /// habilitaciones requeridas.
    /// </summary>
    public class CompanyMaterialQualification : IManagableData<CompanyMaterialQualification>
    {
        private int id;
        private bool deleted;
        private int companyMatId;
        private int qualificationId;
        private DataManager dataManager;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CompanyMaterialQualification"/>.
        /// </summary>
        [JsonConstructor]
        public CompanyMaterialQualification()
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
        public int CompanyMatId
        {
            get => this.companyMatId;
            set => this.companyMatId = value;
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
        public CompanyMaterialQualification Clone()
        {
            CompanyMaterialQualification qualification = new CompanyMaterialQualification();
            qualification.LoadFromJson(this.ConvertToJson());
            return qualification;
        }

        /// <inheritdoc/>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <inheritdoc/>
        public void LoadFromJson(string json)
        {
            CompanyMaterialQualification qualification = JsonSerializer.Deserialize<CompanyMaterialQualification>(json);
            this.Id = qualification.Id;
            this.Deleted = qualification.Deleted;
            this.CompanyMatId = qualification.CompanyMatId;
            this.QualificationId = qualification.QualificationId;
        }
    }
}