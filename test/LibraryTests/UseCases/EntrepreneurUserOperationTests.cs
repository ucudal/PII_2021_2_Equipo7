// -----------------------------------------------------------------------
// <copyright file="EntrepreneurUserOperationTests.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
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
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Test de listar publicaciones.
        /// </summary>
        [Test]
        public void ListPublicationsTest()
        {
            int com_id = 12300006;
            Publication publica1 = this.datMgr.Publication.New();
            publica1.CompanyId = com_id;
            publica1.CompanyMaterialId = 11165;
            publica1.Currency = Currency.PesoUruguayo;
            publica1.Price = 987;
            publica1.ActiveFrom = DateTime.Now.AddDays(-123);
            publica1.ActiveUntil = DateTime.Now.AddDays(123);
            Publication publica2 = this.datMgr.Publication.New();
            publica2.CompanyId = com_id;
            publica2.CompanyMaterialId = 11165;
            publica2.Currency = Currency.PesoUruguayo;
            publica2.Price = 987;
            publica2.ActiveFrom = DateTime.Now.AddDays(-123);
            publica2.ActiveUntil = DateTime.Now.AddDays(123);

            this.datMgr.Publication.Insert(publica1);
            this.datMgr.Publication.Insert(publica2);

            IReadOnlyCollection<int> lista1 = this.datMgr.Publication.GetPublicationsByCompany(com_id);

            Assert.AreEqual(2, lista1.Count);
        }

        /// <summary>
        /// Test de buscar publicaciones por
        /// palabras clave.
        /// </summary>
        [Test]
        public void SearchPublicationsByKeyWords()
        {
            string keyWord1 = "test_entre-op_pub-by-keywords_1";
            string keyWord2 = "test_entre-op_pub-by-keywords_2";
            string keyWord3 = "test_entre-op_pub-by-keywords_3";
            int compId = 871;
            DateTime activeFrom = DateTime.Now.AddMonths(-1);
            DateTime activeUntil = DateTime.Now.AddMonths(1);
            Currency currency = Currency.PesoUruguayo;
            int price = 458;
            int compMatId = 127349309;

            Publication pub1 = this.datMgr.Publication.New();
            pub1.CompanyId = compId;
            pub1.ActiveFrom = activeFrom;
            pub1.ActiveUntil = activeUntil;
            pub1.Currency = currency;
            pub1.Price = price;
            pub1.CompanyMaterialId = compMatId;
            Publication pub2 = pub1.Clone();
            Publication pub3 = pub1.Clone();
            int pubId1 = this.datMgr.Publication.Insert(pub1);
            int pubId2 = this.datMgr.Publication.Insert(pub2);
            int pubId3 = this.datMgr.Publication.Insert(pub3);

            Assert.NotZero(pubId1);
            Assert.NotZero(pubId2);
            Assert.NotZero(pubId3);

            int keyWordsBefore = this.datMgr.PublicationKeyWord.Items.Count;

            PublicationKeyWord pubKeyWord;

            pubKeyWord = this.datMgr.PublicationKeyWord.New();
            pubKeyWord.PublicationId = pubId1;
            pubKeyWord.KeyWord = keyWord1;
            this.datMgr.PublicationKeyWord.Insert(pubKeyWord);
            pubKeyWord = this.datMgr.PublicationKeyWord.New();
            pubKeyWord.PublicationId = pubId3;
            pubKeyWord.KeyWord = keyWord1;
            this.datMgr.PublicationKeyWord.Insert(pubKeyWord);
            pubKeyWord = this.datMgr.PublicationKeyWord.New();
            pubKeyWord.PublicationId = pubId2;
            pubKeyWord.KeyWord = keyWord1;
            this.datMgr.PublicationKeyWord.Insert(pubKeyWord);
            pubKeyWord = this.datMgr.PublicationKeyWord.New();
            pubKeyWord.PublicationId = pubId2;
            pubKeyWord.KeyWord = keyWord2;
            this.datMgr.PublicationKeyWord.Insert(pubKeyWord);
            pubKeyWord = this.datMgr.PublicationKeyWord.New();
            pubKeyWord.PublicationId = pubId3;
            pubKeyWord.KeyWord = keyWord2;
            this.datMgr.PublicationKeyWord.Insert(pubKeyWord);
            pubKeyWord = this.datMgr.PublicationKeyWord.New();
            pubKeyWord.PublicationId = pubId3;
            pubKeyWord.KeyWord = keyWord3;
            this.datMgr.PublicationKeyWord.Insert(pubKeyWord);
            int keyWordsAfter = this.datMgr.PublicationKeyWord.Items.Count;

            int keyWordsExpected = keyWordsBefore + 6;
            Assert.AreEqual(keyWordsExpected, keyWordsAfter);

            IReadOnlyCollection<Publication> publications = this.datMgr.Publication.Items;

            List<int> keyWord1Pubs = new List<int>();
            foreach (Publication publication in publications)
            {
                if (this.datMgr.PublicationKeyWord.PublicationMatchesKeyWord(publication.Id, keyWord1))
                {
                    keyWord1Pubs.Add(publication.Id);
                }
            }

            List<int> keyWord2Pubs = new List<int>();
            foreach (Publication publication in publications)
            {
                if (this.datMgr.PublicationKeyWord.PublicationMatchesKeyWord(publication.Id, keyWord2))
                {
                    keyWord2Pubs.Add(publication.Id);
                }
            }

            List<int> keyWord3Pubs = new List<int>();
            foreach (Publication publication in publications)
            {
                if (this.datMgr.PublicationKeyWord.PublicationMatchesKeyWord(publication.Id, keyWord3))
                {
                    keyWord3Pubs.Add(publication.Id);
                }
            }

            Assert.AreEqual(3, keyWord1Pubs.Count);
            Assert.Contains(pubId1, keyWord1Pubs);
            Assert.Contains(pubId2, keyWord1Pubs);
            Assert.Contains(pubId3, keyWord1Pubs);

            Assert.AreEqual(2, keyWord2Pubs.Count);
            Assert.Contains(pubId2, keyWord2Pubs);
            Assert.Contains(pubId3, keyWord2Pubs);

            Assert.AreEqual(1, keyWord3Pubs.Count);
            Assert.Contains(pubId3, keyWord3Pubs);
        }

        /// <summary>
        /// Test de buscar publicaciones por
        /// su localizacion.
        /// </summary>
        [Test]
        public void SearchPublicationsByLocation()
        {
            Entrepreneur entre = this.datMgr.Entrepreneur.New();
            entre.Name = "Juan Carlos";
            entre.Trade = "Guitarras";
            entre.UserId = 8;
            entre.GeoReference = "Av. 8 de Octubre 2519";
            int entreId = this.datMgr.Entrepreneur.Insert(entre);

            Assert.NotZero(entreId);
            entre = this.datMgr.Entrepreneur.GetById(entreId);

            CompanyLocation compLoc1 = this.datMgr.CompanyLocation.New();
            compLoc1.CompanyId = 5;
            compLoc1.GeoReference = "Av. 8 de Octubre 2492";

            CompanyLocation compLoc2 = this.datMgr.CompanyLocation.New();
            compLoc2.CompanyId = 3;
            compLoc2.GeoReference = "Av. 18 de Julio 930";

            CompanyLocation compLoc3 = this.datMgr.CompanyLocation.New();
            compLoc3.CompanyId = 6;
            compLoc3.GeoReference = "Paysandú 1178";

            int compLocId1 = this.datMgr.CompanyLocation.Insert(compLoc1);
            int compLocId2 = this.datMgr.CompanyLocation.Insert(compLoc2);
            int compLocId3 = this.datMgr.CompanyLocation.Insert(compLoc3);

            Assert.NotZero(compLocId1);
            Assert.NotZero(compLocId2);
            Assert.NotZero(compLocId3);

            CompanyMaterial compMat1 = this.datMgr.CompanyMaterial.New();
            compMat1.CompanyId = 5;
            compMat1.DateBetweenRestocks = 5;
            compMat1.LastRestock = DateTime.Now.AddDays(-3);
            compMat1.MaterialCategoryId = 987;
            compMat1.Name = "Madera";
            int compMatId1 = this.datMgr.CompanyMaterial.Insert(compMat1);
            Assert.NotZero(compMatId1);

            CompanyMaterialStock compMatStock1 = this.datMgr.CompanyMaterialStock.New();
            compMatStock1.CompanyLocationId = compLocId1;
            compMatStock1.CompanyMatId = compMatId1;
            compMatStock1.Stock = 0;
            int compMatStockId1 = this.datMgr.CompanyMaterialStock.Insert(compMatStock1);

            CompanyMaterialStock compMatStock2 = this.datMgr.CompanyMaterialStock.New();
            compMatStock2.CompanyLocationId = compLocId2;
            compMatStock2.CompanyMatId = compMatId1;
            compMatStock2.Stock = 5;
            int compMatStockId2 = this.datMgr.CompanyMaterialStock.Insert(compMatStock2);

            CompanyMaterialStock compMatStock3 = this.datMgr.CompanyMaterialStock.New();
            compMatStock3.CompanyLocationId = compLocId3;
            compMatStock3.CompanyMatId = compMatId1;
            compMatStock3.Stock = 16;
            int compMatStockId3 = this.datMgr.CompanyMaterialStock.Insert(compMatStock3);

            Assert.NotZero(compMatStockId1);
            Assert.NotZero(compMatStockId2);
            Assert.NotZero(compMatStockId3);

            int closestLocId = this.datMgr.CompanyMaterialStock.GetClosestLocationWithMaterialStock(compMatId1, entre.GeoReference);

            Assert.AreEqual(compLocId2, closestLocId);
        }

        /// <summary>
        /// Test de buscar publicaciones por
        /// su categoria.
        /// </summary>
        [Test]
        public void SearchPublicationsByCategory()
        {
            int matCatId1 = 9871;
            int matCatId2 = 9872;

            CompanyMaterial compMat1 = this.datMgr.CompanyMaterial.New();
            compMat1.CompanyId = 5;
            compMat1.DateBetweenRestocks = 5;
            compMat1.LastRestock = DateTime.Now.AddDays(-3);
            compMat1.MaterialCategoryId = matCatId1;
            compMat1.Name = "Madera";
            int compMatId1 = this.datMgr.CompanyMaterial.Insert(compMat1);

            CompanyMaterial compMat2 = this.datMgr.CompanyMaterial.New();
            compMat2.CompanyId = 5;
            compMat2.DateBetweenRestocks = 5;
            compMat2.LastRestock = DateTime.Now.AddDays(-3);
            compMat2.MaterialCategoryId = matCatId1;
            compMat2.Name = "Plastico";
            int compMatId2 = this.datMgr.CompanyMaterial.Insert(compMat2);

            CompanyMaterial compMat3 = this.datMgr.CompanyMaterial.New();
            compMat3.CompanyId = 5;
            compMat3.DateBetweenRestocks = 5;
            compMat3.LastRestock = DateTime.Now.AddDays(-3);
            compMat3.MaterialCategoryId = matCatId2;
            compMat3.Name = "Plastico";
            int compMatId3 = this.datMgr.CompanyMaterial.Insert(compMat3);

            Assert.NotZero(compMatId1);
            Assert.NotZero(compMatId2);
            Assert.NotZero(compMatId3);

            Publication pub1 = this.datMgr.Publication.New();
            pub1.CompanyId = 5;
            pub1.ActiveFrom = DateTime.Now.AddMonths(-1);
            pub1.ActiveUntil = DateTime.Now.AddMonths(1);
            pub1.Currency = Currency.PesoUruguayo;
            pub1.Price = 458;
            pub1.CompanyMaterialId = compMatId1;
            int pubId1 = this.datMgr.Publication.Insert(pub1);

            Publication pub2 = this.datMgr.Publication.New();
            pub2.CompanyId = 5;
            pub2.ActiveFrom = DateTime.Now.AddMonths(-1);
            pub2.ActiveUntil = DateTime.Now.AddMonths(1);
            pub2.Currency = Currency.PesoUruguayo;
            pub2.Price = 458;
            pub2.CompanyMaterialId = compMatId2;
            int pubId2 = this.datMgr.Publication.Insert(pub2);

            Publication pub3 = this.datMgr.Publication.New();
            pub3.CompanyId = 5;
            pub3.ActiveFrom = DateTime.Now.AddMonths(-1);
            pub3.ActiveUntil = DateTime.Now.AddMonths(1);
            pub3.Currency = Currency.PesoUruguayo;
            pub3.Price = 458;
            pub3.CompanyMaterialId = compMatId3;
            int pubId3 = this.datMgr.Publication.Insert(pub3);

            Assert.NotZero(pubId1);
            Assert.NotZero(pubId2);
            Assert.NotZero(pubId3);

            List<int> pubsList = new List<int>();
            IReadOnlyCollection<int> pubsSubList;
            IReadOnlyCollection<int> compMatsList = this.datMgr.CompanyMaterial.GetCompanyMaterialsForCategory(matCatId1);
            foreach (int compMatId in compMatsList)
            {
                pubsSubList = this.datMgr.Publication.GetPublicationsWithCompanyMaterial(compMatId);
                foreach (int pubId in pubsSubList)
                {
                    if (!pubsList.Contains(pubId))
                    {
                        pubsList.Add(pubId);
                    }
                }
            }

            Assert.AreEqual(2, pubsList.Count);
            Assert.Contains(pubId1, pubsList);
            Assert.Contains(pubId2, pubsList);

            pubsList = new List<int>();
            compMatsList = this.datMgr.CompanyMaterial.GetCompanyMaterialsForCategory(matCatId2);
            foreach (int compMatId in compMatsList)
            {
                pubsSubList = this.datMgr.Publication.GetPublicationsWithCompanyMaterial(compMatId);
                foreach (int pubId in pubsSubList)
                {
                    if (!pubsList.Contains(pubId))
                    {
                        pubsList.Add(pubId);
                    }
                }
            }

            Assert.AreEqual(1, pubsList.Count);
            Assert.Contains(pubId3, pubsList);
        }
        /// <summary>
        /// Test de verificar si un material se
        /// regenera constantemente.
        /// </summary>
        [Test]
        public void GetIfMaterialIsConstantlyRestocked()
        {
            CompanyMaterial xcom = this.datMgr.CompanyMaterial.New();

            // Fecha que sirve para saber cuantos dias pasaron desde que se regenero
            // un material respecto a su ultima fecha.
            int diasEntreMaterial = 10;
            xcom.DateBetweenRestocks = diasEntreMaterial;
            int dias = -10;
            xcom.LastRestock = DateTime.Today.AddDays(dias);
            Assert.AreEqual(DateTime.Today.AddDays(dias), xcom.LastRestock);
            Assert.AreEqual(10, xcom.DateBetweenRestocks);
        }

        /// <summary>
        /// Test de conseguir la fecha de
        /// regeneracion de un material.
        /// </summary>
        [Test]
        public void GetMaterialRestockDate()
        {
            CompanyMaterial compa = this.datMgr.CompanyMaterial.New();
            DateTime lastRest = DateTime.Today.AddDays(-6);
            compa.LastRestock = lastRest;
            Assert.AreEqual(lastRest, compa.LastRestock);
        }

        /// <summary>
        /// Test de listar los materiales
        /// comprados en un periodo de tiempo.
        /// </summary>
        [Test]
        public void ListBoughtMaterials()
        {
            int id_entrepenur = 12002392;
            Sale venta = this.datMgr.Sale.New();
            venta.BuyerEntrepreneurId = id_entrepenur;
            venta.Currency = Currency.DolarEstadounidense;
            venta.DateTime = DateTime.Now;
            venta.Price = 123;
            venta.ProductCompanyMaterialId = 8272711;
            venta.ProductQuantity = 12;
            venta.SellerCompanyId = 99202;

            Sale venta2 = this.datMgr.Sale.New();
            venta2.BuyerEntrepreneurId = id_entrepenur;
            venta2.Currency = Currency.DolarEstadounidense;
            venta2.DateTime = DateTime.Now;
            venta2.Price = 123;
            venta2.ProductCompanyMaterialId = 8272711;
            venta2.ProductQuantity = 12;
            venta2.SellerCompanyId = 99202;

            this.datMgr.Sale.Insert(venta);
            this.datMgr.Sale.Insert(venta2);
            IReadOnlyCollection<int> lista = this.datMgr.Sale.GetSalesByBuyer(id_entrepenur);

            Assert.AreEqual(2, lista.Count);
        }
    }
}