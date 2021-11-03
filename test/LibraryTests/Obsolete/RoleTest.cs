/*using System;
using ClassLibrary;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// Prueba de la clase <see cref="Role"/>.
    /// </summary>
     public class RoleTest
    {
        /// <summary>
        /// test del constructor
        /// </summary>

        [Test] 
        public void ConstructorTest()
        {
            int id = 2;
            string firstname ="primer nombre";
            string lastname = "apellido";
            UserRole rol = UserRole.Entrepreneur;
            User usuario = new User(id,firstname,lastname,rol);

            Assert.AreEqual(id,usuario.Id);
            Assert.AreEqual(firstname,usuario.FirstName);
            Assert.AreEqual(lastname,usuario.LastName);
        }
    }
}*/