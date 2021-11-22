// -----------------------------------------------------------------------
// <copyright file="CompanyMaterialStock.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Registro de Stock por
    /// material de empresa
    /// asociado a una localizacion
    /// de la empresa.
    /// </summary>
    public class CompanyMaterialStock : IManagableData<CompanyMaterialStock>
    {
        private int id;
        private bool deleted;
        private int companyMatId;
        private int companyLocationId;
        private int stock;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CompanyMaterialStock"/>.
        /// </summary>
        [JsonConstructor]
        public CompanyMaterialStock()
        {
            this.Id = 0;
            this.deleted = false;
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
        /// Id del material de compania
        /// al cual se le va a indicar
        /// el stock.
        /// </summary>
        public int CompanyMatId
        {
            get => this.companyMatId;
            set => this.companyMatId = value;
        }

        /// <summary>
        /// Localizacion sobre la cual
        /// se indicara el stock del
        /// material de empresa.
        /// </summary>
        public int CompanyLocationId
        {
            get => this.companyLocationId;
            set => this.companyLocationId = value;
        }

        /// <summary>
        /// Cantidad de existencias del
        /// material en su dada unidad
        /// dentro del lugar especificado.
        /// </summary>
        public int Stock
        {
            get => this.stock;
            set => this.stock = value;
        }

        /// <inheritdoc/>
        public CompanyMaterialStock Clone()
        {
            CompanyMaterialStock stock = new CompanyMaterialStock();
            stock.LoadFromJson(this.ConvertToJson());
            return stock;
        }

        /// <inheritdoc/>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <inheritdoc/>
        public void LoadFromJson(string json)
        {
            CompanyMaterialStock stock = JsonSerializer.Deserialize<CompanyMaterialStock>(json);
            this.Id = stock.Id;
            this.Deleted = stock.Deleted;
            this.CompanyMatId = stock.CompanyMatId;
            this.CompanyLocationId = stock.CompanyLocationId;
            this.Stock = stock.Stock;
        }
    }
}