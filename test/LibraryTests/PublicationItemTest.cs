using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="PublicationItem"/>.
    /// </summary>
    [TestFixture]
    public class PublicationItemTest
    {
        /// <summary>
        /// Setup para inicializar variables u objetos
        /// </summary>
        [SetUp]
        public void Setup()
        { 

        }

        /// <summary>
        /// Test del constructor de la clase PublicationItem.
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            int Quantity = 10;
            PublicationItem prueba_publication_item = new PublicationItem(Quantity);
            Assert.AreEqual(Quantity,prueba_publication_item.Quantity);
        }
    }
}