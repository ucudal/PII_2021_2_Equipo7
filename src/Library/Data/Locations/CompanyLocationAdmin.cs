using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClassLibrary
{
    /// <summary>
    /// Clase administradora de las
    /// localizaciones de una empresa.
    /// </summary>
    public class CompanyLocationAdmin : DataAdmin<CompanyLocation>
    {
        /// <summary>
        /// Obtiene una lista de localizaciones
        /// pertenecientes a una empresa.
        /// </summary>
        /// <param name="companyId">
        /// Id de la empresa por la cual
        /// buscar localizaciones.
        /// </param>
        /// <returns>
        /// Lista de localizaciones
        /// pertenecientes a la empresa
        /// por la cual se busco.
        /// </returns>
        public ReadOnlyCollection<CompanyLocation> GetLocationsForCompany(int companyId)
        {
            List<CompanyLocation> resultList = new List<CompanyLocation>();
            ReadOnlyCollection<CompanyLocation> locations = this.Items;
            foreach (CompanyLocation location in locations)
            {
                if (location.CompanyId == companyId)
                {
                    resultList.Add(location);
                }
            }

            return resultList.AsReadOnly();
        }
    }
}