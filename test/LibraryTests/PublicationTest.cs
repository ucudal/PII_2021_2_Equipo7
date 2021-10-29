using System;
using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Publication"/>.
    /// </summary>
    [TestFixture]
    public class PublicationTest
    {
        
        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Setup()
        {

        }
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public void Constructor_Test()
        {
            DateTime ActiveFrom = DateTime.Now;
            DateTime ActiveUntill = DateTime.Now.AddMonths(2);
            int Price = 100;
            Currency Currency = Currency.PesoUruguayo;
            bool Deleted = false;
           
            Publication publication = new Publication(ActiveFrom, ActiveUntill,Price,Currency,Deleted);

            Assert.AreEqual(ActiveFrom,publication.ActiveFrom);
            Assert.AreEqual(ActiveUntill,publication.ActiveUntill);
            Assert.AreEqual(Price,publication.Price);
            Assert.AreEqual(Currency,publication.Currency);
            Assert.AreEqual(Deleted,publication.Deleted);

        }


        /// <summary>
        /// Test para añadir elementos a una lista del tipo KeyWord.
        /// </summary>
        [Test]
        public void AddKeyWordTest()
        {
            String XkeyWord = "Madera";
            List<string> keyWords = new List<string>();
            keyWords.Add(XkeyWord);
            Publication publication = new Publication();
            publication.AddKeyWord(XkeyWord);
            Assert.AreEqual(keyWords,publication.KeyWords);

        }


        /// <summary>
        /// Test para remover elementos a una lista del tipo KeyWord.
        /// </summary>
        [Test]
        public void RemoveKeyWordTest()
        {
            String XkeyWord = "Madera";
            List<string> keyWords = new List<string>();
            Publication publication = new Publication();
            publication.AddKeyWord(XkeyWord);
            Assert.AreNotEqual(keyWords,publication.KeyWords);
            publication.RemoveKeyWord(XkeyWord);
            Assert.AreEqual(keyWords,publication.KeyWords);
        }
    }
}