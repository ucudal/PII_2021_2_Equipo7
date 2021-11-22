// -----------------------------------------------------------------------
// <copyright file="CompanyLocationAdminTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="CompanyAdmin"/>.
    /// </summary>
     public class CompanyLocationAdminTest
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Test para saber si se insertan los datos de la compañía.
        /// </summary>
        [Test]
        public void InsertTest()
        {
            IReadOnlyCollection<CompanyLocation> items = this.datMgr.CompanyLocation.Items;

            string geo = "georeference";
            int companyid = 2;
            CompanyLocation compania = this.datMgr.CompanyLocation.New();
            compania.CompanyId = companyid;
            compania.GeoReference = geo;
            int id = this.datMgr.CompanyLocation.Insert(compania);
            Assert.AreNotEqual(0, id);

            compania = this.datMgr.CompanyLocation.GetById(id);
            Assert.AreEqual(geo, compania.GeoReference);
            Assert.AreEqual(companyid, compania.CompanyId);
        }

        /// <summary>
        /// Test para modificar un dato.
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            // Insertamos una invitacion y validamos que haya quedado agregada
            IReadOnlyCollection<CompanyLocation> locationspre = this.datMgr.CompanyLocation.Items;

            string geo = "georeference";
            int companyid = 2;

            bool used = false;

            CompanyLocation loc = this.datMgr.CompanyLocation.New();
            loc.CompanyId = companyid;
            loc.GeoReference = geo;
            loc.Deleted = used;

            int locId = this.datMgr.CompanyLocation.Insert(loc);

            Assert.AreNotEqual(0, locId);

            IReadOnlyCollection<CompanyLocation> locationspost = this.datMgr.CompanyLocation.Items;

            int expectedInvites = locationspre.Count + 1;

            Assert.AreEqual(expectedInvites, locationspost.Count);

            CompanyLocation xToUpdate = this.datMgr.CompanyLocation.New();
            xToUpdate = this.datMgr.CompanyLocation.GetById(locId);

            string geo1 = "georeference11111111";
            int companyid1 = 3;

            bool used1 = false;

            xToUpdate.GeoReference = geo1;
            xToUpdate.CompanyId = companyid1;
            xToUpdate.Deleted = used1;

            this.datMgr.CompanyLocation.Update(xToUpdate);

            CompanyLocation xComp = this.datMgr.CompanyLocation.GetById(locId);

            Assert.AreEqual(xToUpdate.Id, xComp.Id);
            Assert.AreEqual(xToUpdate.Deleted, xComp.Deleted);
            Assert.AreEqual(xToUpdate.CompanyId, xComp.CompanyId);
            Assert.AreEqual(xToUpdate.GeoReference, xComp.GeoReference);
            Assert.AreEqual(xToUpdate.CompanyId, xComp.CompanyId);
        }

        /// <summary>
        /// Test para crear una nueva localización de la compañía.
        /// </summary>
        [Test]
        public void NewTest()
        {
            CompanyLocation company = this.datMgr.CompanyLocation.New();
            Assert.IsInstanceOf(typeof(CompanyLocation), company);
        }

        /// <summary>
        /// Test para obtener id de la localización.
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            CompanyLocation company = this.datMgr.CompanyLocation.New();
            company.GeoReference = "pepito";
            company.CompanyId = 5;

            int id = this.datMgr.CompanyLocation.Insert(company);
            CompanyLocation company2 = this.datMgr.CompanyLocation.GetById(id);

            Assert.AreEqual(id, company2.Id);
            Assert.AreEqual(company.GeoReference, company2.GeoReference);
            Assert.AreEqual(company.CompanyId, company2.CompanyId);
        }

        /// <summary>
        /// Test para borrar un dato.
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            // Insertamos un elemento
            IReadOnlyCollection<CompanyLocation> locationspre = this.datMgr.CompanyLocation.Items;

            string geo = "georeference";
            int companyid = 2;

            bool used = false;

            CompanyLocation loc = this.datMgr.CompanyLocation.New();
            loc.CompanyId = companyid;
            loc.GeoReference = geo;
            loc.Deleted = used;

            int locId = this.datMgr.CompanyLocation.Insert(loc);

            Assert.AreNotEqual(0, locId);
            IReadOnlyCollection<CompanyLocation> locationspost = this.datMgr.CompanyLocation.Items;

            int expectedInvites = locationspre.Count + 1;

            Assert.AreEqual(expectedInvites, locationspost.Count);

            this.datMgr.CompanyLocation.Delete(locId);

            IReadOnlyCollection<CompanyLocation> afterDelete = this.datMgr.CompanyLocation.Items;

            expectedInvites = locationspost.Count - 1;

            // Comprobamos que se elimino una invitacion
            Assert.AreEqual(expectedInvites, afterDelete.Count);
        }

        /// <summary>
        /// Busca por el id de compania las locaciones de la misma.
        /// </summary>
        [Test]
        public void GetLocationsForCompany()
        {
            CompanyLocation company1 = this.datMgr.CompanyLocation.New();
            company1.CompanyId = 1972;
            company1.GeoReference = "Carlos Maria Ramires y Conciliacion";
            CompanyLocation company2 = this.datMgr.CompanyLocation.New();
            company2.CompanyId = 1972;
            company2.GeoReference = "Miguelete y Cabildo";
            CompanyLocation company3 = this.datMgr.CompanyLocation.New();
            company3.CompanyId = 1972;
            company3.GeoReference = "Av 18 de Julio y Paraguay";
            this.datMgr.CompanyLocation.Insert(company1);
            this.datMgr.CompanyLocation.Insert(company2);
            this.datMgr.CompanyLocation.Insert(company3);

            IReadOnlyCollection<CompanyLocation> lista = this.datMgr.CompanyLocation.GetLocationsForCompany(1972);

            Assert.AreEqual(3, lista.Count);
        }
    }
}