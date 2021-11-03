using System;
using System.Collections.ObjectModel;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Test de la clase que administra las ventas.
    /// </summary>
    public class SaleAdminTest
    {
        private SaleAdmin saleAdmin = Singleton<SaleAdmin>.Instance;


        /// <summary>
        /// Testear que los valores se ingresan en la data.
        /// </summary>
        [Test]
        public void InsertTest()
        {
            ReadOnlyCollection<Sale> items = saleAdmin.Items;

            Sale salePrueba = saleAdmin.New();

            DateTime datetime = DateTime.Today;
            salePrueba.DateTime = datetime;

            int Price = 100;
            salePrueba.Price = Price;

            Currency currency = Currency.PesoUruguayo;
            salePrueba.Currency = currency;

            int sale1 = saleAdmin.Insert(salePrueba);

            Assert.AreNotEqual(0,sale1);

            salePrueba = saleAdmin.GetById(sale1);

            Assert.AreEqual(datetime,salePrueba.DateTime);
            Assert.AreEqual(Price,salePrueba.Price);
            Assert.AreEqual(currency,salePrueba.Currency);
        }

        /// <summary>
        /// Comprobar que se crea una nueva venta.
        /// </summary>
        [Test]
        public void NewTest()
        {
            Sale saleprueba =saleAdmin.New();
            Assert.IsInstanceOf(typeof(Sale),saleprueba);
        }

        /// <summary>
        /// Comprobar que se borran los datos.
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            Sale saleprueba2 =saleAdmin.New();
            saleprueba2.DateTime=DateTime.Today;
            saleprueba2.Price=100;
            saleprueba2.Currency= Currency.DolarEstadounidense;

            saleAdmin.Insert(saleprueba2);

            int NewId =saleprueba2.Id;
            saleAdmin.Delete(NewId);
            Assert.IsNull(saleAdmin.GetById(NewId));
        }

        /// <summary>
        /// Comprobar que funciona el update del DataAdmin.
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            Sale salePrueba = saleAdmin.New();

            DateTime datetime = DateTime.Today;
            salePrueba.DateTime = datetime;

            int Price = 100;
            salePrueba.Price = Price;

            Currency currency = Currency.PesoUruguayo;
            salePrueba.Currency = currency;

            int sale1 = saleAdmin.Insert(salePrueba);

            Assert.AreNotEqual(0,sale1);

            Sale Sale2 = saleAdmin.GetById(sale1);

            Sale2.DateTime = DateTime.Today.AddMonths(2);
            Sale2.Price = 230;
            Sale2.Currency = Currency.DolarEstadounidense;
            saleAdmin.Update(Sale2);

            Sale Sale3 = saleAdmin.GetById(sale1);

            Assert.AreEqual(Sale2.DateTime,Sale3.DateTime);
            Assert.AreEqual(Sale2.Currency,Sale3.Currency);
            Assert.AreEqual(Sale2.Price,Sale3.Price);
            Assert.AreEqual(Sale2.Id,Sale3.Id);


        }

    }
}