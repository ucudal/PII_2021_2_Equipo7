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
    public class UserAdminTest
    {
        private UserAdmin userAdmin = Singleton<UserAdmin>.Instance;

        /// <summary>
        /// Test del metodo GetUserIsSuspended(int userId).
        /// </summary>
        [Test]
        public void GetUserIsSuspendedTest()
        {
            //Agregamos un usuario Suspendido
            string firstName = "Nicolas";
            string lastName = "Maisonnave";;
            UserRole role = new UserRole();
            bool suspended = true;
            bool deleted = false;

            User user = userAdmin.New();
            user.FirstName = firstName;
            user.LastName=lastName;
            user.Role=role;
            user.Suspended=suspended;
            user.Deleted=deleted;
            int userId = userAdmin.Insert(user);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, userId);

            //Validamos que nos retorne true el metodo GetUserIsSuspended
            Assert.AreEqual(userAdmin.GetUserIsSuspended(userId),suspended);
        }

        /// <summary>
        /// Test del metodo Insert(User pElemento).
        /// </summary>
        [Test]
        public void InsertTest()
        {
            //Agregamos un usuario 
            ReadOnlyCollection<User> prevUsers = userAdmin.Items;

            string firstName = "Nicolas";
            string lastName = "Maisonnave";;
            UserRole role = new UserRole();
            bool suspended = true;
            bool deleted = false;

            User user = userAdmin.New();
            user.FirstName = firstName;
            user.LastName=lastName;
            user.Role=role;
            user.Suspended=suspended;
            user.Deleted=deleted;
            int userId = userAdmin.Insert(user);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, userId);

            int expeced=prevUsers.Count + 1;

            ReadOnlyCollection<User> postUsers = userAdmin.Items;

            //Validamos que se agrego un Usuario
            Assert.AreEqual(expeced,postUsers.Count);
        }
        /// <summary>
        /// Test del metodo Update(Invitation pElemento).
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            //Insertamos una invitacion y validamos que haya quedado agregada
            ReadOnlyCollection<User> prevUsers = userAdmin.Items;

            string firstName = "Nicolas";
            string lastName = "Maisonnave";;
            UserRole role = new UserRole();
            bool suspended = true;
            bool deleted = false;

            User user = userAdmin.New();
            user.FirstName = firstName;
            user.LastName=lastName;
            user.Role=role;
            user.Suspended=suspended;
            user.Deleted=deleted;
            int userId = userAdmin.Insert(user);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, userId);

            int expected=prevUsers.Count + 1;

            ReadOnlyCollection<User> postUsers = userAdmin.Items;

            //Validamos que se agrego un Usuario
            Assert.AreEqual(expected,postUsers.Count);
            
            //Obtenemos la invitacion recien agregada, le cambiamos los campos y le damos a update
            User xToUpdate=userAdmin.New();
            xToUpdate=userAdmin.GetById(userId);
            
            //atributos nuevos
            firstName = "Andres";
            lastName = "Espiga";;
            role = new UserRole();
            suspended = false;
            deleted = false;

            xToUpdate.Id=userId;
            xToUpdate.FirstName=firstName;
            xToUpdate.LastName=lastName;
            xToUpdate.Role=role;
            xToUpdate.Suspended=suspended;
            xToUpdate.Deleted=deleted;

            userAdmin.Update(xToUpdate);

            User xComp=userAdmin.GetById(userId);

            Assert.AreEqual(xToUpdate.Id, xComp.Id);
            Assert.AreEqual(xToUpdate.FirstName,xComp.FirstName);
            Assert.AreEqual(xToUpdate.LastName, xComp.LastName);
            Assert.AreEqual(xToUpdate.Suspended, xComp.Suspended);
            Assert.AreEqual(xToUpdate.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo Delete(int pId).
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            //Insertamos una Usuario y validamos que haya quedado agregado
            ReadOnlyCollection<User> prevUsers = userAdmin.Items;

            string firstName = "Nicolas";
            string lastName = "Maisonnave";;
            UserRole role = new UserRole();
            bool suspended = true;
            bool deleted = false;

            User user = userAdmin.New();
            user.FirstName = firstName;
            user.LastName=lastName;
            user.Role=role;
            user.Suspended=suspended;
            user.Deleted=deleted;
            int userId = userAdmin.Insert(user);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, userId);

            int expected=prevUsers.Count + 1;

            ReadOnlyCollection<User> postUsers = userAdmin.Items;

            //Validamos que se agrego un Usuario
            Assert.AreEqual(expected,postUsers.Count);

            //Hacemos el delete y luego validamos que al cantidad haya disminuido 1
            ReadOnlyCollection<User> beforeDelete=postUsers;

            expected=postUsers.Count - 1;

            userAdmin.Delete(userId);

            ReadOnlyCollection<User> afterDelete = userAdmin.Items;

            //Comprobamos que se elimino un usuario
            Assert.AreEqual(expected,afterDelete.Count);
        }

        /// <summary>
        /// Test del metodo GetById(int pId).
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            //Insertamos una Usuario y validamos que haya quedado agregado
            ReadOnlyCollection<User> prevUsers = userAdmin.Items;

            string firstName = "Nicolas";
            string lastName = "Maisonnave";;
            UserRole role = new UserRole();
            bool suspended = true;
            bool deleted = false;

            User user = userAdmin.New();
            user.FirstName = firstName;
            user.LastName=lastName;
            user.Role=role;
            user.Suspended=suspended;
            user.Deleted=deleted;
            int userId = userAdmin.Insert(user);

            //Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, userId);

            int expected=prevUsers.Count + 1;

            ReadOnlyCollection<User> postUsers = userAdmin.Items;

            //Validamos que se agrego un Usuario
            Assert.AreEqual(expected,postUsers.Count);
            
            //Obtenemos el usuario agregada con GetById y comparamos
            User xComp=userAdmin.GetById(userId);
            
            Assert.AreEqual(userId, xComp.Id);
            Assert.AreEqual(user.FirstName,xComp.FirstName);
            Assert.AreEqual(user.LastName, xComp.LastName);
            Assert.AreEqual(user.Suspended, xComp.Suspended);
            Assert.AreEqual(user.Deleted, xComp.Deleted);
        }
    }
}