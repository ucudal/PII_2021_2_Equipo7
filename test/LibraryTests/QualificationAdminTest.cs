using System;
using System.Collections.ObjectModel;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Test de la clase que administra las habilitaciones.
    /// </summary>
    public class QualificationAdminTest
    {
        private QualificationAdmin quaAdmin = Singleton<QualificationAdmin>.Instance;


        [Test]
        public void InsertTest()
        {
            ReadOnlyCollection<Qualification> items = quaAdmin.Items;
            string Name="Habilitacion madera";
            Qualification quali = quaAdmin.New();
            quali.Name = Name;
            int habili = quaAdmin.Insert(quali);
            Assert.AreNotEqual(0,habili);
            quali = quaAdmin.GetById(habili);
            Assert.AreEqual(Name,quali.Name);

        }


        [Test]
        public void NewTest()
        {
            Qualification qualification =quaAdmin.New();
            Assert.IsInstanceOf(typeof(Qualification),qualification);
        }


        [Test]
        public void DeleteTest()
        {
            Qualification qualification =quaAdmin.New();
            qualification.Name="Franco";
            quaAdmin.Insert(qualification);
            int NewId =qualification.Id;
            quaAdmin.Delete(NewId);
            Assert.IsNull(quaAdmin.GetById(NewId));

        }


        [Test]
        public void UpdateTest()
        {
            


        }

    }
}