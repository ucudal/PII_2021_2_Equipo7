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


        /// <summary>
        /// Testear que los valores se ingresan en la data.
        /// </summary>
        [Test]
        public void InsertTestQ()
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

        /// <summary>
        /// Comprobar que se crea una nueva habilitación.
        /// </summary>
        [Test]
        public void NewTestQ()
        {
            Qualification qualification =quaAdmin.New();
            Assert.IsInstanceOf(typeof(Qualification),qualification);
        }

        /// <summary>
        /// Comprobar que se borra un id.
        /// </summary>
        [Test]
        public void DeleteTestQ()
        {
            Qualification qualification =quaAdmin.New();
            qualification.Name="Franco";
            quaAdmin.Insert(qualification);
            int NewId =qualification.Id;
            quaAdmin.Delete(NewId);
            Assert.IsNull(quaAdmin.GetById(NewId));
        }

        /// <summary>
        /// Comprobar que funciona el update del DataAdmin.
        /// </summary>
        [Test]
        public void UpdateTestQ()
        {
            string Name="Habilitacion madera";
            Qualification quali = quaAdmin.New();
            quali.Name = Name;
            int habili = quaAdmin.Insert(quali);
            Assert.AreNotEqual(0,habili);
            Qualification quali2 = quaAdmin.GetById(habili);
            quali2.Name = "Habilitacion plastico";
            quaAdmin.Update(quali2);
            Qualification quali3 = quaAdmin.GetById(habili);
            Assert.AreEqual(quali2.Name,quali3.Name);
            Assert.AreEqual(quali2.Id,quali3.Id);


        }

    }
}