using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="CompanyMaterial"/>.
    /// </summary>
     public class CompanyMaterialTest
    {
        /// <summary>
        /// test de el constructor
        /// </summary>
       [Test] 
        public void TestConstructor()
        {
            int id = 1;
            string name="nombre material";
            
            DateTime hoy = DateTime.Today;
            MaterialCategory material = new MaterialCategory(2,"categoria x");
            CompanyMaterial companiaMaterial = new CompanyMaterial(id,name,hoy,10,material);
            Assert.AreEqual(name,companiaMaterial.Name);
            Assert.AreEqual(id,companiaMaterial.Id);
            Assert.AreEqual(hoy,companiaMaterial.LastRestock);
            Assert.AreEqual(hoy,companiaMaterial.LastRestock);
        }
        /// <summary>
        /// test para comprobar que el atributo deleted en
        ///  company material es verdadero cuando se aplica 
        /// el test
        /// </summary>
        [Test] 
        public void RemoveCompanyMaterialTest()
        {
            int id = 1;
            string name="nombre material";
            DateTime hoy = DateTime.Today;
            MaterialCategory material = new MaterialCategory(2,"categoria x");

            CompanyMaterial companiaMaterial = new CompanyMaterial(id,name,hoy,10,material);

            var anterior = companiaMaterial.Deleted;
            companiaMaterial.RemoveCompanyMaterial();

            Assert.AreNotEqual(anterior,companiaMaterial.Deleted);



        }

         /// <summary>
        /// test para añadir una cualification de company material
        /// </summary>
       [Test] 
        public void AddQualificationTest()
        {
            int id = 1;
            string name="nombre material";
            
            DateTime hoy = DateTime.Today;
            MaterialCategory material = new MaterialCategory(2,"categoria x");
            CompanyMaterial companiaMaterial = new CompanyMaterial(id,name,hoy,10,material);
            Qualification permiso = new Qualification("permiso x");
            int cantidad=companiaMaterial.Qualifications.Count;
            companiaMaterial.AddQualification(permiso);
 
            Assert.AreEqual((cantidad + 1),companiaMaterial.Qualifications.Count );
            Assert.Contains(permiso, companiaMaterial.Qualifications);
        }
         /// <summary>
        /// test para eliminar un permiso de company material
        /// </summary>
       [Test] 
        public void RemoveQualificationTest()
        {
            int id = 1;
            string name="nombre material";
            
            DateTime hoy = DateTime.Today;
            MaterialCategory material = new MaterialCategory(2,"categoria x");
            CompanyMaterial companiaMaterial = new CompanyMaterial(id,name,hoy,10,material);

            Qualification permiso = new Qualification("permiso x");
            Qualification permiso2 = new Qualification("permiso x");

            companiaMaterial.AddQualification(permiso);
            companiaMaterial.AddQualification(permiso2);

            int cantidad=companiaMaterial.Qualifications.Count;

            companiaMaterial.RemoveQualification(permiso2);
            
            Assert.AreEqual((cantidad - 1),companiaMaterial.Qualifications.Count );
            
            foreach (Qualification elemento in companiaMaterial.Qualifications)
            {
                Assert.AreNotSame(permiso2, elemento );
            }
        }
        /// <summary>
        /// buacamos el stock de materiales segun la ubicacion
        /// </summary>
        [Test] 
        public void GetsStockByLocationTest()
        {
            int id = 1;
            string name="nombre material";
            
            DateTime hoy = DateTime.Today;
            MaterialCategory material = new MaterialCategory(2,"categoria x");
            CompanyMaterial companiaMaterial = new CompanyMaterial(id,name,hoy,10,material);
            Location location1 = new Location("LOCATION 1");
            Location location2 = new Location("LOCATION 2");

            CompanyStock stock1 = new CompanyStock(10,location1);
            CompanyStock stock2 = new CompanyStock(20,location2);
            companiaMaterial.StockPerLocations.Add(stock1);
            companiaMaterial.StockPerLocations.Add(stock2);
            Assert.AreEqual(10,companiaMaterial.GetStockForLocation(location1));
            Assert.AreEqual(20,companiaMaterial.GetStockForLocation(location1));


        }
        /// <summary>
        /// 
        /// </summary>

        [Test] 
        public void GetStockTotalTest()
        {
            int id = 1;
            string name="nombre material";
            
            DateTime hoy = DateTime.Today;
            MaterialCategory material = new MaterialCategory(2,"categoria x");
            CompanyMaterial companiaMaterial = new CompanyMaterial(id,name,hoy,10,material);
            Location location1 = new Location("LOCATION 1");
            Location location2 = new Location("LOCATION 2");

            CompanyStock stock1 = new CompanyStock(10,location1);
            CompanyStock stock2 = new CompanyStock(20,location2);
            companiaMaterial.StockPerLocations.Add(stock1);
            companiaMaterial.StockPerLocations.Add(stock2);
            Assert.AreEqual(30,companiaMaterial.GetStockTotal());
        }

        /// <summary>
        /// 
        /// </summary>

        [Test] 
        public void RestockLocationTest()
        {
            int id = 1;
            string name="nombre material";
            
            DateTime hoy = DateTime.Today;
            MaterialCategory material = new MaterialCategory(2,"categoria x");
            CompanyMaterial companiaMaterial = new CompanyMaterial(id,name,hoy,10,material);
            Location location1 = new Location("LOCATION 1");
            Location location2 = new Location("LOCATION 2");

            CompanyStock stock1 = new CompanyStock(10,location1);
            CompanyStock stock2 = new CompanyStock(20,location2);
            companiaMaterial.StockPerLocations.Add(stock1);
            companiaMaterial.StockPerLocations.Add(stock2);
            companiaMaterial.RestockLocation(location1,20);
            Assert.AreEqual(20,companiaMaterial.GetStockForLocation(location1));

        }
       

    }
}