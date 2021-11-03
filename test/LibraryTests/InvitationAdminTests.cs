using System;
using System.Collections.ObjectModel;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests del administrador de invitaciones.
    /// </summary>
    [TestFixture]
    public class InvitationAdminTests
    {
        private InvitationAdmin invAdmin = Singleton<InvitationAdmin>.Instance;

        /// <summary>
        /// Test de creacion de una invitacion.
        /// </summary>
        [Test]
        public void CreateInvitationTest()
        {
            ReadOnlyCollection<Invitation> prevInvites = invAdmin.Items;

            RegistrationType type = RegistrationType.CopmanyNew;
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = 0;
            bool used = false;

            Invitation inv = invAdmin.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = used;
            int invId = invAdmin.Insert(inv);

            Assert.AreNotEqual(0, invId);

            invAdmin.GenerateNewInviteCode(invId);
            inv = invAdmin.GetById(invId);

            Assert.AreEqual(invId, inv.Id);
            Assert.AreEqual(type, inv.Type);
            Assert.AreEqual(validAfter, inv.ValidAfter);
            Assert.AreEqual(validBefore, inv.ValidBefore);
            Assert.AreEqual(companyId, inv.CompanyId);
            Assert.AreEqual(used, inv.Used);
            Assert.AreEqual(false, inv.Deleted);
            Assert.AreEqual(16, inv.Code.Length);

            ReadOnlyCollection<Invitation> afterInvites = invAdmin.Items;

            int expectedInvites = prevInvites.Count + 1;

            Assert.AreEqual(expectedInvites, afterInvites.Count);
        }
        /// <summary>
        /// Test del metodo GetByCode(string pCode).
        /// </summary>
        [Test]
        public void GetByCodeTest()
        {
            ReadOnlyCollection<Invitation> prevInvites = invAdmin.Items;

            RegistrationType type = RegistrationType.CopmanyNew;
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = 0;
            bool used = false;

            Invitation inv = invAdmin.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = used;
            int invId = invAdmin.Insert(inv);

            Assert.AreNotEqual(0, invId);

            invAdmin.GenerateNewInviteCode(invId);
            inv = invAdmin.GetById(invId);

            Invitation xComp=invAdmin.GetByCode(inv.Code);

        
            Assert.AreEqual(inv.Id, xComp.Id);
            Assert.AreEqual(inv.Type,xComp.Type);
            Assert.AreEqual(inv.ValidAfter, xComp.ValidAfter);
            Assert.AreEqual(inv.ValidBefore, xComp.ValidBefore);
            Assert.AreEqual(inv.CompanyId, xComp.CompanyId);
            Assert.AreEqual(inv.Used, xComp.Used);
            Assert.AreEqual(inv.Deleted, xComp.Deleted);
            Assert.AreEqual(inv.Code, xComp.Code);
        }

        /// <summary>
        /// Test del metodo Insert(Invitation pElemento).
        /// </summary>
        [Test]
        public void InsertTest()
        {
            ReadOnlyCollection<Invitation> prevInvites = invAdmin.Items;

            RegistrationType type = RegistrationType.CopmanyNew;
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = 0;
            bool used = false;

            Invitation inv = invAdmin.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = used;
            int invId = invAdmin.Insert(inv);

            Assert.AreNotEqual(0, invId);

            invAdmin.GenerateNewInviteCode(invId);
        
            ReadOnlyCollection<Invitation> afterInvites = invAdmin.Items;

            int expectedInvites = prevInvites.Count + 1;

            Assert.AreEqual(expectedInvites, afterInvites.Count);
        }

        /// <summary>
        /// Test del metodo Update(Invitation pElemento).
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            //Insertamos una invitacion y validamos que haya quedado agregada
            ReadOnlyCollection<Invitation> prevInvites = invAdmin.Items;

            RegistrationType type = RegistrationType.CopmanyNew;
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = 0;
            bool used = false;

            Invitation inv = invAdmin.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = used;
            int invId = invAdmin.Insert(inv);

            Assert.AreNotEqual(0, invId);

            invAdmin.GenerateNewInviteCode(invId);
        
            ReadOnlyCollection<Invitation> afterInvites = invAdmin.Items;

            int expectedInvites = prevInvites.Count + 1;

            Assert.AreEqual(expectedInvites, afterInvites.Count);
            
            //Obtenemos la invitacion recien agregada, le cambiamos los campos y le damos a update
            Invitation xToUpdate=invAdmin.New();
            xToUpdate=invAdmin.GetById(invId);
            
            //atributos nuevos
            RegistrationType xType = RegistrationType.CopmanyNew;
            DateTime xValidAfter = DateTime.Now.AddMonths(1);
            DateTime xValidBefore = DateTime.Now.AddMonths(2);
            int xCompanyId = 1;
            bool xUsed = false;

            xToUpdate.Id=invId;
            xToUpdate.Type=xType;
            xToUpdate.ValidAfter=xValidAfter;
            xToUpdate.ValidBefore=xValidBefore;
            xToUpdate.CompanyId=xCompanyId;
            xToUpdate.Used=xUsed;

            invAdmin.Update(xToUpdate);

            Invitation xComp=invAdmin.GetById(invId);

            Assert.AreEqual(xToUpdate.Id, xComp.Id);
            Assert.AreEqual(xToUpdate.Type,xComp.Type);
            Assert.AreEqual(xToUpdate.ValidAfter, xComp.ValidAfter);
            Assert.AreEqual(xToUpdate.ValidBefore, xComp.ValidBefore);
            Assert.AreEqual(xToUpdate.CompanyId, xComp.CompanyId);
            Assert.AreEqual(xToUpdate.Used, xComp.Used);
            Assert.AreEqual(xToUpdate.Deleted, xComp.Deleted);
            Assert.AreEqual(xToUpdate.Code, xComp.Code);
        }

        /// <summary>
        /// Test del metodo Delete(int pId).
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            //Insertamos un elemento
            ReadOnlyCollection<Invitation> prevInvites = invAdmin.Items;

            RegistrationType type = RegistrationType.CopmanyNew;
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = 0;
            bool used = false;

            Invitation inv = invAdmin.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = used;
            int invId = invAdmin.Insert(inv);

            Assert.AreNotEqual(0, invId);

            invAdmin.GenerateNewInviteCode(invId);
        
            ReadOnlyCollection<Invitation> afterInvites = invAdmin.Items;

            int expectedInvites = prevInvites.Count + 1;

            //Validamos que se haya agregado 
            Assert.AreEqual(expectedInvites, afterInvites.Count);

            //Hacemos el delete y luego validamos que al cantidad haya disminuido 1
            ReadOnlyCollection<Invitation> beforeDelete=afterInvites;

            expectedInvites=afterInvites.Count - 1;

            invAdmin.Delete(invId);

            ReadOnlyCollection<Invitation> afterDelete = invAdmin.Items;

            //Comprobamos que se elimino una invitacion
            Assert.AreEqual(expectedInvites,afterDelete.Count);
        }

        /// <summary>
        /// Test del metodo GetById(int pId).
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            //Insertamos una invitacion y validamos que haya quedado agregada
            ReadOnlyCollection<Invitation> prevInvites = invAdmin.Items;

            RegistrationType type = RegistrationType.CopmanyNew;
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = 0;
            bool used = false;

            Invitation inv = invAdmin.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = used;
            int invId = invAdmin.Insert(inv);

            Assert.AreNotEqual(0, invId);

            invAdmin.GenerateNewInviteCode(invId);
        
            ReadOnlyCollection<Invitation> afterInvites = invAdmin.Items;

            int expectedInvites = prevInvites.Count + 1;

            Assert.AreEqual(expectedInvites, afterInvites.Count);
            
            //Obtenemos la invitacion agregada con GetById y comparamos
            Invitation xComp=invAdmin.GetById(invId);
            
            Assert.AreEqual(invId, xComp.Id);
            Assert.AreEqual(inv.Type,xComp.Type);
            Assert.AreEqual(inv.ValidAfter, xComp.ValidAfter);
            Assert.AreEqual(inv.ValidBefore, xComp.ValidBefore);
            Assert.AreEqual(inv.CompanyId, xComp.CompanyId);
            Assert.AreEqual(inv.Used, xComp.Used);
            Assert.AreEqual(inv.Deleted, xComp.Deleted);
        }
    }
}