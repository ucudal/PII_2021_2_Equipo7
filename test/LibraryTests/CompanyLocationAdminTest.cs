using System;
using System.Collections.ObjectModel;
using ClassLibrary;
using NUnit.Framework;


namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="CompanyAdmin"/>.
    /// </summary>
     public class CompanyLocationAdminTest
    {
        private CompanyLocationAdmin companyLocAdmin = Singleton<CompanyLocationAdmin>.Instance;

        /// <summary>
        /// 
        /// </summary>
        

        
        [Test] 
        public void InsertTest()
        {
            ReadOnlyCollection<CompanyLocation> items = companyLocAdmin.Items;
            
            
            string geo="georeference";
            int companyid = 2;
            CompanyLocation compania = companyLocAdmin.New();
            compania.CompanyId = companyid;
            compania.GeoReference = geo;
            int id = companyLocAdmin.Insert(compania);
            Assert.AreNotEqual(0,id);

            compania = companyLocAdmin.GetById(id);
            Assert.AreEqual(geo,compania.GeoReference);
            Assert.AreEqual(companyid,compania.CompanyId);

        }

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
            
          
            CompanyLocation xToUpdate = companyLocAdmin.New();
            xToUpdate=companyLocAdmin.GetById(locId);
            
            

            string geo1 = "georeference11111111";
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
            company.CompanyId =5;




            int id = companyLocAdmin.Insert(company);
            CompanyLocation company2 =companyLocAdmin.GetById(id);


            
            Assert.AreEqual(id,company2.Id);
            Assert.AreEqual(company.GeoReference,company2.GeoReference);
            Assert.AreEqual(company.CompanyId,company2.CompanyId);
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

            int expectedInvites = locationspre.Count +  1;

            Assert.AreEqual(expectedInvites, locationspost.Count);

            companyLocAdmin.Delete(locId);

            ReadOnlyCollection<CompanyLocation> afterDelete = companyLocAdmin.Items;

            expectedInvites = locationspost.Count -  1;

            //Comprobamos que se elimino una invitacion
            Assert.AreEqual(expectedInvites,afterDelete.Count);


        }


        /// <summary>
        /// busca por el id de compania las locaciones de la misma
        /// </summary>
        [Test]
        public void GetLocationsForCompany()
        {
            CompanyLocation company1 = companyLocAdmin.New();
            company1.CompanyId=1; 
            CompanyLocation company2 = companyLocAdmin.New();
            company2.CompanyId=1; 
            CompanyLocation company3 = companyLocAdmin.New();
            company3.CompanyId=1; 
            companyLocAdmin.Insert(company1);
            companyLocAdmin.Insert(company2);
            companyLocAdmin.Insert(company3);

            ReadOnlyCollection<CompanyLocation> lista = companyLocAdmin.GetLocationsForCompany(1);

            Assert.AreEqual(lista.Count,3);

        }


    }
}