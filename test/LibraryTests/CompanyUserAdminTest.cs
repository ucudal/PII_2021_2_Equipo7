using System;
using System.Collections.ObjectModel;
using ClassLibrary;
using NUnit.Framework;


namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="CompanyUserAdmin"/>.
    /// </summary>
     public class CompanyUserAdminTest
    {
        private CompanyUserAdmin companyUsAdmin = Singleton<CompanyUserAdmin>.Instance;

        /// <summary>
        /// 
        /// </summary>
        

        
        [Test] 
        public void InsertTest()
        {
            ReadOnlyCollection<CompanyUser> items = companyUsAdmin.Items;
            
            
            int userAdminId= 5 ;
            int companyid = 2;
            CompanyUser compania = companyUsAdmin.New();
            compania.CompanyId = companyid;
            compania.AdminUserId = userAdminId; 
            int id = companyUsAdmin.Insert(compania);
            Assert.AreNotEqual(0,id);

            compania = companyUsAdmin.GetById(id);
            Assert.AreEqual(userAdminId,compania.AdminUserId);
            Assert.AreEqual(companyid,compania.CompanyId);

        }
        

        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void UpdateTest()
        {
        
            //Insertamos una invitacion y validamos que haya quedado agregada
            ReadOnlyCollection<CompanyUser> userpre = companyUsAdmin.Items;

            int userid=3;
            int companyid = 2;
            

            CompanyUser loc = companyUsAdmin.New();
            loc.CompanyId = companyid;
            loc.AdminUserId= userid;
            
            
            int locId = companyUsAdmin.Insert(loc);

            Assert.AreNotEqual(0, locId);

            
        
            ReadOnlyCollection<CompanyUser> locationspost = companyUsAdmin.Items;

            int expectedInvites = userpre.Count + 1;

            Assert.AreEqual(expectedInvites, locationspost.Count);
            
          
            CompanyUser xToUpdate=companyUsAdmin.New();
            xToUpdate=companyUsAdmin.GetById(locId);
            
            

            int userid2= 111;
            int companyid1 = 3;
            
            

            xToUpdate.AdminUserId= userid2;
            xToUpdate.CompanyId=companyid1;
            


            companyUsAdmin.Update(xToUpdate);

            CompanyUser xComp=companyUsAdmin.GetById(locId);

            Assert.AreEqual(xToUpdate.Id, xComp.Id);
            Assert.AreEqual(xToUpdate.Deleted,xComp.Deleted);
            Assert.AreEqual(xToUpdate.CompanyId, xComp.CompanyId);
            
            Assert.AreEqual(xToUpdate.CompanyId, xComp.CompanyId);



            
        }
                /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void NewTest()
        {
            CompanyUser company =companyUsAdmin.New();
            Assert.IsInstanceOf(typeof(CompanyUser),company);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void GetByIdTest()
        {
            CompanyUser company =companyUsAdmin.New();
            company.CompanyId= 1;
            int id = companyUsAdmin.Insert(company);
            CompanyUser company2 =companyUsAdmin.GetById(id);


            Assert.AreEqual(company.CompanyId,company2.CompanyId);
            Assert.AreEqual(id,company2.Id);
            
        }
        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void DeleteTest()
        {
            //Insertamos un elemento
            ReadOnlyCollection<CompanyUser> locationspre = companyUsAdmin.Items;

            int usid= 2;
            int companyid = 2;
            

            CompanyUser loc = companyUsAdmin.New();
            loc.CompanyId = companyid;
            loc.AdminUserId = usid;
            
            
            int locId = companyUsAdmin.Insert(loc);

            Assert.AreNotEqual(0, locId);

            
        
            ReadOnlyCollection<CompanyUser> locationspost = companyUsAdmin.Items;

            int expectedInvites = locationspre.Count + 1;

            Assert.AreEqual(expectedInvites, locationspost.Count);

            companyUsAdmin.Delete(locId);

            ReadOnlyCollection<CompanyUser> afterDelete = companyUsAdmin.Items;
            expectedInvites = locationspost.Count - 1;
            //Comprobamos que se elimino una invitacion
            Assert.AreEqual(expectedInvites,afterDelete.Count);


        }
        


    }
}