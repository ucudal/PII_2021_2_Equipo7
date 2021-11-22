// -----------------------------------------------------------------------
// <copyright file="CompanyAdminUserOperationTests.cs" company="Universidad Católica del Uruguay">
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
    /// un administrador de empresa.
    /// </summary>
    [TestFixture]
    public class CompanyAdminUserOperationTests
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Test de creacion de una publicacion
        /// de materiales para la empresa.
        /// </summary>
        [Test]
        public void PublicationCreationTest()
        {
            IReadOnlyCollection<Publication> prevpub = this.datMgr.Publication.Items;

            // creo la company
            Company comp = this.datMgr.Company.New();

            comp.Name = "nombre de la company";
            comp.Trade = "trade";
            int idComp = this.datMgr.Company.Insert(comp);

            // Creo un material de compania y le paso el id de la company.
            CompanyMaterial compmat = this.datMgr.CompanyMaterial.New();
            compmat.Name = "material";
            compmat.CompanyId = idComp;
            compmat.DateBetweenRestocks = 100;
            compmat.LastRestock = DateTime.Now.AddMonths(-1);
            compmat.MaterialCategoryId = 2;
            int idCompMat = this.datMgr.CompanyMaterial.Insert(compmat);

            // creo una publicacion.
            Publication pub = this.datMgr.Publication.New();
            pub.ActiveFrom = DateTime.Now.AddMonths(-1);
            pub.ActiveUntil = DateTime.Now.AddMonths(1);
            pub.CompanyId = idComp;
            pub.CompanyMaterialId = idCompMat;

            Currency currency = Currency.DolarEstadounidense;
            pub.Currency = currency;

            int price = 120;
            pub.Price = price;
            int idPub = this.datMgr.Publication.Insert(pub);

            IReadOnlyCollection<Publication> postpub = this.datMgr.Publication.Items;
            int postcheck = postpub.Count;

            int check = prevpub.Count + 1;

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
            // Agregamos una Categoria.
            string name = "Maderas";
            bool deleted = false;

            MaterialCategory materialCategory = this.datMgr.MaterialCategory.New();
            materialCategory.Name = name;
            materialCategory.Deleted = deleted;
            int materialCategoryId = this.datMgr.MaterialCategory.Insert(materialCategory);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, materialCategoryId);

            // Agregamos una company
            name = "nombre compania";
            string trade = "rubro";

            Company compania = this.datMgr.Company.New();
            compania.Name = name;
            compania.Trade = trade;
            int companyId = this.datMgr.Company.Insert(compania);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyId);

            // Agregamos una material.
            IReadOnlyCollection<CompanyMaterial> prevCompanyMaterial = this.datMgr.CompanyMaterial.Items;

            name = "Tabla de Roble";
            DateTime lastRestock = DateTime.Now.AddMonths(-1);
            int dateBetweenRestocks = 15;
            deleted = false;

            CompanyMaterial companyMaterial = this.datMgr.CompanyMaterial.New();
            companyMaterial.Name = name;
            companyMaterial.LastRestock = lastRestock;
            companyMaterial.DateBetweenRestocks = dateBetweenRestocks;
            companyMaterial.MaterialCategoryId = materialCategoryId;
            companyMaterial.CompanyId = companyId;
            companyMaterial.Deleted = deleted;
            int companyMaterialId = this.datMgr.CompanyMaterial.Insert(companyMaterial);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            int expected = prevCompanyMaterial.Count + 1;

            IReadOnlyCollection<CompanyMaterial> postCompanyMaterial = this.datMgr.CompanyMaterial.Items;

            // Validamos que se agrego un material
            Assert.AreEqual(expected, postCompanyMaterial.Count);
        }

        /// <summary>
        /// Test de añadir habilitaciones al
        /// material de la empresa.
        /// </summary>
        [Test]
        public void CompanyMaterialAddQualificationsTest()
        {
            // Agregamos una material.
            string name = "Tabla de Roble";
            DateTime lastRestock = DateTime.Now.AddMonths(-2);
            int materialCategoryId = 7;
            int companyId = 9;
            int dateBetweenRestocks = 20;
            bool deleted = false;

            CompanyMaterial companyMaterial = this.datMgr.CompanyMaterial.New();
            companyMaterial.Name = name;
            companyMaterial.LastRestock = lastRestock;
            companyMaterial.DateBetweenRestocks = dateBetweenRestocks;
            companyMaterial.MaterialCategoryId = materialCategoryId;
            companyMaterial.CompanyId = companyId;
            companyMaterial.Deleted = deleted;

            // Retorna el id con el que guardo el comapnyMaterial
            int companyMaterialId = this.datMgr.CompanyMaterial.Insert(companyMaterial);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            // Agregamos una habilitacion
            name = "Habilitacion madera";

            Qualification qualification = this.datMgr.Qualification.New();
            qualification.Name = name;

            // Retorna el id con el que guardo la habilitacion
            int qualificationId = this.datMgr.Qualification.Insert(qualification);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, qualificationId);

            // Agregamos una Habilitacion de un material.
            IReadOnlyCollection<CompanyMaterialQualification> prevCompanyMaterialQualification = this.datMgr.CompanyMaterialQualification.Items;

            deleted = false;

            CompanyMaterialQualification companyMaterialQualification = this.datMgr.CompanyMaterialQualification.New();
            companyMaterialQualification.Deleted = deleted;
            companyMaterialQualification.CompanyMatId = companyMaterialId;
            companyMaterialQualification.QualificationId = qualificationId;
            int companyMaterialQualificationId = this.datMgr.CompanyMaterialQualification.Insert(companyMaterialQualification);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialQualificationId);

            int expected = prevCompanyMaterialQualification.Count + 1;

            IReadOnlyCollection<CompanyMaterialQualification> postCompanyMaterialQualification = this.datMgr.CompanyMaterialQualification.Items;

            // Validamos que se agrego una habilitacion de un material
            Assert.AreEqual(expected, postCompanyMaterialQualification.Count);

            CompanyMaterialQualification xQualification = this.datMgr.CompanyMaterialQualification.GetById(companyMaterialQualificationId);

            // Material al que se le agrego la habilitacion para comparar
            CompanyMaterial xCompMat = this.datMgr.CompanyMaterial.GetById(xQualification.CompanyMatId);
            Assert.AreEqual(xCompMat.Id, companyMaterialId);

            // Habilitacion que se le agrego al material para comparar
            Qualification xQualif = this.datMgr.Qualification.GetById(xQualification.QualificationId);
            Assert.AreEqual(xQualif.Id, qualificationId);
        }

        /// <summary>
        /// Test de añadir palabras claves
        /// a una publicacion.
        /// </summary>
        [Test]
        public void PublicationAddKeyWordsTest()
        {
            // Creamos una publicacion a la cual le vamos a agregar palabras clave luego.
            DateTime activeFrom = DateTime.Today;
            DateTime activeuntil = DateTime.Today.AddMonths(3);
            int price = 120;
            Currency currency = Currency.DolarEstadounidense;

            Publication publication = this.datMgr.Publication.New();
            publication.CompanyId = 1235324;
            publication.CompanyMaterialId = 879374;
            publication.ActiveFrom = activeFrom;
            publication.ActiveUntil = activeuntil;
            publication.Price = price;
            publication.Currency = currency;

            // Retorna el id con el cual se inserto.
            int publicationId = this.datMgr.Publication.Insert(publication);

            // Valido que se haya añadido bien.
            Assert.AreNotEqual(0, publicationId);

            // Añadimos una keyWord1 y le asignamos esta publicacion
            PublicationKeyWord publicationKeyWord1 = this.datMgr.PublicationKeyWord.New();
            publicationKeyWord1.KeyWord = "Construcción";
            publicationKeyWord1.Deleted = false;
            publicationKeyWord1.PublicationId = publicationId;
            int publicationKeyWordId = this.datMgr.PublicationKeyWord.Insert(publicationKeyWord1);

            PublicationKeyWord xComp = this.datMgr.PublicationKeyWord.GetById(publicationKeyWordId);
            Assert.AreEqual(xComp.Id, publicationKeyWordId);

            // Me traigo la publicacion que esta asociada a esa keyWord y valido que sea igual la agregada previamente
            Publication xPub = this.datMgr.Publication.GetById(xComp.PublicationId);
            Assert.AreEqual(xPub.Id, publicationId);
        }

        /// <summary>
        /// Test de listar todas las ventas
        /// en un periodo de tiempo.
        /// </summary>
        [Test]
        public void SaleListTest()
        {
            // Agrego un entrepreneur el cual hace las compras
            string name = "Nicolas";
            string trade = "rubro";

            Entrepreneur entrepreneurBuyer = this.datMgr.Entrepreneur.New();
            entrepreneurBuyer.Name = name;
            entrepreneurBuyer.Trade = trade;
            entrepreneurBuyer.UserId = 9872347;
            entrepreneurBuyer.GeoReference = "Av Italia y Propios";
            int entrepreneurBuyerId = this.datMgr.Entrepreneur.Insert(entrepreneurBuyer);

            Assert.AreNotEqual(0, entrepreneurBuyerId);

            // Agregamos una company
            name = "nombre compania";
            trade = "rubro";

            Company compania = this.datMgr.Company.New();
            compania.Name = name;
            compania.Trade = trade;
            int companyId = this.datMgr.Company.Insert(compania);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyId);

            // Agregamos el material1 a comprar
            name = "Madera";
            DateTime lastRestock = DateTime.Now.AddMonths(-1);
            int dateBetweenRestocks = 15;
            int materialCategoryId = 2;
            bool deleted = false;

            CompanyMaterial companyMaterial = this.datMgr.CompanyMaterial.New();
            companyMaterial.Name = name;
            companyMaterial.LastRestock = lastRestock;
            companyMaterial.DateBetweenRestocks = dateBetweenRestocks;
            companyMaterial.MaterialCategoryId = materialCategoryId;
            companyMaterial.CompanyId = companyId;
            companyMaterial.Deleted = deleted;
            int companyMaterialId = this.datMgr.CompanyMaterial.Insert(companyMaterial);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            // Agregamos una venta1
            DateTime datetime = DateTime.Today;
            int price = 100;
            int quantity = 20;
            Currency currency = Currency.PesoUruguayo;

            Sale sale1 = this.datMgr.Sale.New();
            sale1.DateTime = datetime;
            sale1.Price = price;
            sale1.Currency = currency;
            sale1.ProductCompanyMaterialId = companyMaterialId;
            sale1.BuyerEntrepreneurId = entrepreneurBuyerId;
            sale1.ProductQuantity = quantity;
            sale1.SellerCompanyId = companyId;
            int sale1Id = this.datMgr.Sale.Insert(sale1);

            Assert.AreNotEqual(0, sale1Id);

            // Agregamos una venta2
            datetime = DateTime.Today;
            price = 2000;
            quantity = 500;
            currency = Currency.PesoUruguayo;

            Sale sale2 = this.datMgr.Sale.New();
            sale2.DateTime = datetime;
            sale2.Price = price;
            sale2.Currency = currency;
            sale2.ProductCompanyMaterialId = companyMaterialId;
            sale2.BuyerEntrepreneurId = entrepreneurBuyerId;
            sale2.ProductQuantity = quantity;
            sale2.SellerCompanyId = companyId;
            int sale2Id = this.datMgr.Sale.Insert(sale2);

            Assert.AreNotEqual(0, sale2Id);

            int salesExpected = 2;

            Assert.AreEqual(salesExpected, this.datMgr.Sale.GetSalesBySeller(companyId).Count);
        }
    }
}