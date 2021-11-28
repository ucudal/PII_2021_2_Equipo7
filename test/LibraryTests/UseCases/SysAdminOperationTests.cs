// -----------------------------------------------------------------------
// <copyright file="SysAdminOperationTests.cs" company="Universidad Católica del Uruguay">
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
    /// Conjunto de Tests para la operacion de
    /// un administrador del sistema.
    /// </summary>
    [TestFixture]
    public class SysAdminOperationTests
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Test de creacion de una invitacion
        /// a la plataforma.
        /// </summary>
        /// <param name="type">
        /// Tipo de invitacion a crear.
        /// </param>
        [TestCase(RegistrationType.CompanyJoin)]
        [TestCase(RegistrationType.CopmanyNew)]
        [TestCase(RegistrationType.EntrepreneurNew)]
        [TestCase(RegistrationType.SystemAdminJoin)]
        public void InvitationCreationTest(RegistrationType type)
        {
            IReadOnlyCollection<Invitation> prevInvites = this.datMgr.Invitation.Items;

            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = type == RegistrationType.CompanyJoin ? 42 : 0;

            Invitation inv = this.datMgr.Invitation.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            int invId = this.datMgr.Invitation.Insert(inv);

            Assert.AreNotEqual(0, invId);

            this.datMgr.Invitation.GenerateNewInviteCode(invId);
            inv = this.datMgr.Invitation.GetById(invId);

            Assert.AreEqual(invId, inv.Id);
            Assert.AreEqual(type, inv.Type);
            Assert.AreEqual(validAfter, inv.ValidAfter);
            Assert.AreEqual(validBefore, inv.ValidBefore);
            Assert.AreEqual(companyId, inv.CompanyId);
            Assert.AreEqual(false, inv.Used);
            Assert.AreEqual(false, inv.Deleted);
            Assert.AreEqual(18, inv.Code.Length);

            IReadOnlyCollection<Invitation> afterInvites = this.datMgr.Invitation.Items;

            int expectedInvites = prevInvites.Count + 1;

            Assert.AreEqual(expectedInvites, afterInvites.Count);
        }

        /// <summary>
        /// Test de creacion de una
        /// categoria de material.
        /// </summary>
        [Test]
        public void MaterialCategoryCreationTest()
        {
            IReadOnlyCollection<MaterialCategory> prevMatCat = this.datMgr.MaterialCategory.Items;

            string name = "Uranium 235";

            MaterialCategory matCat = this.datMgr.MaterialCategory.New();
            matCat.Name = name;
            int matCatId = this.datMgr.MaterialCategory.Insert(matCat);

            Assert.AreNotEqual(0, matCatId);

            matCat = this.datMgr.MaterialCategory.GetById(matCatId);

            Assert.AreEqual(matCatId, matCat.Id);
            Assert.AreEqual(name, matCat.Name);
            Assert.AreEqual(false, matCat.Deleted);

            IReadOnlyCollection<MaterialCategory> afterMatCat = this.datMgr.MaterialCategory.Items;

            int expectedMatCatCount = prevMatCat.Count + 1;

            Assert.AreEqual(expectedMatCatCount, afterMatCat.Count);
        }

        /// <summary>
        /// Test de eliminacion de una
        /// categoria de material.
        /// </summary>
        [Test]
        public void MaterialCategoryDeletionTest()
        {
            IReadOnlyCollection<MaterialCategory> prevMatCat = this.datMgr.MaterialCategory.Items;

            string name = "Uranium 235";

            MaterialCategory matCat = this.datMgr.MaterialCategory.New();
            matCat.Name = name;
            int matCatId = this.datMgr.MaterialCategory.Insert(matCat);

            Assert.AreNotEqual(0, matCatId);

            matCat = this.datMgr.MaterialCategory.GetById(matCatId);

            Assert.AreEqual(matCatId, matCat.Id);
            Assert.AreEqual(name, matCat.Name);
            Assert.AreEqual(false, matCat.Deleted);

            IReadOnlyCollection<MaterialCategory> afterMatCat = this.datMgr.MaterialCategory.Items;
            int expectedMatCatCount = prevMatCat.Count + 1;

            Assert.AreEqual(expectedMatCatCount, afterMatCat.Count);

            bool isOk = this.datMgr.MaterialCategory.Delete(matCatId);

            Assert.That(isOk);

            matCat = this.datMgr.MaterialCategory.GetById(matCatId);

            Assert.IsNull(matCat);

            IReadOnlyCollection<MaterialCategory> lastMatCat = this.datMgr.MaterialCategory.Items;
            expectedMatCatCount = afterMatCat.Count - 1;

            Assert.AreEqual(expectedMatCatCount, lastMatCat.Count);
        }

        /// <summary>
        /// Test de suspender un usuario.
        /// </summary>
        [Test]
        public void SuspendUserTest()
        {
            string firstName = "Steve";
            string lastName = "Vai";
            UserRole role = UserRole.CompanyAdministrator;

            User usr = this.datMgr.User.New();
            usr.FirstName = firstName;
            usr.LastName = lastName;
            usr.Role = role;
            int usrId = this.datMgr.User.Insert(usr);

            Assert.AreNotEqual(0, usrId);

            usr = this.datMgr.User.GetById(usrId);

            Assert.AreEqual(false, usr.Suspended);

            usr.Suspended = true;
            bool isOk = this.datMgr.User.Update(usr);

            Assert.That(isOk);
            usr = this.datMgr.User.GetById(usrId);

            Assert.AreEqual(true, usr.Suspended);
        }

        /// <summary>
        /// Test de creacion de una
        /// habilitacion.
        /// </summary>
        [Test]
        public void QualificationCreationTest()
        {
            IReadOnlyCollection<Qualification> prevQualificationAdd = this.datMgr.Qualification.Items;

            string name = "Habilitacion madera";

            Qualification qualification = this.datMgr.Qualification.New();
            qualification.Name = name;
            int qualificationId = this.datMgr.Qualification.Insert(qualification);

            // Valido que se le haya agregado una habilitacion
            Assert.AreNotEqual(0, qualificationId);

            Qualification xNuevo = this.datMgr.Qualification.GetById(qualificationId);

            // Valido que la habilitacion traida por GetById= al que ingrese
            Assert.AreEqual(name, xNuevo.Name);
            Assert.AreEqual(qualificationId, xNuevo.Id);

            IReadOnlyCollection<Qualification> postQualificationAdd = this.datMgr.Qualification.Items;

            int expectedQualificationCount = prevQualificationAdd.Count + 1;

            // Valido que se haya agregado una habilitacion a la lista de habilitaciones dentro de this.datMgr.Qualification.Items
            Assert.AreEqual(expectedQualificationCount, postQualificationAdd.Count);
        }
    }
}