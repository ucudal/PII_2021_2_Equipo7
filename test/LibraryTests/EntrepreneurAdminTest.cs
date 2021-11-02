using System;
using System.Collections.ObjectModel;
using ClassLibrary;
using NUnit.Framework;


namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="EntrepreneurAdmin"/>.
    /// </summary>
     public class EntrepreneurAdminTest
    {
        private EntrepreneurAdmin entrepreneurAdmin = Singleton<EntrepreneurAdmin>.Instance;

        /// <summary>
        /// test para incertar un objeto en emprendedor 
        /// </summary>
        

        
        [Test] 
        public void InsertTest()
        {
            ReadOnlyCollection<Entrepreneur> items = entrepreneurAdmin.Items;
            
            
            string name="nombre Entrepreneur";
            string trade ="rubro";
            Entrepreneur empre = entrepreneurAdmin.New();
            empre.Name = name;
            empre.Trade = trade;
            int entreid = entrepreneurAdmin.Insert(empre);
            Assert.AreNotEqual(0,entreid);

            empre = entrepreneurAdmin.GetById(entreid);
            Assert.AreEqual(name,empre.Name);
            Assert.AreEqual(trade,empre.Trade);

        }

        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void UpdateTest()
        {
            Entrepreneur entrepreneur = entrepreneurAdmin.New();
            entrepreneur.Name="pepito";
            int identre = entrepreneurAdmin.Insert(entrepreneur);
            Entrepreneur empre2 = entrepreneurAdmin.New();
            empre2 = entrepreneurAdmin.GetByName("pepito");
            int id = empre2.Id;
            empre2.Trade = "armas";
            entrepreneurAdmin.Update(empre2);
            Entrepreneur empre3 = entrepreneurAdmin.New();
            empre3 = entrepreneurAdmin.GetById(id);
            Assert.AreEqual("armas",empre3.Trade);
            Assert.AreNotEqual(0,identre);
            // no se que hacer en esta patyre si me falta algo

            
        }
                /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void NewTest()
        {
            Entrepreneur entrepreneur =entrepreneurAdmin.New();
            Assert.IsInstanceOf(typeof(Entrepreneur),entrepreneur);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void GetByIdTest()
        {
            Entrepreneur entrepreneur =entrepreneurAdmin.New();
            entrepreneur.Name="pepito";
            int idempre = entrepreneurAdmin.Insert(entrepreneur);
            Entrepreneur empre2 =entrepreneurAdmin.GetById(idempre);
            int id =empre2.Id;
            Entrepreneur entre3= entrepreneurAdmin.GetById(id);
            Assert.AreEqual(empre2,entre3);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void DeleteTest()
        {
            Entrepreneur empre =entrepreneurAdmin.New();
            empre.Name="pepito";
            entrepreneurAdmin.Insert(empre);
            Entrepreneur entre2 =entrepreneurAdmin.GetByName("pepito");
            int id =entre2.Id;
            entrepreneurAdmin.Delete(id);
            Entrepreneur entre3 =entrepreneurAdmin.GetById(id);
            Assert.IsNull(entre3);
            


        }


    }
}