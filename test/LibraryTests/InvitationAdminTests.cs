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
    }
}