using System;
using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Test de la clase que administra las publicaciones.
    /// </summary>
    public class PublicationAdminTest
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Testear que los valores se ingresan en la data.
        /// </summary>
        [Test]
        public void InsertTest()
        {
            IReadOnlyCollection<Publication> items = this.datMgr.Publication.Items;

            Publication pPrueba = this.datMgr.Publication.New();

            DateTime activeFrom = DateTime.Today;
            pPrueba.ActiveFrom = activeFrom;

            DateTime activeuntil = DateTime.Today.AddMonths(3);
            pPrueba.ActiveUntil = activeuntil;

            int Price = 120;
            pPrueba.Price = Price;

            Currency currency = Currency.DolarEstadounidense;
            pPrueba.Currency = currency;

            int compMatId = 88876;
            int compId = 11023;
            pPrueba.CompanyMaterialId = compMatId;
            pPrueba.CompanyId = compId;

            int publi1 = this.datMgr.Publication.Insert(pPrueba);

            Assert.AreNotEqual(0,publi1);

            pPrueba = this.datMgr.Publication.GetById(publi1);

            Assert.AreEqual(activeFrom,pPrueba.ActiveFrom);
            Assert.AreEqual(activeuntil,pPrueba.ActiveUntil);
            Assert.AreEqual(Price,pPrueba.Price);
            Assert.AreEqual(currency,pPrueba.Currency);
            Assert.AreEqual(compId,pPrueba.CompanyId);
            Assert.AreEqual(compMatId,pPrueba.CompanyMaterialId);
        }

        /// <summary>
        /// Comprobar que se crea una nueva publicación.
        /// </summary>
        [Test]
        public void NewTest()
        {
            Publication pPrueba =this.datMgr.Publication.New();
            Assert.IsInstanceOf(typeof(Publication),pPrueba);
        }

        /// <summary>
        /// Comprobar que se borran los datos.
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            Publication pPrueba1 = this.datMgr.Publication.New();
            pPrueba1.ActiveFrom=DateTime.Today;
            pPrueba1.ActiveUntil=DateTime.Today.AddMonths(3);
            pPrueba1.Price=100;
            pPrueba1.Currency= Currency.DolarEstadounidense;
            pPrueba1.CompanyId = 991120;
            pPrueba1.CompanyMaterialId = 9090911;
        
            int prueba = this.datMgr.Publication.Insert(pPrueba1);
            Assert.AreNotEqual(0,prueba);

            int NewId = pPrueba1.Id;
            this.datMgr.Publication.Delete(NewId);
            Assert.IsNull(this.datMgr.Publication.GetById(NewId));
        }

        /// <summary>
        /// Comprobar que funciona el update del this.datMgr.Data.
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            Publication pPrueba = this.datMgr.Publication.New();

            DateTime activeFrom = DateTime.Today;
            pPrueba.ActiveFrom = activeFrom;

            DateTime activeuntil = DateTime.Today.AddMonths(2);
            pPrueba.ActiveUntil = activeuntil;

            int Price = 1000;
            pPrueba.Price = Price;

            Currency currency = Currency.DolarEstadounidense;
            pPrueba.Currency = currency;

            int compMatId = 88876;
            int compId = 11023;
            pPrueba.CompanyMaterialId = compMatId;
            pPrueba.CompanyId = compId;

            int publi1 = this.datMgr.Publication.Insert(pPrueba);

            Assert.AreNotEqual(0,publi1);

            Publication publi2 = this.datMgr.Publication.GetById(publi1);

            publi2.ActiveFrom = DateTime.Today;
            publi2.ActiveUntil = DateTime.Today.AddMonths(2);
            publi2.Price = 230;
            publi2.Currency = Currency.PesoUruguayo;

            this.datMgr.Publication.Update(publi2);

            Publication publi3 = this.datMgr.Publication.GetById(publi1);

            Assert.AreEqual(publi2.ActiveFrom,publi3.ActiveFrom);
            Assert.AreEqual(publi2.ActiveUntil,publi3.ActiveUntil);
            Assert.AreEqual(publi2.Currency,publi3.Currency);
            Assert.AreEqual(publi2.Price,publi3.Price);
            Assert.AreEqual(publi2.CompanyMaterialId,publi3.CompanyMaterialId);
            Assert.AreEqual(publi2.CompanyId,publi3.CompanyId);
            Assert.AreEqual(publi2.Id,publi3.Id);
        }

        /// <summary>
        /// Comprobar que funciona el obtener una publicación por su id y si se guardan 
        /// en la lista de publicaciones.
        /// </summary>
        [Test]
        public void GetPublicationsByCompanyTest()
        {
            Publication pPrueba = this.datMgr.Publication.New();
            pPrueba.ActiveFrom = DateTime.Today;
            pPrueba.ActiveUntil = DateTime.Today.AddMonths(3);
            pPrueba.Price = 120;
            pPrueba.CompanyId = 1;
            pPrueba.Currency = Currency.DolarEstadounidense;
            pPrueba.CompanyMaterialId = 116340;

            Publication pPrueba1 = pPrueba.Clone();
            Publication pPrueba2 = pPrueba.Clone();

            int id1 = this.datMgr.Publication.Insert(pPrueba);
            int id2 = this.datMgr.Publication.Insert(pPrueba1);
            int id3 = this.datMgr.Publication.Insert(pPrueba2);

            Assert.AreNotEqual(0,id1);
            Assert.AreNotEqual(0,id2);
            Assert.AreNotEqual(0,id3);
            

            IReadOnlyCollection<int> lista = this.datMgr.Publication.GetPublicationsByCompany(1);

            Assert.AreEqual(3,lista.Count);
            
        }
    }
}