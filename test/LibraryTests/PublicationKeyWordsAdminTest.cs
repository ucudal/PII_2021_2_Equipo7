using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Test de la clase que administra las palabras claves de las publicaciones.
    /// </summary>
    public class PublicationKeyWordsAdminTest
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Insert()
        {
            PublicationKeyWord keyw = this.datMgr.PublicationKeyWord.New();
            keyw.PublicationId = 18776;
            keyw.KeyWord = "madera";
            int pInt = this.datMgr.PublicationKeyWord.Insert(keyw);
            Assert.AreNotEqual(0,pInt);
        }

        /// <summary>
        /// Test para crear una nueva key
        /// </summary>
        [Test]
        public void NewTest()
        {
            PublicationKeyWord publikey = this.datMgr.PublicationKeyWord.New();
            Assert.IsInstanceOf(typeof(PublicationKeyWord),publikey);
        }

        /// <summary>
        /// Test del deleted
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            PublicationKeyWord pkey = this.datMgr.PublicationKeyWord.New();
            pkey.PublicationId = 98981;
            pkey.KeyWord = "fiambre";
            int p = this.datMgr.PublicationKeyWord.Insert(pkey);
            Assert.AreNotEqual(0,p);
            int NewId =pkey.Id;
            this.datMgr.PublicationKeyWord.Delete(NewId);
            Assert.IsNull(this.datMgr.PublicationKeyWord.GetById(NewId));
        }


        /// <summary>
        /// 
        /// </summary>        
        [Test]
        public void GetKeyWordsForPublicationTest()
        {
            PublicationKeyWord keyw = this.datMgr.PublicationKeyWord.New();
            keyw.PublicationId = 5;
            keyw.KeyWord = "madera";
            this.datMgr.PublicationKeyWord.Insert(keyw);

            PublicationKeyWord keyw1 = this.datMgr.PublicationKeyWord.New();
            keyw1.PublicationId = 5;
            keyw1.KeyWord = "vidrio";
            this.datMgr.PublicationKeyWord.Insert(keyw1);

            PublicationKeyWord keyw2 = this.datMgr.PublicationKeyWord.New();
            keyw2.PublicationId = 5;
            keyw2.KeyWord = "plastico";
            this.datMgr.PublicationKeyWord.Insert(keyw2);

            IReadOnlyCollection<string> lista = this.datMgr.PublicationKeyWord.GetKeyWordsForPublication(5);

            Assert.AreEqual(3,lista.Count);

        }



    }
}