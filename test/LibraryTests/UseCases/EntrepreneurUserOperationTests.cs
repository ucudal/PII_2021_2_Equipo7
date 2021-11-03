using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Test de listar publicaciones.
        /// </summary>
        [Test]
        public void ListPublicationsTest()
        {
            Assert.Pass();
        }
        
        /// <summary>
        /// Test de buscar publicaciones por
        /// palabras clave.
        /// </summary>
        [Test]
        public void SearchPublicationsByKeyWords()
        {
            PublicationAdmin pubAdmin = Singleton<PublicationAdmin>.Instance;
            PublicationKeyWordAdmin pubKeyWordsAdmin = Singleton<PublicationKeyWordAdmin>.Instance;

            string keyWord1 = "test_entre-op_pub-by-keywords_1";
            string keyWord2 = "test_entre-op_pub-by-keywords_2";
            string keyWord3 = "test_entre-op_pub-by-keywords_3";
            
            int compId = 871;
            DateTime activeFrom = DateTime.Now.AddMonths(-1);
            DateTime activeUntil = DateTime.Now.AddMonths(1);
            Currency currency = Currency.PesoUruguayo;
            int price = 458;

            Publication pub1 = pubAdmin.New();
            pub1.CompanyId = compId;
            pub1.ActiveFrom = activeFrom;
            pub1.ActiveUntil = activeUntil;
            pub1.Currency = currency;
            pub1.Price = price;
            
            Publication pub2 = pub1.Clone();
            Publication pub3 = pub1.Clone();

            int pubId1 = pubAdmin.Insert(pub1);
            int pubId2 = pubAdmin.Insert(pub2);
            int pubId3 = pubAdmin.Insert(pub3);

            Assert.NotZero(pubId1);
            Assert.NotZero(pubId2);
            Assert.NotZero(pubId3);

            int keyWordsBefore = pubKeyWordsAdmin.Items.Count;

            PublicationKeyWord pubKeyWord;

            pubKeyWord = pubKeyWordsAdmin.New();
            pubKeyWord.PublicationId = pubId1;
            pubKeyWord.KeyWord = keyWord1;
            pubKeyWordsAdmin.Insert(pubKeyWord);
            
            pubKeyWord = pubKeyWordsAdmin.New();
            pubKeyWord.PublicationId = pubId3;
            pubKeyWord.KeyWord = keyWord1;
            pubKeyWordsAdmin.Insert(pubKeyWord);
            
            pubKeyWord = pubKeyWordsAdmin.New();
            pubKeyWord.PublicationId = pubId2;
            pubKeyWord.KeyWord = keyWord1;
            pubKeyWordsAdmin.Insert(pubKeyWord);
            
            pubKeyWord = pubKeyWordsAdmin.New();
            pubKeyWord.PublicationId = pubId2;
            pubKeyWord.KeyWord = keyWord2;
            pubKeyWordsAdmin.Insert(pubKeyWord);
            
            pubKeyWord = pubKeyWordsAdmin.New();
            pubKeyWord.PublicationId = pubId3;
            pubKeyWord.KeyWord = keyWord2;
            pubKeyWordsAdmin.Insert(pubKeyWord);
            
            pubKeyWord = pubKeyWordsAdmin.New();
            pubKeyWord.PublicationId = pubId3;
            pubKeyWord.KeyWord = keyWord3;
            pubKeyWordsAdmin.Insert(pubKeyWord);

            int keyWordsAfter = pubKeyWordsAdmin.Items.Count;            
            int keyWordsExpected = keyWordsBefore + 6;

            Assert.AreEqual(keyWordsExpected, keyWordsAfter);

            ReadOnlyCollection<Publication> publications = pubAdmin.Items;

            List<int> keyWord1Pubs = new List<int>();
            foreach (Publication publication in publications)
            {
                if (pubKeyWordsAdmin.PublicationMatchesKeyWord(publication.Id, keyWord1))
                {
                    keyWord1Pubs.Add(publication.Id);
                }
            }

            List<int> keyWord2Pubs = new List<int>();
            foreach (Publication publication in publications)
            {
                if (pubKeyWordsAdmin.PublicationMatchesKeyWord(publication.Id, keyWord2))
                {
                    keyWord2Pubs.Add(publication.Id);
                }
            }

            List<int> keyWord3Pubs = new List<int>();
            foreach (Publication publication in publications)
            {
                if (pubKeyWordsAdmin.PublicationMatchesKeyWord(publication.Id, keyWord3))
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
            EntrepreneurAdmin entreAdmin = Singleton<EntrepreneurAdmin>.Instance;
            CompanyLocationAdmin compLocAdmin = Singleton<CompanyLocationAdmin>.Instance;
            CompanyMaterialAdmin compMatAdmin = Singleton<CompanyMaterialAdmin>.Instance;
            CompanyMaterialStockAdmin compMatStockAdmin = Singleton<CompanyMaterialStockAdmin>.Instance;

            Entrepreneur entre = entreAdmin.New();
            entre.Name = "Juan Carlos";
            entre.Trade = "Guitarras";
            entre.UserId = 8;
            entre.GeoReference = "Av. 8 de Octubre 2519";
            int entreId = entreAdmin.Insert(entre);

            Assert.NotZero(entreId);
            entre = entreAdmin.GetById(entreId);

            CompanyLocation compLoc1 = compLocAdmin.New();
            compLoc1.CompanyId = 5;
            compLoc1.GeoReference = "Av. 8 de Octubre 2492";

            CompanyLocation compLoc2 = compLocAdmin.New();
            compLoc2.CompanyId = 3;
            compLoc2.GeoReference = "Av. 18 de Julio 930";

            CompanyLocation compLoc3 = compLocAdmin.New();
            compLoc3.CompanyId = 6;
            compLoc3.GeoReference = "Paysandú 1178";

            int compLocId1 = compLocAdmin.Insert(compLoc1);
            int compLocId2 = compLocAdmin.Insert(compLoc2);
            int compLocId3 = compLocAdmin.Insert(compLoc3);

            Assert.NotZero(compLocId1);
            Assert.NotZero(compLocId2);
            Assert.NotZero(compLocId3);

            CompanyMaterial compMat1 = compMatAdmin.New();
            compMat1.CompanyId = 5;
            compMat1.DateBetweenRestocks = 5;
            compMat1.LastRestock = DateTime.Now.AddDays(-3);
            compMat1.MaterialCategoryId = 987;
            compMat1.Name = "Madera";
            int compMatId1 = compMatAdmin.Insert(compMat1);
            
            Assert.NotZero(compMatId1);

            CompanyMaterialStock compMatStock1 = compMatStockAdmin.New();
            compMatStock1.CompanyLocationId = compLocId1;
            compMatStock1.CompanyMatId = compMatId1;
            compMatStock1.Stock = 0;
            int compMatStockId1 = compMatStockAdmin.Insert(compMatStock1);

            CompanyMaterialStock compMatStock2 = compMatStockAdmin.New();
            compMatStock2.CompanyLocationId = compLocId2;
            compMatStock2.CompanyMatId = compMatId1;
            compMatStock2.Stock = 5;
            int compMatStockId2 = compMatStockAdmin.Insert(compMatStock2);

            CompanyMaterialStock compMatStock3 = compMatStockAdmin.New();
            compMatStock3.CompanyLocationId = compLocId3;
            compMatStock3.CompanyMatId = compMatId1;
            compMatStock3.Stock = 16;
            int compMatStockId3 = compMatStockAdmin.Insert(compMatStock3);

            Assert.NotZero(compMatStockId1);
            Assert.NotZero(compMatStockId2);
            Assert.NotZero(compMatStockId3);

            int closestLocId = compMatStockAdmin.GetClosestLocationWithMaterialStock(compMatId1, entre.GeoReference);

            Assert.AreEqual(compLocId2, closestLocId);
        }
        
        /// <summary>
        /// Test de buscar publicaciones por
        /// su categoria.
        /// </summary>
        [Test]
        public void SearchPublicationsByCategory()
        {
            CompanyMaterialStockAdmin compMatStockAdmin = Singleton<CompanyMaterialStockAdmin>.Instance;
            CompanyMaterialAdmin compMatAdmin = Singleton<CompanyMaterialAdmin>.Instance;
            PublicationAdmin pubAdmin = Singleton<PublicationAdmin>.Instance;

            int matCatId1 = 9871;
            int matCatId2 = 9872;

            CompanyMaterial compMat1 = compMatAdmin.New();
            compMat1.CompanyId = 5;
            compMat1.DateBetweenRestocks = 5;
            compMat1.LastRestock = DateTime.Now.AddDays(-3);
            compMat1.MaterialCategoryId = matCatId1;
            compMat1.Name = "Madera";
            int compMatId1 = compMatAdmin.Insert(compMat1);

            CompanyMaterial compMat2 = compMatAdmin.New();
            compMat2.CompanyId = 5;
            compMat2.DateBetweenRestocks = 5;
            compMat2.LastRestock = DateTime.Now.AddDays(-3);
            compMat2.MaterialCategoryId = matCatId1;
            compMat2.Name = "Plastico";
            int compMatId2 = compMatAdmin.Insert(compMat2);

            CompanyMaterial compMat3 = compMatAdmin.New();
            compMat3.CompanyId = 5;
            compMat3.DateBetweenRestocks = 5;
            compMat3.LastRestock = DateTime.Now.AddDays(-3);
            compMat3.MaterialCategoryId = matCatId2;
            compMat3.Name = "Plastico";
            int compMatId3 = compMatAdmin.Insert(compMat3);

            Assert.NotZero(compMatId1);
            Assert.NotZero(compMatId2);
            Assert.NotZero(compMatId3);

            Publication pub1 = pubAdmin.New();
            pub1.CompanyId = 5;
            pub1.ActiveFrom = DateTime.Now.AddMonths(-1);
            pub1.ActiveUntil = DateTime.Now.AddMonths(1);
            pub1.Currency = Currency.PesoUruguayo;
            pub1.Price = 458;
            pub1.CompanyMaterialId = compMatId1;
            int pubId1 = pubAdmin.Insert(pub1);

            Publication pub2 = pubAdmin.New();
            pub2.CompanyId = 5;
            pub2.ActiveFrom = DateTime.Now.AddMonths(-1);
            pub2.ActiveUntil = DateTime.Now.AddMonths(1);
            pub2.Currency = Currency.PesoUruguayo;
            pub2.Price = 458;
            pub2.CompanyMaterialId = compMatId2;
            int pubId2 = pubAdmin.Insert(pub2);

            Publication pub3 = pubAdmin.New();
            pub3.CompanyId = 5;
            pub3.ActiveFrom = DateTime.Now.AddMonths(-1);
            pub3.ActiveUntil = DateTime.Now.AddMonths(1);
            pub3.Currency = Currency.PesoUruguayo;
            pub3.Price = 458;
            pub3.CompanyMaterialId = compMatId3;
            int pubId3 = pubAdmin.Insert(pub3);

            Assert.NotZero(pubId1);
            Assert.NotZero(pubId2);
            Assert.NotZero(pubId3);

            List<int> pubsList = new List<int>();
            ReadOnlyCollection<int> pubsSubList;
            ReadOnlyCollection<int> compMatsList = compMatAdmin.GetCompanyMaterialsForCategory(matCatId1);
            foreach (int compMatId in compMatsList)
            {
                pubsSubList = pubAdmin.GetPublicationsWithCompanyMaterial(compMatId);
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
            compMatsList = compMatAdmin.GetCompanyMaterialsForCategory(matCatId2);
            foreach (int compMatId in compMatsList)
            {
                pubsSubList = pubAdmin.GetPublicationsWithCompanyMaterial(compMatId);
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
            Assert.Pass();
        }
        
        /// <summary>
        /// Test de conseguir la fecha de
        /// regeneracion de un material.
        /// </summary>
        [Test]
        public void GetMaterialRestockDate()
        {
            Assert.Pass();
        }

        /// <summary>
        /// Test de listar los materiales
        /// comprados en un periodo de tiempo.
        /// </summary>
        [Test]
        public void ListBoughtMaterials()
        {
            Assert.Pass();
        }
    }
}