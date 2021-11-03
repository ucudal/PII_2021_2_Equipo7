using System;
using System.Collections.Generic;
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
        [Test]
        public void Constructor_Test()
        {
            DateTime ActiveFrom = DateTime.Now;
            DateTime ActiveUntil = DateTime.Now.AddMonths(2);
            int Price = 100;
            Currency Currency = Currency.PesoUruguayo;
            bool Deleted = false;
           
            Publication publication = new Publication(ActiveFrom, ActiveUntil,Price,Currency);

            Assert.AreEqual(ActiveFrom,publication.ActiveFrom);
            Assert.AreEqual(ActiveUntil,publication.ActiveUntil);
            Assert.AreEqual(Price,publication.Price);
            Assert.AreEqual(Currency,publication.Currency);
            Assert.AreEqual(Deleted,publication.Deleted);

        }

        /// <summary>
        /// Constructor de la clase test.
        /// </summary>
        [Test]
        public void Constructor_Test2()
        {
            DateTime ActiveFrom = DateTime.Now;
            DateTime ActiveUntil = DateTime.Now.AddDays(12);
            int Price = 78;
            Currency Currency = Currency.PesoUruguayo;
            bool Deleted = false;
           
            Publication publication = new Publication(ActiveFrom, ActiveUntil,Price,Currency);

            Assert.AreEqual(ActiveFrom,publication.ActiveFrom);
            Assert.AreEqual(ActiveUntil,publication.ActiveUntil);
            Assert.AreEqual(Price,publication.Price);
            Assert.AreEqual(Currency,publication.Currency);
            Assert.AreEqual(Deleted,publication.Deleted);

        }
    }

}