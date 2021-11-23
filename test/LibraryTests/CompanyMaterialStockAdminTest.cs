// <copyright file="CompanyMaterialStockAdminTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests del administrador de stock de un material.
    /// </summary>
    [TestFixture]
    public class CompanyMaterialStockAdminTest
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Test del metodo Insert(CompanyMaterialStock pElemento).
        /// </summary>
        [Test]
        public void InsertTest()
        {
            // Agregamos un stock de un material.
            IReadOnlyCollection<CompanyMaterialStock> prevCompanyMaterialStock = this.datMgr.CompanyMaterialStock.Items;

            int companyMatId = 2;
            int companyLocationId = 1;
            int stock = 100;
            bool deleted = false;

            CompanyMaterialStock companyMaterialStock = this.datMgr.CompanyMaterialStock.New();
            companyMaterialStock.CompanyMatId = companyMatId;
            companyMaterialStock.CompanyLocationId = companyLocationId;
            companyMaterialStock.Stock = stock;
            companyMaterialStock.Deleted = deleted;
            int companyMaterialStockId = this.datMgr.CompanyMaterialStock.Insert(companyMaterialStock);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialStockId);

            int expected = prevCompanyMaterialStock.Count + 1;

            IReadOnlyCollection<CompanyMaterialStock> postCompanyMaterialStock = this.datMgr.CompanyMaterialStock.Items;

            // Validamos que se agrego stock de un material
            Assert.AreEqual(expected, postCompanyMaterialStock.Count);
        }

        /// <summary>
        /// Test del metodo Update(CompanyMaterialStock pElemento).
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            // Agregamos un stock de un material.
            IReadOnlyCollection<CompanyMaterialStock> prevCompanyMaterialStock = this.datMgr.CompanyMaterialStock.Items;

            int companyMatId = 2;
            int companyLocationId = 1;
            int stock = 100;
            bool deleted = false;

            CompanyMaterialStock companyMaterialStock = this.datMgr.CompanyMaterialStock.New();
            companyMaterialStock.CompanyMatId = companyMatId;
            companyMaterialStock.CompanyLocationId = companyLocationId;
            companyMaterialStock.Stock = stock;
            companyMaterialStock.Deleted = deleted;
            int companyMaterialStockId = this.datMgr.CompanyMaterialStock.Insert(companyMaterialStock);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialStockId);

            int expected = prevCompanyMaterialStock.Count + 1;

            IReadOnlyCollection<CompanyMaterialStock> postCompanyMaterialStock = this.datMgr.CompanyMaterialStock.Items;

            // Validamos que se agrego stock de un material
            Assert.AreEqual(expected, postCompanyMaterialStock.Count);

            // Obtenemos el stock recien agregada, le cambiamos los campos y le damos a update
            CompanyMaterialStock xToUpdate = this.datMgr.CompanyMaterialStock.New();
            xToUpdate = this.datMgr.CompanyMaterialStock.GetById(companyMaterialStockId);

            // atributos nuevos
            companyMatId = 2;
            companyLocationId = 2;
            stock = 50;
            deleted = false;

            xToUpdate.CompanyMatId = companyMatId;
            xToUpdate.CompanyLocationId = companyLocationId;
            xToUpdate.Stock = stock;
            xToUpdate.Deleted = deleted;

            this.datMgr.CompanyMaterialStock.Update(xToUpdate);

            CompanyMaterialStock xComp = this.datMgr.CompanyMaterialStock.GetById(companyMaterialStockId);

            Assert.AreEqual(xToUpdate.Id, xComp.Id);
            Assert.AreEqual(xToUpdate.CompanyMatId, xComp.CompanyMatId);
            Assert.AreEqual(xToUpdate.CompanyLocationId, xComp.CompanyLocationId);
            Assert.AreEqual(xToUpdate.Stock, xComp.Stock);
            Assert.AreEqual(xToUpdate.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo Delete(int pId).
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            // Agregamos un stock de un material.
            IReadOnlyCollection<CompanyMaterialStock> prevCompanyMaterialStock = this.datMgr.CompanyMaterialStock.Items;

            int companyMatId = 2;
            int companyLocationId = 1;
            int stock = 100;
            bool deleted = false;

            CompanyMaterialStock companyMaterialStock = this.datMgr.CompanyMaterialStock.New();
            companyMaterialStock.CompanyMatId = companyMatId;
            companyMaterialStock.CompanyLocationId = companyLocationId;
            companyMaterialStock.Stock = stock;
            companyMaterialStock.Deleted = deleted;
            int companyMaterialStockId = this.datMgr.CompanyMaterialStock.Insert(companyMaterialStock);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialStockId);
            int expected = prevCompanyMaterialStock.Count + 1;
            IReadOnlyCollection<CompanyMaterialStock> postCompanyMaterialStock = this.datMgr.CompanyMaterialStock.Items;

            // Validamos que se agrego stock de un material
            Assert.AreEqual(expected, postCompanyMaterialStock.Count);

            // Hacemos el delete y luego validamos que al cantidad haya disminuido 1
            IReadOnlyCollection<CompanyMaterialStock> beforeDelete = postCompanyMaterialStock;

            expected = postCompanyMaterialStock.Count - 1;
            this.datMgr.CompanyMaterialStock.Delete(companyMaterialStockId);
            IReadOnlyCollection<CompanyMaterialStock> afterDelete = this.datMgr.CompanyMaterialStock.Items;

            // Comprobamos que se elimino el stock
            Assert.AreEqual(expected, afterDelete.Count);
        }

        /// <summary>
        /// Test del metodo GetById(int pId).
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            // Agregamos un stock de un material.
            IReadOnlyCollection<CompanyMaterialStock> prevCompanyMaterialStock = this.datMgr.CompanyMaterialStock.Items;

            int companyMatId = 2;
            int companyLocationId = 1;
            int stock = 100;
            bool deleted = false;

            CompanyMaterialStock companyMaterialStock = this.datMgr.CompanyMaterialStock.New();
            companyMaterialStock.CompanyMatId = companyMatId;
            companyMaterialStock.CompanyLocationId = companyLocationId;
            companyMaterialStock.Stock = stock;
            companyMaterialStock.Deleted = deleted;
            int companyMaterialStockId = this.datMgr.CompanyMaterialStock.Insert(companyMaterialStock);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialStockId);

            int expected = prevCompanyMaterialStock.Count + 1;

            IReadOnlyCollection<CompanyMaterialStock> postCompanyMaterialStock = this.datMgr.CompanyMaterialStock.Items;

            // Validamos que se agrego stock de un material
            Assert.AreEqual(expected, postCompanyMaterialStock.Count);

            // Obtenemos la categoria agregada con GetById y comparamos
            CompanyMaterialStock xComp = this.datMgr.CompanyMaterialStock.GetById(companyMaterialStockId);

            Assert.AreEqual(companyMaterialStockId, xComp.Id);
            Assert.AreEqual(companyMaterialStock.CompanyMatId, xComp.CompanyMatId);
            Assert.AreEqual(companyMaterialStock.CompanyLocationId, xComp.CompanyLocationId);
            Assert.AreEqual(companyMaterialStock.Stock, xComp.Stock);
            Assert.AreEqual(companyMaterialStock.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo GetStockTotalForCompanyMaterial(int companyMaterialId).
        /// </summary>
        [Test]
        public void GetStockTotalForCompanyMaterialTest()
        {
            // Agregamos un stock de un material.
            int companyMatId = 20;
            int companyLocationId = 1;
            int stock = 100;

            CompanyMaterialStock companyMaterialStock = this.datMgr.CompanyMaterialStock.New();
            companyMaterialStock.CompanyMatId = companyMatId;
            companyMaterialStock.CompanyLocationId = companyLocationId;
            companyMaterialStock.Stock = stock;
            int companyMaterialStockId = this.datMgr.CompanyMaterialStock.Insert(companyMaterialStock);

            int expected = stock;

            Assert.AreEqual(expected, this.datMgr.CompanyMaterialStock.GetStockTotalForCompanyMaterial(20));
        }

        /// <summary>
        /// Test del metodo GetLocationsWithStockForCompanyMaterial(int companyMaterialId).
        /// </summary>
        [Test]
        public void GetLocationsWithStockForCompanyMaterialTest()
        {
            // Agregamos un stock de un material.
            int companyMatId = 21;
            int companyLocationId = 1;
            int stock = 100;

            CompanyMaterialStock companyMaterialStock = this.datMgr.CompanyMaterialStock.New();
            companyMaterialStock.CompanyMatId = companyMatId;
            companyMaterialStock.CompanyLocationId = companyLocationId;
            companyMaterialStock.Stock = stock;
            int companyMaterialStockId = this.datMgr.CompanyMaterialStock.Insert(companyMaterialStock);

            companyMatId = 21;
            companyLocationId = 2;
            stock = 200;

            CompanyMaterialStock companyMaterialStock2 = this.datMgr.CompanyMaterialStock.New();
            companyMaterialStock2.CompanyMatId = companyMatId;
            companyMaterialStock2.CompanyLocationId = companyLocationId;
            companyMaterialStock2.Stock = stock;
            companyMaterialStockId = this.datMgr.CompanyMaterialStock.Insert(companyMaterialStock);

            int expected = 2;

            Assert.AreEqual(expected, this.datMgr.CompanyMaterialStock.GetLocationsWithStockForCompanyMaterial(21).Count);
        }

        /// <summary>
        /// Test del metodo GetCompanyMaterialsInStockForLocation(int companyLocationId).
        /// </summary>
        [Test]
        public void GetCompanyMaterialsInStockForLocationTest()
        {
            // Agregamos un stock de un material.
            int companyMatId = 22;
            int companyLocationId = 3;
            int stock = 100;

            CompanyMaterialStock companyMaterialStock = this.datMgr.CompanyMaterialStock.New();
            companyMaterialStock.CompanyMatId = companyMatId;
            companyMaterialStock.CompanyLocationId = companyLocationId;
            companyMaterialStock.Stock = stock;
            int companyMaterialStockId = this.datMgr.CompanyMaterialStock.Insert(companyMaterialStock);

            companyMatId = 23;
            companyLocationId = 3;
            stock = 200;

            CompanyMaterialStock companyMaterialStock2 = this.datMgr.CompanyMaterialStock.New();
            companyMaterialStock2.CompanyMatId = companyMatId;
            companyMaterialStock2.CompanyLocationId = companyLocationId;
            companyMaterialStock2.Stock = stock;
            companyMaterialStockId = this.datMgr.CompanyMaterialStock.Insert(companyMaterialStock);

            int expected = 2;

            Assert.AreEqual(expected, this.datMgr.CompanyMaterialStock.GetCompanyMaterialsInStockForLocation(3).Count);
        }
    }
}