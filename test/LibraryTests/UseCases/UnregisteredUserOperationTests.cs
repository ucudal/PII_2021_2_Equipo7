using System;
using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Conjunto de Tests para la operacion
    /// de un usuario no registrado.
    /// </summary>
    [TestFixture]
    public class UnregisteredUserOperationTests
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Operacion de registrarse como
        /// un usuario con nueva compania.
        /// </summary>
        [Test]
        public void AcceptCompanyNewInvitationTest()
        {
            IReadOnlyCollection<Invitation> prevInvites = this.datMgr.Invitation.Items;
            
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            RegistrationType type = RegistrationType.CopmanyNew;
            int companyId = 0;


            Invitation inv = this.datMgr.Invitation.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            int invId = this.datMgr.Invitation.Insert(inv);
            this.datMgr.Invitation.GenerateNewInviteCode(invId);

            inv = this.datMgr.Invitation.GetById(invId);

            Assert.IsNotNull(inv);
            Assert.That(!inv.Used);

            string usrFName = "John";
            string usrLName = "Petrucci";
            UserRole role = UserRole.CompanyAdministrator;
            string compName = "Dream Theater";
            string compTrade = "Glorious Music";

            User usr = this.datMgr.User.New();
            usr.FirstName = usrFName;
            usr.LastName = usrLName;
            usr.Role = role;
            int usrId = this.datMgr.User.Insert(usr);

            Assert.AreNotEqual(0, usrId);

            usr = this.datMgr.User.GetById(usrId);

            Company comp = this.datMgr.Company.New();
            comp.Name = compName;
            comp.Trade = compTrade;
            int compId = this.datMgr.Company.Insert(comp);

            Assert.AreNotEqual(0, compId);

            comp = this.datMgr.Company.GetById(compId);

            inv.Used = true;
            this.datMgr.Invitation.Update(inv);
            
            inv = this.datMgr.Invitation.GetById(invId);
            
            Assert.That(inv.Used);
            Assert.AreEqual(compId, comp.Id);
            Assert.AreEqual(compName, comp.Name);
            Assert.AreEqual(compTrade, comp.Trade);
            Assert.AreEqual(usrFName, usr.FirstName);
            Assert.AreEqual(usrLName, usr.LastName);
            Assert.AreEqual(role, usr.Role);
        }

        /// <summary>
        /// Operacion de registrarse como
        /// un usuario a una compania ya
        /// existente.
        /// </summary>
        [Test]
        public void AcceptCompanyJoinInvitationTest()
        {
            IReadOnlyCollection<Invitation> prevInvites = this.datMgr.Invitation.Items;
            
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            RegistrationType type = RegistrationType.CompanyJoin;
            int companyId = 5;


            Invitation inv = this.datMgr.Invitation.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = false;
            int invId = this.datMgr.Invitation.Insert(inv);
            this.datMgr.Invitation.GenerateNewInviteCode(invId);

            inv = this.datMgr.Invitation.GetById(invId);

            Assert.IsNotNull(inv);
            Assert.That(!inv.Used);

            string usrFName = "John";
            string usrLName = "Petrucci";
            UserRole role = UserRole.CompanyAdministrator;
            string compName = "Dream Theater";
            string compTrade = "Glorious Music";

            User usr = this.datMgr.User.New();
            usr.FirstName = usrFName;
            usr.LastName = usrLName;
            usr.Role = role;
            int usrId = this.datMgr.User.Insert(usr);

            Assert.AreNotEqual(0, usrId);

            usr = this.datMgr.User.GetById(usrId);

            Company comp = this.datMgr.Company.New();
            comp.Name = compName;
            comp.Trade = compTrade;
            int compId = this.datMgr.Company.Insert(comp);

            Assert.AreNotEqual(0, compId);

            comp = this.datMgr.Company.GetById(compId);

            inv.Used = true;
            this.datMgr.Invitation.Update(inv);
            
            inv = this.datMgr.Invitation.GetById(invId);
            
            Assert.That(inv.Used);
            Assert.AreEqual(compId, comp.Id);
            Assert.AreEqual(compName, comp.Name);
            Assert.AreEqual(compTrade, comp.Trade);
            Assert.AreEqual(usrFName, usr.FirstName);
            Assert.AreEqual(usrLName, usr.LastName);
            Assert.AreEqual(role, usr.Role);
        }

        /// <summary>
        /// Operacion de registrarse como
        /// un usuario con un nuevo
        /// emprendimiento.
        /// </summary>
        [Test]
        public void AcceptEntrepreneurNewInvitationTest()
        {
            IReadOnlyCollection<Invitation> prevInvites = this.datMgr.Invitation.Items;
            
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            RegistrationType type = RegistrationType.EntrepreneurNew;
            int companyId = 0;


            Invitation inv = this.datMgr.Invitation.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            inv.Used = false;
            int invId = this.datMgr.Invitation.Insert(inv);
            this.datMgr.Invitation.GenerateNewInviteCode(invId);

            inv = this.datMgr.Invitation.GetById(invId);

            Assert.IsNotNull(inv);
            Assert.That(!inv.Used);

            string usrFName = "John";
            string usrLName = "Petrucci";
            UserRole role = UserRole.Entrepreneur;
            string entreName = "Dream Theater";
            string entreTrade = "Glorious Music";

            User usr = this.datMgr.User.New();
            usr.FirstName = usrFName;
            usr.LastName = usrLName;
            usr.Role = role;
            int usrId = this.datMgr.User.Insert(usr);

            Assert.AreNotEqual(0, usrId);

            usr = this.datMgr.User.GetById(usrId);

            Entrepreneur entre = this.datMgr.Entrepreneur.New();
            entre.Name = entreName;
            entre.Trade = entreTrade;
            entre.UserId = usrId;
            entre.GeoReference = "Garibaldi y Bvd Artigas";
            int entreId = this.datMgr.Entrepreneur.Insert(entre);

            Assert.AreNotEqual(0, entreId);

            entre = this.datMgr.Entrepreneur.GetById(entreId);

            inv.Used = true;
            this.datMgr.Invitation.Update(inv);
            
            inv = this.datMgr.Invitation.GetById(invId);
            
            Assert.That(inv.Used);
            Assert.AreEqual(entreId, entre.Id);
            Assert.AreEqual(entreName, entre.Name);
            Assert.AreEqual(entreTrade, entre.Trade);
            Assert.AreEqual(usrFName, usr.FirstName);
            Assert.AreEqual(usrLName, usr.LastName);
            Assert.AreEqual(role, usr.Role);
        }

        /// <summary>
        /// Operacion de registrarse como
        /// un usuario administrador de la
        /// plataforma.
        /// </summary>
        [Test]
        public void AcceptSysAdminNewInvitationTest()
        {
            IReadOnlyCollection<Invitation> prevInvites = this.datMgr.Invitation.Items;
            
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            RegistrationType type = RegistrationType.SystemAdminJoin;
            int companyId = 0;


            Invitation inv = this.datMgr.Invitation.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            int invId = this.datMgr.Invitation.Insert(inv);
            this.datMgr.Invitation.GenerateNewInviteCode(invId);

            inv = this.datMgr.Invitation.GetById(invId);

            Assert.IsNotNull(inv);
            Assert.That(!inv.Used);

            string usrFName = "John";
            string usrLName = "Petrucci";
            UserRole role = UserRole.SystemAdministrator;

            User usr = this.datMgr.User.New();
            usr.FirstName = usrFName;
            usr.LastName = usrLName;
            usr.Role = role;
            int usrId = this.datMgr.User.Insert(usr);

            Assert.AreNotEqual(0, usrId);

            usr = this.datMgr.User.GetById(usrId);

          


            inv.Used = true;
            this.datMgr.Invitation.Update(inv);
            
            inv = this.datMgr.Invitation.GetById(invId);
            
            Assert.That(inv.Used);
            Assert.AreEqual(usrFName, usr.FirstName);
            Assert.AreEqual(usrLName, usr.LastName);
            Assert.AreEqual(role, usr.Role);
        }
    }
}