using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Company"/>.
    /// </summary>
     public class CompanyTest
    {
        /// <summary>
        /// test de el constructor
        /// </summary>
       [Test] 

       public void TestConstructor()
        {
            int id = 1;
            string name="nombre compania";
            string trade ="rubro";
            Company compania = new Company(id,name,trade);
            Assert.AreEqual(name,compania.Name);
            Assert.AreEqual(id,compania.Id);
            Assert.AreEqual(trade,compania.Trade);
        }

        
        /*
        /// <summary>
        /// testa para añadir la o las locaciones de la empresa
        /// </summary>
        [Test]
        public void TestAddLocation()
        {

            string location ="Location 1";
            Location ubic = new Location(location);
            int id = 1;
            string name="nombre compania";
            string trade = "rubro";
            Company compania = new Company(id, name, trade);


            int locations =compania.Locations.Count;


            compania.AddLocation(ubic);

            Assert.AreEqual((locations + 1),compania.Locations.Count );
            Assert.Contains(ubic, compania.Locations);

        }

        /// <summary>
        /// test para eliminar una locacion de una compania
        /// creamos 2 ubicaciones y removemos una y psteriormente
        /// comprobamos que esta nos e encuentre en la lista de 
        /// locations
        /// </summary>

        [Test]
        public void TestRemoveLocations()
        {

            string location ="Location 1";
            Location ubic = new Location(location);
            Location ubic2 = new Location(location);
            int id = 1;
            string name="nombre compania";
            string trade ="rubro";
            Company compania = new Company(id,name,trade);


            compania.AddLocation(ubic2);
            compania.AddLocation(ubic);

            int locations =compania.Locations.Count;

            compania.RemoveLocation(ubic);

            Assert.AreEqual((locations - 1),compania.Locations.Count );
            foreach (Location elemento in compania.Locations)
            {
                Assert.AreNotSame(ubic, elemento );
            }

        }
        /// <summary>
        /// test para añadir un company material
        /// </summary>
       [Test] 

       public void TestAddCompanyMaterial()
        {
            Company company =new Company();
            int contador = company.CompanyMaterials.Count;
            CompanyMaterial material = new CompanyMaterial();
            company.AddCompanyMaterial(material);
            
            
            Assert.AreEqual((contador + 1),company.CompanyMaterials.Count );
            Assert.Contains(material, company.CompanyMaterials);

        }
        /// <summary>
        /// test para remover un company material
        /// </summary>

        [Test]
        public void TestRemoveCompanyMaterial()
        {

            
            CompanyMaterial material1 = new CompanyMaterial();
            CompanyMaterial material2 = new CompanyMaterial();
            int id = 1;
            string name="nombre compania";
            string trade ="rubro";
            Company compania = new Company(id,name,trade);


            compania.AddCompanyMaterial(material1);
            compania.AddCompanyMaterial(material2);

            int materiales =compania.CompanyMaterials.Count;

            compania.RemoveCompanyMaterial(material1);

            Assert.AreEqual((materiales - 1),compania.CompanyMaterials.Count );
            foreach (CompanyMaterial elemento in compania.CompanyMaterials)
            {
                Assert.AreNotSame(material1, elemento );
            }

        }
*/

        


    }

}