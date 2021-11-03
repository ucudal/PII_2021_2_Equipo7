using System;
using System.Collections.ObjectModel;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Conjunto de Tests para la operacion de
    /// un administrador de empresa.
    /// </summary>
    [TestFixture]
    public class CompanyAdminUserOperationTests
    {
        /// <summary>
        /// Test de creacion de una publicacion
        /// de materiales para la empresa.
        /// </summary>
        [Test]
        public void PublicationCreationTest()
        {
            CompanyAdmin compAdmin = Singleton<CompanyAdmin>.Instance;
            CompanyMaterialAdmin compMatAdmin = Singleton<CompanyMaterialAdmin>.Instance;
            PublicationAdmin pubAdmin = Singleton<PublicationAdmin>.Instance;
            ReadOnlyCollection<Publication> prevpub = pubAdmin.Items;


            // creo la company
            Company comp = compAdmin.New();

            comp.Name="nombre de la company" ;
            comp.Trade = "trade";
            
            int idComp = compAdmin.Insert(comp);


            // creo un material de compania y le paso el id de la company


            CompanyMaterial compmat = compMatAdmin.New();
            compmat.Name="material";
            compmat.CompanyId = idComp;
            compmat.DateBetweenRestocks = 100;
            compmat.LastRestock =DateTime.Now.AddMonths(-1);
            compmat.MaterialCategoryId =2;
            int idCompMat = compMatAdmin.Insert(compmat);


            // creo una publicacion 


            Publication pub = pubAdmin.New();
            pub.ActiveFrom = DateTime.Now.AddMonths(-1);
            pub.ActiveUntil = DateTime.Now.AddMonths(1);
            pub.CompanyId = idComp;


            Currency currency = Currency.DolarEstadounidense;
            pub.Currency = currency;

            int Price = 120;
            pub.Price = Price;
            int idPub = pubAdmin.Insert(pub);


            ReadOnlyCollection<Publication> postpub = pubAdmin.Items;
            int postcheck = postpub.Count;
            

            int check = prevpub.Count +1;

            Assert.AreNotEqual(0, idPub);
            Assert.AreNotEqual(0, idCompMat);

            Assert.AreEqual(check, postcheck);





        }

        /// <summary>
        /// Test de creacion de un material de
        /// la empresa.
        /// </summary>
        [Test]
        public void CompanyMaterialCreationTest()
        {
            Assert.Pass();
        }

        /// <summary>
        /// Test de añadir habilitaciones al
        /// material de la empresa.
        /// </summary>
        [Test]
        public void CompanyMaterialAddQualificationsTest()
        {
            Assert.Pass();
        }

        /// <summary>
        /// Test de añadir palabras claves
        /// a una publicacion.
        /// </summary>
        [Test]
        public void PublicationAddKeyWordsTest()
        {
            Assert.Pass();
        }

        /// <summary>
        /// Test de listar todas las ventas
        /// en un periodo de tiempo.
        /// </summary>
        [Test]
        public void SaleListTest()
        {
            Assert.Pass();
        }
    }
}