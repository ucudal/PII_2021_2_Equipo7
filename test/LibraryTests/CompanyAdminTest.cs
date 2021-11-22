// -----------------------------------------------------------------------
// <copyright file="CompanyAdminTest.cs" company="Universidad Católica del Uruguay">
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
     public class CompanyAdminTest
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Test para saber si se insertan los datos de la compañía.
        /// </summary>
        [Test]
        public void InsertTest()
        {
            IReadOnlyCollection<Company> items = this.datMgr.Company.Items;

            string name = "nombre compania";
            string trade = "rubro";
            Company compania = this.datMgr.Company.New();
            compania.Name = name;
            compania.Trade = trade;
            int companyid = this.datMgr.Company.Insert(compania);
            Assert.AreNotEqual(0, companyid);

            compania = this.datMgr.Company.GetById(companyid);
            Assert.AreEqual(name, compania.Name);
            Assert.AreEqual(trade, compania.Trade);
        }

        /// <summary>
        /// Test para probar si se puede modificar una compañía.
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            Company compania = this.datMgr.Company.New();
            compania.Name = "pepito";
            compania.Trade = "galletas";
            int idcompania = this.datMgr.Company.Insert(compania);
            Company compania2 = this.datMgr.Company.New();
            compania2 = this.datMgr.Company.GetByName("pepito");
            int id = compania2.Id;
            compania2.Trade = "armas";
            this.datMgr.Company.Update(compania2);
            Company compania3 = new Company();
            compania3 = this.datMgr.Company.GetById(id);
            Assert.AreEqual("armas", compania3.Trade);
            Assert.AreNotEqual(0, idcompania);
        }

        /// <summary>
        /// Test para crear nueva compañía.
        /// </summary>
        [Test]
        public void NewTest()
        {
            Company company = this.datMgr.Company.New();
            Assert.IsInstanceOf(typeof(Company), company);
        }

        /// <summary>
        /// Test para obtener un id de una compañía.
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            Company company = this.datMgr.Company.New();
            company.Name = "pepito";
            company.Trade = "pepito";
            this.datMgr.Company.Insert(company);
            Company company2 = this.datMgr.Company.GetByName("pepito");
            int id = company2.Id;
            Company company3 = this.datMgr.Company.GetById(id);
            Assert.AreEqual(company2.Id, company3.Id);
            Assert.AreEqual(company2.Name, company3.Name);
            Assert.AreEqual(company2.Trade, company3.Trade);
        }

        /// <summary>
        /// Test para borrar datos de una compañía.
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            Company company = new Company();
            company.Name = "pepito";
            company.Trade = "galletas";
            this.datMgr.Company.Insert(company);
            Company company2 = this.datMgr.Company.GetByName("pepito");
            int id = company2.Id;
            this.datMgr.Company.Delete(id);
            Company company3 = this.datMgr.Company.GetById(id);
            Assert.IsNull(company3);
        }
    }
}