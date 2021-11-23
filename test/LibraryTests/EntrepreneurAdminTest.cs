// <copyright file="EntrepreneurAdminTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="EntrepreneurAdmin"/>.
    /// </summary>
     public class EntrepreneurAdminTest
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// test para incertar un objeto en emprendedor.
        /// </summary>
        [Test]
        public void InsertTest()
        {
            IReadOnlyCollection<Entrepreneur> items = this.datMgr.Entrepreneur.Items;

            string name = "nombre Entrepreneur";
            string trade = "rubro";
            int userId = 81009;
            string geoRef = "Centenario y Propios";
            Entrepreneur empre = this.datMgr.Entrepreneur.New();
            empre.Name = name;
            empre.Trade = trade;
            empre.UserId = userId;
            empre.GeoReference = geoRef;
            int entreid = this.datMgr.Entrepreneur.Insert(empre);
            Assert.AreNotEqual(0, entreid);

            empre = this.datMgr.Entrepreneur.GetById(entreid);
            Assert.AreEqual(name, empre.Name);
            Assert.AreEqual(trade, empre.Trade);
            Assert.AreEqual(userId, empre.UserId);
            Assert.AreEqual(geoRef, empre.GeoReference);
        }

        /// <summary>
        /// Test que prueba la actualizacion de un entreprenur.
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            Entrepreneur entrepreneur = this.datMgr.Entrepreneur.New();
            entrepreneur.Name = "pepito";
            entrepreneur.Trade = "galletas";
            entrepreneur.GeoReference = "Nueva Palmira y La Paz";
            entrepreneur.UserId = 900990;
            int identre = this.datMgr.Entrepreneur.Insert(entrepreneur);
            Entrepreneur empre2 = this.datMgr.Entrepreneur.New();
            empre2 = this.datMgr.Entrepreneur.GetById(identre);
            empre2.Trade = "armas";
            this.datMgr.Entrepreneur.Update(empre2);
            Entrepreneur empre3 = this.datMgr.Entrepreneur.New();
            empre3 = this.datMgr.Entrepreneur.GetById(identre);
            Assert.AreEqual("armas", empre3.Trade);
            Assert.AreEqual(entrepreneur.Name, empre3.Name);
            Assert.AreEqual(entrepreneur.GeoReference, empre3.GeoReference);
            Assert.AreEqual(entrepreneur.UserId, empre3.UserId);

            // no se que hacer en esta patyre si me falta algo
        }

        /// <summary>
        /// Test que crea una nueva instancia de entrepreneur.
        /// </summary>
        [Test]
        public void NewTest()
        {
            Entrepreneur entrepreneur = this.datMgr.Entrepreneur.New();
            Assert.IsInstanceOf(typeof(Entrepreneur), entrepreneur);
        }

        /// <summary>
        /// Test, traer un entrepreneur a partir de un id.
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            Entrepreneur entrepreneur = this.datMgr.Entrepreneur.New();
            entrepreneur.Name = "pepito";
            entrepreneur.Trade = "galletas";
            entrepreneur.UserId = 816240;
            entrepreneur.GeoReference = "Garibaldi y 8 de Octubre";
            int idempre = this.datMgr.Entrepreneur.Insert(entrepreneur);
            Entrepreneur entre3 = this.datMgr.Entrepreneur.GetById(idempre);
            Assert.AreEqual(entrepreneur.Trade, entre3.Trade);
            Assert.AreEqual(entrepreneur.UserId, entre3.UserId);
            Assert.AreEqual(entrepreneur.Name, entre3.Name);
        }

        /// <summary>
        /// Test, eliminar un entrepreneur del sistema.
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            Entrepreneur empre = this.datMgr.Entrepreneur.New();
            empre.Name = "pepito";
            empre.Trade = "galletas";
            empre.UserId = 48927;
            int id = this.datMgr.Entrepreneur.Insert(empre);
            this.datMgr.Entrepreneur.Delete(id);
            Entrepreneur entre3 = this.datMgr.Entrepreneur.GetById(id);
            Assert.IsNull(entre3);
        }
    }
}