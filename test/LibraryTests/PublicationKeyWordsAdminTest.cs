using System;
using System.Collections.ObjectModel;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Test de la clase que administra las palabras claves de las publicaciones.
    /// </summary>
    public class PublicationKeyWordsAdminTest
    {
        private PublicationKeyWordAdmin keyadmin = Singleton<PublicationKeyWordAdmin>.Instance;

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void Insert()
        {
            ReadOnlyCollection<PublicationKeyWord> items = keyadmin.Items;
            PublicationKeyWord keyw = keyadmin.New();
            int pInt = keyadmin.Insert(keyw);
            Assert.AreNotEqual(0,pInt);
        }

        /// <summary>
        /// Test para crear una nueva key
        /// </summary>
        [Test]
        public void NewTest()
        {
            PublicationKeyWord publikey = keyadmin.New();
            Assert.IsInstanceOf(typeof(PublicationKeyWord),publikey);
        }

        /// <summary>
        /// Test del deleted
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            PublicationKeyWord pkey = keyadmin.New();
            int p = keyadmin.Insert(pkey);
            Assert.AreNotEqual(0,p);
            int NewId =pkey.Id;
            keyadmin.Delete(NewId);
            Assert.IsNull(keyadmin.GetById(NewId));
        }


        /// <summary>
        /// 
        /// </summary>        
        [Test]
        public void GetKeyWordsForPublicationTest()
        {
            PublicationKeyWord keyw = keyadmin.New();
            keyw.PublicationId = 1;
            keyadmin.Insert(keyw);

            PublicationKeyWord keyw1 = keyadmin.New();
            keyw1.PublicationId = 1;
            keyadmin.Insert(keyw1);

            PublicationKeyWord keyw2 = keyadmin.New();
            keyw2.PublicationId = 1;
            keyadmin.Insert(keyw2);

            ReadOnlyCollection<string> lista = keyadmin.GetKeyWordsForPublication(1);

            Assert.AreEqual(3,lista.Count);

        }



    }
}