// -----------------------------------------------------------------------
// <copyright file="CompanyMaterialStockAdmin.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Nito.AsyncEx;
using Ucu.Poo.Locations.Client;

namespace ClassLibrary
{
    /// <summary>
    /// Administrador de datos asociado
    /// al stock por localizacion de cada
    /// material de las empresas.
    /// </summary>
    public sealed class CompanyMaterialStockAdmin : DataAdmin<CompanyMaterialStock>
    {
        /// <summary>
        /// Obtiene el stock total
        /// de un material de empresa.
        /// </summary>
        /// <param name="companyMaterialId">
        /// Id del material de empresa
        /// al cual se le quiere obtener
        /// el stock.
        /// </param>
        /// <returns>
        /// Stock total del material.
        /// </returns>
        public int GetStockTotalForCompanyMaterial(int companyMaterialId)
        {
            int result = 0;
            IReadOnlyCollection<CompanyMaterialStock> materialStocks = this.Items;
            foreach (CompanyMaterialStock materialStock in materialStocks)
            {
                if (materialStock.CompanyMatId == companyMaterialId)
                {
                    result += materialStock.Stock;
                }
            }

            return result;
        }

        /// <summary>
        /// Obtiene una lista de las
        /// localizaciones de la empresa
        /// donde hay stock del material.
        /// </summary>
        /// <param name="companyMaterialId">
        /// Id del material por el cual
        /// se quiere buscar localizaciones.
        /// </param>
        /// <returns>
        /// Listado de Ids de localizaciones
        /// de la empresa con stock del material.
        /// </returns>
        public IReadOnlyCollection<int> GetLocationsWithStockForCompanyMaterial(int companyMaterialId)
        {
            List<int> resultList = new List<int>();
            IReadOnlyCollection<CompanyMaterialStock> matStocks = this.Items;
            foreach (CompanyMaterialStock matStock in matStocks)
            {
                if (matStock.CompanyMatId == companyMaterialId && matStock.Stock > 0)
                {
                    resultList.Add(matStock.CompanyLocationId);
                }
            }

            return resultList.AsReadOnly();
        }

        /// <summary>
        /// Obtiene una lista de las
        /// localizaciones de la empresa
        /// donde hay stock del material.
        /// </summary>
        /// <param name="companyMaterialId">
        /// Id del material por el cual
        /// se quiere buscar localizaciones.
        /// </param>
        /// <param name="itemCount">
        /// Cantidad de items por hoja.
        /// </param>
        /// <param name="page">
        /// Hoja la cual recuperar.
        /// </param>
        /// <returns>
        /// Listado de Ids de localizaciones
        /// de la empresa con stock del material.
        /// </returns>
        public IReadOnlyCollection<int> GetLocationsWithStockForCompanyMaterial(int companyMaterialId, int itemCount, int page)
        {
            List<CompanyMaterialStock> resultList = new List<CompanyMaterialStock>();
            IReadOnlyCollection<CompanyMaterialStock> matStocks = this.Items;
            foreach (CompanyMaterialStock matStock in matStocks)
            {
                if (matStock.CompanyMatId == companyMaterialId && matStock.Stock > 0)
                {
                    resultList.Add(matStock);
                }
            }

            IReadOnlyCollection<CompanyMaterialStock> companyMatStockPage = this.GetItemPage(resultList.AsReadOnly(), itemCount, page);
            return companyMatStockPage.Select(matStock => matStock.CompanyLocationId).ToList().AsReadOnly();
        }

        /// <summary>
        /// Obtiene un listado de materiales
        /// de empresa con stock para una
        /// localizacion concreta de la
        /// empresa.
        /// </summary>
        /// <param name="companyLocationId">
        /// Id de la localizacion de la empresa.
        /// </param>
        /// <returns>
        /// Listado de Ids para cada material
        /// de empresa con stock en la
        /// localizacion.
        /// </returns>
        public IReadOnlyCollection<int> GetCompanyMaterialsInStockForLocation(int companyLocationId)
        {
            List<int> resultList = new List<int>();
            IReadOnlyCollection<CompanyMaterialStock> matStocks = this.Items;
            foreach (CompanyMaterialStock matStock in matStocks)
            {
                if (matStock.CompanyLocationId == companyLocationId && matStock.Stock > 0)
                {
                    resultList.Add(matStock.CompanyMatId);
                }
            }

            return resultList.AsReadOnly();
        }

        /// <summary>
        /// Obtiene el CompanyStock a partir de
        /// un id de material y un id de localidad.
        /// </summary>
        /// <param name="matId">
        /// Id del material de la empresa.
        /// </param>
        /// <param name="locId">
        /// Id de la localidad de la empresa.
        /// </param>
        /// <returns>
        /// Un objeto CompanyMaterialStock.
        /// </returns>
        public CompanyMaterialStock GetCompanyMaterialStockByMatAndLocation(int matId, int locId)
        {
            CompanyMaterialStock xretorno = null;
            foreach (CompanyMaterialStock xMatStock in this.Items)
            {
                if (xMatStock.CompanyLocationId == locId && xMatStock.CompanyMatId == matId)
                {
                    xretorno = xMatStock;
                }
            }

            return xretorno;
        }

        /// <summary>
        /// Obtiene un listado de materiales
        /// de empresa con stock para una
        /// localizacion concreta de la
        /// empresa.
        /// </summary>
        /// <param name="companyLocationId">
        /// Id de la localizacion de la empresa.
        /// </param>
        /// <param name="itemCount">
        /// Cantidad de items por hoja.
        /// </param>
        /// <param name="page">
        /// Hoja la cual recuperar.
        /// </param>
        /// <returns>
        /// Listado de Ids para cada material
        /// de empresa con stock en la
        /// localizacion.
        /// </returns>
        public IReadOnlyCollection<int> GetCompanyMaterialsInStockForLocation(int companyLocationId, int itemCount, int page)
        {
            List<CompanyMaterialStock> resultList = new List<CompanyMaterialStock>();
            IReadOnlyCollection<CompanyMaterialStock> matStocks = this.Items;
            foreach (CompanyMaterialStock matStock in matStocks)
            {
                if (matStock.CompanyLocationId == companyLocationId && matStock.Stock > 0)
                {
                    resultList.Add(matStock);
                }
            }

            IReadOnlyCollection<CompanyMaterialStock> companyMatStockPage = this.GetItemPage(resultList.AsReadOnly(), itemCount, page);
            return companyMatStockPage.Select(matStock => matStock.CompanyMatId).ToList().AsReadOnly();
        }

        /// <summary>
        /// Obtiene el id la localizacion de
        /// la empresa donde todavia hay stock
        /// de un cierto material dado.
        /// </summary>
        /// <param name="compMatId">
        /// Material de la empresa para el cual
        /// se busca conseguir la localizacion
        /// con stock mas cercana.
        /// </param>
        /// <param name="geoReference">
        /// Geo referencia contra la cual comparar
        /// las localizaciones con stock del
        /// material dado.
        /// </param>
        /// <returns>
        /// Id de la localizacion con stock
        /// del material de la empresa mas
        /// cercana a la geo referencia
        /// provista.
        /// </returns>
        public int GetClosestLocationWithMaterialStock(int compMatId, string geoReference)
        {
            DataManager dataManager = new DataManager();
            LocationApiClient locClient = new LocationApiClient();

            double closestDistance = 0;
            int closestLocationId = 0;

            IReadOnlyCollection<int> locationIds = this.GetLocationsWithStockForCompanyMaterial(compMatId);
            CompanyLocation compLoc;
            Distance distance;

            foreach (int compLocId in locationIds)
            {
                compLoc = dataManager.CompanyLocation.GetById(compLocId);
                Task<Distance> task = locClient.GetDistanceAsync(compLoc.GeoReference, geoReference);
                distance = AsyncContext.Run(() => task);

                if (closestLocationId == 0)
                {
                    closestLocationId = compLocId;
                    closestDistance = distance.TravelDistance;
                }
                else
                {
                    if (distance.TravelDistance < closestDistance)
                    {
                        closestLocationId = compLocId;
                        closestDistance = distance.TravelDistance;
                    }
                }
            }

            locClient.Dispose();
            
            return closestLocationId;
        }

        /// <inheritdoc/>
        protected override void ValidateData(CompanyMaterialStock item)
        {
            DataManager dataManager = new DataManager();
            if (item != null)
            {
                if (item.CompanyLocationId == 0/* || !dataManager.CompanyLocation.Exists(item.CompanyLocationId)*/)
                {
                    throw new ValidationException("Requerida localizacion del material.");
                }

                if (item.CompanyMatId == 0/* || !dataManager.CompanyMaterial.Exists(item.CompanyMatId)*/)
                {
                    throw new ValidationException("Requerido material de la empresa.");
                }
            }
        }
    }
}