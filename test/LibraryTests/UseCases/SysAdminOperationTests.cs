using System;
using System.Collections.ObjectModel;
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

        private QualificationAdmin qualificationAdmin=Singleton<QualificationAdmin>.Instance;

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
            InvitationAdmin invAdmin = Singleton<InvitationAdmin>.Instance;

            ReadOnlyCollection<Invitation> prevInvites = invAdmin.Items;
            
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = type == RegistrationType.CompanyJoin ? 42 : 0;

            Invitation inv = invAdmin.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            int invId = invAdmin.Insert(inv);

            Assert.AreNotEqual(0, invId);

            invAdmin.GenerateNewInviteCode(invId);
            inv = invAdmin.GetById(invId);

            Assert.AreEqual(invId, inv.Id);
            Assert.AreEqual(type, inv.Type);
            Assert.AreEqual(validAfter, inv.ValidAfter);
            Assert.AreEqual(validBefore, inv.ValidBefore);
            Assert.AreEqual(companyId, inv.CompanyId);
            Assert.AreEqual(false, inv.Used);
            Assert.AreEqual(false, inv.Deleted);
            Assert.AreEqual(16, inv.Code.Length);

            ReadOnlyCollection<Invitation> afterInvites = invAdmin.Items;

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
            MaterialCategoryAdmin matCatAdmin = Singleton<MaterialCategoryAdmin>.Instance;

            ReadOnlyCollection<MaterialCategory> prevMatCat = matCatAdmin.Items;

            string name = "Uranium 235";

            MaterialCategory matCat = matCatAdmin.New();
            matCat.Name = name;
            int matCatId = matCatAdmin.Insert(matCat);

            Assert.AreNotEqual(0, matCatId);

            matCat = matCatAdmin.GetById(matCatId);

            Assert.AreEqual(matCatId, matCat.Id);
            Assert.AreEqual(name, matCat.Name);
            Assert.AreEqual(false, matCat.Deleted);

            ReadOnlyCollection<MaterialCategory> afterMatCat = matCatAdmin.Items;

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
            MaterialCategoryAdmin matCatAdmin = Singleton<MaterialCategoryAdmin>.Instance;

            ReadOnlyCollection<MaterialCategory> prevMatCat = matCatAdmin.Items;

            string name = "Uranium 235";

            MaterialCategory matCat = matCatAdmin.New();
            matCat.Name = name;
            int matCatId = matCatAdmin.Insert(matCat);

            Assert.AreNotEqual(0, matCatId);

            matCat = matCatAdmin.GetById(matCatId);

            Assert.AreEqual(matCatId, matCat.Id);
            Assert.AreEqual(name, matCat.Name);
            Assert.AreEqual(false, matCat.Deleted);

            ReadOnlyCollection<MaterialCategory> afterMatCat = matCatAdmin.Items;
            int expectedMatCatCount = prevMatCat.Count + 1;

            Assert.AreEqual(expectedMatCatCount, afterMatCat.Count);

            bool isOk = matCatAdmin.Delete(matCatId);

            Assert.That(isOk);

            matCat = matCatAdmin.GetById(matCatId);

            Assert.IsNull(matCat);

            ReadOnlyCollection<MaterialCategory> lastMatCat = matCatAdmin.Items;
            expectedMatCatCount = afterMatCat.Count - 1;

            Assert.AreEqual(expectedMatCatCount, lastMatCat.Count);
        }

        /// <summary>
        /// Test de suspender un usuario.
        /// </summary>
        [Test]
        public void SuspendUserTest()
        {
            UserAdmin usrAdmin = Singleton<UserAdmin>.Instance;
            string firstName = "Steve";
            string lastName = "Vai";
            UserRole role = UserRole.CompanyAdministrator;

            User usr = usrAdmin.New();
            usr.FirstName = firstName;
            usr.LastName = lastName;
            usr.Role = role;
            int usrId = usrAdmin.Insert(usr);

            Assert.AreNotEqual(0, usrId);

            usr = usrAdmin.GetById(usrId);
            
            Assert.AreEqual(false, usr.Suspended);

            usr.Suspended = true;
            bool isOk = usrAdmin.Update(usr);

            Assert.That(isOk);
            usr = usrAdmin.GetById(usrId);
            
            Assert.AreEqual(true, usr.Suspended);
        }

        /// <summary>
        /// Test de creacion de una
        /// habilitacion.
        /// </summary>
        [Test]
        public void QualificationCreationTest()
        {
            ReadOnlyCollection<Qualification> prevQualificationAdd = qualificationAdmin.Items;

            string name="Habilitacion madera";

            Qualification qualification = qualificationAdmin.New();
            qualification.Name = name;
            int qualificationId = qualificationAdmin.Insert(qualification);

            //Valido que se le haya agregado una habilitacion
            Assert.AreNotEqual(0,qualificationId);

            Qualification xNuevo = qualificationAdmin.GetById(qualificationId);
            //Valido que la habilitacion traida por GetById= al que ingrese
            Assert.AreEqual(name,xNuevo.Name);
            Assert.AreEqual(qualificationId,xNuevo.Id);

            ReadOnlyCollection<Qualification> postQualificationAdd = qualificationAdmin.Items;

            int expectedQualificationCount = prevQualificationAdd.Count + 1;

            //Valido que se haya agregado una habilitacion a la lista de habilitaciones dentro de qualificationAdmin.Items
            Assert.AreEqual(expectedQualificationCount, postQualificationAdd.Count);
        }
    }
}