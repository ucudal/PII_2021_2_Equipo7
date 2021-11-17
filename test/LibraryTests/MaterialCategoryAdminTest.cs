// -----------------------------------------------------------------------
// <copyright file="MaterialCategoryAdminTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
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
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Test del metodo Insert(MaterialCategory pElemento).
        /// </summary>
        [Test]
        public void InsertTest()
        {
            // Agregamos una categoria.
            IReadOnlyCollection<MaterialCategory> prevMaterialCategory = this.datMgr.MaterialCategory.Items;

            string name = "Maderas";
            bool deleted = false;

            MaterialCategory materialCategory = this.datMgr.MaterialCategory.New();
            materialCategory.Name = name;
            materialCategory.Deleted = deleted;
            int materialCategoryId = this.datMgr.MaterialCategory.Insert(materialCategory);

            // Validamos que se haya añadido correctamente con un id!= 0.
            Assert.AreNotEqual(0, materialCategoryId);

            int expected = prevMaterialCategory.Count + 1;

            IReadOnlyCollection<MaterialCategory> postMaterialCategory = this.datMgr.MaterialCategory.Items;

            // Validamos que se agrego una Categoria.
            Assert.AreEqual(expected, postMaterialCategory.Count);
        }

        /// <summary>
        /// Test del metodo Update(Invitation pElemento).
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            // Agregamos una categoria.
            IReadOnlyCollection<MaterialCategory> prevMaterialCategory = this.datMgr.MaterialCategory.Items;

            string name = "Maderas";
            bool deleted = false;

            MaterialCategory materialCategory = this.datMgr.MaterialCategory.New();
            materialCategory.Name = name;
            materialCategory.Deleted = deleted;
            int materialCategoryId = this.datMgr.MaterialCategory.Insert(materialCategory);

            // Validamos que se haya añadido correctamente con un id!= 0.
            Assert.AreNotEqual(0, materialCategoryId);

            int expected = prevMaterialCategory.Count + 1;

            IReadOnlyCollection<MaterialCategory> postMaterialCategory = this.datMgr.MaterialCategory.Items;

            // Validamos que se agrego una categoria.
            Assert.AreEqual(expected, postMaterialCategory.Count);

            // Obtenemos la categoria recien agregada, le cambiamos los campos y le damos a update
            MaterialCategory xToUpdate = this.datMgr.MaterialCategory.New();
            xToUpdate = this.datMgr.MaterialCategory.GetById(materialCategoryId);

            // Atributos nuevos
            name = "Plasticos";
            deleted = false;

            xToUpdate.Name = name;
            xToUpdate.Deleted = deleted;

            this.datMgr.MaterialCategory.Update(xToUpdate);

            MaterialCategory xComp = this.datMgr.MaterialCategory.GetById(materialCategoryId);

            Assert.AreEqual(xToUpdate.Id, xComp.Id);
            Assert.AreEqual(xToUpdate.Name, xComp.Name);
            Assert.AreEqual(xToUpdate.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo Delete(int pId).
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            // Agregamos una categoria.
            IReadOnlyCollection<MaterialCategory> prevMaterialCategory = this.datMgr.MaterialCategory.Items;

            string name = "Maderas";
            bool deleted = false;

            MaterialCategory materialCategory = this.datMgr.MaterialCategory.New();
            materialCategory.Name = name;
            materialCategory.Deleted = deleted;
            int materialCategoryId = this.datMgr.MaterialCategory.Insert(materialCategory);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, materialCategoryId);

            int expected = prevMaterialCategory.Count + 1;

            IReadOnlyCollection<MaterialCategory> postMaterialCategory = this.datMgr.MaterialCategory.Items;

            // Validamos que se agrego una categoria
            Assert.AreEqual(expected, postMaterialCategory.Count);

            // Hacemos el delete y luego validamos que al cantidad haya disminuido 1
            IReadOnlyCollection<MaterialCategory> beforeDelete = postMaterialCategory;

            expected = postMaterialCategory.Count - 1;

            this.datMgr.MaterialCategory.Delete(materialCategoryId);

            IReadOnlyCollection<MaterialCategory> afterDelete = this.datMgr.MaterialCategory.Items;

            // Comprobamos que se elimino una categoria
            Assert.AreEqual(expected, afterDelete.Count);
        }

        /// <summary>
        /// Test del metodo GetById(int pId).
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            // Agregamos una categoria
            IReadOnlyCollection<MaterialCategory> prevMaterialCategory = this.datMgr.MaterialCategory.Items;

            string name = "Maderas";
            bool deleted = false;

            MaterialCategory materialCategory = this.datMgr.MaterialCategory.New();
            materialCategory.Name = name;
            materialCategory.Deleted = deleted;
            int materialCategoryId = this.datMgr.MaterialCategory.Insert(materialCategory);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, materialCategoryId);

            int expected = prevMaterialCategory.Count + 1;

            IReadOnlyCollection<MaterialCategory> postMaterialCategory = this.datMgr.MaterialCategory.Items;

            // Validamos que se agrego una categoria
            Assert.AreEqual(expected, postMaterialCategory.Count);

            // Obtenemos la categoria agregada con GetById y comparamos
            MaterialCategory xComp = this.datMgr.MaterialCategory.GetById(materialCategoryId);

            Assert.AreEqual(materialCategoryId, xComp.Id);
            Assert.AreEqual(materialCategory.Name, xComp.Name);
            Assert.AreEqual(materialCategory.Deleted, xComp.Deleted);
        }
    }
}