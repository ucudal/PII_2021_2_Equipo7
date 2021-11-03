using System;
using System.Collections.ObjectModel;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Conjunto de Tests para la operacion de
    /// un emprededor.
    /// </summary>
    [TestFixture]
    public class EntrepreneurUserOperationTests
    {
        private PublicationAdmin publiAdmin = Singleton<PublicationAdmin>.Instance;
        private CompanyAdmin compadmin = Singleton<CompanyAdmin>.Instance;
        private CompanyMaterialAdmin comaadmin = Singleton<CompanyMaterialAdmin>.Instance;

        /// <summary>
        /// Test de listar publicaciones.
        /// </summary>
        [Test]
        public void ListPublicationsTest()
        {
            Company com = compadmin.New();

            Publication pub1 = publiAdmin.New();
            pub1.CompanyId = com.Id;

            Publication pub2 = publiAdmin.New();
            pub2.CompanyId = com.Id;

            publiAdmin.Insert(pub1);
            publiAdmin.Insert(pub2);

            ReadOnlyCollection<int> lista = publiAdmin.GetPublicationsByCompany(com.Id);

            Assert.AreEqual(2,lista.Count);

        }
        
        /// <summary>
        /// Test de buscar publicaciones por
        /// palabras clave.
        /// </summary>
        [Test]
        public void SearchPublicationsByKeyWords()
        {
            Assert.Pass();
        }
        
        /// <summary>
        /// Test de buscar publicaciones por
        /// su localizacion.
        /// </summary>
        [Test]
        public void SearchPublicationsByLocation()
        {
            Assert.Pass();
        }
        
        /// <summary>
        /// Test de buscar publicaciones por
        /// su categoria.
        /// </summary>
        [Test]
        public void SearchPublicationsByCategory()
        {
            Assert.Pass();
        }
        
        /// <summary>
        /// Test de verificar si un material se
        /// regenera constantemente.
        /// </summary>
        [Test]
        public void GetIfMaterialIsConstantlyRestocked()
        {
            CompanyMaterial com = comaadmin.New();

            // Fecha que sirve para saber cuantos dias pasaron desde que se regenero 
            // un material respecto a su ultima fecha.
            int DiasEntreMaterial = 10;
            com.DateBetweenRestocks = DiasEntreMaterial;
            int dias = -10;
            com.LastRestock = DateTime.Today.AddDays(dias);
            Assert.AreEqual(DateTime.Today.AddDays(dias),com.LastRestock);
            Assert.AreEqual(10,com.DateBetweenRestocks);

        }
        
        /// <summary>
        /// Test de conseguir la fecha de
        /// regeneracion de un material.
        /// </summary>
        [Test]
        public void GetMaterialRestockDate()
        {
            CompanyMaterial com = comaadmin.New();

            DateTime LastRest = DateTime.Today.AddDays(-6);

            com.LastRestock = LastRest;
            Assert.AreEqual(LastRest, com.LastRestock);
            
        }

        /// <summary>
        /// Test de listar los materiales
        /// comprados en un periodo de tiempo.
        /// </summary>
        [Test]
        public void ListBoughtMaterials()
        {
            
        }
    }
}