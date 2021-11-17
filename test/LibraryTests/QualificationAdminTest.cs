// -----------------------------------------------------------------------
// <copyright file="QualificationAdminTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Test de la clase que administra las habilitaciones.
    /// </summary>
    public class QualificationAdminTest
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Testear que los valores se ingresan en la data.
        /// </summary>
        [Test]
        public void InsertTestQ()
        {
            IReadOnlyCollection<Qualification> items = this.datMgr.Qualification.Items;
            string name = "Habilitacion madera";
            Qualification quali = this.datMgr.Qualification.New();
            quali.Name = name;
            int habili = this.datMgr.Qualification.Insert(quali);
            Assert.AreNotEqual(0, habili);
            quali = this.datMgr.Qualification.GetById(habili);
            Assert.AreEqual(name, quali.Name);
        }

        /// <summary>
        /// Comprobar que se crea una nueva habilitación.
        /// </summary>
        [Test]
        public void NewTestQ()
        {
            Qualification qualification = this.datMgr.Qualification.New();
            Assert.IsInstanceOf(typeof(Qualification), qualification);
        }

        /// <summary>
        /// Comprobar que se borra un id.
        /// </summary>
        [Test]
        public void DeleteTestQ()
        {
            Qualification qualification = this.datMgr.Qualification.New();
            qualification.Name = "Franco";
            this.datMgr.Qualification.Insert(qualification);
            int newId = qualification.Id;
            this.datMgr.Qualification.Delete(newId);
            Assert.IsNull(this.datMgr.Qualification.GetById(newId));
        }

        /// <summary>
        /// Comprobar que funciona el update del this.datMgr.Data.
        /// </summary>
        [Test]
        public void UpdateTestQ()
        {
            string name = "Habilitacion madera";
            Qualification quali = this.datMgr.Qualification.New();
            quali.Name = name;
            int habili = this.datMgr.Qualification.Insert(quali);
            Assert.AreNotEqual(0, habili);
            Qualification quali2 = this.datMgr.Qualification.GetById(habili);
            quali2.Name = "Habilitacion plastico";
            this.datMgr.Qualification.Update(quali2);
            Qualification quali3 = this.datMgr.Qualification.GetById(habili);
            Assert.AreEqual(quali2.Name, quali3.Name);
            Assert.AreEqual(quali2.Id, quali3.Id);
        }
    }
}