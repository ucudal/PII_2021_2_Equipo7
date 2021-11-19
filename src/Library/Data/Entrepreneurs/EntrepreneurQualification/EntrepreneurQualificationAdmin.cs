using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Clase administradora de habilitaciones para un emprendedor.
    /// </summary>
    public sealed class EntrepreneurQualificationAdmin : DataAdmin<EntrepreneurQualification>
    {
        /// <summary>
        /// Obtiene la lista de habilitaciones para un emprendedor por su id.
        /// </summary>
        /// <param name="entrepreneurId">
        /// Id del emprendedor por el cual buscar habilitaciones. </param>
        /// <returns>
        /// Listado de Ids para cada habilitacion asociada al emprendedor.
        /// </returns>
        public IReadOnlyCollection<int> GetQualificationsForEntrepreneur(int entrepreneurId)
        {
            List<int> resultList = new List<int>();
            IReadOnlyCollection<EntrepreneurQualification> qualifications = this.Items;
            foreach (EntrepreneurQualification qualification in qualifications)
            {
                if (qualification.EntrepreneurId == entrepreneurId)
                {
                    resultList.Add(qualification.Id);
                }
            }
            return resultList.AsReadOnly();
        }
        
        /// <summary>
        /// Obtiene la lista de habilitaciones para un emprendedor por su id.
        /// </summary>
        /// <param name="entrepreneurId">
        /// Id del emprendedor por el cual buscar habilitaciones.
        /// </param>
        /// <param name="itemCount">Cantidad de items por hoja.</param>
        /// <param name="page">Hoja la cual recuperar.</param>
        /// <returns>
        /// Listado de Ids para cada habilitacion asociada al emprendedor.
        /// </returns>
        public IReadOnlyCollection<int> GetQualificationsForEntrepreneur(int entrepreneurId, int itemCount, int page)
        {
            List<EntrepreneurQualification> resultList = new List<EntrepreneurQualification>();
            IReadOnlyCollection<EntrepreneurQualification> qualifications = this.Items;
            foreach (EntrepreneurQualification qualification in qualifications)
            {
                if (qualification.EntrepreneurId == entrepreneurId)
                {
                    resultList.Add(qualification);
                }
            }

            IReadOnlyCollection<EntrepreneurQualification> qualificationsPage = this.GetItemPage(resultList.AsReadOnly(), itemCount, page);
            return qualificationsPage.Select(mat => mat.Id).ToList().AsReadOnly();
        }

        /// <summary>
        /// Verifica si un emprendedor tiene una habilitacion concreta o no.
        /// </summary>
        /// <param name="entrepreneurId">Id del emprendedor por el cual buscar.</param>
        /// <param name="qualificationId"> Habilitacion la cual se busca verificar. </param>
        /// <returns>
        /// Valor booleano referenciando si el emprendedor tiene
        /// la habilitacion o no.
        /// </returns>
        public bool GetEntrepreneurHasQualification(int entrepreneurId, int qualificationId)
        {
            IReadOnlyCollection<EntrepreneurQualification> qualifications = this.Items;
            foreach (EntrepreneurQualification qualification in qualifications)
            {
                if (qualification.EntrepreneurId == entrepreneurId && qualification.QualificationId == qualificationId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        protected override void ValidateData(EntrepreneurQualification item)
        {
            DataManager dataManager = new DataManager();
            if(item.EntrepreneurId == 0/* || !dataManager.Entrepreneur.Exists(item.CompanyMatId)*/) 
                throw new ValidationException("Requerido material de la empresa.");
            if(item.QualificationId == 0/* || !dataManager.Qualification.Exists(item.QualificationId)*/) 
                throw new ValidationException("Requerida habilitacion.");
        }
    }
}