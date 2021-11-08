using System.Collections.Generic;
using ClassLibrary;
using NUnit.Framework;


namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="CompanyUserAdmin"/>.
    /// </summary>
     public class CompanyUserAdminTest
    {
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void InsertTest()
        {
            IReadOnlyCollection<CompanyUser> items = this.datMgr.CompanyUser.Items;
            
            int userAdminId= 5 ;
            int companyid = 2;
            CompanyUser compania = this.datMgr.CompanyUser.New();
            compania.CompanyId = companyid;
            compania.AdminUserId = userAdminId; 
            int id = this.datMgr.CompanyUser.Insert(compania);
            Assert.AreNotEqual(0,id);

            compania = this.datMgr.CompanyUser.GetById(id);
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
            IReadOnlyCollection<CompanyUser> userpre = this.datMgr.CompanyUser.Items;

            int userid=3;
            int companyid = 2;

            CompanyUser loc = this.datMgr.CompanyUser.New();
            loc.CompanyId = companyid;
            loc.AdminUserId= userid;
            
            
            int locId = this.datMgr.CompanyUser.Insert(loc);

            Assert.AreNotEqual(0, locId);

            
        
            IReadOnlyCollection<CompanyUser> locationspost = this.datMgr.CompanyUser.Items;

            int expectedInvites = userpre.Count + 1;

            Assert.AreEqual(expectedInvites, locationspost.Count);
            
          
            CompanyUser xToUpdate=this.datMgr.CompanyUser.New();
            xToUpdate=this.datMgr.CompanyUser.GetById(locId);
            
            

            int userid2= 111;
            int companyid1 = 3;
            
            

            xToUpdate.AdminUserId= userid2;
            xToUpdate.CompanyId=companyid1;
            


            this.datMgr.CompanyUser.Update(xToUpdate);

            CompanyUser xComp=this.datMgr.CompanyUser.GetById(locId);

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
            CompanyUser company =this.datMgr.CompanyUser.New();
            Assert.IsInstanceOf(typeof(CompanyUser),company);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void GetByIdTest()
        {
            CompanyUser company =this.datMgr.CompanyUser.New();
            company.CompanyId= 1364;
            company.AdminUserId = 83;
            int id = this.datMgr.CompanyUser.Insert(company);
            CompanyUser company2 =this.datMgr.CompanyUser.GetById(id);


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
            IReadOnlyCollection<CompanyUser> locationspre = this.datMgr.CompanyUser.Items;

            int usid= 2;
            int companyid = 2;

            CompanyUser loc = this.datMgr.CompanyUser.New();
            loc.CompanyId = companyid;
            loc.AdminUserId = usid;
            
            
            int locId = this.datMgr.CompanyUser.Insert(loc);

            Assert.AreNotEqual(0, locId);

            
        
            IReadOnlyCollection<CompanyUser> locationspost = this.datMgr.CompanyUser.Items;

            int expectedInvites = locationspre.Count + 1;

            Assert.AreEqual(expectedInvites, locationspost.Count);

            this.datMgr.CompanyUser.Delete(locId);

            IReadOnlyCollection<CompanyUser> afterDelete = this.datMgr.CompanyUser.Items;
            expectedInvites = locationspost.Count - 1;
            //Comprobamos que se elimino una invitacion
            Assert.AreEqual(expectedInvites,afterDelete.Count);


        }
        


    }
}