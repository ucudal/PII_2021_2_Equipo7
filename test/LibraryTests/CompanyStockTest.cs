using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Test de la clase CompanyStock.
    /// </summary>
    public class CompanyStockTest
    {
        /// <summary>
        /// Test del constructor de la clase.
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            int stock = 111;
            Location location = new Location();
            CompanyStock companyStock = new CompanyStock(stock,location);
            Assert.AreEqual(stock, companyStock.Stock);
            Assert.AreEqual(location, companyStock.Location);
        }
    }
}