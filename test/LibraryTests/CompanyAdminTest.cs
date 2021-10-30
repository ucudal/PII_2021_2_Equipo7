using System;
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
            Company compania = new Company();
            compania.Name="pepito";
            companyAdmin.Insert(compania);
            Assert.That(companyAdmin.Items.Exists(item=>item.Name=="pepito"));
            
        }

        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void UpdateTest()
        {
            Company compania = new Company();
            compania.Name="pepito";
            companyAdmin.Insert(compania);
            Company compania2 = new Company();
            compania2=companyAdmin.GetByName("pepito");
            int id =compania2.Id;
            compania2.Trade="armas";
            companyAdmin.Update(compania2);
            Company compania3 = new Company();
            compania3=companyAdmin.GetById(id);
            Assert.AreEqual("armas",compania3.Trade);

            Assert.That(companyAdmin.Items.Exists(item=>item.Name=="pepito"));
            
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
            companyAdmin.Insert(company);
            Company company2 =companyAdmin.GetByName("pepito");
            int id =company2.Id;
            Company company3= companyAdmin.GetById(id);
            Assert.AreEqual(company2,company3);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void DeleteTest()
        {
            Company company =companyAdmin.New();
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