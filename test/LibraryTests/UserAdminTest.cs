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
    }
}