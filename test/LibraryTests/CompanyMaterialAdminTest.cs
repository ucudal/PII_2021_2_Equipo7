// -----------------------------------------------------------------------
// <copyright file="CompanyMaterialAdminTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests del administrador de MaterialCategory.
    /// </summary>
    [TestFixture]
    public class CompanyMaterialAdminTest
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Test del metodo Insert(CompanyMaterial pElemento).
        /// </summary>
        [Test]
        public void InsertTest()
        {
            // Agregamos una material
            IReadOnlyCollection<CompanyMaterial> prevCompanyMaterial = this.datMgr.CompanyMaterial.Items;

            string name = "Madera";
            DateTime lastRestock = DateTime.Now.AddMonths(-1);
            int dateBetweenRestocks = 15;
            int materialCategoryId = 2;
            int companyId = 2;
            bool deleted = false;

            CompanyMaterial companyMaterial = this.datMgr.CompanyMaterial.New();
            companyMaterial.Name = name;
            companyMaterial.LastRestock = lastRestock;
            companyMaterial.DateBetweenRestocks = dateBetweenRestocks;
            companyMaterial.MaterialCategoryId = materialCategoryId;
            companyMaterial.CompanyId = companyId;
            companyMaterial.Deleted = deleted;
            int companyMaterialId = this.datMgr.CompanyMaterial.Insert(companyMaterial);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            int expected = prevCompanyMaterial.Count + 1;

            IReadOnlyCollection<CompanyMaterial> postCompanyMaterial = this.datMgr.CompanyMaterial.Items;

            // Validamos que se agrego un material
            Assert.AreEqual(expected, postCompanyMaterial.Count);
        }

        /// <summary>
        /// Test del metodo Update(CompanyMaterial pElemento).
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            // Agregamos una material
            IReadOnlyCollection<CompanyMaterial> prevCompanyMaterial = this.datMgr.CompanyMaterial.Items;

            string name = "Madera";
            DateTime lastRestock = DateTime.Now.AddMonths(-1);
            int dateBetweenRestocks = 15;
            int materialCategoryId = 2;
            int companyId = 2;
            bool deleted = false;

            CompanyMaterial companyMaterial = this.datMgr.CompanyMaterial.New();
            companyMaterial.Name = name;
            companyMaterial.LastRestock = lastRestock;
            companyMaterial.DateBetweenRestocks = dateBetweenRestocks;
            companyMaterial.MaterialCategoryId = materialCategoryId;
            companyMaterial.CompanyId = companyId;
            companyMaterial.Deleted = deleted;
            int companyMaterialId = this.datMgr.CompanyMaterial.Insert(companyMaterial);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            int expected = prevCompanyMaterial.Count + 1;

            IReadOnlyCollection<CompanyMaterial> postCompanyMaterial = this.datMgr.CompanyMaterial.Items;

            // Validamos que se agrego un material
            Assert.AreEqual(expected, postCompanyMaterial.Count);

            // Obtenemos el material recien agregada, le cambiamos los campos y le damos a update
            CompanyMaterial xToUpdate = this.datMgr.CompanyMaterial.New();
            xToUpdate = this.datMgr.CompanyMaterial.GetById(companyMaterialId);

            // Atributos nuevos
            name = "plastico";
            lastRestock = DateTime.Now;
            dateBetweenRestocks = 20;
            materialCategoryId = 3;
            companyId = 2;
            deleted = false;

            xToUpdate.Name = name;
            xToUpdate.LastRestock = lastRestock;
            xToUpdate.DateBetweenRestocks = dateBetweenRestocks;
            xToUpdate.MaterialCategoryId = materialCategoryId;
            xToUpdate.CompanyId = companyId;
            xToUpdate.Deleted = deleted;

            this.datMgr.CompanyMaterial.Update(xToUpdate);

            CompanyMaterial xComp = this.datMgr.CompanyMaterial.GetById(companyMaterialId);

            Assert.AreEqual(xToUpdate.Id, xComp.Id);
            Assert.AreEqual(xToUpdate.Name, xComp.Name);
            Assert.AreEqual(xToUpdate.LastRestock, xComp.LastRestock);
            Assert.AreEqual(xToUpdate.DateBetweenRestocks, xComp.DateBetweenRestocks);
            Assert.AreEqual(xToUpdate.CompanyId, xComp.CompanyId);
            Assert.AreEqual(xToUpdate.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo Delete(int pId).
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            // Agregamos una material
            IReadOnlyCollection<CompanyMaterial> prevCompanyMaterial = this.datMgr.CompanyMaterial.Items;

            string name = "Madera";
            DateTime lastRestock = DateTime.Now.AddMonths(-1);
            int dateBetweenRestocks = 15;
            int materialCategoryId = 2;
            int companyId = 2;
            bool deleted = false;

            CompanyMaterial companyMaterial = this.datMgr.CompanyMaterial.New();
            companyMaterial.Name = name;
            companyMaterial.LastRestock = lastRestock;
            companyMaterial.DateBetweenRestocks = dateBetweenRestocks;
            companyMaterial.MaterialCategoryId = materialCategoryId;
            companyMaterial.CompanyId = companyId;
            companyMaterial.Deleted = deleted;
            int companyMaterialId = this.datMgr.CompanyMaterial.Insert(companyMaterial);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            int expected = prevCompanyMaterial.Count + 1;

            IReadOnlyCollection<CompanyMaterial> postCompanyMaterial = this.datMgr.CompanyMaterial.Items;

            // Validamos que se agrego un material
            Assert.AreEqual(expected, postCompanyMaterial.Count);

            // Hacemos el delete y luego validamos que al cantidad haya disminuido 1
            IReadOnlyCollection<CompanyMaterial> beforeDelete = postCompanyMaterial;

            expected = postCompanyMaterial.Count - 1;

            this.datMgr.CompanyMaterial.Delete(companyMaterialId);

            IReadOnlyCollection<CompanyMaterial> afterDelete = this.datMgr.CompanyMaterial.Items;

            // Comprobamos que se elimino un material
            Assert.AreEqual(expected, afterDelete.Count);
        }

        /// <summary>
        /// Test del metodo GetById(int pId).
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            // Agregamos una material
            IReadOnlyCollection<CompanyMaterial> prevCompanyMaterial = this.datMgr.CompanyMaterial.Items;

            string name = "Madera";
            DateTime lastRestock = DateTime.Now.AddMonths(-1);
            int dateBetweenRestocks = 15;
            int materialCategoryId = 2;
            int companyId = 2;
            bool deleted = false;

            CompanyMaterial companyMaterial = this.datMgr.CompanyMaterial.New();
            companyMaterial.Name = name;
            companyMaterial.LastRestock = lastRestock;
            companyMaterial.DateBetweenRestocks = dateBetweenRestocks;
            companyMaterial.MaterialCategoryId = materialCategoryId;
            companyMaterial.CompanyId = companyId;
            companyMaterial.Deleted = deleted;
            int companyMaterialId = this.datMgr.CompanyMaterial.Insert(companyMaterial);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            int expected = prevCompanyMaterial.Count + 1;

            IReadOnlyCollection<CompanyMaterial> postCompanyMaterial = this.datMgr.CompanyMaterial.Items;

            // Validamos que se agrego un material
            Assert.AreEqual(expected, postCompanyMaterial.Count);

            // Obtenemos la categoria agregada con GetById y comparamos
            CompanyMaterial xComp = this.datMgr.CompanyMaterial.GetById(companyMaterialId);

            Assert.AreEqual(companyMaterialId, xComp.Id);
            Assert.AreEqual(companyMaterial.Name, xComp.Name);
            Assert.AreEqual(companyMaterial.LastRestock, xComp.LastRestock);
            Assert.AreEqual(companyMaterial.DateBetweenRestocks, xComp.DateBetweenRestocks);
            Assert.AreEqual(companyMaterial.CompanyId, xComp.CompanyId);
            Assert.AreEqual(companyMaterial.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo GetById(int pId).
        /// </summary>
        [Test]
        public void GetCompanyMaterialsInCompanyTest()
        {
            IReadOnlyCollection<int> listaAntes = this.datMgr.CompanyMaterial.GetCompanyMaterialsInCompany(11);
            CompanyMaterial company1 = this.datMgr.CompanyMaterial.New();
            company1.CompanyId = 11;
            company1.MaterialCategoryId = 197;
            company1.Name = "Pedro";
            CompanyMaterial company2 = this.datMgr.CompanyMaterial.New();
            company2.CompanyId = 11;
            company2.MaterialCategoryId = 197;
            company2.Name = "Pedro";
            CompanyMaterial company3 = this.datMgr.CompanyMaterial.New();
            company3.CompanyId = 11;
            company3.MaterialCategoryId = 197;
            company3.Name = "Pedro";

            this.datMgr.CompanyMaterial.Insert(company1);
            this.datMgr.CompanyMaterial.Insert(company2);
            this.datMgr.CompanyMaterial.Insert(company3);

            IReadOnlyCollection<int> lista = this.datMgr.CompanyMaterial.GetCompanyMaterialsInCompany(11);
            Assert.AreEqual(lista.Count, 3 + listaAntes.Count);
        }

        /// <summary>
        /// Test del metodo GetById(int pId).
        /// </summary>
        [Test]
        public void GetCompanyMaterialsInCompanyForCategoryTest()
        {
            IReadOnlyCollection<int> listaAntes = this.datMgr.CompanyMaterial.GetCompanyMaterialsInCompanyForCategory(8467, 197);
            CompanyMaterial company1 = this.datMgr.CompanyMaterial.New();
            company1.CompanyId = 8467;
            company1.MaterialCategoryId = 197;
            company1.Name = "Juan";
            CompanyMaterial company2 = this.datMgr.CompanyMaterial.New();
            company2.CompanyId = 8467;
            company2.MaterialCategoryId = 197;
            company2.Name = "Lucas";
            CompanyMaterial company3 = this.datMgr.CompanyMaterial.New();
            company3.CompanyId = 8467;
            company3.MaterialCategoryId = 197;
            company3.Name = "Pedro";

            this.datMgr.CompanyMaterial.Insert(company1);
            this.datMgr.CompanyMaterial.Insert(company2);
            this.datMgr.CompanyMaterial.Insert(company3);

            IReadOnlyCollection<int> lista = this.datMgr.CompanyMaterial.GetCompanyMaterialsInCompanyForCategory(8467, 197);
            Assert.AreEqual(3 + listaAntes.Count, lista.Count);
        }
    }
}