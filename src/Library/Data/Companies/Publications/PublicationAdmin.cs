using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Clase para administrar las publicaciones
    /// </summary>
    public sealed class PublicationAdmin : DataAdmin<Publication>
    {
        /// <summary>
        /// Obtiene una lista de publicaciones filtrada por la empresa que las realizó.
        /// </summary>
        /// <param name="companyId">Id de la empresa por la cual se busca filtrar la lista.</param>
        /// <returns>Listado de Ids de todas las publicaciones pertenecientes a la empresa.</returns>
        public IReadOnlyCollection<int> GetPublicationsByCompany(int companyId)
        {
            List<int> resultList = new List<int>();
            IReadOnlyCollection<Publication> publications = this.Items;
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
        public IReadOnlyCollection<int> GetPublicationsByCompany(int companyId, int itemCount, int page)
        {
            List<Publication> resultList = new List<Publication>();
            IReadOnlyCollection<Publication> publications = this.Items;
            foreach (Publication pub in publications)
            {
                if (pub.CompanyId == companyId)
                {
                    resultList.Add(pub);
                }
            }

            IReadOnlyCollection<Publication> publicationsPage = this.GetItemPage(resultList.AsReadOnly(), itemCount, page);
            return publicationsPage.Select(pub => pub.Id).ToList().AsReadOnly();
        }

        /// <summary>
        /// Obtiene una lista de publicaciones filtrada por el material de empresa.
        /// </summary>
        /// <param name="compMatId">Id del material de empresa.</param>
        /// <returns>Listado de Ids de todas las publicaciones encontradas.</returns>
        public IReadOnlyCollection<int> GetPublicationsWithCompanyMaterial(int compMatId)
        {
            List<int> resultList = new List<int>();
            IReadOnlyCollection<Publication> publications = this.Items;
            foreach (Publication pub in publications)
            {
                if (pub.CompanyMaterialId == compMatId)
                {
                    resultList.Add(pub.Id);
                }
            }

            return resultList.AsReadOnly();
        }

        /// <inheritdoc/>
        protected override void ValidateData(Publication item)
        {
            DataManager dataManager = new DataManager();
            if(item.CompanyId == 0/* || !dataManager.Company.Exists(item.CompanyId)*/) 
                throw new ValidationException("Requerida compania publicante.");
            if(item.CompanyMaterialId == 0/* || !dataManager.CompanyMaterial.Exists(item.CompanyMaterialId)*/) 
                throw new ValidationException("Requerido material de empresa publicado.");
            if(item.Currency == 0) 
                throw new ValidationException("Requerida moneda.");
            if(item.Price == 0) 
                throw new ValidationException("Requerido precio de venta.");
            if(item.ActiveFrom == DateTime.MinValue) 
                throw new ValidationException("Requerida fecha para inicio de validez.");
            if(item.ActiveUntil == DateTime.MinValue) 
                throw new ValidationException("Requerida fecha para final de validez.");
        }
    }
}