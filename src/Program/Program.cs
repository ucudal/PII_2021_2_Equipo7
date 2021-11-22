// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;
using ClassLibrary;

namespace Program
{
    /// <summary>
    /// Programa Principal.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            InitDatabase();

            using TelegramAPI telegramAPI = new TelegramAPI();
            Console.WriteLine($"Oprima una tecla para terminar de ejecutar el bot.");
            Console.ReadLine();

            telegramAPI.Stop();
        }

        private static void InitDatabase()
        {
            if (!File.Exists(@"database.json"))
            {
                CreateSomeQualifications();
                CreateSomeMaterialCategories();
                CreateSomeCompany();
                CreateSomeInvites();
            }
        }

        private static void CreateSomeQualifications()
        {
            DataManager dataManager = new DataManager();

            Qualification qual;

            qual = dataManager.Qualification.New();
            qual.Name = "Armas de Fuego";
            dataManager.Qualification.Insert(qual);

            qual = dataManager.Qualification.New();
            qual.Name = "Armas Blancas";
            dataManager.Qualification.Insert(qual);

            qual = dataManager.Qualification.New();
            qual.Name = "Biologicos";
            dataManager.Qualification.Insert(qual);

            qual = dataManager.Qualification.New();
            qual.Name = "Combustibles";
            dataManager.Qualification.Insert(qual);

            qual = dataManager.Qualification.New();
            qual.Name = "Acidos";
            dataManager.Qualification.Insert(qual);

            qual = dataManager.Qualification.New();
            qual.Name = "Solventes";
            dataManager.Qualification.Insert(qual);

            qual = dataManager.Qualification.New();
            qual.Name = "Animales";
            dataManager.Qualification.Insert(qual);

            qual = dataManager.Qualification.New();
            qual.Name = "Alimentos";
            dataManager.Qualification.Insert(qual);

            qual = dataManager.Qualification.New();
            qual.Name = "Humanos";
            dataManager.Qualification.Insert(qual);

            qual = dataManager.Qualification.New();
            qual.Name = "Nucleares";
            dataManager.Qualification.Insert(qual);
        }

        private static void CreateSomeMaterialCategories()
        {
            DataManager dataManager = new DataManager();

            MaterialCategory matCat;

            matCat = dataManager.MaterialCategory.New();
            matCat.Name = "Madera";
            dataManager.MaterialCategory.Insert(matCat);

            matCat = dataManager.MaterialCategory.New();
            matCat.Name = "Plastico";
            dataManager.MaterialCategory.Insert(matCat);

            matCat = dataManager.MaterialCategory.New();
            matCat.Name = "Vidrio";
            dataManager.MaterialCategory.Insert(matCat);

            matCat = dataManager.MaterialCategory.New();
            matCat.Name = "Quimico";
            dataManager.MaterialCategory.Insert(matCat);

            matCat = dataManager.MaterialCategory.New();
            matCat.Name = "Metal";
            dataManager.MaterialCategory.Insert(matCat);

            matCat = dataManager.MaterialCategory.New();
            matCat.Name = "Biologico";
            dataManager.MaterialCategory.Insert(matCat);
        }

        private static void CreateSomeInvites()
        {
            DataManager dataManager = new DataManager();

            Invitation inv1 = dataManager.Invitation.New();
            inv1.Used = false;
            inv1.ValidAfter = DateTime.Now.AddMonths(-2);
            inv1.ValidBefore = DateTime.Now.AddMonths(2);
            inv1.Type = RegistrationType.CopmanyNew;
            int inv1Id = dataManager.Invitation.Insert(inv1);

            dataManager.Invitation.GenerateNewInviteCode(inv1Id);
            inv1 = dataManager.Invitation.GetById(inv1Id);

            Invitation inv2 = dataManager.Invitation.New();
            inv2.Used = false;
            inv2.ValidAfter = DateTime.Now.AddMonths(-2);
            inv2.ValidBefore = DateTime.Now.AddMonths(2);
            inv2.Type = RegistrationType.EntrepreneurNew;
            int inv2Id = dataManager.Invitation.Insert(inv2);

            dataManager.Invitation.GenerateNewInviteCode(inv2Id);
            inv2 = dataManager.Invitation.GetById(inv2Id);

            Invitation inv3 = dataManager.Invitation.New();
            inv3.Used = false;
            inv3.ValidAfter = DateTime.Now.AddMonths(-2);
            inv3.ValidBefore = DateTime.Now.AddMonths(2);
            inv3.Type = RegistrationType.SystemAdminJoin;
            int inv3Id = dataManager.Invitation.Insert(inv3);

            dataManager.Invitation.GenerateNewInviteCode(inv3Id);
            inv3 = dataManager.Invitation.GetById(inv3Id);

            Invitation inv4 = dataManager.Invitation.New();
            inv4.Used = false;
            inv4.ValidAfter = DateTime.Now.AddMonths(-2);
            inv4.ValidBefore = DateTime.Now.AddMonths(2);
            inv4.Type = RegistrationType.CompanyJoin;
            inv4.CompanyId = 1;
            int inv4Id = dataManager.Invitation.Insert(inv4);

            dataManager.Invitation.GenerateNewInviteCode(inv4Id);
            inv4 = dataManager.Invitation.GetById(inv4Id);

            Console.WriteLine($"{inv1.Code}");
            Console.WriteLine($"{inv2.Code}");
            Console.WriteLine($"{inv3.Code}");
            Console.WriteLine($"{inv4.Code}");
        }

        private static void CreateSomeCompany()
        {
            DataManager dataManager = new DataManager();

            User user;
            Company company;
            Account account;
            CompanyUser companyUser;
            CompanyMaterial compMat;
            MaterialCategory matCat;
            CompanyMaterialStock compMatStock;
            CompanyLocation compLoc;
            Invitation inv4;
            Publication pub;
            PublicationKeyWord keyWord;

            company = dataManager.Company.New();
            company.Name = "Dream Theater";
            company.Trade = "Musica";
            int companyId = dataManager.Company.Insert(company);

            inv4 = dataManager.Invitation.New();
            inv4.Used = false;
            inv4.ValidAfter = DateTime.Now.AddMonths(-2);
            inv4.ValidBefore = DateTime.Now.AddMonths(2);
            inv4.Type = RegistrationType.CompanyJoin;
            inv4.CompanyId = 1;
            int inv4Id = dataManager.Invitation.Insert(inv4);

            dataManager.Invitation.GenerateNewInviteCode(inv4Id);

            user = dataManager.User.New();
            user.FirstName = "John";
            user.LastName = "Petrucci";
            user.Suspended = false;
            user.Role = UserRole.CompanyAdministrator;
            int userId = dataManager.User.Insert(user);

            account = dataManager.Account.New();
            account.CodeInService = "11121";
            account.Service = MessagingService.Console;
            account.UserId = userId;
            dataManager.Account.Insert(account);

            companyUser = dataManager.CompanyUser.New();
            companyUser.AdminUserId = userId;
            companyUser.CompanyId = companyId;
            dataManager.CompanyUser.Insert(companyUser);

            compLoc = dataManager.CompanyLocation.New();
            compLoc.CompanyId = companyId;
            compLoc.GeoReference = "Paraguay 1312";
            int compLocId = dataManager.CompanyLocation.Insert(compLoc);

            matCat = dataManager.MaterialCategory.New();
            matCat.Name = "Discos";
            int matCatId = dataManager.MaterialCategory.Insert(matCat);

            compMat = dataManager.CompanyMaterial.New();
            compMat.CompanyId = companyId;
            compMat.DateBetweenRestocks = 0;
            compMat.LastRestock = DateTime.Now.AddDays(-5);
            compMat.MaterialCategoryId = matCatId;
            compMat.Name = "Images and Words";
            int compMat1Id = dataManager.CompanyMaterial.Insert(compMat);

            compMatStock = dataManager.CompanyMaterialStock.New();
            compMatStock.CompanyMatId = compMat1Id;
            compMatStock.Stock = 15;
            compMatStock.CompanyLocationId = compLocId;
            dataManager.CompanyMaterialStock.Insert(compMatStock);

            compMat = dataManager.CompanyMaterial.New();
            compMat.CompanyId = companyId;
            compMat.DateBetweenRestocks = 0;
            compMat.LastRestock = DateTime.Now.AddDays(-5);
            compMat.MaterialCategoryId = matCatId;
            compMat.Name = "Systematic Chaos";
            int compMat2Id = dataManager.CompanyMaterial.Insert(compMat);

            compMatStock = dataManager.CompanyMaterialStock.New();
            compMatStock.CompanyMatId = compMat2Id;
            compMatStock.Stock = 19;
            compMatStock.CompanyLocationId = compLocId;
            dataManager.CompanyMaterialStock.Insert(compMatStock);

            int pubId;

            pub = dataManager.Publication.New();
            pub.CompanyLocationId = compLocId;
            pub.CompanyMaterialId = compMat1Id;
            pub.Currency = Currency.DolarEstadounidense;
            pub.Description = "Second studio album by American progressive metal band Dream Theater, released on July 7, 1992";
            pub.Price = 21;
            pub.Quantity = 1;
            pub.Title = "Images and Words";
            pub.ActiveFrom = DateTime.Now.AddMonths(-2);
            pub.ActiveUntil = DateTime.Now.AddYears(5);
            pub.CompanyId = companyId;
            pubId = dataManager.Publication.Insert(pub);

            keyWord = dataManager.PublicationKeyWord.New();
            keyWord.PublicationId = pubId;
            keyWord.KeyWord = "Progressive";
            dataManager.PublicationKeyWord.Insert(keyWord);

            pub = dataManager.Publication.New();
            pub.CompanyLocationId = compLocId;
            pub.CompanyMaterialId = compMat2Id;
            pub.Currency = Currency.DolarEstadounidense;
            pub.Description = "Ninth studio album by American progressive metal band Dream Theater. Released on June 4, 2007 in the United Kingdom and June 5, 2007 in the United States.";
            pub.Price = 16;
            pub.Quantity = 1;
            pub.Title = "Systematic Chaos";
            pub.ActiveFrom = DateTime.Now.AddMonths(-2);
            pub.ActiveUntil = DateTime.Now.AddYears(5);
            pub.CompanyId = companyId;
            pubId = dataManager.Publication.Insert(pub);

            keyWord = dataManager.PublicationKeyWord.New();
            keyWord.PublicationId = pubId;
            keyWord.KeyWord = "Progressive";
            dataManager.PublicationKeyWord.Insert(keyWord);
        }
    }
}
