// <copyright file="CompanyMaterialQualificationAdminTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests del administrador de MaterialCategory.
    /// </summary>
    [TestFixture]
    public class CompanyMaterialQualificationAdminTest
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Test del metodo Insert(CompanyMaterialQualification pElemento).
        /// </summary>
        [Test]
        public void InsertTest()
        {
            // Agregamos una Habilitacion de un material.
            IReadOnlyCollection<CompanyMaterialQualification> prevCompanyMaterialQualification = this.datMgr.CompanyMaterialQualification.Items;

            bool deleted = false;
            int companyMatId = 1;
            int qualificationId = 1;

            CompanyMaterialQualification companyMaterialQualification = this.datMgr.CompanyMaterialQualification.New();
            companyMaterialQualification.Deleted = deleted;
            companyMaterialQualification.CompanyMatId = companyMatId;
            companyMaterialQualification.QualificationId = qualificationId;
            int companyMaterialQualificationId = this.datMgr.CompanyMaterialQualification.Insert(companyMaterialQualification);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialQualificationId);

            int expected = prevCompanyMaterialQualification.Count + 1;

            IReadOnlyCollection<CompanyMaterialQualification> postCompanyMaterialQualification = this.datMgr.CompanyMaterialQualification.Items;

            // Validamos que se agrego una habilitacion de un material
            Assert.AreEqual(expected, postCompanyMaterialQualification.Count);
        }

        /// <summary>
        /// Test del metodo Update(CompanyMaterialQualification pElemento).
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            // Agregamos una Habilitacion de un material.
            IReadOnlyCollection<CompanyMaterialQualification> prevCompanyMaterialQualification = this.datMgr.CompanyMaterialQualification.Items;

            bool deleted = false;
            int companyMatId = 1;
            int qualificationId = 1;

            CompanyMaterialQualification companyMaterialQualification = this.datMgr.CompanyMaterialQualification.New();
            companyMaterialQualification.Deleted = deleted;
            companyMaterialQualification.CompanyMatId = companyMatId;
            companyMaterialQualification.QualificationId = qualificationId;
            int companyMaterialQualificationId = this.datMgr.CompanyMaterialQualification.Insert(companyMaterialQualification);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialQualificationId);

            int expected = prevCompanyMaterialQualification.Count + 1;

            IReadOnlyCollection<CompanyMaterialQualification> postCompanyMaterialQualification = this.datMgr.CompanyMaterialQualification.Items;

            // Validamos que se agrego una habilitacion de un material
            Assert.AreEqual(expected, postCompanyMaterialQualification.Count);

            // Obtenemos la categoria recien agregada, le cambiamos los campos y le damos a update
            CompanyMaterialQualification xToUpdate = this.datMgr.CompanyMaterialQualification.New();
            xToUpdate = this.datMgr.CompanyMaterialQualification.GetById(companyMaterialQualificationId);

            // atributos nuevos
            deleted = false;
            companyMatId = 1;
            qualificationId = 2;

            xToUpdate.CompanyMatId = companyMatId;
            xToUpdate.QualificationId = qualificationId;
            xToUpdate.Deleted = deleted;

            this.datMgr.CompanyMaterialQualification.Update(xToUpdate);

            CompanyMaterialQualification xComp = this.datMgr.CompanyMaterialQualification.GetById(companyMaterialQualificationId);

            Assert.AreEqual(xToUpdate.Id, xComp.Id);
            Assert.AreEqual(xToUpdate.CompanyMatId, xComp.CompanyMatId);
            Assert.AreEqual(xToUpdate.QualificationId, xComp.QualificationId);
            Assert.AreEqual(xToUpdate.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo Delete(int pId).
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            // Agregamos una Habilitacion de un material.
            IReadOnlyCollection<CompanyMaterialQualification> prevCompanyMaterialQualification = this.datMgr.CompanyMaterialQualification.Items;

            bool deleted = false;
            int companyMatId = 1;
            int qualificationId = 1;

            CompanyMaterialQualification companyMaterialQualification = this.datMgr.CompanyMaterialQualification.New();
            companyMaterialQualification.Deleted = deleted;
            companyMaterialQualification.CompanyMatId = companyMatId;
            companyMaterialQualification.QualificationId = qualificationId;
            int companyMaterialQualificationId = this.datMgr.CompanyMaterialQualification.Insert(companyMaterialQualification);

            // Validamos que se haya añadido correctamente con un id!= 0.
            Assert.AreNotEqual(0, companyMaterialQualificationId);

            int expected = prevCompanyMaterialQualification.Count + 1;

            IReadOnlyCollection<CompanyMaterialQualification> postCompanyMaterialQualification = this.datMgr.CompanyMaterialQualification.Items;

            // Validamos que se agrego una habilitacion de un material.
            Assert.AreEqual(expected, postCompanyMaterialQualification.Count);

            // Hacemos el delete y luego validamos que al cantidad haya disminuido 1.
            IReadOnlyCollection<CompanyMaterialQualification> beforeDelete = postCompanyMaterialQualification;

            expected = postCompanyMaterialQualification.Count - 1;

            this.datMgr.CompanyMaterialQualification.Delete(companyMaterialQualificationId);

            IReadOnlyCollection<CompanyMaterialQualification> afterDelete = this.datMgr.CompanyMaterialQualification.Items;

            // Comprobamos que se elimino una habilitacion
            Assert.AreEqual(expected, afterDelete.Count);
        }

        /// <summary>
        /// Test del metodo GetById(int pId).
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            // Agregamos una Habilitacion de un material.
            IReadOnlyCollection<CompanyMaterialQualification> prevCompanyMaterialQualification = this.datMgr.CompanyMaterialQualification.Items;

            bool deleted = false;
            int companyMatId = 1;
            int qualificationId = 1;

            CompanyMaterialQualification companyMaterialQualification = this.datMgr.CompanyMaterialQualification.New();
            companyMaterialQualification.Deleted = deleted;
            companyMaterialQualification.CompanyMatId = companyMatId;
            companyMaterialQualification.QualificationId = qualificationId;
            int companyMaterialQualificationId = this.datMgr.CompanyMaterialQualification.Insert(companyMaterialQualification);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialQualificationId);

            int expected = prevCompanyMaterialQualification.Count + 1;

            IReadOnlyCollection<CompanyMaterialQualification> postCompanyMaterialQualification = this.datMgr.CompanyMaterialQualification.Items;

            // Validamos que se agrego una habilitacion de un material
            Assert.AreEqual(expected, postCompanyMaterialQualification.Count);

            // Obtenemos la categoria agregada con GetById y comparamos
            CompanyMaterialQualification xComp = this.datMgr.CompanyMaterialQualification.GetById(companyMaterialQualificationId);

            Assert.AreEqual(companyMaterialQualificationId, xComp.Id);
            Assert.AreEqual(companyMaterialQualification.CompanyMatId, xComp.CompanyMatId);
            Assert.AreEqual(companyMaterialQualification.QualificationId, xComp.QualificationId);
            Assert.AreEqual(companyMaterialQualification.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo GetQualificationsForCompanyMaterial(int companyMaterialId).
        /// </summary>
        [Test]
        public void GetQualificationsForCompanyMaterialTest()
        {
            IReadOnlyCollection<int> listaAntes = this.datMgr.CompanyMaterialQualification.GetQualificationsForCompanyMaterial(10);

            // Agregamos una Habilitacion de un material.
            bool deleted = false;
            int companyMatId = 10;
            int qualificationId = 1;

            CompanyMaterialQualification companyMaterialQualification = this.datMgr.CompanyMaterialQualification.New();
            companyMaterialQualification.Deleted = deleted;
            companyMaterialQualification.CompanyMatId = companyMatId;
            companyMaterialQualification.QualificationId = qualificationId;
            int companyMaterialQualificationId = this.datMgr.CompanyMaterialQualification.Insert(companyMaterialQualification);

            // Agregamos  Habilitacion2 de un material.
            deleted = false;
            companyMatId = 10;
            qualificationId = 2;

            CompanyMaterialQualification companyMaterialQualification2 = this.datMgr.CompanyMaterialQualification.New();
            companyMaterialQualification2.Deleted = deleted;
            companyMaterialQualification2.CompanyMatId = companyMatId;
            companyMaterialQualification2.QualificationId = qualificationId;
            companyMaterialQualificationId = this.datMgr.CompanyMaterialQualification.Insert(companyMaterialQualification2);

            int expectedCountQualificationsFromMaterial1 = 2;

            // Comparo que el numero de habilitaciones agregadas= al numero de habilitaciones que agregue
            Assert.AreEqual(expectedCountQualificationsFromMaterial1 + listaAntes.Count, this.datMgr.CompanyMaterialQualification.GetQualificationsForCompanyMaterial(10).Count);
        }

        /// <summary>
        /// Test del metodo GetCompanyMaterialHasQualification(int companyMatId, int qualificationId).
        /// </summary>
        [Test]
        public void GetCompanyMaterialHasQualificationTest()
        {
            // Agregamos una Habilitacion de un material.
            bool deleted = false;
            int companyMatId = 1;
            int qualificationId = 1;

            CompanyMaterialQualification companyMaterialQualification = this.datMgr.CompanyMaterialQualification.New();
            companyMaterialQualification.Deleted = deleted;
            companyMaterialQualification.CompanyMatId = companyMatId;
            companyMaterialQualification.QualificationId = qualificationId;
            int companyMaterialQualificationId = this.datMgr.CompanyMaterialQualification.Insert(companyMaterialQualification);

            bool expected = true;

            // Comparo que el numero de habilitaciones agregadas= al numero de habilitaciones que agregue
            Assert.AreEqual(expected, this.datMgr.CompanyMaterialQualification.GetCompanyMaterialHasQualification(1, 1));
        }
    }
}