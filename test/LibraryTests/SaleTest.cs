using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class SaleTest
    {
        /// <summary>
        /// Test para el constructor de Sale.
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            DateTime dateTime = DateTime.Now;
            int Price = 1000;
            Currency currency = Currency.DolarEstadounidense;
            Sale sale = new Sale(dateTime,Price,currency);
            Assert.AreEqual(dateTime,sale.DateTime);
            Assert.AreEqual(Price,sale.Price);
            Assert.AreEqual(currency,sale.Currency);
            Assert.False(sale.Deleted);

        }

        /// <summary>
        /// Test añadir una compañia a una lista
        /// </summary>
        [Test]
        public void AddItemTest()
        {

        }


        /// <summary>
        /// Test remover una compañia a una lista
        /// </summary>
        [Test]
        public void RemoveItemTest()
        {

        }

    }
}