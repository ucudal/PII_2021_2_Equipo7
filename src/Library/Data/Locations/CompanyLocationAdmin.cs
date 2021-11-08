using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ClassLibrary.Services.Location.Client;
using Nito.AsyncEx;

namespace ClassLibrary
{
    /// <summary>
    /// Clase administradora de las
    /// localizaciones de una empresa.
    /// </summary>
    public sealed class CompanyLocationAdmin : DataAdmin<CompanyLocation>
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
        public IReadOnlyCollection<CompanyLocation> GetLocationsForCompany(int companyId)
        {
            List<CompanyLocation> resultList = new List<CompanyLocation>();
            IReadOnlyCollection<CompanyLocation> locations = this.Items;
            foreach (CompanyLocation location in locations)
            {
                if (location.CompanyId == companyId)
                {
                    resultList.Add(location);
                }
            }

            return resultList.AsReadOnly();
        }

        /// <summary>
        /// Obtiene un <see cref="CompanyLocation"/> con
        /// la localizacion de la empresa mas
        /// cercana a la geo referencia dada.
        /// </summary>
        /// <param name="companyId">
        /// Id de la compania para la cual se
        /// desea buscar la localizacion mas
        /// cercana.
        /// </param>
        /// <param name="geoRef">
        /// Geo referencia contra cual se quiere
        /// comparar la distancia a las localizaciones
        /// de la empresa
        /// </param>
        /// <returns>
        /// <see cref="CompanyLocation"/> con los datos
        /// de la localizacion mas cercana.
        /// </returns>
        public CompanyLocation GetClosestCompanyLocationToGeoReference(int companyId, string geoRef)
        {
            IReadOnlyCollection<CompanyLocation> compLocs = this.GetLocationsForCompany(companyId);
            LocationAPIClient locClient = new LocationAPIClient();

            double closestDistance = 0;
            CompanyLocation closestLocation = null;
            
            Distance distance;

            foreach (CompanyLocation compLoc in compLocs)
            {
                Task<Distance> task = locClient.GetDistanceAsync(compLoc.GeoReference, geoRef); 
                distance = AsyncContext.Run(() => task);

                if (closestLocation is null)
                {
                    closestLocation = compLoc;
                    closestDistance = distance.TravelDistance;
                }
                else
                {
                    if (distance.TravelDistance < closestDistance)
                    {
                        closestLocation = compLoc;
                        closestDistance = distance.TravelDistance;
                    }
                }
            }

            return closestLocation.Clone();
        }

        /// <inheritdoc/>
        protected override void ValidateData(CompanyLocation item)
        {
            DataManager dataManager = new DataManager();
            if(item.CompanyId == 0 /*|| !dataManager.Company.Exists(item.CompanyId)*/) 
                throw new ValidationException("Requerida compania valida.");
            if(item.GeoReference is null || item.GeoReference.Length == 0) 
                throw new ValidationException("Requerida geo referencia.");
        }
    }
}