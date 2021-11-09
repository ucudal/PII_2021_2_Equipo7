using System;
using System.Collections.Generic;
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
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Test de creacion de una invitacion.
        /// </summary>
        [Test]
        public void CreateInvitationTest()
        {
            IReadOnlyCollection<Invitation> prevInvites = this.datMgr.Invitation.Items;

            RegistrationType type = RegistrationType.CopmanyNew;
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = 0;
            bool used = false;

            Invitation inv = this.datMgr.Invitation.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = used;
            int invId = this.datMgr.Invitation.Insert(inv);

            Assert.AreNotEqual(0, invId);

            this.datMgr.Invitation.GenerateNewInviteCode(invId);
            inv = this.datMgr.Invitation.GetById(invId);

            Assert.AreEqual(invId, inv.Id);
            Assert.AreEqual(type, inv.Type);
            Assert.AreEqual(validAfter, inv.ValidAfter);
            Assert.AreEqual(validBefore, inv.ValidBefore);
            Assert.AreEqual(companyId, inv.CompanyId);
            Assert.AreEqual(used, inv.Used);
            Assert.AreEqual(false, inv.Deleted);
            Assert.AreEqual(16, inv.Code.Length);

            IReadOnlyCollection<Invitation> afterInvites = this.datMgr.Invitation.Items;

            int expectedInvites = prevInvites.Count + 1;

            Assert.AreEqual(expectedInvites, afterInvites.Count);
        }
        /// <summary>
        /// Test del metodo GetByCode(string pCode).
        /// </summary>
        [Test]
        public void GetByCodeTest()
        {
            IReadOnlyCollection<Invitation> prevInvites = this.datMgr.Invitation.Items;

            RegistrationType type = RegistrationType.CopmanyNew;
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = 0;
            bool used = false;

            Invitation inv = this.datMgr.Invitation.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = used;
            int invId = this.datMgr.Invitation.Insert(inv);

            Assert.AreNotEqual(0, invId);

            this.datMgr.Invitation.GenerateNewInviteCode(invId);
            inv = this.datMgr.Invitation.GetById(invId);

            Invitation xComp=this.datMgr.Invitation.GetByCode(inv.Code);

        
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
        /// Test del metodo GetInvitationIsOfType(string code, RegistrationType type).
        /// </summary>
        [Test]
        public void GetInvitationIsOfTypeTest()
        {
            //Inserto una company
            IReadOnlyCollection<Invitation> prevInvites = this.datMgr.Invitation.Items;

            RegistrationType type = RegistrationType.CopmanyNew;
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = 0;
            bool used = false;

            Invitation inv = this.datMgr.Invitation.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = used;
            int invId = this.datMgr.Invitation.Insert(inv);

            Assert.AreNotEqual(0, invId);

            this.datMgr.Invitation.GenerateNewInviteCode(invId);

            Invitation CompanyInvitation=this.datMgr.Invitation.GetById(invId);
        
            IReadOnlyCollection<Invitation> afterInvites = this.datMgr.Invitation.Items;

            int expectedInvites = prevInvites.Count + 1;

            //Valido que me haya agregado bien
            Assert.AreEqual(expectedInvites, afterInvites.Count);
            
            bool expectedIsCompanyInvitation=true;
            Assert.AreEqual(expectedIsCompanyInvitation, this.datMgr.Invitation.GetInvitationIsOfType(CompanyInvitation.Code,RegistrationType.CopmanyNew));


        }

        /// <summary>
        /// Test del metodo Insert(Invitation pElemento).
        /// </summary>
        [Test]
        public void InsertTest()
        {
            IReadOnlyCollection<Invitation> prevInvites = this.datMgr.Invitation.Items;

            RegistrationType type = RegistrationType.CopmanyNew;
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = 0;
            bool used = false;

            Invitation inv = this.datMgr.Invitation.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = used;
            int invId = this.datMgr.Invitation.Insert(inv);

            Assert.AreNotEqual(0, invId);

            this.datMgr.Invitation.GenerateNewInviteCode(invId);
        
            IReadOnlyCollection<Invitation> afterInvites = this.datMgr.Invitation.Items;

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
            IReadOnlyCollection<Invitation> prevInvites = this.datMgr.Invitation.Items;

            RegistrationType type = RegistrationType.CopmanyNew;
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = 0;
            bool used = false;

            Invitation inv = this.datMgr.Invitation.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = used;
            int invId = this.datMgr.Invitation.Insert(inv);

            Assert.AreNotEqual(0, invId);

            this.datMgr.Invitation.GenerateNewInviteCode(invId);
        
            IReadOnlyCollection<Invitation> afterInvites = this.datMgr.Invitation.Items;

            int expectedInvites = prevInvites.Count + 1;

            Assert.AreEqual(expectedInvites, afterInvites.Count);
            
            //Obtenemos la invitacion recien agregada, le cambiamos los campos y le damos a update
            Invitation xToUpdate=this.datMgr.Invitation.New();
            xToUpdate=this.datMgr.Invitation.GetById(invId);
            
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

            this.datMgr.Invitation.Update(xToUpdate);

            Invitation xComp=this.datMgr.Invitation.GetById(invId);

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
            IReadOnlyCollection<Invitation> prevInvites = this.datMgr.Invitation.Items;

            RegistrationType type = RegistrationType.CopmanyNew;
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = 0;
            bool used = false;

            Invitation inv = this.datMgr.Invitation.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = used;
            int invId = this.datMgr.Invitation.Insert(inv);

            Assert.AreNotEqual(0, invId);

            this.datMgr.Invitation.GenerateNewInviteCode(invId);
        
            IReadOnlyCollection<Invitation> afterInvites = this.datMgr.Invitation.Items;

            int expectedInvites = prevInvites.Count + 1;

            //Validamos que se haya agregado 
            Assert.AreEqual(expectedInvites, afterInvites.Count);

            //Hacemos el delete y luego validamos que al cantidad haya disminuido 1
            IReadOnlyCollection<Invitation> beforeDelete=afterInvites;

            expectedInvites=afterInvites.Count - 1;

            this.datMgr.Invitation.Delete(invId);

            IReadOnlyCollection<Invitation> afterDelete = this.datMgr.Invitation.Items;

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
            IReadOnlyCollection<Invitation> prevInvites = this.datMgr.Invitation.Items;

            RegistrationType type = RegistrationType.CopmanyNew;
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            int companyId = 0;
            bool used = false;

            Invitation inv = this.datMgr.Invitation.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = used;
            int invId = this.datMgr.Invitation.Insert(inv);

            Assert.AreNotEqual(0, invId);

            this.datMgr.Invitation.GenerateNewInviteCode(invId);
        
            IReadOnlyCollection<Invitation> afterInvites = this.datMgr.Invitation.Items;

            int expectedInvites = prevInvites.Count + 1;

            Assert.AreEqual(expectedInvites, afterInvites.Count);
            
            //Obtenemos la invitacion agregada con GetById y comparamos
            Invitation xComp=this.datMgr.Invitation.GetById(invId);
            
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