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

            int Price = 100;
            salePrueba.Price = Price;

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

            Assert.AreNotEqual(0,sale1);

            salePrueba = this.datMgr.Sale.GetById(sale1);

            Assert.AreEqual(datetime,salePrueba.DateTime);
            Assert.AreEqual(Price,salePrueba.Price);
            Assert.AreEqual(currency,salePrueba.Currency);
            Assert.AreEqual(compId,salePrueba.SellerCompanyId);
            Assert.AreEqual(compMatId,salePrueba.ProductCompanyMaterialId);
            Assert.AreEqual(entreId,salePrueba.BuyerEntrepreneurId);
            Assert.AreEqual(quantity,salePrueba.ProductQuantity);
        }

        /// <summary>
        /// Comprobar que se crea una nueva venta.
        /// </summary>
        [Test]
        public void NewTest()
        {
            Sale saleprueba =this.datMgr.Sale.New();
            Assert.IsInstanceOf(typeof(Sale),saleprueba);
        }

        /// <summary>
        /// Comprobar que se borran los datos.
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            Sale saleprueba2 =this.datMgr.Sale.New();
            saleprueba2.DateTime=DateTime.Today;
            saleprueba2.Price=100;
            saleprueba2.Currency= Currency.DolarEstadounidense;

            this.datMgr.Sale.Insert(saleprueba2);

            int NewId =saleprueba2.Id;
            this.datMgr.Sale.Delete(NewId);
            Assert.IsNull(this.datMgr.Sale.GetById(NewId));
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

            int Price = 100;
            salePrueba.Price = Price;

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

            Assert.AreNotEqual(0,sale1);

            Sale Sale2 = this.datMgr.Sale.GetById(sale1);

            Sale2.DateTime = DateTime.Today.AddMonths(2);
            Sale2.Price = 230;
            Sale2.Currency = Currency.DolarEstadounidense;
            this.datMgr.Sale.Update(Sale2);

            Sale Sale3 = this.datMgr.Sale.GetById(sale1);

            Assert.AreNotEqual(salePrueba.DateTime,Sale3.DateTime);
            Assert.AreNotEqual(salePrueba.Currency,Sale3.Currency);
            Assert.AreNotEqual(salePrueba.Price,Sale3.Price);
            Assert.AreEqual(salePrueba.BuyerEntrepreneurId,Sale3.BuyerEntrepreneurId);
            Assert.AreEqual(salePrueba.SellerCompanyId,Sale3.SellerCompanyId);
            Assert.AreEqual(salePrueba.ProductQuantity,Sale3.ProductQuantity);
            Assert.AreEqual(salePrueba.ProductCompanyMaterialId,Sale3.ProductCompanyMaterialId);


        }


        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void GetSalesBySellerTest()
        {

            Sale sale1 = this.datMgr.Sale.New();

            DateTime datetime = DateTime.Today;
            sale1.DateTime = datetime;

            int Price = 100;
            sale1.Price = Price;

            Currency currency = Currency.PesoUruguayo;
            sale1.Currency = currency;

            int sellerCompanyId = 2;
            sale1.SellerCompanyId = sellerCompanyId;

            int compMatId = 91170;
            sale1.ProductCompanyMaterialId = compMatId;

            int entreId = 908977;
            sale1.BuyerEntrepreneurId = entreId;

            sale1.ProductQuantity = 1;


            Sale sale2 = this.datMgr.Sale.New();

            DateTime datetime2 = DateTime.Today;
            sale2.DateTime = datetime2;

            int Price2 = 100;
            sale2.Price = Price2;

            Currency currency2 = Currency.PesoUruguayo;
            sale2.Currency = currency2;

            sale2.SellerCompanyId = sellerCompanyId;

            sale2.ProductCompanyMaterialId = compMatId;

            sale2.BuyerEntrepreneurId = entreId;

            sale2.ProductQuantity = 1;


            Sale sale3 = this.datMgr.Sale.New();

            DateTime datetime3 = DateTime.Today;
            sale3.DateTime = datetime3;

            int Price3 = 100;
            sale3.Price = Price3;

            Currency currency3 = Currency.PesoUruguayo;
            sale3.Currency = currency3;

            sale3.SellerCompanyId = sellerCompanyId;

            sale3.ProductCompanyMaterialId = compMatId;

            sale3.BuyerEntrepreneurId = entreId;

            sale3.ProductQuantity = 1;

            this.datMgr.Sale.Insert(sale1);
            this.datMgr.Sale.Insert(sale2);
            this.datMgr.Sale.Insert(sale3);

            int Cventa = 3;

            IReadOnlyCollection<int> lista = this.datMgr.Sale.GetSalesBySeller(sellerCompanyId);

            Assert.AreEqual(Cventa,lista.Count);
            
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void GetSalesByBuyerTest()
        {
            Sale sale1 = this.datMgr.Sale.New();

            DateTime datetime = DateTime.Today;
            sale1.DateTime = datetime;

            int Price = 1033;
            sale1.Price = Price;

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

            int Price2 = 100;
            sale2.Price = Price2;

            Currency currency2 = Currency.PesoUruguayo;
            sale2.Currency = currency2;

            sale2.BuyerEntrepreneurId = 2;

            sale2.ProductCompanyMaterialId = compMatId;

            sale2.SellerCompanyId = compId;

            sale2.ProductQuantity = 1;

            Sale sale3 = this.datMgr.Sale.New();

            DateTime datetime3 = DateTime.Today;
            sale3.DateTime = datetime3;

            int Price3 = 100;
            sale3.Price = Price3;

            Currency currency3 = Currency.PesoUruguayo;
            sale3.Currency = currency3;

            sale3.BuyerEntrepreneurId = 2;

            sale3.ProductCompanyMaterialId = compMatId;

            sale3.SellerCompanyId = compId;

            sale3.ProductQuantity = 1;

            this.datMgr.Sale.Insert(sale1);
            this.datMgr.Sale.Insert(sale2);
            this.datMgr.Sale.Insert(sale3);

            int Cventa = 3;

            IReadOnlyCollection<int> lista = this.datMgr.Sale.GetSalesByBuyer(2);

            Assert.AreEqual(Cventa,lista.Count);

        }
    }
}
