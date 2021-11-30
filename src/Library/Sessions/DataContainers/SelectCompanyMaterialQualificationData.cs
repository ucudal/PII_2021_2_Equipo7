// -----------------------------------------------------------------------
// <copyright file="SelectCompanyMaterialQualificationData.cs" company="Universidad Católica del Uruguay">
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
    public class SelectCompanyMaterialQualificationData : ActivityData
    {
        private CompanyMaterialQualification companyMaterialQualification;
        private DataManager dataManager = new DataManager();

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        public SelectCompanyMaterialQualificationData()
        {
        }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        public CompanyMaterialQualification CompanyMaterialQualification { get => this.companyMaterialQualification; set => this.companyMaterialQualification = value; }

        /// <summary>
        /// Identificador dentro del servicio de
        /// mensajeria del usuario a registrar.
        /// </summary>
        /// <returns>retorna un bool.</returns>
        public override bool RunTask()
        {
            bool retorno = false;
            CompanyMaterialQualification matQual = this.dataManager.CompanyMaterialQualification.GetById(this.CompanyMaterialQualification.Id);
            matQual.Deleted = true;
            if (this.dataManager.CompanyMaterialQualification.Update(matQual))
            {
                retorno = true;
            }

            return retorno;
        }
    }
}