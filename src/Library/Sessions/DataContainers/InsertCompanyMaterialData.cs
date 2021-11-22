// -----------------------------------------------------------------------
// <copyright file="InsertCompanyMaterialData.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor con los datos
    /// del proceso de registro
    /// para un usuario.
    /// </summary>
    public class InsertCompanyMaterialData
    {
        private CompanyMaterial companyMaterial;
        private MaterialCategory materialCategory;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InsertCompanyMaterialData"/>.
        /// </summary>
        public InsertCompanyMaterialData()
        {
        }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public CompanyMaterial CompanyMaterial { get => this.companyMaterial; set => this.companyMaterial = value; }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public MaterialCategory MaterialCategory { get => this.materialCategory; set => this.materialCategory = value; }
    }
}