using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase para administrar las publicaciones
    /// </summary>
    public class PublicationAdmin : DataAdmin<Publication>
    {
        /// <summary>
        /// Obtiene una lista de publicaciones filtrada por la empresa que las realizó.
        /// </summary>
        /// <param name="companyId">Id de la empresa por la cual se busca filtrar la lista.</param>
        /// <returns>Listado de Ids de todas las publicaciones pertenecientes a la empresa.</returns>
        public ReadOnlyCollection<int> GetPublicationsByCompany(int companyId)
        {
            List<int> resultList = new List<int>();
            ReadOnlyCollection<Publication> publications = this.Items;
            foreach (Publication pub in publications)
            {
                if (pub.CompanyId == companyId)
                {
                    resultList.Add(pub.Id);
                }
            }

            return resultList.AsReadOnly();
        }


        /// <summary>
        /// Obtiene una lista de publicaciones filtrada por la empresa que las realizó.
        /// </summary>
        /// <param name="companyId">Id de la empresa por la cual se busca filtrar la lista.</param>
        /// <param name="itemCount">Cantidad de items por hoja.</param>
        /// <param name="page">Hoja la cual recuperar.</param>
        /// <returns>Listado de Ids de todas las publicaciones pertenecientes a la empresa.</returns>
        public ReadOnlyCollection<int> GetPublicationsByCompany(int companyId, int itemCount, int page)
        {
            List<Publication> resultList = new List<Publication>();
            ReadOnlyCollection<Publication> publications = this.Items;
            foreach (Publication pub in publications)
            {
                if (pub.CompanyId == companyId)
                {
                    resultList.Add(pub);
                }
            }

            List<Publication> publicationsPage = this.GetItemPage(resultList, itemCount, page);
            return publicationsPage.Select(pub => pub.Id).ToList().AsReadOnly();
        }

    }
}