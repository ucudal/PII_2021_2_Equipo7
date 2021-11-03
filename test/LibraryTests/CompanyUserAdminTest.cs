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
        /*

        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void UpdateTest()
        {
        
            //Insertamos una invitacion y validamos que haya quedado agregada
            ReadOnlyCollection<CompanyLocation> locationspre = companyLocAdmin.Items;

            string geo="georeference";
            int companyid = 2;
            
            bool used = false;

            CompanyLocation loc = companyLocAdmin.New();
            loc.CompanyId = companyid;
            loc.GeoReference = geo;
            loc.Deleted = used;
            
            int locId = companyLocAdmin.Insert(loc);

            Assert.AreNotEqual(0, locId);

            
        
            ReadOnlyCollection<CompanyLocation> locationspost = companyLocAdmin.Items;

            int expectedInvites = locationspre.Count + 1;

            Assert.AreEqual(expectedInvites, locationspost.Count);
            
          
            CompanyLocation xToUpdate=companyLocAdmin.New();
            xToUpdate=companyLocAdmin.GetById(locId);
            
            

            string geo1="georeference11111111";
            int companyid1 = 3;
            
            bool used1 = false;

            xToUpdate.GeoReference=geo1;
            xToUpdate.CompanyId=companyid1;
            xToUpdate.Deleted=used1;


            companyLocAdmin.Update(xToUpdate);

            CompanyLocation xComp=companyLocAdmin.GetById(locId);

            Assert.AreEqual(xToUpdate.Id, xComp.Id);
            Assert.AreEqual(xToUpdate.Deleted,xComp.Deleted);
            Assert.AreEqual(xToUpdate.CompanyId, xComp.CompanyId);
            Assert.AreEqual(xToUpdate.GeoReference, xComp.GeoReference);
            Assert.AreEqual(xToUpdate.CompanyId, xComp.CompanyId);



            
        }
                /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void NewTest()
        {
            CompanyLocation company =companyLocAdmin.New();
            Assert.IsInstanceOf(typeof(CompanyLocation),company);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void GetByIdTest()
        {
            CompanyLocation company =companyLocAdmin.New();
            company.GeoReference="pepito";
            int id = companyLocAdmin.Insert(company);
            CompanyLocation company2 =companyLocAdmin.GetById(id);


            Assert.AreEqual(company,company2);
        }
        /// <summary>
        /// 
        /// </summary>
        [Test] 
        public void DeleteTest()
        {
 //Insertamos un elemento
            ReadOnlyCollection<CompanyLocation> locationspre = companyLocAdmin.Items;

            string geo="georeference";
            int companyid = 2;
            
            bool used = false;

            CompanyLocation loc = companyLocAdmin.New();
            loc.CompanyId = companyid;
            loc.GeoReference = geo;
            loc.Deleted = used;
            
            int locId = companyLocAdmin.Insert(loc);

            Assert.AreNotEqual(0, locId);

            
        
            ReadOnlyCollection<CompanyLocation> locationspost = companyLocAdmin.Items;

            int expectedInvites = locationspre.Count + 1;

            Assert.AreEqual(expectedInvites, locationspost.Count);

            companyLocAdmin.Delete(locId);

            ReadOnlyCollection<CompanyLocation> afterDelete = companyLocAdmin.Items;

            //Comprobamos que se elimino una invitacion
            Assert.AreEqual(expectedInvites,afterDelete.Count);


        }
        */


    }
}