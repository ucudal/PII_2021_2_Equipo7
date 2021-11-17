// -----------------------------------------------------------------------
// <copyright file="UserAdminTest.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
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
        private DataManager datMgr = new DataManager();

        /// <summary>
        /// Test del metodo GetUserIsSuspended(int userId).
        /// </summary>
        [Test]
        public void GetUserIsSuspendedTest()
        {
            // Agregamos un usuario Suspendido.
            string firstName = "Nicolas";
            string lastName = "Maisonnave";
            UserRole role = UserRole.Undefined;
            bool suspended = false;
            bool deleted = false;

            User user = this.datMgr.User.New();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Role = role;
            user.Suspended = suspended;
            user.Deleted = deleted;
            int userId = this.datMgr.User.Insert(user);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, userId);

            // Validamos que nos retorne true el metodo GetUserIsSuspended
            Assert.AreEqual(this.datMgr.User.GetUserIsSuspended(userId), suspended);
        }

        /// <summary>
        /// Test del metodo Insert(User pElemento).
        /// </summary>
        [Test]
        public void InsertTest()
        {
            // Agregamos un usuario.
            IReadOnlyCollection<User> prevUsers = this.datMgr.User.Items;

            string firstName = "Nicolas";
            string lastName = "Maisonnave";
            UserRole role = UserRole.Undefined;
            bool suspended = false;
            bool deleted = false;

            User user = this.datMgr.User.New();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Role = role;
            user.Suspended = suspended;
            user.Deleted = deleted;
            int userId = this.datMgr.User.Insert(user);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, userId);

            int expeced = prevUsers.Count + 1;

            IReadOnlyCollection<User> postUsers = this.datMgr.User.Items;

            // Validamos que se agrego un Usuario
            Assert.AreEqual(expeced, postUsers.Count);
        }

        /// <summary>
        /// Test del metodo Update(Invitation pElemento).
        /// </summary>
        [Test]
        public void UpdateTest()
        {
            // Insertamos una invitacion y validamos que haya quedado agregada
            IReadOnlyCollection<User> prevUsers = this.datMgr.User.Items;

            string firstName = "Nicolas";
            string lastName = "Maisonnave";
            UserRole role = UserRole.Entrepreneur;
            bool suspended = false;
            bool deleted = false;

            User user = this.datMgr.User.New();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Role = role;
            user.Suspended = suspended;
            user.Deleted = deleted;
            int userId = this.datMgr.User.Insert(user);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, userId);

            int expected = prevUsers.Count + 1;

            IReadOnlyCollection<User> postUsers = this.datMgr.User.Items;

            // Validamos que se agrego un Usuario
            Assert.AreEqual(expected, postUsers.Count);

            // Obtenemos la invitacion recien agregada, le cambiamos los campos y le damos a update
            User xToUpdate = this.datMgr.User.New();
            xToUpdate = this.datMgr.User.GetById(userId);

            // Atributos nuevos
            firstName = "Andres";
            lastName = "Espiga";
            suspended = true;

            xToUpdate.FirstName = firstName;
            xToUpdate.LastName = lastName;
            xToUpdate.Suspended = suspended;

            this.datMgr.User.Update(xToUpdate);

            User xComp = this.datMgr.User.GetById(userId);

            Assert.AreNotEqual(user.FirstName, xComp.FirstName);
            Assert.AreNotEqual(user.LastName, xComp.LastName);
            Assert.AreNotEqual(user.Suspended, xComp.Suspended);
            Assert.AreEqual(user.Deleted, xComp.Deleted);
        }

        /// <summary>
        /// Test del metodo Delete(int pId).
        /// </summary>
        [Test]
        public void DeleteTest()
        {
            // Insertamos una Usuario y validamos que haya quedado agregado
            IReadOnlyCollection<User> prevUsers = this.datMgr.User.Items;

            string firstName = "Nicolas";
            string lastName = "Maisonnave";
            UserRole role = UserRole.Undefined;
            bool suspended = false;
            bool deleted = false;

            User user = this.datMgr.User.New();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Role = role;
            user.Suspended = suspended;
            user.Deleted = deleted;
            int userId = this.datMgr.User.Insert(user);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, userId);

            int expected = prevUsers.Count + 1;

            IReadOnlyCollection<User> postUsers = this.datMgr.User.Items;

            // Validamos que se agrego un Usuario
            Assert.AreEqual(expected, postUsers.Count);

            // Hacemos el delete y luego validamos que al cantidad haya disminuido 1
            IReadOnlyCollection<User> beforeDelete = postUsers;

            expected = postUsers.Count - 1;

            this.datMgr.User.Delete(userId);

            IReadOnlyCollection<User> afterDelete = this.datMgr.User.Items;

            // Comprobamos que se elimino un usuario
            Assert.AreEqual(expected, afterDelete.Count);
        }

        /// <summary>
        /// Test del metodo GetById(int pId).
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            // Insertamos una Usuario y validamos que haya quedado agregado
            IReadOnlyCollection<User> prevUsers = this.datMgr.User.Items;

            string firstName = "Nicolas";
            string lastName = "Maisonnave";
            UserRole role = UserRole.Undefined;
            bool suspended = false;
            bool deleted = false;

            User user = this.datMgr.User.New();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Role = role;
            user.Suspended = suspended;
            user.Deleted = deleted;
            int userId = this.datMgr.User.Insert(user);

            // Validamos que se haya añadido correctamente con un id!= 0
            Assert.AreNotEqual(0, userId);

            int expected = prevUsers.Count + 1;

            IReadOnlyCollection<User> postUsers = this.datMgr.User.Items;

            // Validamos que se agrego un Usuario
            Assert.AreEqual(expected, postUsers.Count);

            // Obtenemos el usuario agregada con GetById y comparamos
            User xComp = this.datMgr.User.GetById(userId);

            Assert.AreEqual(userId, xComp.Id);
            Assert.AreEqual(user.FirstName, xComp.FirstName);
            Assert.AreEqual(user.LastName, xComp.LastName);
            Assert.AreEqual(user.Suspended, xComp.Suspended);
            Assert.AreEqual(user.Deleted, xComp.Deleted);
        }
    }
}