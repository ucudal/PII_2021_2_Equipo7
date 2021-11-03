using System;
using System.Collections.ObjectModel;
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
        /// <summary>
        /// Operacion de registrarse como
        /// un usuario con nueva compania.
        /// </summary>
        [Test]
        public void AcceptCompanyNewInvitationTest()
        {
            CompanyAdmin compAdmin = Singleton<CompanyAdmin>.Instance;
            UserAdmin usrAdmin = Singleton<UserAdmin>.Instance;
            InvitationAdmin invAdmin = Singleton<InvitationAdmin>.Instance;

            ReadOnlyCollection<Invitation> prevInvites = invAdmin.Items;
            
            DateTime validAfter = DateTime.Now.AddMonths(-1);
            DateTime validBefore = DateTime.Now.AddMonths(1);
            RegistrationType type = RegistrationType.CopmanyNew;
            int companyId = 0;


            Invitation inv = invAdmin.New();
            inv.Type = type;
            inv.ValidAfter = validAfter;
            inv.ValidBefore = validBefore;
            inv.CompanyId = companyId;
            int invId = invAdmin.Insert(inv);
            invAdmin.GenerateNewInviteCode(invId);

            inv = invAdmin.GetById(invId);

            Assert.IsNotNull(inv);
            Assert.That(!inv.Used);

            string usrFName = "John";
            string usrLName = "Petrucci";
            UserRole role = UserRole.CompanyAdministrator;
            string compName = "Dream Theater";
            string compTrade = "Glorious Music";

            User usr = usrAdmin.New();
            usr.FirstName = usrFName;
            usr.LastName = usrLName;
            usr.Role = role;
            int usrId = usrAdmin.Insert(usr);

            Assert.AreNotEqual(0, usrId);

            usr = usrAdmin.GetById(usrId);

            Company comp = compAdmin.New();
            comp.Name = compName;
            comp.Trade = compTrade;
            int compId = compAdmin.Insert(comp);

            Assert.AreNotEqual(0, compId);

            comp = compAdmin.GetById(compId);

            inv.Used = true;
            invAdmin.Update(inv);
            
            inv = invAdmin.GetById(invId);
            
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
            Assert.Pass();
        }

        /// <summary>
        /// Operacion de registrarse como
        /// un usuario con un nuevo
        /// emprendimiento.
        /// </summary>
        [Test]
        public void AcceptEntrepreneurNewInvitationTest()
        {
            Assert.Pass();
        }

        /// <summary>
        /// Operacion de registrarse como
        /// un usuario administrador de la
        /// plataforma.
        /// </summary>
        [Test]
        public void AcceptSysAdminNewInvitationTest()
        {
            Assert.Pass();
        }
    }
}