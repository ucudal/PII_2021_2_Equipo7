using System;
using System.Collections.ObjectModel;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Conjunto de Tests para la operacion de
    /// un administrador de empresa.
    /// </summary>
    [TestFixture]
    public class CompanyAdminUserOperationTests
    {
        private CompanyMaterialAdmin companyMaterialAdmin=Singleton<CompanyMaterialAdmin>.Instance;
        private MaterialCategoryAdmin materialCategoryAdmin=Singleton<MaterialCategoryAdmin>.Instance;
        private CompanyAdmin companyAdmin=Singleton<CompanyAdmin>.Instance;
        private QualificationAdmin qualificationAdmin=Singleton<QualificationAdmin>.Instance;
        private CompanyMaterialQualificationAdmin companyMaterialQualificationAdmin=Singleton<CompanyMaterialQualificationAdmin>.Instance;
        private PublicationAdmin publicationAdmin=Singleton<PublicationAdmin>.Instance;
        private PublicationKeyWordAdmin publicationKeyWordAdmin=Singleton<PublicationKeyWordAdmin>.Instance;
        private SaleAdmin saleAdmin=Singleton<SaleAdmin>.Instance;
        private EntrepreneurAdmin entrepreneurAdmin=Singleton<EntrepreneurAdmin>.Instance;

        /// <summary>
        /// Test de creacion de una publicacion
        /// de materiales para la empresa.
        /// </summary>
        [Test]
        public void PublicationCreationTest()
        {
            CompanyAdmin compAdmin = Singleton<CompanyAdmin>.Instance;
            CompanyMaterialAdmin compMatAdmin = Singleton<CompanyMaterialAdmin>.Instance;
            PublicationAdmin pubAdmin = Singleton<PublicationAdmin>.Instance;
            ReadOnlyCollection<Publication> prevpub = pubAdmin.Items;


            // creo la company
            Company comp = compAdmin.New();

            comp.Name="nombre de la company" ;
            comp.Trade = "trade";
            
            int idComp = compAdmin.Insert(comp);


            // creo un material de compania y le paso el id de la company


            CompanyMaterial compmat = compMatAdmin.New();
            compmat.Name="material";
            compmat.CompanyId = idComp;
            compmat.DateBetweenRestocks = 100;
            compmat.LastRestock =DateTime.Now.AddMonths(-1);
            compmat.MaterialCategoryId =2;
            int idCompMat = compMatAdmin.Insert(compmat);


            // creo una publicacion 


            Publication pub = pubAdmin.New();
            pub.ActiveFrom = DateTime.Now.AddMonths(-1);
            pub.ActiveUntil = DateTime.Now.AddMonths(1);
            pub.CompanyId = idComp;


            Currency currency = Currency.DolarEstadounidense;
            pub.Currency = currency;

            int Price = 120;
            pub.Price = Price;
            int idPub = pubAdmin.Insert(pub);


            ReadOnlyCollection<Publication> postpub = pubAdmin.Items;
            int postcheck = postpub.Count;
            

            int check = prevpub.Count +1;

            Assert.AreNotEqual(0, idPub);
            Assert.AreNotEqual(0, idCompMat);

            Assert.AreEqual(check, postcheck);





        }

        /// <summary>
        /// Test de creacion de un material de
        /// la empresa.
        /// </summary>
        [Test]
        public void CompanyMaterialCreationTest()
        {
            //Agregamos una Categoria
            string name = "Maderas";
            bool deleted = false;

            MaterialCategory materialCategory=materialCategoryAdmin.New();
            materialCategory.Name=name;
            materialCategory.Deleted=deleted;
            int materialCategoryId = materialCategoryAdmin.Insert(materialCategory);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, materialCategoryId);

            //Agregamos una company
            name="nombre compania";
            string trade ="rubro";

            Company compania = companyAdmin.New();
            compania.Name = name;
            compania.Trade = trade;
            int companyId = companyAdmin.Insert(compania);
            
            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0,companyId);

            //Agregamos una material 
            ReadOnlyCollection<CompanyMaterial> prevCompanyMaterial = companyMaterialAdmin.Items;

            name = "Tabla de Roble";
            DateTime lastRestock=DateTime.Now.AddMonths(-1);
            int dateBetweenRestocks=15;
            deleted = false;

            CompanyMaterial companyMaterial=companyMaterialAdmin.New();
            companyMaterial.Name=name;
            companyMaterial.LastRestock=lastRestock;
            companyMaterial.DateBetweenRestocks=dateBetweenRestocks;
            companyMaterial.MaterialCategoryId=materialCategoryId;
            companyMaterial.CompanyId=companyId;
            companyMaterial.Deleted=deleted;
            int companyMaterialId = companyMaterialAdmin.Insert(companyMaterial);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            int expected=prevCompanyMaterial.Count + 1;

            ReadOnlyCollection<CompanyMaterial> postCompanyMaterial = companyMaterialAdmin.Items;

            //Validamos que se agrego un material
            Assert.AreEqual(expected,postCompanyMaterial.Count);
        }

        /// <summary>
        /// Test de añadir habilitaciones al
        /// material de la empresa.
        /// </summary>
        [Test]
        public void CompanyMaterialAddQualificationsTest()
        {
            //Agregamos una material 
            string name = "Tabla de Roble";
            DateTime lastRestock=DateTime.Now.AddMonths(-2);
            int materialCategoryId=7;
            int companyId=9;
            int dateBetweenRestocks=20;
            bool deleted = false;

            CompanyMaterial companyMaterial=companyMaterialAdmin.New();
            companyMaterial.Name=name;
            companyMaterial.LastRestock=lastRestock;
            companyMaterial.DateBetweenRestocks=dateBetweenRestocks;
            companyMaterial.MaterialCategoryId=materialCategoryId;
            companyMaterial.CompanyId=companyId;
            companyMaterial.Deleted=deleted;
            //Retorna el id con el que guardo el comapnyMaterial
            int companyMaterialId = companyMaterialAdmin.Insert(companyMaterial);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            //Agregamos una habilitacion
            name="Habilitacion madera";

            Qualification qualification = qualificationAdmin.New();
            qualification.Name=name;
            //Retorna el id con el que guardo la habilitacion
            int qualificationId = qualificationAdmin.Insert(qualification);
            
            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0,qualificationId);
        
            //Agregamos una Habilitacion de un material 
            ReadOnlyCollection<CompanyMaterialQualification> prevCompanyMaterialQualification = companyMaterialQualificationAdmin.Items;

            deleted=false;

            CompanyMaterialQualification companyMaterialQualification=companyMaterialQualificationAdmin.New();
            companyMaterialQualification.Deleted=deleted;
            companyMaterialQualification.CompanyMatId=companyMaterialId;
            companyMaterialQualification.QualificationId=qualificationId;
            int companyMaterialQualificationId = companyMaterialQualificationAdmin.Insert(companyMaterialQualification);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialQualificationId);

            int expected=prevCompanyMaterialQualification.Count + 1;

            ReadOnlyCollection<CompanyMaterialQualification> postCompanyMaterialQualification = companyMaterialQualificationAdmin.Items;

            //Validamos que se agrego una habilitacion de un material
            Assert.AreEqual(expected,postCompanyMaterialQualification.Count);

            CompanyMaterialQualification xQualification=companyMaterialQualificationAdmin.GetById(companyMaterialQualificationId);

            //Material al que se le agrego la habilitacion para comparar
            CompanyMaterial xCompMat=companyMaterialAdmin.GetById(xQualification.CompanyMatId);
            Assert.AreEqual(xCompMat.Id,companyMaterialId);

            //Habilitacion que se le agrego al material para comparar
            Qualification xQualif=qualificationAdmin.GetById(xQualification.QualificationId);
            Assert.AreEqual(xQualif.Id,qualificationId);
        }

        /// <summary>
        /// Test de añadir palabras claves
        /// a una publicacion.
        /// </summary>
        [Test]
        public void PublicationAddKeyWordsTest()
        {
            //Creamos una publicacion a la cual le vamos a agregar palabras clave luego. 
            DateTime activeFrom = DateTime.Today;
            DateTime activeuntil = DateTime.Today.AddMonths(3);
            int Price = 120;
            Currency currency = Currency.DolarEstadounidense;

            Publication publication = publicationAdmin.New();
            publication.ActiveFrom = activeFrom;
            publication.ActiveUntil = activeuntil;
            publication.Price = Price;
            publication.Currency = currency;
            //Retorna el id con el cual se inserto.
            int publicationId = publicationAdmin.Insert(publication);

            //Valido que se haya añadido bien.
            Assert.AreNotEqual(0,publicationId);

            //Añadimos una keyWord1 y le asignamos esta publicacion
            PublicationKeyWord publicationKeyWord1 = publicationKeyWordAdmin.New();
            publicationKeyWord1.KeyWord="Construcción";
            publicationKeyWord1.Deleted=false;
            publicationKeyWord1.PublicationId=publicationId;
            int publicationKeyWordId  = publicationKeyWordAdmin.Insert(publicationKeyWord1);

            PublicationKeyWord xComp=publicationKeyWordAdmin.GetById(publicationKeyWordId);
            Assert.AreEqual(xComp.Id,publicationKeyWordId);

            //Me traigo la publicacion que esta asociada a esa keyWord y valido que sea igual la agregada previamente
            Publication xPub=publicationAdmin.GetById(xComp.PublicationId);
            Assert.AreEqual(xPub.Id,publicationId);           
        }

        /// <summary>
        /// Test de listar todas las ventas
        /// en un periodo de tiempo.
        /// </summary>
        [Test]
        public void SaleListTest()
        {
            //Agrego un entrepreneur el cual hace las compras
            string name="Nicolas";
            string trade ="rubro";

            Entrepreneur entrepreneurBuyer = entrepreneurAdmin.New();
            entrepreneurBuyer.Name = name;
            entrepreneurBuyer.Trade = trade;
            int entrepreneurBuyerId = entrepreneurAdmin.Insert(entrepreneurBuyer);
            
            Assert.AreNotEqual(0,entrepreneurBuyerId);

            //Agregamos una company
            name="nombre compania";
            trade ="rubro";

            Company compania = companyAdmin.New();
            compania.Name = name;
            compania.Trade = trade;
            int companyId = companyAdmin.Insert(compania);
            
            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0,companyId);
            

            //Agregamos el material1 a comprar
            name = "Madera";
            DateTime lastRestock=DateTime.Now.AddMonths(-1);
            int dateBetweenRestocks=15;
            int materialCategoryId=2;
            bool deleted = false;

            CompanyMaterial companyMaterial=companyMaterialAdmin.New();
            companyMaterial.Name=name;
            companyMaterial.LastRestock=lastRestock;
            companyMaterial.DateBetweenRestocks=dateBetweenRestocks;
            companyMaterial.MaterialCategoryId=materialCategoryId;
            companyMaterial.CompanyId=companyId;
            companyMaterial.Deleted=deleted;
            int companyMaterialId = companyMaterialAdmin.Insert(companyMaterial);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, companyMaterialId);

            //Agregamos una venta1
            DateTime datetime = DateTime.Today;
            int price = 100;
            int quantity=20;
            Currency currency = Currency.PesoUruguayo;

            Sale sale1 = saleAdmin.New();
            sale1.DateTime = datetime;
            sale1.Price = price;
            sale1.Currency = currency;
            sale1.ProductCompanyMaterialId=companyMaterialId;
            sale1.BuyerEntrepreneurId=entrepreneurBuyerId;
            sale1.ProductQuantity=quantity;
            sale1.SellerCompanyId=companyId;
            int sale1Id = saleAdmin.Insert(sale1);

            Assert.AreNotEqual(0,sale1Id);

            //Agregamos una venta2
            datetime = DateTime.Today;
            price = 2000;
            quantity=500;
            currency = Currency.PesoUruguayo;

            Sale sale2 = saleAdmin.New();
            sale2.DateTime = datetime;
            sale2.Price = price;
            sale2.Currency = currency;
            sale2.ProductCompanyMaterialId=companyMaterialId;
            sale2.BuyerEntrepreneurId=entrepreneurBuyerId;
            sale2.ProductQuantity=quantity;
            sale2.SellerCompanyId=companyId;
            int sale2Id = saleAdmin.Insert(sale2);

            Assert.AreNotEqual(0,sale2Id);

            int salesExpected=2;

            Assert.AreEqual(salesExpected,saleAdmin.GetSalesBySeller(companyId).Count);
        }
    }
}