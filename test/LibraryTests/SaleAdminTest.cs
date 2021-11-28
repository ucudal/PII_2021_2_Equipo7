// -----------------------------------------------------------------------
// <copyright file="SaleAdminTest.cs" company="Universidad Católica del Uruguay">
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
    /// Test de la clase que administra las ventas.
    /// </summary>
    public class SaleAdminTest
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Testear que los valores se ingresan en la data.
        /// </summary>
        [Test]
        public void InsertTest()
        {
            Sale salePrueba = this.datMgr.Sale.New();

            DateTime datetime = DateTime.Today;
            salePrueba.DateTime = datetime;

            int price = 100;
            salePrueba.Price = price;

            Currency currency = Currency.PesoUruguayo;
            salePrueba.Currency = currency;

            int compId = 119980;
            int compMatId = 90567;
            int entreId = 36540;
            int quantity = 14;

            salePrueba.SellerCompanyId = compId;
            salePrueba.ProductCompanyMaterialId = compMatId;
            salePrueba.BuyerEntrepreneurId = entreId;
            salePrueba.ProductQuantity = quantity;

            int sale1 = this.datMgr.Sale.Insert(salePrueba);

            Assert.AreNotEqual(0, sale1);

            salePrueba = this.datMgr.Sale.GetById(sale1);

            Assert.AreEqual(datetime, salePrueba.DateTime);
            Assert.AreEqual(price, salePrueba.Price);
            Assert.AreEqual(currency, salePrueba.Currency);
            Assert.AreEqual(compId, salePrueba.SellerCompanyId);
            Assert.AreEqual(compMatId, salePrueba.ProductCompanyMaterialId);
            Assert.AreEqual(entreId, salePrueba.BuyerEntrepreneurId);
            Assert.AreEqual(quantity, salePrueba.ProductQuantity);
        }

        /// <summary>
        /// Comprobar que se crea una nueva venta.
        /// </summary>
        [Test]
        public void NewTest()
        {
            Sale saleprueba = this.datMgr.Sale.New();
            Assert.IsInstanceOf(typeof(Sale), saleprueba);
        }

        /// <summary>
        /// Comprobar que se borran los datos.
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            Entrepreneur usuario = this.datMgr.Entrepreneur.New();
            usuario.Name = "NOMBRE";
            usuario.Trade = "Rubro";
            usuario.GeoReference = "Malasia";
            usuario.UserId = 12223;

            int buyerId = this.datMgr.Entrepreneur.Insert(usuario);
            Sale saleprueba2 = this.datMgr.Sale.New();
            saleprueba2.DateTime = DateTime.Today;
            saleprueba2.Price = 100;
            saleprueba2.ProductCompanyMaterialId = 21212;
            saleprueba2.ProductQuantity = 121223;
            saleprueba2.SellerCompanyId = 2223;
            saleprueba2.Currency = Currency.DolarEstadounidense;

            saleprueba2.BuyerEntrepreneurId = buyerId;

            int saleId = this.datMgr.Sale.Insert(saleprueba2);

            this.datMgr.Sale.Delete(saleId);
            Assert.IsNull(this.datMgr.Sale.GetById(saleprueba2.Id));
        }

        /// <summary>
        /// Comprobar que funciona el update del this.datMgr.Data.
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            Sale salePrueba = this.datMgr.Sale.New();

            DateTime datetime = DateTime.Today;
            salePrueba.DateTime = datetime;

            int price = 100;
            salePrueba.Price = price;

            Currency currency = Currency.PesoUruguayo;
            salePrueba.Currency = currency;

            int compId = 119981;
            int compMatId = 56568;
            int entreId = 36541;
            int quantity = 14;

            salePrueba.SellerCompanyId = compId;
            salePrueba.ProductCompanyMaterialId = compMatId;
            salePrueba.BuyerEntrepreneurId = entreId;
            salePrueba.ProductQuantity = quantity;

            int sale1 = this.datMgr.Sale.Insert(salePrueba);

            Assert.AreNotEqual(0, sale1);

            Sale sale2 = this.datMgr.Sale.GetById(sale1);

            sale2.DateTime = DateTime.Today.AddMonths(2);
            sale2.Price = 230;
            sale2.Currency = Currency.DolarEstadounidense;
            this.datMgr.Sale.Update(sale2);

            Sale sale3 = this.datMgr.Sale.GetById(sale1);

            Assert.AreNotEqual(salePrueba.DateTime, sale3.DateTime);
            Assert.AreNotEqual(salePrueba.Currency, sale3.Currency);
            Assert.AreNotEqual(salePrueba.Price, sale3.Price);
            Assert.AreEqual(salePrueba.BuyerEntrepreneurId, sale3.BuyerEntrepreneurId);
            Assert.AreEqual(salePrueba.SellerCompanyId, sale3.SellerCompanyId);
            Assert.AreEqual(salePrueba.ProductQuantity, sale3.ProductQuantity);
            Assert.AreEqual(salePrueba.ProductCompanyMaterialId, sale3.ProductCompanyMaterialId);
        }

        /// <summary>
        /// Obtener la venta como vendedor.
        /// </summary>
        [Test]
        public void GetSalesBySellerTest()
        {
            int sellerCompanyId = 2;

            IReadOnlyCollection<int> listaantes1 = this.datMgr.Sale.GetSalesBySeller(sellerCompanyId);

            Sale sale1 = this.datMgr.Sale.New();

            DateTime datetime = DateTime.Today;
            sale1.DateTime = datetime;

            int price = 100;
            sale1.Price = price;

            Currency currency = Currency.PesoUruguayo;
            sale1.Currency = currency;

            sale1.SellerCompanyId = sellerCompanyId;

            int compMatId = 91170;
            sale1.ProductCompanyMaterialId = compMatId;

            int entreId = 908977;
            sale1.BuyerEntrepreneurId = entreId;

            sale1.ProductQuantity = 1;

            Sale sale2 = this.datMgr.Sale.New();

            DateTime datetime2 = DateTime.Today;
            sale2.DateTime = datetime2;

            int price2 = 100;
            sale2.Price = price2;

            Currency currency2 = Currency.PesoUruguayo;
            sale2.Currency = currency2;

            sale2.SellerCompanyId = sellerCompanyId;

            sale2.ProductCompanyMaterialId = compMatId;

            sale2.BuyerEntrepreneurId = entreId;

            sale2.ProductQuantity = 1;

            Sale sale3 = this.datMgr.Sale.New();

            DateTime datetime3 = DateTime.Today;
            sale3.DateTime = datetime3;

            int price3 = 100;
            sale3.Price = price3;

            Currency currency3 = Currency.PesoUruguayo;
            sale3.Currency = currency3;

            sale3.SellerCompanyId = sellerCompanyId;

            sale3.ProductCompanyMaterialId = compMatId;

            sale3.BuyerEntrepreneurId = entreId;

            sale3.ProductQuantity = 1;

            this.datMgr.Sale.Insert(sale1);
            this.datMgr.Sale.Insert(sale2);
            this.datMgr.Sale.Insert(sale3);

            IReadOnlyCollection<int> lista = this.datMgr.Sale.GetSalesBySeller(sellerCompanyId);

            Assert.AreEqual(listaantes1.Count + 3, lista.Count);
        }

        /// <summary>
        /// Obtener compra con comprador.
        /// </summary>
        [Test]
        public void GetSalesByBuyerTest()
        {
            IReadOnlyCollection<int> listaantes = this.datMgr.Sale.GetSalesByBuyer(2);

            Sale sale1 = this.datMgr.Sale.New();

            DateTime datetime = DateTime.Today;
            sale1.DateTime = datetime;

            int price = 1033;
            sale1.Price = price;

            Currency currency = Currency.DolarEstadounidense;
            sale1.Currency = currency;

            sale1.BuyerEntrepreneurId = 2;

            int compMatId = 911230;
            sale1.ProductCompanyMaterialId = compMatId;

            int compId = 908978;
            sale1.SellerCompanyId = compId;

            sale1.ProductQuantity = 1;

            Sale sale2 = this.datMgr.Sale.New();

            DateTime datetime2 = DateTime.Today;
            sale2.DateTime = datetime2;

            int price2 = 100;
            sale2.Price = price2;

            Currency currency2 = Currency.PesoUruguayo;
            sale2.Currency = currency2;

            sale2.BuyerEntrepreneurId = 2;

            sale2.ProductCompanyMaterialId = compMatId;

            sale2.SellerCompanyId = compId;

            sale2.ProductQuantity = 1;

            Sale sale3 = this.datMgr.Sale.New();

            DateTime datetime3 = DateTime.Today;
            sale3.DateTime = datetime3;

            int price3 = 100;
            sale3.Price = price3;

            Currency currency3 = Currency.PesoUruguayo;
            sale3.Currency = currency3;

            sale3.BuyerEntrepreneurId = 2;

            sale3.ProductCompanyMaterialId = compMatId;

            sale3.SellerCompanyId = compId;

            sale3.ProductQuantity = 1;

            this.datMgr.Sale.Insert(sale1);
            this.datMgr.Sale.Insert(sale2);
            this.datMgr.Sale.Insert(sale3);

            IReadOnlyCollection<int> lista = this.datMgr.Sale.GetSalesByBuyer(2);

            Assert.AreEqual(listaantes.Count + 3, lista.Count);
        }
    }
}
