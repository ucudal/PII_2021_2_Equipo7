using System;
using System.Collections.ObjectModel;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Test de la clase que administra las publicaciones.
    /// </summary>
    public class PublicationAdminTest
    {
        private PublicationAdmin publiAdmin = Singleton<PublicationAdmin>.Instance;


        /// <summary>
        /// Testear que los valores se ingresan en la data.
        /// </summary>
        [Test]
        public void InsertTest()
        {
            ReadOnlyCollection<Publication> items = publiAdmin.Items;

            Publication pPrueba = publiAdmin.New();

            DateTime activeFrom = DateTime.Today;
            pPrueba.ActiveFrom = activeFrom;

            DateTime activeuntil = DateTime.Today.AddMonths(3);
            pPrueba.ActiveUntil = activeuntil;

            int Price = 120;
            pPrueba.Price = Price;

            Currency currency = Currency.DolarEstadounidense;
            pPrueba.Currency = currency;

            int publi1 = publiAdmin.Insert(pPrueba);

            Assert.AreNotEqual(0,publi1);

            pPrueba = publiAdmin.GetById(publi1);

            Assert.AreEqual(activeFrom,pPrueba.ActiveFrom);
            Assert.AreEqual(activeuntil,pPrueba.ActiveUntil);
            Assert.AreEqual(Price,pPrueba.Price);
            Assert.AreEqual(currency,pPrueba.Currency);
        }

        /// <summary>
        /// Comprobar que se crea una nueva publicación.
        /// </summary>
        [Test]
        public void NewTest()
        {
            Publication pPrueba =publiAdmin.New();
            Assert.IsInstanceOf(typeof(Publication),pPrueba);
        }

        /// <summary>
        /// Comprobar que se borran los datos.
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            Publication pPrueba1 = publiAdmin.New();
            pPrueba1.ActiveFrom=DateTime.Today;
            pPrueba1.ActiveUntil=DateTime.Today.AddMonths(3);
            pPrueba1.Price=100;
            pPrueba1.Currency= Currency.DolarEstadounidense;
        
            int prueba = publiAdmin.Insert(pPrueba1);
            Assert.AreEqual(0,prueba);

            int NewId =pPrueba1.Id;
            publiAdmin.Delete(NewId);
            Assert.IsNull(publiAdmin.GetById(NewId));
        }

        /// <summary>
        /// Comprobar que funciona el update del DataAdmin.
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            Publication pPrueba = publiAdmin.New();

            DateTime activeFrom = DateTime.Today;
            pPrueba.ActiveFrom = activeFrom;

            DateTime activeuntil = DateTime.Today.AddMonths(2);
            pPrueba.ActiveUntil = activeuntil;

            int Price = 1000;
            pPrueba.Price = Price;

            Currency currency = Currency.DolarEstadounidense;
            pPrueba.Currency = currency;

            int publi1 = publiAdmin.Insert(pPrueba);

            Assert.AreNotEqual(0,publi1);

            Publication publi2 = publiAdmin.GetById(publi1);

            publi2.ActiveFrom = DateTime.Today;
            publi2.ActiveUntil = DateTime.Today.AddMonths(2);
            publi2.Price = 230;
            publi2.Currency = Currency.PesoUruguayo;

            publiAdmin.Update(publi2);

            Publication publi3 = publiAdmin.GetById(publi1);

            Assert.AreEqual(publi2.ActiveFrom,publi3.ActiveFrom);
            Assert.AreEqual(publi2.ActiveUntil,publi3.ActiveUntil);
            Assert.AreEqual(publi2.Currency,publi3.Currency);
            Assert.AreEqual(publi2.Price,publi3.Price);
            Assert.AreEqual(publi2.Id,publi3.Id);


        }

    }
}