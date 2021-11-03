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
    public class MaterialCategoryAdminTest
    {
        private MaterialCategoryAdmin materialCategoryAdmin = Singleton<MaterialCategoryAdmin>.Instance;

        /// <summary>
        /// Test del metodo Insert(MaterialCategory pElemento).
        /// </summary>
        [Test]
        public void InsertTest()
        {
            //Agregamos una categoria 
            ReadOnlyCollection<MaterialCategory> prevMaterialCategory = materialCategoryAdmin.Items;

            string name = "Maderas";
            bool deleted = false;

            MaterialCategory materialCategory=materialCategoryAdmin.New();
            materialCategory.Name=name;
            materialCategory.Deleted=deleted;
            int materialCategoryId = materialCategoryAdmin.Insert(materialCategory);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, materialCategoryId);

            int expected=prevMaterialCategory.Count + 1;

            ReadOnlyCollection<MaterialCategory> postMaterialCategory = materialCategoryAdmin.Items;

            //Validamos que se agrego una Categoria
            Assert.AreEqual(expected,postMaterialCategory.Count);
        }

        /// <summary>
        /// Test del metodo Update(Invitation pElemento).
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            //Agregamos una categoria 
            ReadOnlyCollection<MaterialCategory> prevMaterialCategory = materialCategoryAdmin.Items;

            string name = "Maderas";
            bool deleted = false;

            MaterialCategory materialCategory=materialCategoryAdmin.New();
            materialCategory.Name=name;
            materialCategory.Deleted=deleted;
            int materialCategoryId = materialCategoryAdmin.Insert(materialCategory);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, materialCategoryId);

            int expected=prevMaterialCategory.Count + 1;

            ReadOnlyCollection<MaterialCategory> postMaterialCategory = materialCategoryAdmin.Items;

            //Validamos que se agrego una categoria
            Assert.AreEqual(expected,postMaterialCategory.Count);
            
            //Obtenemos la categoria recien agregada, le cambiamos los campos y le damos a update
            MaterialCategory xToUpdate=materialCategoryAdmin.New();
            xToUpdate=materialCategoryAdmin.GetById(materialCategoryId);
            
            //atributos nuevos
            name = "Plasticos";
            deleted = false;

            xToUpdate.Name=name;
            xToUpdate.Deleted=deleted;

            materialCategoryAdmin.Update(xToUpdate);

            MaterialCategory xComp=materialCategoryAdmin.GetById(materialCategoryId);

            Assert.AreEqual(xToUpdate.Id, xComp.Id);
            Assert.AreEqual(xToUpdate.Name,xComp.Name);
            Assert.AreEqual(xToUpdate.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo Delete(int pId).
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            //Agregamos una categoria 
            ReadOnlyCollection<MaterialCategory> prevMaterialCategory = materialCategoryAdmin.Items;

            string name = "Maderas";
            bool deleted = false;

            MaterialCategory materialCategory=materialCategoryAdmin.New();
            materialCategory.Name=name;
            materialCategory.Deleted=deleted;
            int materialCategoryId = materialCategoryAdmin.Insert(materialCategory);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, materialCategoryId);

            int expected=prevMaterialCategory.Count + 1;

            ReadOnlyCollection<MaterialCategory> postMaterialCategory = materialCategoryAdmin.Items;

            //Validamos que se agrego una categoria
            Assert.AreEqual(expected,postMaterialCategory.Count);

            //Hacemos el delete y luego validamos que al cantidad haya disminuido 1
            ReadOnlyCollection<MaterialCategory> beforeDelete=postMaterialCategory;

            expected=postMaterialCategory.Count - 1;

            materialCategoryAdmin.Delete(materialCategoryId);

            ReadOnlyCollection<MaterialCategory> afterDelete = materialCategoryAdmin.Items;

            //Comprobamos que se elimino una categoria
            Assert.AreEqual(expected,afterDelete.Count);
        }

        /// <summary>
        /// Test del metodo GetById(int pId).
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            //Agregamos una categoria 
            ReadOnlyCollection<MaterialCategory> prevMaterialCategory = materialCategoryAdmin.Items;

            string name = "Maderas";
            bool deleted = false;

            MaterialCategory materialCategory=materialCategoryAdmin.New();
            materialCategory.Name=name;
            materialCategory.Deleted=deleted;
            int materialCategoryId = materialCategoryAdmin.Insert(materialCategory);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, materialCategoryId);

            int expected=prevMaterialCategory.Count + 1;

            ReadOnlyCollection<MaterialCategory> postMaterialCategory = materialCategoryAdmin.Items;

            //Validamos que se agrego una categoria
            Assert.AreEqual(expected,postMaterialCategory.Count);
            
            //Obtenemos la categoria agregada con GetById y comparamos
            MaterialCategory xComp=materialCategoryAdmin.GetById(materialCategoryId);
            
            Assert.AreEqual(materialCategoryId, xComp.Id);
            Assert.AreEqual(materialCategory.Name,xComp.Name);
            Assert.AreEqual(materialCategory.Deleted, xComp.Deleted);
        }
    }
}