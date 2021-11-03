using System;
using System.Collections.ObjectModel;
using ClassLibrary;
using NUnit.Framework;


namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="CompanyAdmin"/>.
    /// </summary>
     public class CompanyAdminTest
    {
        private CompanyAdmin companyAdmin = Singleton<CompanyAdmin>.Instance;

        /// <summary>
        /// 
        /// </summary>
        

        
        [Test] 
        public void InsertTest()
        {
            ReadOnlyCollection<Company> items = companyAdmin.Items;
            
            
            string name="nombre compania";
            string trade ="rubro";
            Company compania = companyAdmin.New();
            compania.Name = name;
            compania.Trade = trade;
            int companyid = companyAdmin.Insert(compania);
            Assert.AreNotEqual(0,companyid);

            compania = companyAdmin.GetById(companyid);
            Assert.AreEqual(name,compania.Name);
            Assert.AreEqual(trade,compania.Trade);

        }

        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void UpdateTest()
        {
            Company compania = companyAdmin.New();
            compania.Name="pepito";
            int idcompania = companyAdmin.Insert(compania);
            Company compania2 = companyAdmin.New();
            compania2=companyAdmin.GetByName("pepito");
            int id =compania2.Id;
            compania2.Trade="armas";
            companyAdmin.Update(compania2);
            Company compania3 = new Company();
            compania3=companyAdmin.GetById(id);
            Assert.AreEqual("armas",compania3.Trade);
            Assert.AreNotEqual(0,idcompania);
            // no se que hacer en esta patyre si me falta algo

            
        }
                /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void NewTest()
        {
            Company company =companyAdmin.New();
            Assert.IsInstanceOf(typeof(Company),company);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void GetByIdTest()
        {
            Company company =companyAdmin.New();
            company.Name="pepito";
            company.Trade="pepito";
            companyAdmin.Insert(company);
            Company company2 =companyAdmin.GetByName("pepito");
            int id =company2.Id;
            Company company3= companyAdmin.GetById(id);
            Assert.AreEqual(company2.Id,company3.Id);
            Assert.AreEqual(company2.Name,company3.Name);
            Assert.AreEqual(company2.Trade,company3.Trade);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void DeleteTest()
        {
            Company company =new Company();
            company.Name="pepito";
            companyAdmin.Insert(company);
            Company company2 =companyAdmin.GetByName("pepito");
            int id =company2.Id;
            companyAdmin.Delete(id);
            Company company3 =companyAdmin.GetById(id);
            Assert.IsNull(company3);
            


        }


    }
}