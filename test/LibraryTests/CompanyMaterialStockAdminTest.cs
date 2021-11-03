using System;
using System.Collections.ObjectModel;
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
        private CompanyMaterialStockAdmin companyMaterialStockAdmin = Singleton<CompanyMaterialStockAdmin>.Instance;

        /// <summary>
        /// Test del metodo Insert(CompanyMaterialStock pElemento).
        /// </summary>
        [Test]
        public void InsertTest()
        {
            //Agregamos un stock de un material 
            ReadOnlyCollection<CompanyMaterialStock> prevCompanyMaterialStock = companyMaterialStockAdmin.Items;

            int companyMatId = 2;
            int companyLocationId=1;
            int stock=100;
            bool deleted = false;

            CompanyMaterialStock companyMaterialStock=companyMaterialStockAdmin.New();
            companyMaterialStock.CompanyMatId=companyMatId;
            companyMaterialStock.CompanyLocationId=companyLocationId;
            companyMaterialStock.Stock=stock;
            companyMaterialStock.Deleted=deleted;
            int companyMaterialStockId = companyMaterialStockAdmin.Insert(companyMaterialStock);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialStockId);

            int expected=prevCompanyMaterialStock.Count + 1;

            ReadOnlyCollection<CompanyMaterialStock> postCompanyMaterialStock = companyMaterialStockAdmin.Items;

            //Validamos que se agrego stock de un material
            Assert.AreEqual(expected,postCompanyMaterialStock.Count);
        }

        /// <summary>
        /// Test del metodo Update(CompanyMaterialStock pElemento).
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            //Agregamos un stock de un material 
            ReadOnlyCollection<CompanyMaterialStock> prevCompanyMaterialStock = companyMaterialStockAdmin.Items;

            int companyMatId = 2;
            int companyLocationId=1;
            int stock=100;
            bool deleted = false;

            CompanyMaterialStock companyMaterialStock=companyMaterialStockAdmin.New();
            companyMaterialStock.CompanyMatId=companyMatId;
            companyMaterialStock.CompanyLocationId=companyLocationId;
            companyMaterialStock.Stock=stock;
            companyMaterialStock.Deleted=deleted;
            int companyMaterialStockId = companyMaterialStockAdmin.Insert(companyMaterialStock);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialStockId);

            int expected=prevCompanyMaterialStock.Count + 1;

            ReadOnlyCollection<CompanyMaterialStock> postCompanyMaterialStock = companyMaterialStockAdmin.Items;

            //Validamos que se agrego stock de un material
            Assert.AreEqual(expected,postCompanyMaterialStock.Count);
            
            //Obtenemos el stock recien agregada, le cambiamos los campos y le damos a update
            CompanyMaterialStock xToUpdate=companyMaterialStockAdmin.New();
            xToUpdate=companyMaterialStockAdmin.GetById(companyMaterialStockId);
            
            //atributos nuevos
            companyMatId = 2;
            companyLocationId=2;
            stock=50;
            deleted = false;

            xToUpdate.CompanyMatId=companyMatId;
            xToUpdate.CompanyLocationId=companyLocationId;
            xToUpdate.Stock=stock;
            xToUpdate.Deleted=deleted;

            companyMaterialStockAdmin.Update(xToUpdate);

            CompanyMaterialStock xComp=companyMaterialStockAdmin.GetById(companyMaterialStockId);

            Assert.AreEqual(xToUpdate.Id, xComp.Id);
            Assert.AreEqual(xToUpdate.CompanyMatId,xComp.CompanyMatId);
            Assert.AreEqual(xToUpdate.CompanyLocationId,xComp.CompanyLocationId);
            Assert.AreEqual(xToUpdate.Stock,xComp.Stock);
            Assert.AreEqual(xToUpdate.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo Delete(int pId).
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            //Agregamos un stock de un material 
            ReadOnlyCollection<CompanyMaterialStock> prevCompanyMaterialStock = companyMaterialStockAdmin.Items;

            int companyMatId = 2;
            int companyLocationId=1;
            int stock=100;
            bool deleted = false;

            CompanyMaterialStock companyMaterialStock=companyMaterialStockAdmin.New();
            companyMaterialStock.CompanyMatId=companyMatId;
            companyMaterialStock.CompanyLocationId=companyLocationId;
            companyMaterialStock.Stock=stock;
            companyMaterialStock.Deleted=deleted;
            int companyMaterialStockId = companyMaterialStockAdmin.Insert(companyMaterialStock);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialStockId);

            int expected=prevCompanyMaterialStock.Count + 1;

            ReadOnlyCollection<CompanyMaterialStock> postCompanyMaterialStock = companyMaterialStockAdmin.Items;

            //Validamos que se agrego stock de un material
            Assert.AreEqual(expected,postCompanyMaterialStock.Count);

            //Hacemos el delete y luego validamos que al cantidad haya disminuido 1
            ReadOnlyCollection<CompanyMaterialStock> beforeDelete=postCompanyMaterialStock;

            expected=postCompanyMaterialStock.Count - 1;

            companyMaterialStockAdmin.Delete(companyMaterialStockId);

            ReadOnlyCollection<CompanyMaterialStock> afterDelete = companyMaterialStockAdmin.Items;

            //Comprobamos que se elimino el stock
            Assert.AreEqual(expected,afterDelete.Count);
        }

        /// <summary>
        /// Test del metodo GetById(int pId).
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            //Agregamos un stock de un material 
            ReadOnlyCollection<CompanyMaterialStock> prevCompanyMaterialStock = companyMaterialStockAdmin.Items;

            int companyMatId = 2;
            int companyLocationId=1;
            int stock=100;
            bool deleted = false;

            CompanyMaterialStock companyMaterialStock=companyMaterialStockAdmin.New();
            companyMaterialStock.CompanyMatId=companyMatId;
            companyMaterialStock.CompanyLocationId=companyLocationId;
            companyMaterialStock.Stock=stock;
            companyMaterialStock.Deleted=deleted;
            int companyMaterialStockId = companyMaterialStockAdmin.Insert(companyMaterialStock);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialStockId);

            int expected=prevCompanyMaterialStock.Count + 1;

            ReadOnlyCollection<CompanyMaterialStock> postCompanyMaterialStock = companyMaterialStockAdmin.Items;

            //Validamos que se agrego stock de un material
            Assert.AreEqual(expected,postCompanyMaterialStock.Count);
            
            //Obtenemos la categoria agregada con GetById y comparamos
            CompanyMaterialStock xComp=companyMaterialStockAdmin.GetById(companyMaterialStockId);
            
            Assert.AreEqual(companyMaterialStock.Id, xComp.Id);
            Assert.AreEqual(companyMaterialStock.CompanyMatId,xComp.CompanyMatId);
            Assert.AreEqual(companyMaterialStock.CompanyLocationId,xComp.CompanyLocationId);
            Assert.AreEqual(companyMaterialStock.Stock,xComp.Stock);
            Assert.AreEqual(companyMaterialStock.Deleted, xComp.Deleted);
        }
    }
}