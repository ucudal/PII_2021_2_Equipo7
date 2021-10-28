using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Publication"/>.
    /// </summary>
    [TestFixture]
    public class PublicationTest
    {
        
        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Setup()
        { 

        }
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public void Constructor_Test()
        {
            DateTime ActiveFrom = DateTime.Now;
            DateTime ActiveUntill = DateTime.Now.AddMonths(2);
            int Price = 100;
            Currency Currency = Currency.PesoUruguayo;
            bool Deleted = false;
           
            Publication publication = new Publication(ActiveFrom, ActiveUntill,Price,Currency,Deleted);

            Assert.AreEqual(ActiveFrom,publication.ActiveFrom);
            Assert.AreEqual(ActiveUntill,publication.ActiveUntill);
            Assert.AreEqual(Price,publication.Price);
            Assert.AreEqual(Currency,publication.Currency);
            Assert.AreEqual(Deleted,publication.Deleted);

        }

        /// <summary>
        /// Test para añadir elementos a la lista CompanyMaterial
        /// </summary>
        [Test]
        public void AddItemTest()
        {

            Publication publication = new Publication();
            CompanyMaterial companyMaterial = new CompanyMaterial();
            var x = publication.ListCompanyMaterial;
            publication.ListCompanyMaterial.Add(companyMaterial);
            Assert.AreNotEqual(x,publication.ListCompanyMaterial);

        }


        /// <summary>
        /// Test para remover elementos de una lista del tipo CompanyMaterial.
        /// </summary>
        [Test]
        public void removeItem()
        {

        }


        /// <summary>
        /// Test para añadir elementos a una lista del tipo KeyWord.
        /// </summary>
        [Test]
        public void AddKeyWordTest()
        {

        }


        /// <summary>
        /// Test para remover elementos a una lista del tipo KeyWord.
        /// </summary>
        [Test]
        public void RemoveKeyWordTest()
        {

        }



    }
}