using System;
using System.Collections.ObjectModel;
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
        private CompanyMaterialAdmin companyMaterialAdmin = Singleton<CompanyMaterialAdmin>.Instance;

        /// <summary>
        /// Test del metodo Insert(CompanyMaterial pElemento).
        /// </summary>
        [Test]
        public void InsertTest()
        {
            //Agregamos una material 
            ReadOnlyCollection<CompanyMaterial> prevCompanyMaterial = companyMaterialAdmin.Items;

            string name = "Madera";
            DateTime lastRestock=DateTime.Now.AddMonths(-1);
            int dateBetweenRestocks=15;
            int materialCategoryId=2;
            int companyId=2;
            bool deleted = false;

            CompanyMaterial companyMaterial=companyMaterialAdmin.New();
            companyMaterial.Name=name;
            companyMaterial.LastRestock=lastRestock;
            companyMaterial.DateBetweenRestocks=dateBetweenRestocks;
            companyMaterial.MaterialCategoryId=materialCategoryId;
            companyMaterial.CompanyId=companyId;
            companyMaterial.Deleted=deleted;
            int companyMaterialId = companyMaterialAdmin.Insert(companyMaterial);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            int expected=prevCompanyMaterial.Count + 1;

            ReadOnlyCollection<CompanyMaterial> postCompanyMaterial = companyMaterialAdmin.Items;

            //Validamos que se agrego un material
            Assert.AreEqual(expected,postCompanyMaterial.Count);
        }

        /// <summary>
        /// Test del metodo Update(CompanyMaterial pElemento).
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            //Agregamos una material 
            ReadOnlyCollection<CompanyMaterial> prevCompanyMaterial = companyMaterialAdmin.Items;

            string name = "Madera";
            DateTime lastRestock=DateTime.Now.AddMonths(-1);
            int dateBetweenRestocks=15;
            int materialCategoryId=2;
            int companyId=2;
            bool deleted = false;

            CompanyMaterial companyMaterial=companyMaterialAdmin.New();
            companyMaterial.Name=name;
            companyMaterial.LastRestock=lastRestock;
            companyMaterial.DateBetweenRestocks=dateBetweenRestocks;
            companyMaterial.MaterialCategoryId=materialCategoryId;
            companyMaterial.CompanyId=companyId;
            companyMaterial.Deleted=deleted;
            int companyMaterialId = companyMaterialAdmin.Insert(companyMaterial);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            int expected=prevCompanyMaterial.Count + 1;

            ReadOnlyCollection<CompanyMaterial> postCompanyMaterial = companyMaterialAdmin.Items;

            //Validamos que se agrego un material
            Assert.AreEqual(expected,postCompanyMaterial.Count);
            
            //Obtenemos el material recien agregada, le cambiamos los campos y le damos a update
            CompanyMaterial xToUpdate=companyMaterialAdmin.New();
            xToUpdate=companyMaterialAdmin.GetById(companyMaterialId);
            
            //atributos nuevos
            name = "plastico";
            lastRestock=DateTime.Now;
            dateBetweenRestocks=20;
            materialCategoryId=3;
            companyId=2;
            deleted = false;

            xToUpdate.Name=name;
            xToUpdate.LastRestock=lastRestock;
            xToUpdate.DateBetweenRestocks=dateBetweenRestocks;
            xToUpdate.MaterialCategoryId=materialCategoryId;
            xToUpdate.CompanyId=companyId;
            xToUpdate.Deleted=deleted;

            companyMaterialAdmin.Update(xToUpdate);

            CompanyMaterial xComp=companyMaterialAdmin.GetById(companyMaterialId);

            Assert.AreEqual(xToUpdate.Id, xComp.Id);
            Assert.AreEqual(xToUpdate.Name,xComp.Name);
            Assert.AreEqual(xToUpdate.LastRestock, xComp.LastRestock);
            Assert.AreEqual(xToUpdate.DateBetweenRestocks,xComp.DateBetweenRestocks);
            Assert.AreEqual(xToUpdate.CompanyId,xComp.CompanyId);
            Assert.AreEqual(xToUpdate.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo Delete(int pId).
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            //Agregamos una material 
            ReadOnlyCollection<CompanyMaterial> prevCompanyMaterial = companyMaterialAdmin.Items;

            string name = "Madera";
            DateTime lastRestock=DateTime.Now.AddMonths(-1);
            int dateBetweenRestocks=15;
            int materialCategoryId=2;
            int companyId=2;
            bool deleted = false;

            CompanyMaterial companyMaterial=companyMaterialAdmin.New();
            companyMaterial.Name=name;
            companyMaterial.LastRestock=lastRestock;
            companyMaterial.DateBetweenRestocks=dateBetweenRestocks;
            companyMaterial.MaterialCategoryId=materialCategoryId;
            companyMaterial.CompanyId=companyId;
            companyMaterial.Deleted=deleted;
            int companyMaterialId = companyMaterialAdmin.Insert(companyMaterial);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            int expected=prevCompanyMaterial.Count + 1;

            ReadOnlyCollection<CompanyMaterial> postCompanyMaterial = companyMaterialAdmin.Items;

            //Validamos que se agrego un material
            Assert.AreEqual(expected,postCompanyMaterial.Count);

            //Hacemos el delete y luego validamos que al cantidad haya disminuido 1
            ReadOnlyCollection<CompanyMaterial> beforeDelete=postCompanyMaterial;

            expected=postCompanyMaterial.Count - 1;

            companyMaterialAdmin.Delete(companyMaterialId);

            ReadOnlyCollection<CompanyMaterial> afterDelete = companyMaterialAdmin.Items;

            //Comprobamos que se elimino un material
            Assert.AreEqual(expected,afterDelete.Count);
        }

        /// <summary>
        /// Test del metodo GetById(int pId).
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
             //Agregamos una material 
            ReadOnlyCollection<CompanyMaterial> prevCompanyMaterial = companyMaterialAdmin.Items;

            string name = "Madera";
            DateTime lastRestock=DateTime.Now.AddMonths(-1);
            int dateBetweenRestocks=15;
            int materialCategoryId=2;
            int companyId=2;
            bool deleted = false;

            CompanyMaterial companyMaterial=companyMaterialAdmin.New();
            companyMaterial.Name=name;
            companyMaterial.LastRestock=lastRestock;
            companyMaterial.DateBetweenRestocks=dateBetweenRestocks;
            companyMaterial.MaterialCategoryId=materialCategoryId;
            companyMaterial.CompanyId=companyId;
            companyMaterial.Deleted=deleted;
            int companyMaterialId = companyMaterialAdmin.Insert(companyMaterial);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            int expected=prevCompanyMaterial.Count + 1;

            ReadOnlyCollection<CompanyMaterial> postCompanyMaterial = companyMaterialAdmin.Items;

            //Validamos que se agrego un material
            Assert.AreEqual(expected,postCompanyMaterial.Count);
            
            //Obtenemos la categoria agregada con GetById y comparamos
            CompanyMaterial xComp=companyMaterialAdmin.GetById(companyMaterialId);
            
            Assert.AreEqual(companyMaterial.Id, xComp.Id);
            Assert.AreEqual(companyMaterial.Name,xComp.Name);
            Assert.AreEqual(companyMaterial.LastRestock, xComp.LastRestock);
            Assert.AreEqual(companyMaterial.DateBetweenRestocks,xComp.DateBetweenRestocks);
            Assert.AreEqual(companyMaterial.CompanyId,xComp.CompanyId);
            Assert.AreEqual(companyMaterial.Deleted, xComp.Deleted);
        }
    }
}