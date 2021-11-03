using System;
using System.Collections.ObjectModel;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Tests del administrador de Usuarios.
    /// </summary>
    [TestFixture]
    public class AccountAdminTest
    {
        private AccountAdmin accountAdmin = Singleton<AccountAdmin>.Instance;

        /// <summary>
        /// Test del metodo Insert(Account pElemento).
        /// </summary>
        [Test]
        public void InsertTest()
        {
            //Agregamos una cuenta 
            ReadOnlyCollection<Account> prevAccount = accountAdmin.Items;

            int userId = 1;
            MessagingService service =new MessagingService();
            string codeInService = "Code";
            bool deleted = false;

            Account account=accountAdmin.New();
            account.UserId=userId;
            account.Service=service;
            account.CodeInService=codeInService;
            account.Deleted=deleted;

            int accountId=accountAdmin.Insert(account);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, accountId);

            int expected=prevAccount.Count + 1;

            ReadOnlyCollection<Account> postAccount = accountAdmin.Items;

            //Validamos que se agrego una Cuenta
            Assert.AreEqual(expected,postAccount.Count);
        }

        /// <summary>
        /// Test del metodo Update(Invitation pElemento).
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            //Agregamos una cuenta 
            ReadOnlyCollection<Account> prevAccount = accountAdmin.Items;

            int userId = 1;
            MessagingService service =new MessagingService();
            string codeInService = "Code";
            bool deleted = false;

            Account account=accountAdmin.New();
            account.UserId=userId;
            account.Service=service;
            account.CodeInService=codeInService;
            account.Deleted=deleted;

            int accountId=accountAdmin.Insert(account);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, userId);

            int expected=prevAccount.Count + 1;

            ReadOnlyCollection<Account> postAccount = accountAdmin.Items;

            //Validamos que se agrego una Cuenta
            Assert.AreEqual(expected,postAccount.Count);
            
            //Obtenemos la invitacion recien agregada, le cambiamos los campos y le damos a update
            Account xToUpdate=accountAdmin.GetById(accountId);

            //atributos nuevos
            userId = 2;
            service =new MessagingService();
            codeInService = "Code2";
            deleted = false;

            xToUpdate.UserId=userId;
            xToUpdate.Service=service;
            xToUpdate.CodeInService=codeInService;
            xToUpdate.Deleted=deleted;

            accountAdmin.Update(xToUpdate);

            Account xComp=accountAdmin.GetById(accountId);

            Assert.AreEqual(xToUpdate.Id, xComp.Id);
            Assert.AreEqual(xToUpdate.UserId,xComp.UserId);
            Assert.AreEqual(xToUpdate.CodeInService, xComp.CodeInService);
            Assert.AreEqual(xToUpdate.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo Delete(int pId).
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            //Agregamos una cuenta 
            ReadOnlyCollection<Account> prevAccount = accountAdmin.Items;

            int userId = 1;
            MessagingService service =new MessagingService();
            string codeInService = "Code";
            bool deleted = false;

            Account account=accountAdmin.New();
            account.UserId=userId;
            account.Service=service;
            account.CodeInService=codeInService;
            account.Deleted=deleted;

            int accountId=accountAdmin.Insert(account);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, accountId);

            int expected=prevAccount.Count + 1;

            ReadOnlyCollection<Account> postAccount = accountAdmin.Items;

            //Validamos que se agrego una Cuenta
            Assert.AreEqual(expected,postAccount.Count);

            //Hacemos el delete y luego validamos que al cantidad haya disminuido 1

            expected=prevAccount.Count;

            accountAdmin.Delete(accountId);

            ReadOnlyCollection<Account> afterDelete = accountAdmin.Items;

            //Comprobamos que se elimino un usuario
            Assert.AreEqual(expected,afterDelete.Count);
        }

        /// <summary>
        /// Test del metodo GetById(int pId).
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            //Agregamos una cuenta 
            ReadOnlyCollection<Account> prevAccount = accountAdmin.Items;

            int userId = 1;
            MessagingService service =new MessagingService();
            string codeInService = "Code";
            bool deleted = false;

            Account account=accountAdmin.New();
            account.UserId=userId;
            account.Service=service;
            account.CodeInService=codeInService;
            account.Deleted=deleted;

            int accountId=accountAdmin.Insert(account);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, accountId);

            int expected=prevAccount.Count + 1;

            ReadOnlyCollection<Account> postAccount = accountAdmin.Items;

            //Validamos que se agrego una Cuenta
            Assert.AreEqual(expected,postAccount.Count);
            
            //Obtenemos el usuario agregada con GetById y comparamos
            Account xComp=accountAdmin.GetById(accountId);
            
            Assert.AreEqual(accountId, xComp.Id);
            Assert.AreEqual(account.CodeInService,xComp.CodeInService);
            Assert.AreEqual(account.UserId, xComp.UserId);
            Assert.AreEqual(account.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo GetUserIdForAccount(MessagingService service, string account).
        /// </summary>
        [Test]
        public void GetUserIdForAccountTest()
        {
            //Agregamos una cuenta 
            ReadOnlyCollection<Account> prevAccount = accountAdmin.Items;

            int userId = 1;
            MessagingService service=MessagingService.Console;
            string codeInService = "Code";

            Account account=accountAdmin.New();
            account.UserId=userId;
            account.Service=service;
            account.CodeInService=codeInService;

            int accountId=accountAdmin.Insert(account);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, accountId);

            int expected=prevAccount.Count + 1;

            ReadOnlyCollection<Account> postAccount = accountAdmin.Items;

            //Validamos que se agrego una Cuenta
            Assert.AreEqual(expected,postAccount.Count);
            
            int userGetId=accountAdmin.GetUserIdForAccount(service,codeInService);

            Assert.AreEqual(account.UserId,userGetId);
            
        }
    }
}