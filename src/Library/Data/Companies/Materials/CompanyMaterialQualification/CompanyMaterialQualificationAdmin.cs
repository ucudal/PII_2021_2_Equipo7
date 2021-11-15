using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Clase administradora de habilitaciones para un material de empresa.
    /// </summary>
    public sealed class CompanyMaterialQualificationAdmin : DataAdmin<CompanyMaterialQualification>
    {
        /// <summary>
        /// Obtiene la lista de habilitaciones para un material de empresa por su id.
        /// </summary>
        /// <param name="companyMaterialId">
        /// Id del material de empresa por el cual buscar habilitaciones. </param>
        /// <returns>
        /// Listado de Ids para cada habilitacion asociada al material de empresa.
        /// </returns>
        public IReadOnlyCollection<int> GetQualificationsForCompanyMaterial(int companyMaterialId)
        {
            List<int> resultList = new List<int>();
            IReadOnlyCollection<CompanyMaterialQualification> qualifications = this.Items;
            foreach (CompanyMaterialQualification qualification in qualifications)
            {
                if (qualification.CompanyMatId == companyMaterialId)
                {
                    resultList.Add(qualification.QualificationId);
                }
            }

            return resultList.AsReadOnly();
        }
        
        /// <summary>
        /// Obtiene la lista de habilitaciones para un material de empresa por su id.
        /// </summary>
        /// <param name="companyMaterialId">
        /// Id del material de empresa por el cual buscar habilitaciones.
        /// </param>
        /// <param name="itemCount">Cantidad de items por hoja.</param>
        /// <param name="page">Hoja la cual recuperar.</param>
        /// <returns>
        /// Listado de Ids para cada habilitacion asociada al material de empresa.
        /// </returns>
        public IReadOnlyCollection<int> GetQualificationsForCompanyMaterial(int companyMaterialId, int itemCount, int page)
        {
            List<CompanyMaterialQualification> resultList = new List<CompanyMaterialQualification>();
            IReadOnlyCollection<CompanyMaterialQualification> qualifications = this.Items;
            foreach (CompanyMaterialQualification qualification in qualifications)
            {
                if (qualification.CompanyMatId == companyMaterialId)
                {
                    resultList.Add(qualification);
                }
            }

            IReadOnlyCollection<CompanyMaterialQualification> qualificationsPage = this.GetItemPage(resultList.AsReadOnly(), itemCount, page);
            return qualificationsPage.Select(mat => mat.Id).ToList().AsReadOnly();
        }

        /// <summary>
        /// Verifica si un material de empresa requiere una habilitacion concreta o no.
        /// </summary>
        /// <param name="companyMatId">Id del material de empresa por el cual buscar.</param>
        /// <param name="qualificationId"> Habilitacion la cual se busca verificar. </param>
        /// <returns>
        /// Valor booleano referenciando si el material de empresa requiere
        /// la habilitacion o no.
        /// </returns>
        public bool GetCompanyMaterialHasQualification(int companyMatId, int qualificationId)
        {
            IReadOnlyCollection<CompanyMaterialQualification> qualifications = this.Items;
            foreach (CompanyMaterialQualification qualification in qualifications)
            {
                if (qualification.CompanyMatId == companyMatId && qualification.QualificationId == qualificationId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        protected override void ValidateData(CompanyMaterialQualification item)
        {
            DataManager dataManager = new DataManager();
            if(item.CompanyMatId == 0/* || !dataManager.CompanyMaterial.Exists(item.CompanyMatId)*/) 
                throw new ValidationException("Requerido material de la empresa.");
            if(item.QualificationId == 0/* || !dataManager.Qualification.Exists(item.QualificationId)*/) 
                throw new ValidationException("Requerida habilitacion.");
        }
    }
}