using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Services.Location.Client;
using Nito.AsyncEx;

namespace ClassLibrary
{
    /// <summary>
    /// Administrador de datos asociado
    /// al stock por localizacion de cada
    /// material de las empresas.
    /// </summary>
    public class CompanyMaterialStockAdmin : DataAdmin<CompanyMaterialStock>
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
            ReadOnlyCollection<CompanyMaterialStock> materialStocks = this.Items;
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
        public ReadOnlyCollection<int> GetLocationsWithStockForCompanyMaterial(int companyMaterialId)
        {
            List<int> resultList = new List<int>();
            ReadOnlyCollection<CompanyMaterialStock> matStocks = this.Items;
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
        public ReadOnlyCollection<int> GetLocationsWithStockForCompanyMaterial(int companyMaterialId, int itemCount, int page)
        {
            List<CompanyMaterialStock> resultList = new List<CompanyMaterialStock>();
            ReadOnlyCollection<CompanyMaterialStock> matStocks = this.Items;
            foreach (CompanyMaterialStock matStock in matStocks)
            {
                if (matStock.CompanyMatId == companyMaterialId && matStock.Stock > 0)
                {
                    resultList.Add(matStock);
                }
            }

            List<CompanyMaterialStock> companyMatStockPage = this.GetItemPage(resultList, itemCount, page);
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
        public ReadOnlyCollection<int> GetCompanyMaterialsInStockForLocation(int companyLocationId)
        {
            List<int> resultList = new List<int>();
            ReadOnlyCollection<CompanyMaterialStock> matStocks = this.Items;
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
        public ReadOnlyCollection<int> GetCompanyMaterialsInStockForLocation(int companyLocationId, int itemCount, int page)
        {
            List<CompanyMaterialStock> resultList = new List<CompanyMaterialStock>();
            ReadOnlyCollection<CompanyMaterialStock> matStocks = this.Items;
            foreach (CompanyMaterialStock matStock in matStocks)
            {
                if (matStock.CompanyLocationId == companyLocationId && matStock.Stock > 0)
                {
                    resultList.Add(matStock);
                }
            }

            List<CompanyMaterialStock> companyMatStockPage = this.GetItemPage(resultList, itemCount, page);
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
            CompanyLocationAdmin compLocAdmin = Singleton<CompanyLocationAdmin>.Instance;
            LocationAPIClient locClient = new LocationAPIClient();

            double closestDistance = 0;
            int closestLocationId = 0;

            ReadOnlyCollection<int> locationIds = this.GetLocationsWithStockForCompanyMaterial(compMatId);
            CompanyLocation compLoc;
            Distance distance;

            foreach (int compLocId in locationIds)
            {
                compLoc = compLocAdmin.GetById(compLocId);
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

            return closestLocationId;
        }
    }
}