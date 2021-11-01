using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace ClassLibrary
{
    /// <summary>
    /// Clase administradora de habilitaciones para un material de empresa.
    /// </summary>
    public class CompanyMaterialQualificationAdmin : DataAdmin<CompanyMaterialQualification>
    {
        /// <summary>
        /// Obtiene la lista de habilitaciones para un material de empresa por su id.
        /// </summary>
        /// <param name="companyMaterialId">
        /// Id del material de empresa por el cual buscar habilitaciones. </param>
        /// <returns>
        /// Listado de Ids para cada habilitacion asociada al material de empresa.
        /// </returns>
        public ReadOnlyCollection<int> GetQualificationsForCompanyMaterial(int companyMaterialId)
        {
            List<int> resultList = new List<int>();
            ReadOnlyCollection<CompanyMaterialQualification> qualifications = this.Items;
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
        public ReadOnlyCollection<int> GetQualificationsForCompanyMaterial(int companyMaterialId, int itemCount, int page)
        {
            List<CompanyMaterialQualification> resultList = new List<CompanyMaterialQualification>();
            ReadOnlyCollection<CompanyMaterialQualification> qualifications = this.Items;
            foreach (CompanyMaterialQualification qualification in qualifications)
            {
                if (qualification.CompanyMatId == companyMaterialId)
                {
                    resultList.Add(qualification);
                }
            }

            List<CompanyMaterialQualification> qualificationsPage = this.GetItemPage(resultList, itemCount, page);
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
            ReadOnlyCollection<CompanyMaterialQualification> qualifications = this.Items;
            foreach (CompanyMaterialQualification qualification in qualifications)
            {
                if (qualification.CompanyMatId == companyMatId && qualification.QualificationId == qualificationId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}