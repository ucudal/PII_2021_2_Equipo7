using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Company"/>.
    /// </summary>
     public class EntrepreneurTest
    {
        /// <summary>
        /// test de el constructor
        /// </summary>
       [Test] 

       public void TestConstructor()
        {
            int id = 1;
            string name="nombre Emprendedor";
            string trade ="rubro";
            int userid = 2;
            

            
            
            Entrepreneur emprendedor  = new Entrepreneur(name,userid, id,trade);


            Assert.AreEqual(name,emprendedor.Name);
            Assert.AreEqual(id,emprendedor.Id);
            Assert.AreEqual(trade,emprendedor.Trade);
            Assert.AreEqual(userid,emprendedor.UserId);
        }
        /*
        /// <summary>
        /// añadimos la locacion del emprendedor
        /// </summary>

        [Test]
        public void TestAddLocation()
        {

            string location ="Location 1";
            Location ubic = new Location(location);
            int id = 1;
            string name="nombre emprendedor";
            string trade ="rubro";
            User usuario = new User();
            Entrepreneur emprendedor= new Entrepreneur(name,usuario,id,trade);


            int locations =emprendedor.Locations.Count;


            emprendedor.AddLocation(ubic);

            Assert.AreEqual((locations + 1),emprendedor.Locations.Count );
            Assert.Contains(ubic, emprendedor.Locations);

        }

        /// <summary>
        /// test para eliminar una locacion de un emprendedor
        /// creamos 2 ubicaciones y removemos una y Posteriormente
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
            string name="nombre emprendedor";
            string trade ="rubro";

            User usuario= new User();

            Entrepreneur emprendedor = new Entrepreneur(name,usuario,id,trade);


            emprendedor.AddLocation(ubic2);
            emprendedor.AddLocation(ubic);

            int locations =emprendedor.Locations.Count;

            emprendedor.RemoveLocation(ubic);

            Assert.AreEqual((locations - 1),emprendedor.Locations.Count );
            foreach (Location elemento in emprendedor.Locations)
            {
                Assert.AreNotSame(ubic, elemento );
            }

        }
        */

    }
}