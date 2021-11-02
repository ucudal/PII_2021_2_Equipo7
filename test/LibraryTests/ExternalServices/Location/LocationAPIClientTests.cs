using ClassLibrary;
using NUnit.Framework;
using ClassLibrary.Services.Location.Client;
using System.Collections.ObjectModel;
using Nito.AsyncEx;
using System.Threading.Tasks;

namespace Tests
{
    /// <summary>
    /// Tests de la API de localizacion.
    /// </summary>
    [TestFixture]
    public class LocationAPIClientTests
    {
        private LocationAPIClient locClient = new LocationAPIClient();
        private CompanyAdmin compAdmin = Singleton<CompanyAdmin>.Instance;
        private CompanyLocationAdmin compLocAdmin = Singleton<CompanyLocationAdmin>.Instance;
        private EntrepreneurAdmin entreAdmin = Singleton<EntrepreneurAdmin>.Instance;

        /// <summary>
        /// Test que prueba si se puede encontrar
        /// la localizacion de una empresa mas
        /// cercana al emprendedor por medio de la
        /// API de localizacion.
        /// </summary>
        [Test]
        public void CompareLocationBetweenClientAndCompany()
        {
            string locationEntrepreneur = "Av. 8 de Octubre 2738";
            string locationClosest = "Av. 8 de Octubre 2492";
            string locationExtra1 = "Guatemala 1075";
            string locationExtra2 = "Paysandú 1178";

            Company comp = compAdmin.New();
            comp.Name = "Combobulative Designs";
            comp.Trade = "Software Dev";
            int compId = compAdmin.Insert(comp);

            CompanyLocation loc;

            loc = compLocAdmin.New();
            loc.CompanyId = compId;
            loc.GeoReference = locationClosest;
            int locId = compLocAdmin.Insert(loc);
            
            loc = compLocAdmin.New();
            loc.CompanyId = compId;
            loc.GeoReference = locationExtra1;
            compLocAdmin.Insert(loc);
            
            loc = compLocAdmin.New();
            loc.CompanyId = compId;
            loc.GeoReference = locationExtra2;
            compLocAdmin.Insert(loc);

            ClassLibrary.Location location = new ClassLibrary.Location();
            location.Georeference = locationEntrepreneur;

            ReadOnlyCollection<CompanyLocation> locs = compLocAdmin.GetLocationsForCompany(compId);
            double shortestDistance = 0.0;
            int closestLocationId = 0;


            Distance distance;
            foreach (CompanyLocation compLoc in locs)
            {
                Task<Distance> task = locClient.GetDistanceAsync(compLoc.GeoReference, location.Georeference); 
                distance = AsyncContext.Run(() => task);
                if (closestLocationId == 0)
                {
                    closestLocationId = compLoc.Id;
                    shortestDistance = distance.TravelDistance;
                }
                else
                {
                    if (shortestDistance >= distance.TravelDistance)
                    {
                        closestLocationId = compLoc.Id;
                        shortestDistance = distance.TravelDistance;
                    }
                }
            }

            Assert.AreEqual(locId, closestLocationId);
        }
    }
}